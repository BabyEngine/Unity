using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

namespace BabyEngine {
    public class Installer : MonoBehaviour {
        private static string installFlag = $"{Application.persistentDataPath }/installed";
        private static string FRAMEWORK_FILE = $"{Application.streamingAssetsPath}/{GameConf.LUA_FRAMEWORK}";
        public static bool IsInstall() {
            try {
                // check flag
                if (!File.Exists(installFlag)) {
                    return false;
                }
                var versionTxt = File.ReadAllText(installFlag);
                long version;
                if (!long.TryParse(versionTxt, out version)) {
                    return false;
                }
                long fileVersion = GetBuildVersion();
                if (fileVersion > version) {
                    return false;
                }
                return true;
            } catch(Exception e) {
                Debug.LogError(e);
                return false;
            }
        }

        private static long GetBuildVersion() {
            long version = 0;
            var ta = Resources.Load<TextAsset>("baby_version");
            if (ta != null) {
                long.TryParse(ta.text, out version);
            }
            return version;
        }
        public static void DoInstall(Action cb) {
            var go = new GameObject();
            go.AddComponent<Installer>().doInstall(cb);
            go.name = "BabyEngineInstaller";
        }
        public void doInstall(Action cb) {
            // 展开framework
            StartCoroutine(LoadAssetBundleFromStreamingAssetsCoroutine(GameConf.LUA_FRAMEWORK, FRAMEWORK_FILE, (ab) => {
                try {
                    if (ab == null) {
                        // download fail
                        return;
                    }
                    var names = ab.GetAllAssetNames();
                    foreach (var name in names) {
                        var ta = ab.LoadAsset<TextAsset>(name);
                        // 替换前缀
                        var lsf = LuaSourceFile.FromJson(ta.text);
                        if (lsf != null) {
                            var outPath = Path.Combine(Application.persistentDataPath, lsf.OutFile);
                            var dir = Path.GetDirectoryName(outPath);
                            Directory.CreateDirectory(dir);
                            File.WriteAllText(outPath, lsf.code);
                            Debug.Log($"install {outPath}");
                        }
                    }
                    var version = $"{GetBuildVersion()}";

                    Debug.Log($"install ok({version})");
                    File.WriteAllText(installFlag, version);
                } finally {
                    cb();
                    Destroy(gameObject);
                }
            }));
        }
        private IEnumerator LoadAssetBundleFromStreamingAssetsCoroutine(string bundleName, string path, Action<AssetBundle> handler) {
            // Loading asset bundle
            var req = AssetBundle.LoadFromFileAsync(path);
            yield return req;

            Assert.IsNotNull(req.assetBundle, "AssetBundleLoader : asset bundle wans't loaded from streaming assets");
            Assert.IsNotNull(handler, "No callback handler");

            if (req.assetBundle == null) {
                handler(null);
                yield break;
            }

            handler(req.assetBundle);
        }
    }
}
