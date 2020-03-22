using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

namespace BabyEngine {
    public class Installer : MonoBehaviour {
        private static string installFlag = $"{Application.persistentDataPath }/installed";
        public static bool IsInstall() {
            return File.Exists(installFlag);
        }
        public static void DoInstall(Action cb) {
            var go = new GameObject();
            go.AddComponent<Installer>().doInstall(cb);
            go.name = "BabyEngineInstaller";
        }
        public void doInstall(Action cb) {
            // 展开framework
            StartCoroutine(LoadAssetBundleFromStreamingAssetsCoroutine(GameConf.LUA_FRAMEWORK, $"{Application.streamingAssetsPath}/{GameConf.LUA_FRAMEWORK}", (ab) => {
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
                    File.WriteAllText(installFlag, "");
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
