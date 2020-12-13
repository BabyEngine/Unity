#define ENABLE_ALI_OSS
#define ENABLE_QCLOUD_COS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using Debug = UnityEngine.Debug;
using UObject = UnityEngine.Object;

#if ENABLE_ALI_OSS
using Aliyun.OSS;
#endif
#if ENABLE_ALI_OSS
using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using COSXML.Model.Bucket;
using COSXML.CosException;
using COSXML.Transfer;
using COSXML.Model;
#endif

namespace BabyEngine {
    public class PackerWindow : EditorWindow {
        string[] platformOptions = new string[] {
            "Android", "iOS", "Windows", "macOS"
        };
        string platformOption = "Android";

        [SerializeField]
        protected List<UObject> startupGameObjects = new List<UObject>();
        protected SerializedObject serializedObject;
        protected SerializedProperty assetLstProperty;

        class PackerConfig {
            public string[] startupObjectPaths = new string[0];
            public bool luac;
        }

        [MenuItem("Tools/打包AssetBundle面板")]
        public static void Init() {
            PackerWindow window = (PackerWindow)EditorWindow.GetWindow(typeof(PackerWindow));
            window.titleContent = new GUIContent("打包器");
            window.Show();
        }
        PackerConfig _currentConfig = null;

        PackerConfig currentConfig {
            get {
                if (_currentConfig != null) {
                    return _currentConfig;
                }
                var save = EditorPrefs.GetString("packer_startup");
                if (!string.IsNullOrEmpty(save)) {
                    var obj = JsonUtility.FromJson<PackerConfig>(save);
                    if (obj != null) {
                        startupGameObjects.Clear();
                        foreach (var path in obj.startupObjectPaths) {
                            var go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                            if (go != null) {
                                startupGameObjects.Add(go);
                            }
                        }
                        _currentConfig = obj;
                    }
                } else {
                    _currentConfig = new PackerConfig();
                }
                return _currentConfig;
            }
        }

        protected void OnEnable() {
            serializedObject = new SerializedObject(this);
            assetLstProperty = serializedObject.FindProperty("startupGameObjects");
        }

        private void OnDisable() {
            List<string> paths = new List<string>();
            foreach (var obj in startupGameObjects) {
                var path = AssetDatabase.GetAssetPath(obj);
                paths.Add(path);
            }
            currentConfig.startupObjectPaths = paths.ToArray();
            var data = JsonUtility.ToJson(currentConfig);
            EditorPrefs.SetString("packer_startup", data);
            //Debug.Log("关闭打包器:" + data);
        }
        void DoPackStartup( string savePath ) {
            BuildTarget target;
            switch (platformOption) {
            case "Android":
                target = BuildTarget.Android;
                break;
            case "iOS":
                target = BuildTarget.iOS;
                break;
            case "Windows":
                target = BuildTarget.StandaloneWindows;
                break;
            case "macOS":
                target = BuildTarget.StandaloneOSX;
                break;
            default:
                EditorUtility.DisplayDialog("提醒", "没有选中编译的平台", "确定");
                return;
            }
            // 打包
            List<string> names = new List<string>();
            foreach (var go in startupGameObjects) {
                names.Add(AssetDatabase.GetAssetPath(go));
            }
            var abPath = Path.GetDirectoryName(savePath);
            var abName = Path.GetFileName(savePath);

            if (!Directory.Exists(abPath)) {
                Directory.CreateDirectory(abPath);
            }

            AssetBundleBuild build = new AssetBundleBuild();
            build.assetNames = names.ToArray();
            build.assetBundleName = abName;
            
            var mf = BuildPipeline.BuildAssetBundles(abPath, new AssetBundleBuild[] { build }, BuildAssetBundleOptions.StrictMode, target);
            AssetDatabase.SaveAssets();
            Debug.Log("build end:" + File.Exists(savePath));
            Debug.Log(mf.GetAllAssetBundles().Length);
            foreach(string name in mf.GetAllAssetBundles()) {
                Debug.Log("构建完成:" + name);
            }
            
            if (!string.IsNullOrEmpty(GameConf.EncryptPassword) && File.Exists(savePath)) {
                var data = File.ReadAllBytes(savePath);
                AssetBundleLoader.Reset(true);
                var enc_data = AssetBundleLoader.Encode(data);
                File.WriteAllBytes(savePath, enc_data);
                Debug.Log("加密前:" + AssetBundleLoader.GetMD5(data));
                Debug.Log("加密后:" + AssetBundleLoader.GetMD5(enc_data));
                // 检查是否成功
                var ab = AssetBundleLoader.LoadFromMemory("init.dat", enc_data);
                if (ab != null) {
                    Debug.Log("加载成功" + ab.GetAllAssetNames().Length);
                    ab.Unload(true);
                } else {
                    Debug.LogError($"校验文件失败{savePath}");
                }

                return;
            }
        }

