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
            var path = Path.Combine(targetPath, "Build/UnityLoader.js");
            var text = File.ReadAllText(path);
            text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
            text = text.Replace("[\"Edge\", \"Firefox\", \"Chrome\", \"Safari\"].indexOf(UnityLoader.SystemInfo.browser) == -1", "false");
            File.WriteAllText(path, text);
        }

        [MenuItem("Tools/Build/Android")]
        public static void BuildAndroid() {
            // 
            BuildLua();
            //
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
        [MenuItem("Tools/Build/Copy Lua Framework")]
        public static void BuildLua() {
            makeLuaAssetBundle(GameConf.LUA_BASE_PATH, $"Assets/Abs/{GameConf.LUA_FRAMEWORK}");
        }
        #endregion

        #region 打包lua
        public static void makeLuaAssetBundle(string subDir, string outputPath) {
            try {
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
                            OutFile = file.Replace(luaDir, GameConf.LUA_TEMP_PATH).Replace("\\", "/").Replace(".lua", ".json"),
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
                    src.OutFile = src.OutFile.Replace(GameConf.LUA_TEMP_PATH, "").Replace(".json", ".lua");

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
                BuildPipeline.BuildAssetBundles(GameConf.AB_PATH, buildMap.ToArray(), BuildAssetBundleOptions.None, BuildTarget.Android);
               
                AssetDatabase.Refresh();
                // 复制 GameConf.LUA_FRAMEWORK
                Directory.CreateDirectory(Application.streamingAssetsPath);
                File.Copy(outputPath, $"{Application.streamingAssetsPath}/{abName}", true);
                File.Copy(outputPath+ ".manifest", $"{Application.streamingAssetsPath}/{abName}.manifest", true);
                AssetDatabase.Refresh();

                
                FileInfo fileInfo = new FileInfo(outputPath);
                var version = $"{fileInfo.CreationTime.ToFileTimeUtc()}";
                if (!Directory.Exists("Assets/Resources")) {
                    Directory.CreateDirectory("Assets/Resources");
                }
                File.WriteAllText("Assets/Resources/baby_version.txt", version);
                var elapsedTime = DateTime.Now.Subtract(startTime);
                Debug.Log($"copy {count} lua files, elapsed time:{elapsedTime} version:{version}");
                
            } catch (Exception e) {
                Debug.LogError(e);
            } finally {
                // 清理战场
                DeleteDir($"Assets/{GameConf.LUA_TEMP_PATH}");
                DeleteDir(GameConf.AB_PATH);
                AssetDatabase.Refresh();
            }
        }
        private static void DeleteDir(string dir) {
            if (Directory.Exists(dir)) {
                Directory.Delete(dir, true);
            }
            if (File.Exists($"{dir.Remove(dir.Length - 1)}.meta")) {
                File.Delete($"{dir.Remove(dir.Length - 1)}.meta");
            }
        }
        #endregion

        #region 打包资源
        static readonly List<string> filetype = new List<string> { 
            ".shader", ".renderTexture", ".jpg", ".png", ".mat",".tga",
            ".anim", ".fbx", ".prefab", ".mp3", ".ogg", ".asset",
            ".json", ".txt", ".wav", ".ttf", ".fontsettings",
            ".controller", ".bytes"
        };
        //[MenuItem("Tools/Build/iOS Resource", false, 100)]
        //public static void BuildiPhoneResource() {
        //    BuildAssetResource(BuildTarget.iOS);
        //}
        public static void BuildAssetResource(BuildTarget target, string path) {
            var startTime = DateTime.Now;
            if (Application.isPlaying || EditorApplication.isCompiling) {
                EditorUtility.DisplayDialog("提醒", "运行中或编译未完成", "确定");
                return;
            }
            if (!Directory.Exists(Application.streamingAssetsPath)) {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }
            path = Application.dataPath + "/" + path;
            List<string> tempList = new List<string>();
            maps.Clear();
            // 遍历文件
            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach(string item in dirs) {
                string[] files = Directory.GetFiles(item);
                tempList.Clear();
                foreach (string str in files) {
                    string ext = Path.GetExtension(str);
                    if (!filetype.Contains(ext)) {
                        continue;
                    }
                    var tmp = "Assets" + str.Replace(Application.dataPath, "");
                    tempList.Add(tmp);
                }
                files = tempList.ToArray();
                if (files.Length == 0) {
                    continue;
                }
                var temp = item.Substring(Application.dataPath.Length + 1).Replace("/", "-").Replace("\\", "-");
                var dirName = temp + ".unity3d";
                AssetBundleBuild build = new AssetBundleBuild();
                build.assetBundleName = dirName;
                build.assetNames = files;
                maps.Add(build);
            }
            // 构建AB
            if(!Directory.Exists(GameConf.AB_PATH)) {
                Directory.CreateDirectory(GameConf.AB_PATH);
            }
            BuildPipeline.BuildAssetBundles(GameConf.AB_PATH, maps.ToArray(), BuildAssetBundleOptions.None, target);
            AssetDatabase.Refresh();
            var elapsedTime = DateTime.Now.Subtract(startTime);
            Debug.Log($"build {maps.Count} AB, elapsed time:{elapsedTime}");
        }
        
        static List<AssetBundleBuild> maps = new List<AssetBundleBuild>();
        #endregion
    }
}
