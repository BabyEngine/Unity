using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BabyEngine {
    public class EditorLoader : Loader {
        public override byte[] Load(ref string filepath) {
            //filepath = filepath.Replace(".", "/");
            //var path = Application.dataPath + "/" + GameConf.LUA_BASE_PATH + filepath + ".lua";
            //if (File.Exists(path)) {
            //    var code = File.ReadAllBytes(path);
            //    return code;
            //}
            //return null;
            byte[] result = TryLoadByPath(GameConf.LUA_BASE_PATH, ref filepath);
            if (result != null)
                return result;
            
            if (!string.IsNullOrEmpty(GameConf.CustomLuaGame)) {
                result = TryLoadByPath(GameConf.CustomLuaGame, ref filepath);
            }
            
            return result;

        }
        private byte[] TryLoadByPath(string filepath, ref string filename) {
            filepath = filepath.Replace(".", "/");
            filename = filename.Replace(".", "/");
            var path = Application.dataPath + "/" + filepath + filename + ".lua";
            if (File.Exists(path)) {
                var code = File.ReadAllBytes(path);
                return code;
            }
            return null;
        }
    }
}
