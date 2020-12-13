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
        public static BuildTarget currentBuildingTarget = BuildTarget.Android;
        
        public static string ReleaseOutputDir {
            get {
                return $"{ReleaseOutputBaseDir}{ReleaseOutputSubDir}";
            }
        }

        public static string ReleaseOutputBaseDir {
            get {
                return $"{Application.dataPath.RemoveSuffix("Assets")}ReleaseAssetBundle/";
            }
        }
        public static string ReleaseOutputSubDir {
            get {
                return $"{currentBuildingTarget.ToString().ToLower()}/v{VersionDir}";
            }
        }
        public static string VersionDir {
            get {
                return EditorPrefs.GetString("__build_datetime__");
            }
            set {
                EditorPrefs.SetString("__build_datetime__", value);
            }
        }

        public static void ResetVersion(bool force=false) {
            var timestamp = $"{ DateTime.Now.ToString("yyyyMMdd_HHmmss") }";
            if (force) {
                VersionDir = timestamp;
                return;
            }
            string msg = "";
            if (string.IsNullOrEmpty(VersionDir)) {
                msg = $"新版本的目录:{currentBuildingTarget.ToString().ToLower()}/v{timestamp}";
            } else {
                msg = $"当前版本目录:{ReleaseOutputSubDir}\n新版本的目录:{currentBuildingTarget.ToString().ToLower()}/v{timestamp}";
            }
            if (EditorUtility.DisplayDialog("重置目录", msg, "确定", "取消")) {
                VersionDir = timestamp;
            }
        }
        private static List<string> DirSearch( string sDir ) {
            List<string> files = new List<string>();
            try {
                Debug.Log($"搜索 {sDir}");
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
            BuildPipeline.BuildPlayer(levels.ToArray(), $"{PlayerSettings.productName}_{PlayerSettings.Android.bundleVersionCode}.apk", BuildTarget.Android, BuildOptions.None);
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
        private static void SearchLuaToBuild( string subDir, string outputPath ) {
            string luaDir = $"{Application.dataPath}/{subDir}";
            List<string> luaFiles = DirSearch(luaDir);
            // ignore .meta  files
            luaFiles.RemoveAll(x => x.EndsWith(".meta") || x.EndsWith(".DS_Store"));
            var outLuaFile = luaFiles.Select(s => s.Replace($"{Application.dataPath}/{subDir}", "lua/")).ToList();
            // 
            outLuaFile = luaFiles.Select(s => "lua/" + s).ToList();
            List<LuaSourceFile> luaSources = new List<LuaSourceFile>();
            if (!theOptions.EnableLUAC) { // 是否启用luac
                foreach (var file in luaFiles) {
                    //Debug.Log(file);
                    var bytes = File.ReadAllBytes(file);
                    if (bytes != null) {
                        luaSources.Add(new LuaSourceFile() {
                            OutFile = file.Replace(luaDir, GameConf.LUA_TEMP_PATH).Replace("\\", "/").Replace(".lua", ".json"),
                            code = bytes
                        });
                    }
                }
            } else { // 启用luac
#if UNITY_EDITOR_OSX
                string cmdPath = Application.dataPath + "/../Tools/luac";
#else
                string cmdPath = Application.dataPath + "/../Tools/luac.exe";
#endif
                if (!Directory.Exists(ReleaseOutputDir)) {
                    Directory.CreateDirectory(ReleaseOutputDir);
                }

                foreach (var file in luaFiles) {
                    if (!file.EndsWith(".lua")) {
                        continue;
                    }
                    string strCmdText;
                    strCmdText = " " + file; //+ " -o " + ReleaseOutputDir + "/tmp.luac";
                    var cmd = new System.Diagnostics.Process();
                    cmd.StartInfo.FileName = cmdPath;
                    cmd.StartInfo.Arguments = file;
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    var cmdResult = cmd.StandardOutput.ReadToEnd();
                    //Debug.Log(cmdResult);

                    var bytes = File.ReadAllBytes("luac.out");
                    if (bytes != null) {
                        luaSources.Add(new LuaSourceFile() {
                            OutFile = file.Replace(luaDir, GameConf.LUA_TEMP_PATH).Replace("\\", "/").Replace(".lua", ".json"),
                            code = bytes
                        });
                    }
                    File.Delete("luac.out");
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
            var originFileName = abName.ToLower().Replace(Path.DirectorySeparatorChar.ToString(), "/");
            abName = StringMD5(originFileName);
            Debug.Log($" {abName} ");
            AssetBundleBuild build = new AssetBundleBuild();
            build.assetBundleName = abName;
            build.assetNames = luaPaths.ToArray();
            buildMap.Add(build);

            AddABFile("lua", $"{GameConf.AB_PATH}{abName}", originFileName);
            abNames.Add(outputPath);
        }

        private static void BuildAssetBundles( BuildTarget target, string outputPath ) {
            string abPath = Path.GetDirectoryName(outputPath).Replace("\\", "/");
            CreateDirIfNotExist(abPath);
            BuildPipeline.BuildAssetBundles(abPath, buildMap.ToArray(), BuildAssetBundleOptions.None, target);
        }
        static void CreateDirIfNotExist( string path ) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }

        static void CopyAssetBundles() {
            // rename Manifest
            var tmp = GameConf.AB_PATH.RemoveSuffix("/");
            tmp = tmp.Substring(tmp.LastIndexOf("/"));
            var manifestName = GameConf.AB_PATH + tmp;
            var manifestOutputPath = $"{GameConf.AB_PATH}" + StringMD5("manifest");
            if (File.Exists(manifestName)) {
                if (File.Exists(manifestOutputPath)) {
                    File.Delete(manifestOutputPath);
                }
                File.Move(manifestName, manifestOutputPath);
            }
            AddABFile("res", manifestOutputPath, "manifest");
            Utility.CopyDirectory(GameConf.AB_PATH, ReleaseOutputDir, new string[] { ".meta", ".manifest" });
        }

        private static void CleanAssetBundle() {
            DeleteDir("Assets/" + GameConf.LUA_TEMP_PATH);
            DeleteDir(GameConf.AB_PATH);

            var statusFile = $"{ReleaseOutputDir}/build_status.txt";
            if (File.Exists(statusFile)) {
                File.Delete(statusFile);
            }
        }

        static void AddABFile(string type, string filepath, string originFileName) {
            versionInfo.files = versionInfo.files.Append(new VersionFile { Type = type, Path = filepath }).ToArray();
        }
        private static void DeleteDir( string dir ) {
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
            ".controller", ".bytes",
#if UNITY_2017_1_OR_NEWER
            ".spriteatlas",
#endif
        };
        static List<string> abNames = new List<string>();
        private static void SearchResourceToBuild( string path, string outputPath ) {
            path = Application.dataPath + "/" + path;
            if (!Directory.Exists(path)) {
                return;
            }
            List<string> tempList = new List<string>();
            // 遍历文件
            string abPath = Path.GetDirectoryName(outputPath) + "/";
            var extSubDir = abPath.Replace(Path.DirectorySeparatorChar, '/').Replace(GameConf.AB_PATH, "");
            Action<string> handleDir = ( string item ) => {
                string[] files = Directory.GetFiles(item);
                // 过滤有效文件
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

                foreach (var name in files) {
                    var fileNameOnly = Path.GetFileNameWithoutExtension(name);
                    var abName = extSubDir + temp + "/" + fileNameOnly;
                    var originFileName = abName.ToLower().Replace(Path.DirectorySeparatorChar.ToString(), "/");
                    abName = StringMD5(originFileName);
                    AssetBundleBuild build = new AssetBundleBuild();
                    build.assetBundleName = abName;
                    build.assetNames = new string[1] { name };
                    buildMap.Add(build);
                    abNames.Add($"{abName}");

                    AddABFile("res", $"{GameConf.AB_PATH}{abName}", originFileName);
                    //Debug.LogWarning($"temp: {abName}=> {temp} abName:{abName}");
                }
            };

            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            handleDir(path);
            foreach (string item in dirs) {
                handleDir(item);
            }
        }
        #endregion
        #region 生成Hash文件
        private static VersionInfo versionInfo;
        [Serializable]
        public class VersionInfo {
            public int version;
            public string platform;
            public VersionFile[] files = new VersionFile[0];
        }
        [Serializable]
        public class VersionFile {
            public string Type;
            public string Hash;
            public long   Size;
            public string Path;

        }
        public static void ResetBuildStatus() {
            DeleteDir(ReleaseOutputDir);
            Directory.CreateDirectory(ReleaseOutputDir);
            abNames.Clear();
            buildMap.Clear();
        }
        public static void BuildHashFile() {
            if (!Directory.Exists(ReleaseOutputDir)) {
                Directory.CreateDirectory(ReleaseOutputDir);
            }
            
            foreach (var ver in versionInfo.files) {
                try {
                    var filepath = ver.Path;
                    var path = filepath.Replace(ReleaseOutputDir, "").ToLower();
                    if (path.StartsWith(GameConf.AB_PATH.ToLower())) {
                        path = path.Replace(GameConf.AB_PATH.ToLower(), "");
                    }
                    ver.Path = path;

                    if(string.IsNullOrEmpty(GameConf.EncryptPassword)) {
                        ver.Hash = CalculateMD5(filepath);
                        ver.Size = FileSize(filepath);
                    } else {
                        //Debug.Log(ver.Path +">1>" + CalculateMD5(filepath));
                        var originData = File.ReadAllBytes(filepath);
                        var encData = AESHelper.Encrypt(GameConf.EncryptPassword, originData);
                        File.Delete(filepath);
                        filepath = $"{ReleaseOutputDir}/{path}";
                        File.WriteAllBytes(filepath, encData);
                        
                        //Debug.Log(ver.Path + ">2>" + CalculateMD5(filepath));

                        ver.Hash = CalculateMD5(filepath);
                        ver.Size = FileSize(filepath);
                    }
                     
                } catch (Exception e) {
                    Debug.LogError(e);
                }
            }

            File.WriteAllText($"{ReleaseOutputDir}/version.json", JsonUtility.ToJson(versionInfo));
        }
        #endregion
        #region utils functions
        static string CalculateMD5( string filename ) {
            using (var md5 = MD5.Create()) {
                using (var stream = File.OpenRead(filename)) {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        static string StringMD5( string str ) {
            using (var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(str.GetUTF8Bytes());
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
        static long FileSize( string filename ) {
            return new FileInfo(filename).Length;
        }
        #endregion
        public struct Options {
            public BuildTarget target;
            public bool EnableLUAC; // 是否启用luac
        }
        static Options theOptions;
        public static void BuildAll( Options options ) {
            var startTime = DateTime.Now;
            try {
                if (Application.isPlaying || EditorApplication.isCompiling) {
                    EditorUtility.DisplayDialog("提醒", "运行中或编译未完成", "确定");
                    return;
                }
                if (string.IsNullOrEmpty(VersionDir)) {
                    ResetVersion(true);
                }
                versionInfo = new VersionInfo();
                theOptions = options;
                currentBuildingTarget = theOptions.target;
                var target = theOptions.target;
                ResetBuildStatus();
                SearchLuaToBuild(GameConf.LUA_BASE_PATH, $"{GameConf.AB_PATH}{GameConf.LUA_FRAMEWORK}"); // framework
                SearchLuaToBuild($"Game/lua/", $"{GameConf.AB_PATH}/src"); // subgame
                SearchResourceToBuild($"Game/res/", $"{GameConf.AB_PATH}");
                BuildAssetBundles(target, $"{GameConf.AB_PATH}");
                
                CopyAssetBundles();
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
