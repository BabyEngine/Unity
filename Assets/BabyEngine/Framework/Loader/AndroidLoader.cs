using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace BabyEngine {
    public class AndroidLoader : Loader {
        bool isInited = false;
        Dictionary<string, LuaSourceFile> map = new Dictionary<string, LuaSourceFile>();
        void Init() {
            if (isInited) {
                return;
            }
            isInited = true;
            string[] files = Directory.GetFileSystemEntries(Application.persistentDataPath + "/source/");
            foreach (string file in files) {
                //Debug.Log($"===>{file}");
                try {
                    var ab = AssetBundleLoader.LoadFromFile(file);
                    foreach (var name in ab.GetAllAssetNames()) {
                        var json = ab.LoadAsset<TextAsset>(name);
                        var lua = LuaSourceFile.FromJson(json.text);
                        var key = lua.OutFile.Replace("/", ".").RemoveSuffix(".lua");
                        //Debug.Log($"{ key }");
                        map.Add(key, lua);
                    }
                } catch (Exception e) {
                    Debug.LogError(e);
                }
            }
        }
        public override byte[] Load(ref string filepath) {
            Init();
            var key = filepath.Replace("/", ".");
            if (map.ContainsKey(key)) {
                return map[key].code;
            }

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
                // Debug.Log($"Try load: {path}");
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
