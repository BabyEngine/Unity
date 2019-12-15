using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.Linq;
using UObject=UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BabyEngine {
    public class ResourceManager : MonoBehaviour {
        public static ResourceManager Instance;
        public static ResourceManager Get() {
            return Instance;
        }

        private void Awake() {
            Instance = this;
        }

        public void LoadTexture(string path, LuaFunction func) {
            var tx = Resources.Load<Texture2D>(path); 
            func?.Call(tx);
        }

        public void LoadSprite(string path, LuaFunction func) {
            var tx = Resources.Load<Sprite>(path);
            func?.Call(tx);
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
#endif
        }
    }
}