        void BuildUI_PackStartup() {
#region 打包的Prefab列表
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(assetLstProperty, true);
            if (EditorGUI.EndChangeCheck()) {//提交修改
                serializedObject.ApplyModifiedProperties();
            }
#endregion
#region 触发打包
            if (GUILayout.Button(new GUIContent("打启动包"))) {
                var path = EditorUtility.SaveFilePanel("保存文件", "", "init.dat", "");
                DoPackStartup(path);
            }
#endregion
        }
        void BuildUI_PackGame() {
            #region 热更生成
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("luac:");
            currentConfig.luac = EditorGUILayout.Toggle(currentConfig.luac);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (string.IsNullOrEmpty(Packer.VersionDir)) {
                EditorGUILayout.LabelField($"热更版本号: 没有任何版本信息");
            } else {
                
                EditorGUILayout.BeginVertical();
                {
                    EditorGUILayout.LabelField($"热更版本号:{Packer.ReleaseOutputSubDir}");
                }
                {
                    string val = EditorGUILayout.TextField($"{Packer.VersionDir}");
                    if (val != Packer.VersionDir) {
                        Packer.VersionDir = val;
                    }
                }

                EditorGUILayout.EndVertical();
                //EditorGUILayout.LabelField($"热更版本号:{Packer.currentBuildingTarget.ToString().ToLower()}/v");
                
            }
            
            if (GUILayout.Button(new GUIContent("生成热更版本号"))) {
                Packer.ResetVersion();
            }
            EditorGUILayout.EndHorizontal();
#endregion

#region 触发打包
            if (GUILayout.Button(new GUIContent("打包"))) {
                DoPack();
                DoPackStartup(Packer.ReleaseOutputDir + "/init.dat");
            }
#endregion
            if (GUILayout.Button(new GUIContent("打开-打包目录"))) {
                EditorUtility.RevealInFinder(Packer.ReleaseOutputDir);
            }
            EditorGUILayout.Space();


        }
        void OnGUI() {

#region 选中编译平台
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("平台:");
            if (EditorGUILayout.DropdownButton(new GUIContent(platformOption), FocusType.Keyboard)) {
                GenericMenu menu = new GenericMenu();
                foreach (var item in platformOptions) {
                    menu.AddItem(new GUIContent(item), platformOptions.Equals(item), OnValueSelected_Platform, item);
                }
                menu.ShowAsContext();//显示菜单
            }
            EditorGUILayout.EndHorizontal();
#endregion

            BuildUI_PackStartup();
            GuiLine();

            BuildUI_PackGame();
            GuiLine();

            BuildUI_LocalHotPatchServer();
            GuiLine();

            BuildUI_OSS();
            GuiLine();

            BuildUI_COS();
            GuiLine();
        }

        void BuildUI_LocalHotPatchServer() {
            #region 热更调试服务器
            string serverStatus = serverCmdId == -1 ? "启动-热更调试服务器" : "停止-热更调试服务器";
            if (GUILayout.Button(new GUIContent(serverStatus))) {
                StartServer();
            }
            EditorGUILayout.Space();
            #endregion
        }
        void OnValueSelected_Platform( object p ) {
            platformOption = p.ToString();
            BuildTarget target;
            switch (platformOption) {
                case "Android":
                    target = BuildTarget.Android;
                    break;
                case "iOS":
                    target = BuildTarget.iOS;
                    break;
                case "Windows":
                    target = BuildTarget.StandaloneWindows;
                    break;
                case "macOS":
                    target = BuildTarget.StandaloneOSX;
                    break;
                default:
                    EditorUtility.DisplayDialog("提醒", "没有选中编译的平台", "确定");
                    return;
            }
            Packer.currentBuildingTarget = target;
        }

