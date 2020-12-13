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
    public class LooperManager : IManager {
        object mLock = new object();
        public LuaFunction OnGUIFunc;
        public LuaFunction UpdateFunc;
        public LuaFunction FixedUpdateFunc;
        public LuaFunction LateUpdateFunc;
        private List<Action> actions = new List<Action>();
        private void OnGUI() {
            if (OnGUIFunc != null) {
                OnGUIFunc.Call();
            }
        }
        private void Update() {
            if(UpdateFunc != null) {
                UpdateFunc.Call();
            }
            List<Action> runningActions = new List<Action>();
            lock(mLock) {
                runningActions.AddRange(actions);
                actions.Clear();
            }

            foreach(var act in runningActions) {
                try {
                    act?.Invoke();
                }catch(Exception e) {
                    Debug.LogError(e);
                }
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

        public void RunOnMainThread(Action act) {
            lock (mLock) {
                actions.Add(act);
            }
        }
        public void RunCoroutineOnMainThread(object obj) {
            IEnumerator co = obj as IEnumerator;
            if (co == null) { return; }
            lock (mLock) {
                actions.Add(()=> {
                    StartCoroutine(co);
                });
            }
        }
    }
}