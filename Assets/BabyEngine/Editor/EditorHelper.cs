using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace BabyEngine {
    public class EditorHelper {
        const string luaTemplate = "";

        [MenuItem("Tools/PlayerPrefs/DeleteAll")]
        public static void DeleteAllPlayerPrefs() {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Tools/截图")]
        public static void CaptureScreen() {
            var path = "截图-" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_FFF") + ".png";
            Debug.Log(path);
            ScreenCapture.CaptureScreenshot(path);
        }
        #region create lua file
        [MenuItem("Assets/Create/new.lua")]
        public static void NewLuaFile() {
            NewFile(".lua", luaTemplate);
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
        #endregion
        #region Tools
        /// <summary>
        /// Copy selection gameObject in hierarchy 
        /// </summary>
        [MenuItem("GameObject/Tools/Copy Full Path", false, 10)]
        static void CopyFullPathInHierarchy() {
            var gos = Selection.gameObjects;
            
            if (gos != null && gos.Length > 0) {
                Transform tra = gos[0].transform;
                string path = "";
                while (tra != null) {
                    if (tra.parent != null) {
                        path += tra.name + "|";
                    } else {
                        path += tra.name;
                    }
                    tra = tra.parent;
                }
                List<string> list = new List<string>();
                list.AddRange(path.Split('|'));
                list.Reverse();
                path = string.Join("/", list.ToArray());

                TextEditor te = new TextEditor();
                te.text = path;
                te.SelectAll();
                te.Copy();
            }
        }
        #endregion


        [MenuItem("GameObject/BabyEngine/C-数字重命名子节点", priority = -99)]
        public static void RenameChildByNumber() {
            if (Selection.gameObjects.Length == 0) {
                return;
            }
            Transform t = Selection.gameObjects[0].transform;
            int idx = 1;
            foreach (Transform tra in t) {
                tra.name = (idx++).ToString();
            }
            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            if (prefabStage != null) {
                EditorSceneManager.MarkSceneDirty(prefabStage.scene);
            }
        }

        [MenuItem("GameObject/BabyEngine/D-复制子节点节点位置", priority = -98)]
        public static void CopySelectionObjectPosition() {
            if (Selection.gameObjects.Length == 0) {
                return;
            }
            var transform = Selection.gameObjects[0].transform;
            StringBuilder sb = new StringBuilder();
            foreach (Transform tra in transform) {
                var pos = tra.position;
                sb.AppendFormat("{{ {0}, {1}, {2} }},", pos.x, pos.y, pos.z);
            }
            TextEditor te = new TextEditor();
            te.text = sb.ToString();
            te.SelectAll();
            te.Copy();
        }
    }
}