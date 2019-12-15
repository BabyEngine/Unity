using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BabyEngine {
    public class EditorHelper {
        const string luaTemplate = "";

        [MenuItem("Tools/缓存/清空缓存")]
        public static void DeleteAllPlayerPrefs() {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Assets/Create/new.lua")]
        public static void NewLuaFile() {
            NewFile(".lua", luaTemplate);
        }

        [MenuItem("Tools/截图")]
        public static void CaptureScreen() {
            UnityEngine.ScreenCapture.CaptureScreenshot("截图-" + DateTime.Now + ".png");
        }

        public static void NewFile(string ext, string template) {
            UnityEngine.Object selected = Selection.activeObject;
            if (selected == null || selected.name.Length <= 0) {
                Debug.Log("Selected object not Valid");
                return;
            }

            // remove whitespace and minus
            string name = selected.name.Replace(" ", "_");
            name = name.Replace("-", "_");
            var path = AssetDatabase.GetAssetPath(selected);
            string copyPath = path + "/" + name + ext;
            int idx = 1;
            do {
                if (!File.Exists(copyPath)) {
                    break;
                }
                copyPath = path + "/" + name + (idx++) + ext;
            } while (true);


            if (File.Exists(copyPath) == false) { // do not overwrite
                using (StreamWriter outfile =
                    new StreamWriter(copyPath)) {
                    outfile.WriteLine(template);
                }//File written
            }
            AssetDatabase.Refresh();
            //selected.AddComponent(Type.GetType(name));
        }
    }
}