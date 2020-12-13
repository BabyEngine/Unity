using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Security.Cryptography;

namespace BabyEngine {
    public static class GameConf {
        public static string EncryptPassword {
            get {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes("BadC0f22b@dA991e"));
                string md5Hash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                return md5Hash;
            }
        }
        public static string CustomLuaGame;
        public static readonly string LUA_TEMP_PATH = "__lua_dir__/";
        public static string[] PACK_EXCLUED_LUA = new string[] {};
        #region DO NOT MODIFY!!!
        public static readonly string LUA_BASE_PATH = "BabyEngine/lua/";
        public static readonly string LUA_FRAMEWORK = "lua-framework.unity3d";
        public static readonly string AB_PATH = "Assets/ABs/";
        //public static readonly string AB_EXT = "";
        #endregion
    }
}