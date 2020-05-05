using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            makeLuaAssetBundle(GameConf.LUA_BASE_PATH, $"{GameConf.AB_PATH}{GameConf.LUA_FRAMEWORK}");
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
                // ext sub dirs
                var extSubDir = abPath.Replace(Path.DirectorySeparatorChar, '/').Replace(GameConf.AB_PATH, "");
                Directory.CreateDirectory(abPath);
                BuildPipeline.BuildAssetBundles(GameConf.AB_PATH + extSubDir, buildMap.ToArray(), BuildAssetBundleOptions.None, BuildTarget.Android);
               
                AssetDatabase.Refresh();
                // 复制 GameConf.LUA_FRAMEWORK
                Directory.CreateDirectory(Application.streamingAssetsPath+$"/{extSubDir}");
                File.Copy(outputPath, $"{Application.streamingAssetsPath}/{extSubDir}/{abName}", true);
                File.Copy(outputPath+ ".manifest", $"{Application.streamingAssetsPath}/{extSubDir}/{abName}.manifest", true);
                AssetDatabase.Refresh();

                
                FileInfo fileInfo = new FileInfo(outputPath);
                var version = $"{fileInfo.CreationTime.ToFileTimeUtc()}";
                if (!Directory.Exists("Assets/Resources")) {
                    Directory.CreateDirectory("Assets/Resources");
                }
                File.WriteAllText("Assets/Resources/baby_version.txt", version);
                AddABFile($"{Application.streamingAssetsPath}/{extSubDir}/{abName}");

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
        static void AddABFile(string filepath) {
            
            var statusFile = $"{Application.streamingAssetsPath}/build_status";
            // load
            List<string> lines = new List<string>();
            if (File.Exists(statusFile)) {
                lines.AddRange(File.ReadAllLines(statusFile));
            }
            // add
            lines.Add(filepath);
            // write
            File.WriteAllLines(statusFile, lines.Distinct());
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
        public static string[] BuildAssetResource(BuildTarget target, string path, string outputPath) {
            List<string> allAssetBundleFilename = new List<string>();
            try {
                var startTime = DateTime.Now;
                List<AssetBundleBuild> maps = new List<AssetBundleBuild>();
                if (Application.isPlaying || EditorApplication.isCompiling) {
                    EditorUtility.DisplayDialog("提醒", "运行中或编译未完成", "确定");
                    return allAssetBundleFilename.ToArray();
                }
                if (!Directory.Exists(Application.streamingAssetsPath)) {
                    Directory.CreateDirectory(Application.streamingAssetsPath);
                }
                path = Application.dataPath + "/" + path;
                List<string> tempList = new List<string>();
                // 遍历文件
                string abPath = Path.GetDirectoryName(outputPath);
                var extSubDir = abPath.Replace(Path.DirectorySeparatorChar, '/').Replace(GameConf.AB_PATH, "");
                List<string> abNames = new List<string>();
                Action<string> handleDir = (string item) => {
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
                        return;
                    }
                    string temp = item.Substring(Application.dataPath.Length + 1);//.Replace("/", "-").Replace("\\", "-");
                    if (item == path) {
                        temp = temp.Substring(0, temp.Length - 1);
                    }
                    var abName = extSubDir + "/" + temp + ".unity3d";
                    AssetBundleBuild build = new AssetBundleBuild();
                    build.assetBundleName = abName;
                    build.assetNames = files;
                    maps.Add(build);
                    abNames.Add(abName);
                };

                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                handleDir(path);
                foreach (string item in dirs) {
                    handleDir(item);
                }
                // 构建AB
                if (!Directory.Exists(GameConf.AB_PATH)) {
                    Directory.CreateDirectory(GameConf.AB_PATH);
                }
                BuildPipeline.BuildAssetBundles(GameConf.AB_PATH, maps.ToArray(), BuildAssetBundleOptions.None, target);

                // copy to StreamingAssets
                Directory.CreateDirectory(Application.streamingAssetsPath + $"/{extSubDir}");
                foreach (var abName in abNames) {
                    var filepath = $"{Application.streamingAssetsPath}/{abName}";
                    //Debug.Log(filepath);
                    allAssetBundleFilename.Add(filepath);
                }
                if (!Directory.Exists($"{Application.streamingAssetsPath}/{extSubDir}")) {
                    Directory.CreateDirectory($"{Application.streamingAssetsPath}/{extSubDir}");
                }
                Utility.CopyDirectory(outputPath, $"{Application.streamingAssetsPath}/{extSubDir}");

                AssetDatabase.Refresh();
                var elapsedTime = DateTime.Now.Subtract(startTime);
                Debug.Log($"build {maps.Count} AB, elapsed time:{elapsedTime}");
            }catch(Exception e) {
                Debug.LogError(e);
            } finally {
                // 清理战场
                DeleteDir($"Assets/{GameConf.LUA_TEMP_PATH}");
                DeleteDir(GameConf.AB_PATH);
                AssetDatabase.Refresh();
            }
            return allAssetBundleFilename.ToArray();
        }
        
        
        #endregion

        #region utils functions
        static string CalculateMD5(string filename) {
            using (var md5 = MD5.Create()) {
                using (var stream = File.OpenRead(filename)) {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        static long FileSize(string filename) {
            return new System.IO.FileInfo(filename).Length;
        }
        #endregion
    }
}
