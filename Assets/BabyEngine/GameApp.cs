using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using XLua;

namespace BabyEngine {
    public class GameApp : MonoBehaviour {
        private LuaEnv lua = new LuaEnv();
        public string MainGameApp;
        public string CustomSearchPath;
        public string StartupUrl;

        private void Awake() {
            // load pb
            lua.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPB);
            // 检查是否展开文件
            InitManager();
            Screen.fullScreen = true;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true, 60);
        }

        private void Start() {
            if (string.IsNullOrEmpty(StartupUrl)) {
                onLuaStart(() => {
                    InitLua();
                    Invoke("RunLua", 0);
                });
            } else {
                StartCoroutine(CheckStartup(() => {
                    InitLua();
                    Invoke("RunLua", 0);

                },(err) => {
                    Debug.LogError($"检查失败{err}");
                 }));
            }
        }

        private IEnumerator CheckStartup(Action onOk, Action<string> onErr) {
            yield return null;
            //UnityWebRequest request = UnityWebRequest.Get(StartupUrl);
            //yield return request.SendWebRequest();
            //if (request.isNetworkError || request.isHttpError) {
            //    Debug.Log(StartupUrl);
            //    okErr(request.error);
            //    yield break;
            //}
            //string body = request.downloadHandler.text;
            //Debug.Log(body);
            //// TODO something
            //onOk();
            
            var co = CacheableDownloadHandler.GetBytes(StartupUrl, (statusCode, header, body) => {
                if (statusCode == 200) { // use new data

                }
                switch (statusCode) {
                    case 200: // use new data
                        Debug.Log(body.ToUTF8String());
                        onOk();
                        break;
                    case 304: // use cache daeta
                        Debug.Log(body.ToUTF8String());
                        onOk();
                        break;
                    default:  // not respect this
                        onErr($"http ${statusCode}");
                        break;
                }
            });
            StartCoroutine(co);
        }

        void onLuaStart(Action cb) {
            if (Installer.IsInstall()) {
                cb();
            } else {
                Installer.DoInstall(cb);
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
            lua.DoString($"local ok, ret = pcall(require, '{MainGameApp}')" +
                $"if not ok then " +
                $"  print(ret)" +
                $"  BabyEngine.CallUpdateHelp() " +
                $"end");
        }
    }
}