        void DoPack() {
            BuildTarget target;
            switch (platformOption) {
            case "Android":
                target = BuildTarget.Android;
                break;
            case "iOS":
                target = BuildTarget.iOS;
                break;
            case "Windows":
                target = BuildTarget.StandaloneWindows;
                break;
            case "macOS":
                target = BuildTarget.StandaloneOSX;
                break;
            default:
                EditorUtility.DisplayDialog("提醒", "没有选中编译的平台", "确定");
                return;
            }

            Packer.BuildAll(new Packer.Options {
                target = target,
                EnableLUAC = currentConfig.luac,
            });
        }
        int serverCmdId {
            get {
                return EditorPrefs.GetInt("hotpatch_pid", -1);
            }
            set {
                EditorPrefs.SetInt("hotpatch_pid", value);
            }
        }
        void StartServer() {
            if (serverCmdId != -1) {
                tryKillServerCmd();
                return;
            }
#if UNITY_EDITOR_OSX
            string cmdPath = Application.dataPath + "/../Tools/SimpleHTTPServer";
#else
                string cmdPath = Application.dataPath + "/../Tools/SimpleHTTPServer.exe";
#endif
            ProcessStartInfo startInfo = new ProcessStartInfo(cmdPath);
            startInfo.Arguments = "-path=" + $"{Application.dataPath.RemoveSuffix("Assets")}ReleaseAssetBundle/{platformOption.ToString().ToLower()}/";
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            try {
                Process process = Process.Start(startInfo);
                serverCmdId = process.Id;
                process.OutputDataReceived += ( s, _e ) => {
                    if (_e.Data != null) {
                        Debug.Log(_e.Data);
                    }
                };
                process.ErrorDataReceived += ( s, _e ) => {
                    if (_e.Data != null) {
                        Debug.LogError(_e.Data);
                    }
                };
                process.EnableRaisingEvents = true;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                new Task(() => {
                    process.WaitForExit();
                }).Start();
            } catch (Exception e) {
                Debug.LogError(e.Message);
            }
        }

        void tryKillServerCmd() {
            try {
                if (serverCmdId != -1) {
                    var p = Process.GetProcessById(serverCmdId);
                    Debug.Log($"停止调试服务器, pid:{serverCmdId}, name:{p}");
                    if (p != null) {
                        p.Kill();
                    }
                    return;
                }
            } catch (Exception e) {
                Debug.LogError(e);
            } finally {
                serverCmdId = -1;
            }
        }

        protected void OnDestroy() {
            tryKillServerCmd();
        }
        void Run(Action action) {
            lock (actions) {
                actions.Add(action);
            }
        }
        List<Action> actions = new List<Action>();
        private void Update() {
            lock(actions) {
                for(int i = 0;i< actions.Count;i++) {
                    actions[i]();
                }
                actions.Clear();
            }
        }
        #region 阿里云OSS
#if ENABLE_ALI_OSS
        private string oss_endpoint = "";
        private string oss_accessKeyId = "";
        private string oss_accessKeySecret = "";
        private string oss_bucketName = "";
        private string oss_prefix = "";
        private bool enableOSSConfig = false;
        private bool enableOSS;
        void uploadToAliyunOSS( string versinoType ) {
            if (string.IsNullOrEmpty(oss_endpoint) ||
                string.IsNullOrEmpty(oss_accessKeyId) ||
                string.IsNullOrEmpty(oss_accessKeySecret) ||
                string.IsNullOrEmpty(oss_prefix) ||
                string.IsNullOrEmpty(oss_bucketName)) {
                EditorUtility.DisplayDialog("警告", $"配置信息丢失", "确认");
                return;
            }
            var dir = Packer.ReleaseOutputDir;
            Debug.Log($"上传dir:{dir}");

            OssClient client = new OssClient(oss_endpoint, oss_accessKeyId, oss_accessKeySecret);
            // 上传文件
            var files = DirSearch(dir);
            foreach (string file in files) {
                var nameOnly = file.Replace(Packer.ReleaseOutputBaseDir, "").Replace("\\", "/");
                var resp = client.PutObject(oss_bucketName, $"{oss_prefix}/{versinoType}/{nameOnly}" , file);
                Debug.Log($"上传:{nameOnly} {resp.HttpStatusCode}");
            }
        }
        void BuildUI_OSS() {
            enableOSS = EditorGUILayout.Foldout(enableOSS, "阿里云OSS");
            if (!enableOSS) {
                return;
            }
            if (GUILayout.Button(new GUIContent("阿里云(正式版)"))) {
                if (EditorUtility.DisplayDialog("发布正式包", $"确认发布到阿里云{Packer.ReleaseOutputSubDir}", "确认发布", "取消发布")) {
                    uploadToAliyunOSS("release");
                }
            }

            if (GUILayout.Button(new GUIContent("阿里云(测试版)"))) {
                uploadToAliyunOSS("debug");
            }
            // 显示配置
            var lastEnableAliOSSConfig = enableOSSConfig;
            enableOSSConfig = EditorGUILayout.Foldout(enableOSSConfig, "配置");
            if (lastEnableAliOSSConfig != enableOSSConfig) {
                if (enableOSSConfig) {
                    oss_endpoint = EditorPrefs.GetString("ali_endpoint");
                    oss_accessKeyId = EditorPrefs.GetString("ali_accessKeyId");
                    oss_accessKeySecret = EditorPrefs.GetString("ali_accessKeySecret");
                    oss_bucketName = EditorPrefs.GetString("ali_bucketName");
                    oss_prefix = EditorPrefs.GetString("oss_prefix");
                } else {
                    EditorPrefs.SetString("ali_endpoint", oss_endpoint);
                    EditorPrefs.SetString("ali_accessKeyId", oss_accessKeyId);
                    EditorPrefs.SetString("ali_accessKeySecret", oss_accessKeySecret);
                    EditorPrefs.SetString("ali_bucketName", oss_bucketName);
                    EditorPrefs.SetString("oss_prefix", oss_prefix);
                }
            }
            if (enableOSSConfig) {
                oss_endpoint = EditorGUILayout.TextField("Endpoint: ", oss_endpoint);
                oss_accessKeyId = EditorGUILayout.TextField("Access Key Id: ", oss_accessKeyId);
                oss_accessKeySecret = EditorGUILayout.TextField("Access Key Secret: ", oss_accessKeySecret);
                oss_bucketName = EditorGUILayout.TextField("Bucket Name: ", oss_bucketName);
                oss_prefix = EditorGUILayout.TextField("File Prefix Path: ", oss_prefix);
            }

            EditorGUILayout.Space();
        }
#endif
        #endregion

