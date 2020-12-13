using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BabyEngine {
    [CustomEditor(typeof(GameApp))]
    public class GameAppEditor : Editor {
        private GameApp gameApp { get { return target as GameApp; } }

        TabsBlock tabs;
        private void OnEnable() {
            tabs = new TabsBlock(new Dictionary<string, System.Action>() {
                { "editor", EditorTab },
                { "text asset", RunTextAsset },
                { "asset bundle", RunAssetBundle },
            });
            tabs.SetCurrentMethod(gameApp.lastTab);
        }
        public override void OnInspectorGUI() {
            //base.OnInspectorGUI();
            Undo.RecordObject(gameApp, "GAME_APP");
            tabs.Draw();
            if (GUI.changed) {
                gameApp.lastTab = tabs.curMethodIndex;
                EditorUtility.SetDirty(gameApp);
            }
        }
        private void EditorTab() {
            using (new VerticalBlock()) {
                using (new HorizontalBlock()) {
                    GUILayout.Label("�����", EditorStyles.boldLabel, GUILayout.Width(80f));
                    gameApp.MainGameApp = EditorGUILayout.TextField(gameApp.MainGameApp);
                }

                using (new HorizontalBlock()) {
                    GUILayout.Label("��Ŀ·��", EditorStyles.boldLabel, GUILayout.Width(80f));
                    gameApp.CustomSearchPath = EditorGUILayout.TextField(gameApp.CustomSearchPath);
                }
            }
        }

        private void RunTextAsset() {
            using (new HorizontalBlock()) {
                GUILayout.Label("��������", EditorStyles.boldLabel, GUILayout.Width(50f));
                gameApp.textAsset = (TextAsset)EditorGUILayout.ObjectField(gameApp.textAsset, typeof(TextAsset), true);
            }
        }

        private void RunAssetBundle() {
            using (new HorizontalBlock()) {
                GUILayout.Label("AB������", EditorStyles.boldLabel, GUILayout.Width(100f));
                gameApp.MainGameApp = EditorGUILayout.TextField(gameApp.MainGameApp);

            }
        }
    }


}