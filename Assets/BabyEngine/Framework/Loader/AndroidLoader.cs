using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace BabyEngine {
    public class AndroidLoader : Loader {
        public override byte[] Load(ref string filepath) {
            byte[] result;
            // 优先加载外部代码
            result = TryLoadByPath(Application.persistentDataPath + "/scripts/", ref filepath);
            if (result != null) { return result; }
            //// 加载内嵌代码 android 没有内嵌代码
            //result = TryLoadByPath(Application.streamingAssetsPath + "/" + GameConf.CustomLuaGame, ref filepath);
            //if (result != null) { return result; }

            return result;

        }
        private byte[] TryLoadByPath(string filepath, ref string filename) {
            filename = filename.Replace(".", "/");
            var path = filepath + filename + ".lua";
            try {
                // Debug.Log($"Try load: {path}");
                return File.ReadAllBytes(path);
            }catch(Exception e) {
                if (e != null) { 
                
                }
                //Debug.LogError(e);
                return null;
            }
        }
    }
}
