using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.Linq;
using UObject = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BabyEngine {
    public class LooperManager : MonoBehaviour {
        public static LooperManager Instance;
        public static LooperManager Get() {
            return Instance;
        }

        private void Awake() {
            Instance = this;
        }
        public LuaFunction OnGUIFunc;
        public LuaFunction UpdateFunc;
        public LuaFunction FixedUpdateFunc;
        public LuaFunction LateUpdateFunc;

        private void OnGUI() {
            if (OnGUIFunc != null) {
                OnGUIFunc.Call();
            }
        }

        private void Update() {
            if(UpdateFunc != null) {
                UpdateFunc.Call();
            }
        }

        private void FixedUpdate() {
            if (FixedUpdateFunc != null) {
                FixedUpdateFunc.Call();
            }
        }
        private void LateUpdate() {
            if (LateUpdateFunc != null) {
                LateUpdateFunc.Call();
            }
        }
    }
}