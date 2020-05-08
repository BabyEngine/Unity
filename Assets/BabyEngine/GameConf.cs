using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BabyEngine {
    public static class GameConf {
        
        public static string CustomLuaGame;
        public static readonly string LUA_TEMP_PATH = "__lua_dir__/";
        #region DO NOT MODIFY!!!
        public static readonly string LUA_BASE_PATH = "BabyEngine/lua/";
        public static readonly string LUA_FRAMEWORK = "lua-framework.unity3d";
        public static readonly string AB_PATH = "Assets/ABs/";
        public static readonly string AB_EXT = ".unity3d";
        #endregion

        public static string PlatformName {
            get {
                if (Application.platform == RuntimePlatform.WindowsEditor) {
                    return "standalonewindows";
                }
                return Application.platform.ToString().ToLower();
            }
        }
    }
}