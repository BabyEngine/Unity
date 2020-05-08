using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace BabyEngine {
    public class WindowsLoader : Loader {
        public override byte[] Load(ref string filepath) {
            byte[] result;
            // 优先加载外部代码
            result = TryLoadByPath(Application.persistentDataPath + "/scripts/", ref filepath);
            if (result != null) { return result; }

            return result;

        }
        private byte[] TryLoadByPath(string filepath, ref string filename) {
            filename = filename.Replace(".", "/");
            var path = filepath + filename + ".lua";
            try {
                return File.ReadAllBytes(path);
            } catch (Exception e) {
                if (e != null) {

                }
                //Debug.LogError(e);
                return null;
            }
        }
    }
}
