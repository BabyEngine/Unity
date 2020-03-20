using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using XLua;

namespace BabyEngine {
    public class GameApp : MonoBehaviour {
        private LuaEnv lua = new LuaEnv();
        public string MainGameApp;
        public string CustomSearchPath;

        private void Awake() {
            // load pb
            lua.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPB);
            // 检查是否展开文件
            InitManager();
            Screen.fullScreen = true;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true, 60);
        }
        #region 安装
        // 检查是否安装
        bool checkIsInstall() {
            return false;
        }
        // 执行安装
        void doInstall(Action cb) {
            var installFlag = $"{Application.persistentDataPath }/installed";
            if (File.Exists(installFlag)) {
                cb();
                return;
            } else {
                // 展开framework
                StartCoroutine(LoadAssetBundleFromStreamingAssetsCoroutine(GameConf.LUA_FRAMEWORK, $"{Application.streamingAssetsPath}/{GameConf.LUA_FRAMEWORK}", (ab)=> {
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
                    cb();
                }));
            }
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
        #endregion

        private void Start() {
            onLuaStart(()=> {
                InitLua();
                Invoke("RunLua", 0);
            });
        }

        void onLuaStart(Action cb) {
            if (checkIsInstall()) {
                cb();
            } else {
                doInstall(cb);
            }
        }

        private void InitManager() {
            gameObject.AddComponent<ResourceManager>();
            gameObject.AddComponent<LooperManager>();
        }

        private void InitLua() {
            lua.AddLoader(Loader.Create());
            string luaCode;
            if (string.IsNullOrEmpty(CustomSearchPath)) {
                luaCode = @"package.path=package.path .. " + $"';{GameConf.LUA_BASE_PATH}?.lua;{Application.persistentDataPath}?.lua;{Application.streamingAssetsPath}?.lua;'";
            } else {
                GameConf.CustomLuaGame = CustomSearchPath;
                luaCode = $"package.path=package.path ..';{GameConf.LUA_BASE_PATH}?.lua;{CustomSearchPath}?.lua;{Application.persistentDataPath}?.lua;{Application.streamingAssetsPath}?.lua;'";
            }
            
            lua.DoString(luaCode);

            lua.Global.Set("ResourceManager", ResourceManager.Get());
            lua.Global.Set("LooperManager", LooperManager.Get());
            lua.DoString("BabyEngine = BabyEngine or {}\nrequire('framework.init')");
        }

        private void RunLua() {
            lua.DoString($"if not pcall(require, '{MainGameApp}') then BabyEngine.CallUpdateHelp() end");
        }
    }
}
