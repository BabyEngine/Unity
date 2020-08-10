using UnityEngine;
using System.Collections;
using XLua;
using System;

public class BackendLooperManager {
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
        if (UpdateFunc != null) {
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

    internal void Tick() {
        Update();
        FixedUpdate();
        LateUpdate();
        OnGUI();
    }
}
