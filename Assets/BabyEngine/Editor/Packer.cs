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
        public static string ReleaseOutputDir {
            get {
                return $"{Application.dataPath.RemoveSuffix("Assets")}ReleaseAssetBundle/";
            }
        }
        
        private static List<string> DirSearch(string sDir) {
            List<string> files = new List<string>();
            try {
                foreach (string f in Directory.GetFiles(sDir)) {
                    string ext = Path.GetExtension(f);
                    if (ext.Equals(".meta")) {
                        continue;
                    }
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir)) {
                    files.AddRange(DirSearch(d.Replace('\\', '/')));
                }
            } catch (Exception e) {
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
 
        #region 打包lua
        static List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();
        public static void BuildMe() {
            var startTime = DateTime.Now;
            SearchLuaToBuild(GameConf.LUA_BASE_PATH, $"{GameConf.AB_PATH}{GameConf.LUA_FRAMEWORK}");
            

            var elapsedTime = DateTime.Now.Subtract(startTime);
            Debug.Log($" elapsed time:{elapsedTime}");
        }
        private static void SearchLuaToBuild(string subDir, string outputPath) {
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
            string abPath = Path.GetDirectoryName(outputPath).Replace("\\", "/");
            string abName = Path.GetFileName(outputPath).Replace("\\", "/");
            var extSubDir = abPath.Replace(Path.DirectorySeparatorChar, '/').Replace(GameConf.AB_PATH, "");
            
            if (subDir.StartsWith("Game") && subDir.EndsWith("lua/")) {
                abName = $"game/{extSubDir}/{abName}";
            }
            
            AssetBundleBuild build = new AssetBundleBuild();
            build.assetBundleName = abName;
            build.assetNames = luaPaths.ToArray();
            buildMap.Add(build);

            AddABFile("lua", $"{GameConf.AB_PATH}{abName}");
            abNames.Add(outputPath);
        }

        private static void BuildAssetBundles(BuildTarget target, string outputPath) {
            string abPath = Path.GetDirectoryName(outputPath).Replace("\\", "/");
            CreateDirIfNotExist(abPath);
            BuildPipeline.BuildAssetBundles(abPath, buildMap.ToArray(), BuildAssetBundleOptions.None, target);
        }
        static void CreateDirIfNotExist(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }
    
        static void CopyAssetBundles(string gameName) {
            // rename Manifest
            var tmp = GameConf.AB_PATH.RemoveSuffix("/");
            tmp = tmp.Substring(tmp.LastIndexOf("/"));
            var manifestName = GameConf.AB_PATH + tmp;
            var manifestOutputPath = $"{GameConf.AB_PATH}manifest{GameConf.AB_EXT}";
            if (File.Exists(manifestName)) {
                if(File.Exists(manifestOutputPath)) {
                    File.Delete(manifestOutputPath);
                }
                File.Move(manifestName, manifestOutputPath);
            }
            AddABFile("res", manifestOutputPath);
            Utility.CopyDirectory(GameConf.AB_PATH, ReleaseOutputDir, new string[] { ".meta", ".manifest"});
        }

        private static void CleanAssetBundle() {
            DeleteDir("Assets/"+GameConf.LUA_TEMP_PATH);
            DeleteDir(GameConf.AB_PATH);

            var statusFile = $"{ReleaseOutputDir}/build_status.txt";
            if (File.Exists(statusFile)) {
                File.Delete(statusFile);
            }
        }

        static void AddABFile(string type, string filepath) {
            filepath = filepath.Replace("//", "/");
            var statusFile = $"{ReleaseOutputDir}/build_status.txt";
            // load
            List<string> lines = new List<string>();
            if (File.Exists(statusFile)) {
                lines.AddRange(File.ReadAllLines(statusFile));
            }
            // add
            string info = $"{type}|{filepath}";
            lines.Add(info);
            // write
            File.WriteAllLines(statusFile, lines.Distinct().ToArray());
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
        static List<string> abNames = new List<string>();
        private static void SearchResourceToBuild(string path, string outputPath) {
            path = Application.dataPath + "/" + path;
            List<string> tempList = new List<string>();
            // 遍历文件
            string abPath = Path.GetDirectoryName(outputPath) + "/";
            var extSubDir = abPath.Replace(Path.DirectorySeparatorChar, '/').Replace(GameConf.AB_PATH, "");

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
                string temp = item.Substring(Application.dataPath.Length + 1);
                if (item == path) {
                    temp = temp.Substring(0, temp.Length - 1);
                }

                
                var abName = extSubDir + temp + GameConf.AB_EXT;
                AssetBundleBuild build = new AssetBundleBuild();
                build.assetBundleName = abName;
                build.assetNames = files;
                buildMap.Add(build);
                abNames.Add($"{abName}");
                AddABFile("res", $"{GameConf.AB_PATH}{abName}");
                // Debug.LogWarning($"temp: {temp} abName:{abName}");
            };

            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            handleDir(path);
            foreach (string item in dirs) {
                handleDir(item);
            }
        }
        #endregion
        #region 生成Hash文件
        
        public static void ResetBuildStatus() {
            var statusFile = $"{ReleaseOutputDir}/build_status.txt";
            var outputFile = $"{ReleaseOutputDir}/update.txt";
            if (File.Exists(statusFile)) {
                File.Delete(statusFile);
            }
            if (File.Exists(outputFile)) {
                File.Delete(outputFile);
            }

            DeleteDir(ReleaseOutputDir);
            Directory.CreateDirectory(ReleaseOutputDir);
            abNames.Clear();
            buildMap.Clear();
        }
        public static void BuildHashFile() {
            var statusFile = $"{ReleaseOutputDir}/build_status.txt";
            var outputFile = $"{ReleaseOutputDir}/update.txt";
            List<string> lines = new List<string>();
            if(!Directory.Exists(ReleaseOutputDir)) {
                Directory.CreateDirectory(ReleaseOutputDir);
            }
            if (File.Exists(statusFile)) {
                lines.AddRange(File.ReadAllLines(statusFile));
            }
            StringWriter sw = new StringWriter();
            foreach(var line in lines) {
                try {
                    var tokens = line.Split('|');
                    if (tokens == null || tokens.Length == 0) {
                        continue;
                    }
                    var type = tokens[0];
                    var filepath = tokens[1];
                    if (!File.Exists(filepath)) {
                        Debug.Log($"文件不存在: {filepath}");
                        continue;
                    }
                    var hash = CalculateMD5(filepath);
                    var size = FileSize(filepath);
                    var path = filepath.Replace(ReleaseOutputDir, "").ToLower();
                    if (path.StartsWith(GameConf.AB_PATH.ToLower())) {
                        path = path.Replace(GameConf.AB_PATH.ToLower(), "");
                    }

                    string info = $"{type}|{hash}|{size}|{path}";
                    //Debug.Log(info);
                    sw.WriteLine(info);
                }catch(Exception e) {
                    Debug.LogError(e);
                }
            }
            File.WriteAllText(outputFile, sw.ToString());
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
            return new FileInfo(filename).Length;
        }
        #endregion

        public static void BuildAll(BuildTarget target, string gameName) {
            var startTime = DateTime.Now;
            try {
                if (Application.isPlaying || EditorApplication.isCompiling) {
                    EditorUtility.DisplayDialog("提醒", "运行中或编译未完成", "确定");
                    return;
                }
                
                ResetBuildStatus();
                SearchLuaToBuild(GameConf.LUA_BASE_PATH, $"{GameConf.AB_PATH}{GameConf.LUA_FRAMEWORK}"); // framework
                SearchLuaToBuild($"Game/{gameName}/lua/", $"{GameConf.AB_PATH}/{gameName}/src{GameConf.AB_EXT}"); // subgame
                SearchResourceToBuild($"Game/{gameName}/res/", $"{GameConf.AB_PATH}{gameName}");
                BuildAssetBundles(target, $"{GameConf.AB_PATH}{gameName}");
                CopyAssetBundles(gameName);
                BuildHashFile();
            } catch (Exception e) {
                Debug.LogError(e);
            } finally {
                CleanAssetBundle();
                AssetDatabase.Refresh();
                var elapsedTime = DateTime.Now.Subtract(startTime);
                Debug.Log($"build elapsed time:{elapsedTime}");
            }
        }
    }
}
