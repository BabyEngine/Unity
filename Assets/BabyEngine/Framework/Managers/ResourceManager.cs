using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.Linq;
using UObject = UnityEngine.Object;
using System.IO;
using UnityEngine.UI;
#if UNITY_2017_1_OR_NEWER
using UnityEngine.U2D;
using System.Security.Cryptography;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BabyEngine {
    [CSharpCallLua]
    public class ResourceManager : IManager {
        private Dictionary<string, AssetBundle> loadedAssetBundles = new Dictionary<string, AssetBundle>();
        static string StringMD5( string str ) {
            using (var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(str.GetUTF8Bytes());
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
        private T AssetBundleLoad<T>(string path) where T : UObject {
            try {
                path = path.ToLower();
                if (path.StartsWith("assets/")) {
                    path = path.Substring(7);
                }
                string abPath = StringMD5(path);
                string fileName = path.Substring(path.LastIndexOf('/') + 1);
                //GetABPath(path, out abPath, out fileName);
                if(!loadedAssetBundles.ContainsKey(abPath)) {
                    // 加载文件
                    LoadDependencies(abPath);
                }

                AssetBundle assetBundle = null;
                if (!loadedAssetBundles.TryGetValue(abPath, out assetBundle)) {
                    return null;
                }
                return assetBundle.LoadAsset<T>(fileName);
            } catch (Exception e) {
                Debug.Log("AssetBundleLoad Error:" + e.ToString() + "\n" + path);
            }
            return null;
        }
        private AssetBundleManifest manifest = null;
        private AssetBundle manifestAssetBundle = null;

        private void LoadDependencies( string abPath ) {
            if (manifest == null) {
                string abManifest = $"{Application.persistentDataPath}/assets/" + StringMD5("manifest");
                if (File.Exists(abManifest)) {
                    if (manifestAssetBundle == null) {
                        manifestAssetBundle = AssetBundleLoader.LoadFromFile(abManifest);
                    }
                    manifest = manifestAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                } else {
                    Debug.Log("依赖文件不存在");
                }
            }
            if (manifest == null) {
                Debug.LogError("manifest not loaded");
                return;
            }

            var deps = manifest.GetAllDependencies($"{abPath}");
            foreach (var dep in deps) {
                Debug.Log($"依赖项: {dep}");
                LoadAB($"{Application.persistentDataPath}/assets/{dep}");
            }
            LoadAB($"{Application.persistentDataPath}/assets/{abPath}");
        }

        private void LoadAB( string path ) {
            string abPath = path;
            if (loadedAssetBundles.ContainsKey(abPath)) {
                return;
            }
            if (File.Exists(abPath)) {
                var assetBundle = AssetBundleLoader.LoadFromFile(abPath);
                if (assetBundle != null) {
                    string key = abPath;

                    key = key.Replace($"{Application.persistentDataPath}/assets/", "");
                    //key = key.RemoveSuffix(GameConf.AB_EXT);

                    loadedAssetBundles[key] = assetBundle;
                }
            } else {
                Debug.LogWarning($"文件不存在:{abPath}");
            }
        }
        private T LoadObject<T>( string path ) where T : UObject {
            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.WindowsEditor) {
                var obj = EditorLoad<T>(path);
                if (obj != null) {
                    return obj;
                }
#if UNITY_EDITOR
                return null;
#endif
            }
            return AssetBundleLoad<T>(path);
        }
#if UNITY_EDITOR
        private T EditorLoad<T>( string path ) where T : UObject {
            if (string.IsNullOrEmpty(path)) {
                return null;
            }
            if (!path.StartsWith("Assets/")) {
                path = "Assets/" + path;
            }
            string[] exts = {
                // images
                ".png", ".bmp", "gif", ".psd", ".tif", ".tga", ".jpg",
                // audios
                ".mp3", ".ogg", ".wav", ".aif", ".xm", ".mod", ".it", ".s3m",
                // 3d
                ".fbx", ".obj", ".dae", ".3ds", ".dxf",
                // misc
                ".prefab", ".asset",
                // animation
                ".anim", ".controller",
                //字体
                ".ttf", ".spriteatlas"
            };
            T obj = null;
            foreach (var ext in exts) {
                var fullpath = path + ext;
                obj = AssetDatabase.LoadAssetAtPath<T>(fullpath);
                if (obj != null) { break; }
            }
            return obj;
        }
#else
    private T EditorLoad<T>(string path) where T : UObject { return null; }
#endif

        #region APIs
        public void LoadTexture( string path, LuaFunction func ) {
            func.Call(LoadObject<Texture>(path));
        }
        public void LoadTexture2D( string path, LuaFunction func ) {
            func.Call(LoadObject<Texture2D>(path));
        }
        public void LoadTexture3D( string path, LuaFunction func ) {
            func.Call(LoadObject<Texture3D>(path));
        }
        public void LoadSprite( string path, LuaFunction func ) {
            func.Call(LoadObject<Sprite>(path));
        }
        public void LoadAudioClip( string path, LuaFunction func ) {
            func.Call(LoadObject<AudioClip>(path));
        }
        public void LoadObject( string path, LuaFunction func ) {
            func.Call(LoadObject<UObject>(path));
        }
        public void LoadNetworkImage( string url, LuaFunction func ) {
            CacheableDownloadHandler.GetTexture2D(url, CacheOption.kCacheTemporary, ( code, header, tx ) => {
                if (code == 200 || code == 304) {
                    if (tx != null) {
                        func.Call(tx.ToSprite());
                        return;
                    }
                }
                func.Call();
            }).Run(this);
        }
#if UNITY_2017_1_OR_NEWER
        public void LoadSpriteAtlas( string path, LuaFunction func ) {
            func.Call(LoadObject<SpriteAtlas>(path));
        }
#endif
        #endregion
    }
}