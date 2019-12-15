using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace BabyEngine {
    public class GameApp : MonoBehaviour {
        private LuaEnv lua = new LuaEnv();
        public string MainGameApp;
        public string CustomSearchPath;

        private void Awake() {
            InitManager();
            Screen.fullScreen = true;
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true, 60);
            // Application.ExternalEval("SetFullscreen(1)");
        }

        private void Start() {
            InitLua();
            Invoke("RunLua", 0);
        }

        private void InitManager() {
            gameObject.AddComponent<ResourceManager>();
        }

        private void InitLua() {
            //LuaTable mt = lua.NewTable();
            //mt.Set("__index", lua.Global);
            //mt.Dispose();
            lua.AddLoader(Loader.Create());
            string luaCode;
            if (string.IsNullOrEmpty(CustomSearchPath)) {
                luaCode = @"package.path=package.path .. " + $"';{GameConf.LUA_BASE_PATH}?.lua'";
            } else {
                GameConf.CustomLuaGame = CustomSearchPath;
                luaCode = $"package.path=package.path ..';{GameConf.LUA_BASE_PATH}?.lua;{CustomSearchPath}?.lua;'";
            }
            
            lua.DoString(luaCode);

            lua.Global.Set("ResourceManager", ResourceManager.Get());
            lua.DoString("require('framework.init_babyengine')");
        }

        private void RunLua() {
            //lua.DoString("require('main')");
            lua.DoString($"require('{MainGameApp}')");
        }
    }
}
