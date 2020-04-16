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
            Debug.Log("替换文件咯");
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
                var destPath = $"{Application.streamingAssetsPath}/{abName}";
                Directory.CreateDirectory(Application.streamingAssetsPath);
                
                File.Copy(outputPath, destPath, true);
                AssetDatabase.Refresh();

                var elapsedTime = DateTime.Now.Subtract(startTime);
                FileInfo fileInfo = new FileInfo(outputPath);
                var version = $"{fileInfo.CreationTime.ToFileTimeUtc()}";
                if (!Directory.Exists("Assets/Resources")) {
                    Directory.CreateDirectory("Assets/Resources");
                }
                File.WriteAllText("Assets/Resources/baby_version.txt", version);
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
    }
}
