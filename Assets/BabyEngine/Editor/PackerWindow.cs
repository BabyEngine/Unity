using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace BabyEngine {
    public class PackerWindow : EditorWindow {
        
        string[] platformOptions = new string[] {
            "Android", "iOS", "Windows", "macOS"
        };
        string platformOption = "Android";
        string[] subGames = new string[0];
        string subGame;
        int versionNumber = 1;
        bool enableLUAC = true;

        const string KEY_LAST_VERSION = "packer.lastVersion";
        const string KEY_LAST_GAMENAME = "packer.lastGame";
        [MenuItem("Tools/打开打包面板")]
        public static void Init() {
            PackerWindow window = (PackerWindow)EditorWindow.GetWindow(typeof(PackerWindow));
            window.titleContent = new GUIContent("打包器");
            window.versionNumber = EditorPrefs.GetInt(KEY_LAST_VERSION, 1); // 上次打包的版本
            window.subGame = EditorPrefs.GetString(KEY_LAST_GAMENAME); // 上一次打包的游戏
            window.Show();
        }
        void ReloadSubGameInfo () {
            var dirs = Directory.GetDirectories(Path.Combine(Application.dataPath, "Game"));
            List<string> list = new List<string>();
            foreach(var d in dirs) {
                list.Add(new DirectoryInfo(d).Name);
            }
            subGames = list.ToArray();
        }
        void OnGUI() {
            #region 支持的子游戏
            if (subGames.Length == 0) {
                ReloadSubGameInfo();
            }
            if (GUILayout.Button(new GUIContent("刷新游戏信息"))) {
                ReloadSubGameInfo();
            }
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("游戏:");
            if (EditorGUILayout.DropdownButton(new GUIContent(subGame), FocusType.Keyboard)) {
                GenericMenu menu = new GenericMenu();
                foreach (var item in subGames) {
                    menu.AddItem(new GUIContent(item), subGames.Equals(item), OnValueSelected_Game, item);
                    
                }
                menu.ShowAsContext();//显示菜单
            }
            EditorGUILayout.EndHorizontal();
            #endregion

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

            #region 版本号
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("版本号:");
            this.versionNumber = EditorGUILayout.IntField(this.versionNumber);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region luac
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("luac:");
            this.enableLUAC = EditorGUILayout.Toggle(this.enableLUAC);
            EditorGUILayout.EndHorizontal();
            #endregion

            #region 触发打包
            if (GUILayout.Button(new GUIContent("打包"))) {
                DoPack();
            }
            #endregion
        }
        void OnValueSelected_Platform(object p) {
            platformOption = p.ToString();
        }
        void OnValueSelected_Game(object p) {
            subGame = p.ToString();
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
            EditorPrefs.SetInt(KEY_LAST_VERSION, versionNumber);
            EditorPrefs.GetString(KEY_LAST_GAMENAME, subGame);
            Packer.BuildAll(target, subGame, versionNumber, enableLUAC);
        }
    }
}
