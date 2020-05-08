using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.Linq;
using UObject=UnityEngine.Object;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BabyEngine {
    [CSharpCallLua]
    public class ResourceManager : MonoBehaviour {
        public static ResourceManager Instance;
        public static ResourceManager Get() {
            return Instance;
        }

        private Dictionary<string, AssetBundle> loadedAssetBundles = new Dictionary<string, AssetBundle>();

        private void Awake() {
            Instance = this;
        }

        private static void GetABPath(string path, out string abPath, out string fileName) {
            fileName = path.Substring(path.LastIndexOf('/') + 1);
            abPath = path.Substring(0, path.LastIndexOf('/'));
        }

        private T AssetBundleLoad<T>(string path) where T : UObject {
            try {
                path = path.ToLower();
                string abPath;
                string fileName;
                GetABPath(path, out abPath, out fileName);

                if(!loadedAssetBundles.ContainsKey(abPath)) {
                    // 加载文件
                    LoadDependencies(abPath);
                }
                AssetBundle assetBundle = null;
                if(!loadedAssetBundles.TryGetValue(abPath, out assetBundle)) {
                    return null;
                }
                //foreach (var name in assetBundle.GetAllAssetNames()) {
                //    Debug.Log(name);
                //}
                //Debug.Log($"path: {path} => subpath: {abPath} fileName: {fileName}");
                return assetBundle.LoadAsset<T>(fileName);
            } catch(Exception e) {
                Debug.Log($"AssetBundleLoad Error:{e}");
            }
            return null;
        }
        private AssetBundleManifest manifest = null;
        private AssetBundle manifestAssetBundle = null;
        private void LoadDependencies(string abPath) {
            if (manifest == null) {
                string abManifest = $"{Application.persistentDataPath}/assets/{GameConf.PlatformName}/manifest{GameConf.AB_EXT}";
                if (File.Exists(abManifest)) {
                    if (manifestAssetBundle == null) {
                        manifestAssetBundle = AssetBundleLoader.LoadFromFile(abManifest);
                    }
                    manifest = manifestAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                }
            }
            if (manifest == null) {
                Debug.LogError("manifest not loaded");
                return;
            } 

            var deps = manifest.GetAllDependencies($"{GameConf.PlatformName}/{abPath}{GameConf.AB_EXT}");
            foreach(var dep in deps) {
                //Debug.Log($"依赖项: {dep}");
                LoadAB($"{Application.persistentDataPath}/assets/{dep}");
            }
            LoadAB($"{Application.persistentDataPath}/assets/{GameConf.PlatformName}/{abPath}{GameConf.AB_EXT}");
            //foreach (var kv in loadedAssetBundles) {
            //    Debug.Log($"已经加载的ab: {kv.Key}");
            //}
        }

        private void LoadAB(string path) {
            string abPath = path;
            if (!abPath.EndsWith(GameConf.AB_EXT)) {
                abPath += GameConf.AB_EXT;
            }
            if (loadedAssetBundles.ContainsKey(abPath)) {
                return;
            }
            if (File.Exists(abPath)) {
                var assetBundle = AssetBundleLoader.LoadFromFile(abPath);
                if (assetBundle != null) {
                    string key = abPath;

                    key = key.Replace($"{Application.persistentDataPath}/assets/{GameConf.PlatformName}/", "");
                    key = key.RemoveSuffix(GameConf.AB_EXT);

                    loadedAssetBundles[key] = assetBundle;
                }
            } else {
                Debug.LogWarning($"文件不存在:{abPath}");
            }
        }
    
        public void LoadTexture(string path, LuaFunction func) {
            func?.Call(LoadObject<Texture2D>(path));
        }

        public void LoadSprite(string path, LuaFunction func) {
            func?.Call(LoadObject<Sprite>(path));
        }

        private T LoadObject<T>(string path) where T : UObject {
#if UNITY_EDITORx
            return Resources.Load<T>(path); 
#else
            return AssetBundleLoad<T>(path);
#endif
        }

        public void LoadObject(string path, LuaFunction func) {
            path =$"Assets/{path}";
#if UNITY_EDITOR
            string[] exts = {
                // images
                ".png", ".bmp", "gif", ".psd", ".tif", ".tga", ".jpg",
                // audios
                ".mp3", ".ogg", ".wav", ".aif", ".xm", ".mod", ".it", ".s3m",
                // 3d
                ".fbx", ".obj", ".dae", ".3ds", ".dxf",
                // misc
                ".prefab", ".asset"
            };
            UObject obj = null;
            foreach (var ext in exts) {
                var fullpath = $"{path}{ext}";
                obj = AssetDatabase.LoadAssetAtPath<UObject>(fullpath);
                if (obj != null) { break; }
            }
            
            func?.Call(obj);
            return;
#else
            func?.Call(AssetBundleLoad<UObject>(path));
#endif
        }
    }
}