using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BabyEngine {
    public class EditorLoader : Loader {
        bool isInited = false;
        Dictionary<string, LuaSourceFile> map = new Dictionary<string, LuaSourceFile>();
        void Init() {
            if (isInited) {
                return;
            }
            map.Clear();
            isInited = true;
            string[] files = Directory.GetFileSystemEntries(Application.persistentDataPath + "/source/");
            foreach (string file in files) {
                //Debug.Log($"===>{file}");
                var ab = AssetBundleLoader.LoadFromFile(file);
                foreach (var name in ab.GetAllAssetNames()) {
                    var json = ab.LoadAsset<TextAsset>(name);
                    var lua = LuaSourceFile.FromJson(json.text);
                    var key = lua.OutFile.Replace("/", ".").RemoveSuffix(".lua");
                    //Debug.Log($"{ key }");
                    map.Add(key, lua);
                }
            }
        }
        public override byte[] Load(ref string filepath) {
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
            var key = filename;
            if (map.ContainsKey(key)) {
                return map[key].code;
            }
            var path = Application.dataPath + "/" + filepath + filename + ".lua";
            if (File.Exists(path)) {
                var code = File.ReadAllBytes(path);
                return code;
            }
            return null;
        }
    }
}
