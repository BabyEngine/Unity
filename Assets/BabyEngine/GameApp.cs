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
        
        private void Awake() {
            // load pb
            lua.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPB);
            // 检查是否展开文件
            InitManager();
            Screen.fullScreen = true;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true, 60);
        }
        bool isStart = false;
        private void Start() {
            PerfomLuaStart();
        }

        public void PerfomLuaStart() {
            onLuaStart(() => {
                if (isStart)
                    return;
                isStart = true;
                InitLua();
                Invoke("RunLua", 0);
            });
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
