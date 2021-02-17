using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
[XLua.LuaCallCSharp]
public class LogOutputHandler : MonoBehaviour {
    public LogType logType;
    public string project = "my project";
    public string serviceAddress = "http://localhost:8080";
    public string[] extendKeys;
    private Stack<string> logs = new Stack<string>();
    private bool isSending = false;
    
    public void OnEnable() {
        Debug.Log("LogOutputHandler start");
        Application.logMessageReceived += HandleLog;
    }
    public void OnDisable() {
        Application.logMessageReceived -= HandleLog;
        Debug.Log("LogOutputHandler stop");
    }
    
    public void HandleLog(string logString, string stackTrace, LogType type) {
        if (type > logType) {
            return;
        }
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("ts={0}", UnityWebRequest.EscapeURL(System.DateTime.Now.ToString()));
        sb.AppendFormat("&l={0}", UnityWebRequest.EscapeURL(type.ToString()));
        sb.AppendFormat("&m={0}", UnityWebRequest.EscapeURL(logString));
        sb.AppendFormat("&t={0}", UnityWebRequest.EscapeURL(stackTrace));
        sb.AppendFormat("&d={0}", UnityWebRequest.EscapeURL( SystemInfo.operatingSystem +"," +SystemInfo.deviceName +","+ SystemInfo.deviceUniqueIdentifier));
        foreach(var key in extendKeys) {
            var val = PlayerPrefs.GetString(key);
            if (!string.IsNullOrWhiteSpace(val)) {
                sb.AppendFormat("&{0}={1}", UnityWebRequest.EscapeURL(key), UnityWebRequest.EscapeURL(val));
            }
        }
        logs.Push(sb.ToString());
        tryPost();
    }

    void tryPost() {
        if (isSending) { return; }
        StartCoroutine(SendData());
    }

    public IEnumerator SendData() {
        while(true) {
            if (logs.Count == 0) {
                break;
            }
            string parameters = logs.Pop();
            string url = serviceAddress + "/log?p=" + project;
            var sendLog = UnityWebRequest.Post(url, parameters);
            yield return sendLog.SendWebRequest();
        }
        isSending = false;
    }
}