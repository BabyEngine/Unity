using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BabyEngine {
    [XLua.LuaCallCSharp]
    public static class Utility {
        public static Sprite TextureToSprite(Texture texture) {
            return Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        public static Sprite ToSprite(this Texture2D texture) {
            if (texture == null) { return null; }
            return TextureToSprite(texture);
        }

        public static void CopyDirectory(string source, string target, string[] ignoreFileExt = null) {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0) {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*")) {
                    bool isIgnoreFile = false;
                    if (ignoreFileExt != null) {
                        foreach(var ext in ignoreFileExt) {
                            if(file.EndsWith(ext)) {
                                isIgnoreFile = true;
                                break;
                            }
                        }
                    }
                    
                    if (isIgnoreFile) {
                        continue;
                    }
                    File.Copy(file, Path.Combine(folders.Target, Path.GetFileName(file)), true);
                }

                foreach (var folder in Directory.GetDirectories(folders.Source)) {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
        }

        public class Folders {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target) {
                Source = source;
                Target = target;
            }
        }

        public static GameObject FindGameObject(string search) {
            var scene = SceneManager.GetActiveScene();
            var sceneRoots = scene.GetRootGameObjects();
            List<string> paths = new List<string>(search.Split('/'));
            
            foreach (var root in sceneRoots) {
                if (paths.Count == 0) {
                    break;
                }
                var currentName = paths[0];
                if (root.name.Equals(currentName)) {
                    if (paths.Count == 1) {
                        // fully match
                        return root.gameObject;
                    }
                    // match
                    paths.RemoveAt(0);
                    return FindNextNode(root, paths);
                }
                
            }

            return null;
        }

        static GameObject FindNextNode(GameObject obj, List<string> paths) {
            foreach (Transform child in obj.transform) {
                var name = paths[0];
                if (child.name.Equals(name)) {
                    if (paths.Count == 1) {
                        return child.gameObject;
                    }
                    paths.RemoveAt(0);
                    return FindNextNode(child.gameObject, paths);
                    
                }
            }
            return null;
        }

        #region 剪切板
        public static void PasteBoardWrite( string str ) {
            GUIUtility.systemCopyBuffer = str;
        }

        public static string PasteBoardRead() {
            return GUIUtility.systemCopyBuffer;
        }
        #endregion

        #region Hash
        public static string StringMD5(string str) {
            return ByteMD5(System.Text.Encoding.UTF8.GetBytes(str));
        }

        public static string ByteMD5(byte[] data) {
            using (var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(data);
                string md5Hash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                return md5Hash;
            }
        }
        public static string FileMD5( string filepath ) {
            using (var md5 = MD5.Create()) {
                using (var stream = File.OpenRead(filepath)) {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        #endregion

        
    }
}