        #region 腾讯云OSS
#if ENABLE_ALI_OSS
        private string cos_region = "";
        private string cos_host = "";
        private string cos_secretId = "";
        private string cos_secretKey = "";
        private string cos_bucketName = "";
        private string cos_prefix = "";
        private bool enableCOSConfig = false;
        private bool enableCOS;
        private object cos_lock = new object();
        private int cos_ok_count;
        private int cos_failed_count;
        private int cos_total_count;
        void cosPostUpload() {
            lock (cos_lock) {
                if (cos_failed_count + cos_ok_count < cos_total_count) {
                    return;
                }
            }
            Run(() => { 
                EditorUtility.DisplayDialog("提示", $"发布结束,成功{cos_ok_count} 失败:{cos_failed_count}", "确认");
            });
        }
        void doUploadCOS(CosXml cosXml, string localFile, string removePath) {
            TransferConfig transferConfig = new TransferConfig();
            TransferManager transferManager = new TransferManager(cosXml, transferConfig);
            COSXMLUploadTask uploadTask = new COSXMLUploadTask(cos_bucketName, removePath);
            uploadTask.SetSrcPath(localFile);
            uploadTask.progressCallback = delegate (long completed, long total) {
                //Debug.Log($"{removePath} progress = {completed * 100.0 / total}");
            };
            uploadTask.successCallback = delegate (CosResult cosResult) {
                COSXMLUploadTask.UploadTaskResult result = cosResult
                  as COSXMLUploadTask.UploadTaskResult;
                //Debug.Log(result.GetResultInfo());
                //string eTag = result.eTag;
                lock (cos_lock) {
                    cos_ok_count++;
                }
                cosPostUpload();
                Debug.Log($"上传状态: {removePath} {result.GetResultInfo()} ");
            };
            uploadTask.failCallback = delegate (CosClientException clientEx, CosServerException serverEx) {
                lock (cos_lock) {
                    cos_failed_count++;
                }
                cosPostUpload();
                if (clientEx != null) {
                    Debug.LogError("CosClientException: " + clientEx);
                }
                if (serverEx != null) {
                    Debug.LogError("CosServerException: " + serverEx.GetInfo());
                }
            };
            transferManager.Upload(uploadTask);
        }
        void uploadToCOS(string versinoType) {
            if (string.IsNullOrEmpty(cos_region) ||
                string.IsNullOrEmpty(cos_secretId) ||
                string.IsNullOrEmpty(cos_host) ||
                string.IsNullOrEmpty(cos_secretKey) ||
                string.IsNullOrEmpty(cos_prefix) ||
                string.IsNullOrEmpty(cos_bucketName)) {
                EditorUtility.DisplayDialog("警告", $"配置信息丢失", "确认");
                return;
            }
            var dir = Packer.ReleaseOutputDir;
            Debug.Log($"上传dir:{dir}");
            
            CosXmlConfig config = new CosXmlConfig.Builder()
              .IsHttps(true)  //设置默认 HTTPS 请求
              .setHost(cos_host)
              .SetRegion(cos_region)  //设置一个默认的存储桶地域
              .SetDebugLog(true)  //显示日志
              .Build();  //创建 CosXmlConfig 对象
            long durationSecond = 600;  //每次请求签名有效时长，单位为秒

            QCloudCredentialProvider cosCredentialProvider = new DefaultQCloudCredentialProvider(
              cos_secretId, cos_secretKey, durationSecond);
            CosXml cosXml = new CosXmlServer(config, cosCredentialProvider);

            // 上传文件
            var files = DirSearch(dir);
            lock (cos_lock) {
                cos_total_count = files.Count;
                cos_ok_count = 0;
                cos_failed_count = 0;
            }
            foreach (string file in files) {
                var nameOnly = file.Replace(Packer.ReleaseOutputBaseDir, "").Replace("\\", "/");
                doUploadCOS(cosXml, file, $"{cos_prefix}/{versinoType}/{nameOnly}");
            }
            
            
        }
        void BuildUI_COS() {
            enableCOS = EditorGUILayout.Foldout(enableCOS, "腾讯云COS");
            if (!enableCOS) {
                return;
            }

            if (GUILayout.Button(new GUIContent("腾讯云(正式版)"))) {
                if (EditorUtility.DisplayDialog("发布正式包", $"确认发布到腾讯云{Packer.ReleaseOutputSubDir}", "确认发布", "取消发布")) {
                    uploadToCOS("release");
                }
            }

            if (GUILayout.Button(new GUIContent("腾讯云(测试版)"))) {
                uploadToCOS("debug");
            }
            // 显示配置
            var lastEnableOSSConfig = enableCOSConfig;
            enableCOSConfig = EditorGUILayout.Foldout(enableCOSConfig, "配置");
            if (lastEnableOSSConfig != enableCOSConfig) {
                if (enableCOSConfig) {
                    cos_region = EditorPrefs.GetString("cos_region");
                    cos_host = EditorPrefs.GetString("cos_host");
                    cos_secretId = EditorPrefs.GetString("cos_secretId");
                    cos_secretKey = EditorPrefs.GetString("cos_secretKey");
                    cos_bucketName = EditorPrefs.GetString("cos_bucketName");
                    cos_prefix = EditorPrefs.GetString("cos_prefix");
                } else {
                    EditorPrefs.SetString("cos_region", cos_region);
                    EditorPrefs.SetString("cos_host", cos_host);
                    EditorPrefs.SetString("cos_secretId", cos_secretId);
                    EditorPrefs.SetString("cos_secretKey", cos_secretKey);
                    EditorPrefs.SetString("cos_bucketName", cos_bucketName);
                    EditorPrefs.SetString("cos_prefix", cos_prefix);
                }
            }
            if (enableCOSConfig) {
                cos_region = EditorGUILayout.TextField("Region: ", cos_region);
                cos_host = EditorGUILayout.TextField("Host: ", cos_host);
                cos_secretId = EditorGUILayout.TextField("Secret Id: ", cos_secretId);
                cos_secretKey = EditorGUILayout.TextField("Secret Key: ", cos_secretKey);
                cos_bucketName = EditorGUILayout.TextField("Bucket Name: ", cos_bucketName);
                cos_prefix = EditorGUILayout.TextField("File Prefix Path: ", cos_prefix);
            }
            
            EditorGUILayout.Space();
        }
#endif
        #endregion
        #region Utils
        private static List<string> DirSearch( string sDir ) {
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
        void GuiLine(int i_height = 3) {
            EditorGUILayout.Space();
            Rect rect = EditorGUILayout.GetControlRect(false, i_height);
            rect.height = i_height;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }
        #endregion
    }

}