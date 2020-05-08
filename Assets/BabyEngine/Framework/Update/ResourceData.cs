using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BabyEngine {
    public class ResourceData {
        public string ActionName = string.Empty;
        public int Status = 0;
        public string Hash;
        public long Size;
        public string Path;
        public string Platform;
        public AssetBundle assetBundle;

        public static ResourceData NewResourceData(string actionName, string[] args) {
            ResourceData result = null;
            if (actionName == "lua") {
                if (args.Length != 3) {
                    Debug.LogWarning($"lua format erorr({args.Length})" + string.Join("|", args));
                    return null;
                }
                result = new ResourceData();
                result.ActionName = actionName;
                result.Hash = args[0];
                long.TryParse(args[1], out result.Size);
                result.Path = args[2];
            } else if (actionName == "res") {
                if (args.Length != 4) {
                    Debug.LogWarning($"res format erorr({args.Length})" + string.Join("|", args));
                    return null;
                }
                result = new ResourceData();
                result.ActionName = actionName;
                result.Hash = args[0];
                long.TryParse(args[1], out result.Size);
                result.Path = args[2];
                result.Platform = args[3];
                string curPlatform = GameConf.PlatformName;

                if (!curPlatform.Equals(result.Platform)) {
                    Debug.Log(result.Platform);
                    Debug.Log(curPlatform);
                    return null;
                }
            } else if (actionName == "dep") {
                if (args.Length != 4) {
                    Debug.LogWarning($"lua format erorr({args.Length})" + string.Join("|", args));
                    return null;
                }
                result = new ResourceData();
                result.ActionName = actionName;
                result.Hash = args[0];
                long.TryParse(args[1], out result.Size);
                result.Path = args[2];
            }
            return result;
        }
        private ResourceData() {}

        public UnityWebRequest Download(string baseURL) {
            Debug.Log($"开始下载{Path}");
            return UnityWebRequest.Get($"{baseURL}/{Path}");
        }

        private void installLua() {
            try {
                var names = assetBundle.GetAllAssetNames();
                foreach (var name in names) {
                    var ta = assetBundle.LoadAsset<TextAsset>(name);
                    // 替换前缀
                    var lsf = LuaSourceFile.FromJson(ta.text);
                    if (lsf != null) {
                        var outPath = System.IO.Path.Combine(Application.persistentDataPath + "/scripts/", lsf.OutFile);
                        var dir = System.IO.Path.GetDirectoryName(outPath);
                        Directory.CreateDirectory(dir);
                        File.WriteAllText(outPath, lsf.code);
                        //Debug.Log($"install {outPath}");
                    }
                }
            } catch (Exception e) {
                Debug.LogError(e);
            } finally {
                assetBundle.Unload(false);
            }
        }

        private void listRes() {
            try {
                var names = assetBundle.GetAllAssetNames();
                foreach (var name in names) {
                    //Debug.Log(name);
                }
            } catch (Exception e) {
                Debug.LogError(e);
            }
        }

        public void Install() {
            if (assetBundle == null) {
                return;
            }
            switch (ActionName) {
                case "lua":
                    installLua();
                    break;
                case "res":
                    listRes();
                    break;
            }
        }

        public override string ToString() {
            return $"action:{ActionName}";
        }

        public void Save(byte[] data) {
            try {
                // 写文件
                string filepath = Application.persistentDataPath + "/assets/" + this.Path;
                var dir = System.IO.Path.GetDirectoryName(filepath);
                if (!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);
                }
                File.WriteAllBytes(filepath, data);

                if (this.ActionName.Equals("lua") || this.ActionName.Equals("res")) {
                    var key = filepath;
                    //var key = filepath.Replace(Application.persistentDataPath + $"/assets/{GameConf.PlatformName}/", "");
                    this.assetBundle = AssetBundleLoader.LoadFromMemory(key, data);
                }
            }catch(Exception e) {
                Debug.LogError(e);
            }
        }
    }
}
