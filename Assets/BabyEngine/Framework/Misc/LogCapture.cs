using UnityEngine;
using XLua;
[LuaCallCSharp]
public class LogCapture : MonoBehaviour {
    public LuaFunction logHandler;
    private void Awake() {
        Application.logMessageReceived += logMessageReceived;
    }

    private void logMessageReceived( string condition, string stackTrace, LogType type ) {
        logHandler?.Call(condition, stackTrace, type);
    }

    private void OnDestroy() {
        Application.logMessageReceived -= logMessageReceived;
    }
}
