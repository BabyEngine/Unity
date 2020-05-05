using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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

        public static void CopyDirectory(string source, string target) {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0) {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*")) {
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
    }
}
