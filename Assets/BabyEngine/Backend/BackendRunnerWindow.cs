using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using XLua;
using System.Timers;

namespace BabyEngine {
    public class BackendRunnerWindow : EditorWindow {
        private LuaEnv lua = new LuaEnv();
        bool isRunning;
        Timer timer = new Timer();
        BackendLooperManager looper = new BackendLooperManager();
        private string searchPath = "Game/Example/lua/";
        private string entryFile = "ConsoleMain";
        private string timerInterval = "1000";
        [MenuItem("Tools/打开后端模拟面板")]
        public static void Init() {
            BackendRunnerWindow window = (BackendRunnerWindow)EditorWindow.GetWindow(typeof(BackendRunnerWindow));
            window.titleContent = new GUIContent("后端模拟");
            window.Show();
        }
        void OnGUI() {
            searchPath = GUILayout.TextField(searchPath);
            entryFile = GUILayout.TextField(entryFile);
            timerInterval = GUILayout.TextField(timerInterval);

            if (GUILayout.Button(new GUIContent(GetStateName()))) {
                StartOrStop();
            }

        }
        string GetStateName() {
            if (isRunning) {
                return "Stop";
            } else {
                return "Start";
            }
        }

        void StartOrStop() {
            isRunning = !isRunning;
            if (isRunning) { // 启动lua
                lua = new LuaEnv();
                // load pb
                lua.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPB);
                lua.AddLoader(Loader.Create());
                GameConf.CustomLuaGame = searchPath;
                if (!string.IsNullOrEmpty(searchPath)) {
                    lua.DoString(string.Format("package.path=package.path .. ';{0}?.lua;' ", searchPath));
                }

                lua.Global.Set("LooperManager", looper);

                lua.DoString("BabyEngine = BabyEngine or {}\nrequire('framework.init')");

                lua.DoString(string.Format("require('{0}')", entryFile));
                int interval;
                if (!int.TryParse(timerInterval, out interval)) {
                    interval = 1000;
                }
                timer.Interval = interval;
                timer.Elapsed += OnTick;
                timer.Start();

            } else { // 停止lua 
                lua.Tick();
                lua.GC();
                lua.Dispose();
                lua = null;
                timer.Elapsed -= OnTick;
                timer.Close();
            }
        }

        void OnTick(object sender, ElapsedEventArgs e) {
            looper.Tick();
        }
    }

}
