using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace BabyEngine {
    public class GameApp : MonoBehaviour {
#if UNITY_EDITOR
        public int lastTab = 0;
#endif
        #region VARS
        public string MainGameApp;
        public string CustomSearchPath;
        public TextAsset textAsset;
        #endregion
        private LuaEnv lua = new LuaEnv();

        public LuaFunction onLowMemory;
        public LuaFunction onApplicationFocus;
        public LuaFunction onApplicationPause;
        public LuaFunction onApplicationQuit;

        private void Awake() {
            Application.targetFrameRate = 60;
            lua.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPB);
            lua.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
            lua.AddBuildin("lpeg", XLua.LuaDLL.Lua.LoadLPeg);
            lua.AddBuildin("ffi", XLua.LuaDLL.Lua.LoadFFI);
            lua.AddBuildin("serialize", XLua.LuaDLL.Lua.LoadSerialize);
            lua.AddBuildin("cmsgpack", XLua.LuaDLL.Lua.LoadCMSGPack);
            Application.lowMemory += OnLowMemory;

            StartCoroutine(runMoniter());
        }

        private IEnumerator runMoniter() {
            while (true) {
                lua.Tick();
                yield return new WaitForSeconds(1);
            }
        }

        bool isStart = false;
        private void Start() {
            PerfomLuaStart();
        }

        public void PerfomLuaStart() {
            if (isStart)
                return;
            isStart = true;
            InitLua();
            RunLua();
            //Invoke("RunLua", 0);
        } 
        private void InitManagers() {
            AddManager<ResourceManager>("ResourceManager");
            AddManager<LooperManager>("LooperManager");
            AddManager<NetworkManager>("NetworkManager");
        }
        Dictionary<string, IManager> managersMap = new Dictionary<string, IManager>();
        private void AddManager<T> (string name) where T : IManager {
            var comp = gameObject.AddComponent<T>();
            comp.getManagerHandler = this.GetManager;
            lua.Global.Set(name, comp);
            managersMap.Add(name, comp);
        }
        
        public IManager GetManager(string name) {
            if (managersMap.ContainsKey(name)) {
                return managersMap[name];
            }
            return null;
        }

        private void InitLua() {
            lua.AddLoader(Loader.Create());
            string luaCode;
            if (string.IsNullOrEmpty(CustomSearchPath)) {
                luaCode = @"package.path=package.path .. " + $"';{GameConf.LUA_BASE_PATH}?.lua;{Application.persistentDataPath}?.lua;{Application.streamingAssetsPath}?.lua;'";
            } else {
                GameConf.CustomLuaGame = CustomSearchPath;
                luaCode = $"package.path=package.path ..';{GameConf.LUA_BASE_PATH}?.lua;{CustomSearchPath}?.lua;{Application.persistentDataPath}?.lua;{Application.streamingAssetsPath}?.lua;'";
            }
            lua.Global.Set("GameApp", this);
            lua.DoString(luaCode);
            InitManagers();
        }

        private void RunLua() {
            if (textAsset != null) {
                lua.DoString(textAsset.text);
                return;
            }
            lua.DoString("require('framework.init')");
            lua.DoString($"local ok, ret = pcall(require, '{MainGameApp}')" +
                $"if not ok and GameApp then " +
                $"  GameApp:OnError(ret)" +
                $"end");
        }

        public void OnError(string err) {
            Debug.LogError("发生错误:" + err);
        }
        
        private void OnLowMemory() {
            Resources.UnloadUnusedAssets();
            onLowMemory?.Call();
        }

        void OnApplicationFocus(bool hasFocus) {
            onApplicationFocus?.Call(hasFocus);
        }

        void OnApplicationPause(bool pauseStatus) {
            onApplicationPause?.Call(pauseStatus);
        }
        void OnApplicationQuit() {
            try {
                onApplicationQuit?.Call();
            } finally {
                Resources.UnloadUnusedAssets();
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                if (lua != null) {
                    lua.Tick();
                    lua.FullGc();
                }
                lua = null;
            }
        }
    }
}
