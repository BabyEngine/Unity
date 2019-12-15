using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
namespace BabyEngine {
    public class Packer {

        private struct LuaSourceFile {
            public string InFile;
            public string OutFile;
            public TextAsset textAsset;
        }

        [MenuItem("Assets/Build Lua AssetBundles")]
        static void BuildLuaAB() {
            var startTime = DateTime.Now;
            string luaDir = Application.dataPath + "/" + GameConf.LUA_BASE_PATH;
            List<string> luaFiles = DirSearch(luaDir);
            // ignore .meta  files
            luaFiles.RemoveAll(x => x.EndsWith(".meta"));
            // replace LUA_BASE_PATH .Replace(Application.dataPath+"/", "")
            var outLuaFile = luaFiles.Select(s => s.Replace(Application.dataPath + "/" + GameConf.LUA_BASE_PATH, "lua/")).ToList();
            // 
            outLuaFile = luaFiles.Select(s => "lua/" + s).ToList();
            // create
            
            List<LuaSourceFile> luaSources = new List<LuaSourceFile>();
            foreach (var file in luaFiles) {
                var bytes = File.ReadAllBytes(file);
                if(bytes != null) {
                    var outFile = "";
                    luaSources.Add(new LuaSourceFile() {
                        InFile = file,
                        OutFile = file.Replace(Application.dataPath + "/" + GameConf.LUA_BASE_PATH, "lua/").Replace("\\", "/").Replace(".lua", ".bytes"),
                        textAsset = new TextAsset(bytes.ToUTF8String())
                    });
                }
            }
            // create .bytes asset

            foreach(var src in luaSources) {
                var tmp = Application.dataPath + "/"+ src.OutFile;
                var dir = Path.GetDirectoryName(tmp);
                Directory.CreateDirectory(dir);
                //Debug.Log($"{tmp}\n{dir}\n{src.InFile} \n{src.OutFile}\n {src.textAsset.text}");
                Debug.Log($"Dir: {dir}");
                Debug.Log($"Output: {src.OutFile}");
                AssetDatabase.CreateAsset(src.textAsset, "Assets/" + src.OutFile);
            }

            var elapsedTime = DateTime.Now.Subtract(startTime);
        }

        private static List<String> DirSearch(string sDir) {
            List<String> files = new List<String>();
            try {
                foreach (string f in Directory.GetFiles(sDir)) {
                    
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir)) {
                    files.AddRange(DirSearch(d));
                }
            } catch (System.Exception e) {
                Debug.LogError(e);
            }

            return files;
        }

        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string targetPath) {
            if (target != BuildTarget.WebGL)
                return;
            Debug.Log("替换文件咯");
            var path = Path.Combine(targetPath, "Build/UnityLoader.js");
            var text = File.ReadAllText(path);
            text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
            text = text.Replace("[\"Edge\", \"Firefox\", \"Chrome\", \"Safari\"].indexOf(UnityLoader.SystemInfo.browser) == -1", "false");
            File.WriteAllText(path, text);
        }
    }
}
