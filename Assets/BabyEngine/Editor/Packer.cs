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

        //private struct LuaSourceFile {
        //    public string InFile;
        //    public string OutFile;
        //    public TextAsset textAsset;
        //    public string str;
        //}

        //[MenuItem("Assets/Build Lua AssetBundles")]
        //static void BuildLuaAB() {
        //    var startTime = DateTime.Now;
        //    string luaDir = Application.dataPath + "/" + GameConf.LUA_BASE_PATH;
        //    List<string> luaFiles = DirSearch(luaDir);
        //    // ignore .meta  files
        //    luaFiles.RemoveAll(x => x.EndsWith(".meta"));
        //    // replace LUA_BASE_PATH .Replace(Application.dataPath+"/", "")
        //    var outLuaFile = luaFiles.Select(s => s.Replace(Application.dataPath + "/" + GameConf.LUA_BASE_PATH, "lua/")).ToList();
        //    // 
        //    outLuaFile = luaFiles.Select(s => "lua/" + s).ToList();
        //    // create

        //    List<LuaSourceFile> luaSources = new List<LuaSourceFile>();
        //    foreach (var file in luaFiles) {
        //        var bytes = File.ReadAllBytes(file);
        //        if(bytes != null) {
        //            luaSources.Add(new LuaSourceFile() {
        //                InFile = file,
        //                OutFile = file.Replace(Application.dataPath + "/" + GameConf.LUA_BASE_PATH, "lua/").Replace("\\", "/").Replace(".lua", ".bytes"),
        //                textAsset = new TextAsset(bytes.ToUTF8String())
        //            });
        //        }
        //    }
        //    // create .bytes asset
        //    foreach(var src in luaSources) {
        //        var tmp = Application.dataPath + "/"+ src.OutFile;
        //        var dir = Path.GetDirectoryName(tmp);
        //        Directory.CreateDirectory(dir);
        //        Debug.Log($"{tmp}\n{dir}\n{src.InFile} \n{src.OutFile}\n {src.textAsset.text}");
        //        Debug.Log($"Dir: {dir}");
        //        Debug.Log($"Output: {src.OutFile}");
        //        AssetDatabase.CreateAsset(src.textAsset, "Assets/" + src.OutFile);
        //    }

        //    var elapsedTime = DateTime.Now.Subtract(startTime);
        //}

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

        [MenuItem("Tools/Build/Android")]
        public static void BuildAndroid() {
            var startTime = DateTime.Now;
            List<string> levels = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
                if (!scene.enabled)
                    continue;
                levels.Add(scene.path);
            }
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
            BuildPipeline.BuildPlayer(levels.ToArray(), "android.apk", BuildTarget.Android, BuildOptions.None);
            var elapsedTime = DateTime.Now.Subtract(startTime);
            Debug.Log($"build android.apk elapsed time:{elapsedTime}");
        }
        #region 复制lua
        [MenuItem("Tools/Build/Copy Lua")]
        public static void BuildLua() {
            //var startTime = DateTime.Now;
            //string luaDir = Application.dataPath + "/" + GameConf.LUA_BASE_PATH;
            //List<string> luaFiles = DirSearch(luaDir);
            //// ignore .meta  files
            //luaFiles.RemoveAll(x => x.EndsWith(".meta"));
            //var outLuaFile = luaFiles.Select(s => s.Replace(Application.dataPath + "/" + GameConf.LUA_BASE_PATH, "lua/")).ToList();
            //// 
            //outLuaFile = luaFiles.Select(s => "lua/" + s).ToList();
            //// create
            //List<LuaSourceFile> luaSources = new List<LuaSourceFile>();
            //foreach (var file in luaFiles) {
            //    var bytes = File.ReadAllBytes(file);
            //    if (bytes != null) {
            //        luaSources.Add(new LuaSourceFile() {
            //            OutFile = file.Replace(Application.dataPath + "/" + GameConf.LUA_BASE_PATH, GameConf.LUA_PATH).Replace("\\", "/").Replace(".lua", ".json"),
            //            code = bytes.ToUTF8String()
            //        });
            //    }
            //}
            //// create .bytes asset
            //int count = 0;
            //List<string> luaPaths = new List<string>();
            //foreach (var src in luaSources) {
            //    var tmp = Application.dataPath + $"/" + src.OutFile;
            //    var dir = Path.GetDirectoryName(tmp);
            //    Directory.CreateDirectory(dir);
            //    var outfile = $"Assets/{src.OutFile}";
            //    src.OutFile = src.OutFile.Replace(GameConf.LUA_PATH, "").Replace(".json", ".lua");

            //    File.WriteAllText(outfile, src.ToString());
            //    luaPaths.Add(outfile);
            //    count++;
            //}
            //AssetDatabase.Refresh();
            ////Create the array of bundle build details.
            //List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();
            //AssetBundleBuild build = new AssetBundleBuild();
            //build.assetBundleName = GameConf.LUA_FRAMEWORK;
            //build.assetNames = luaPaths.ToArray();

            //buildMap.Add(build);
            //Directory.CreateDirectory("Assets/ABs");
            //BuildPipeline.BuildAssetBundles("Assets/ABs", buildMap.ToArray(), BuildAssetBundleOptions.None, BuildTarget.Android);
            //// 清理战场
            //string buildDir = $"Assets/{GameConf.LUA_PATH}";
            //Directory.Delete(buildDir, true);
            //File.Delete($"{buildDir.Remove(buildDir.Length-1)}.meta");
            //// 复制 GameConf.LUA_FRAMEWORK
            //File.Copy($"Assets/ABs/{GameConf.LUA_FRAMEWORK}", $"{Application.streamingAssetsPath}/{GameConf.LUA_FRAMEWORK}", true);
            //AssetDatabase.Refresh();

            //var elapsedTime = DateTime.Now.Subtract(startTime);
            //Debug.Log($"copy {count} lua files, elapsed time:{elapsedTime}");
            makeLuaAssetBundle(GameConf.LUA_BASE_PATH, $"Assets/Abs/{GameConf.LUA_FRAMEWORK}");
        }
        #endregion

        #region 打包lua
        public static void makeLuaAssetBundle(string subDir, string outputPath) {
            var startTime = DateTime.Now;
            string luaDir = $"{Application.dataPath}/{subDir}";
            List<string> luaFiles = DirSearch(luaDir);
            // ignore .meta  files
            luaFiles.RemoveAll(x => x.EndsWith(".meta"));
            var outLuaFile = luaFiles.Select(s => s.Replace($"{Application.dataPath}/{subDir}", "lua/")).ToList();
            // 
            outLuaFile = luaFiles.Select(s => "lua/" + s).ToList();
            // create
            List<LuaSourceFile> luaSources = new List<LuaSourceFile>();
            foreach (var file in luaFiles) {
                var bytes = File.ReadAllBytes(file);
                if (bytes != null) {
                    luaSources.Add(new LuaSourceFile() {
                        OutFile = file.Replace(luaDir, GameConf.LUA_PATH).Replace("\\", "/").Replace(".lua", ".json"),
                        code = bytes.ToUTF8String()
                    });
                }
            }
            // create .bytes asset
            int count = 0;
            List<string> luaPaths = new List<string>();
            foreach (var src in luaSources) {
                var tmp = Application.dataPath + $"/" + src.OutFile;
                var dir = Path.GetDirectoryName(tmp);
                Directory.CreateDirectory(dir);
                var outfile = $"Assets/{src.OutFile}";
                src.OutFile = src.OutFile.Replace(GameConf.LUA_PATH, "").Replace(".json", ".lua");

                File.WriteAllText(outfile, src.ToString());
                luaPaths.Add(outfile);
                count++;
            }
            AssetDatabase.Refresh();
            //Create the array of bundle build details.
            string abPath = Path.GetDirectoryName(outputPath);
            string abName = Path.GetFileName(outputPath);
            List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();
            AssetBundleBuild build = new AssetBundleBuild();
            build.assetBundleName = abName;
            build.assetNames = luaPaths.ToArray();

            buildMap.Add(build);

            
            Directory.CreateDirectory(abPath);
            BuildPipeline.BuildAssetBundles("Assets/ABs", buildMap.ToArray(), BuildAssetBundleOptions.None, BuildTarget.Android);
            // 清理战场
            string buildDir = $"Assets/{GameConf.LUA_PATH}";
            Directory.Delete(buildDir, true);
            File.Delete($"{buildDir.Remove(buildDir.Length - 1)}.meta");
            // 复制 GameConf.LUA_FRAMEWORK
            File.Copy(outputPath, $"{Application.streamingAssetsPath}/{abName}", true);
            AssetDatabase.Refresh();

            var elapsedTime = DateTime.Now.Subtract(startTime);
            Debug.Log($"copy {count} lua files, elapsed time:{elapsedTime}");
        }
        #endregion
    }
}
