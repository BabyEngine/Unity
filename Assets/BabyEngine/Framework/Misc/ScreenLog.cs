using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A console to display Unity's debug logs in-game.
/// </summary>
public class ScreenLog : MonoBehaviour {
    struct Log {
        public string message;
        public string stackTrace;
        public LogType type;
    }
    public int FontSize = 20;
    private GUIStyle textStyle = null;
    public int MaxLog = 300;
    public bool EnableKeyToggle;
    /// <summary>
    /// The hotkey to show and hide the console window.
    /// </summary>
    public KeyCode toggleKey = KeyCode.BackQuote;

    List<Log> logs = new List<Log>();
    Vector2 scrollPosition;
    public bool show;
    bool collapse;
    bool oneLineLog=true;

    public bool ShowOnGUIButton;
    
    // Visual elements:

    static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>()
    {
        { LogType.Assert, Color.white },
        { LogType.Error, Color.red },
        { LogType.Exception, Color.red },
        { LogType.Log, Color.white },
        { LogType.Warning, Color.yellow },
    };

    const int margin = 20;

    Rect windowRect = new Rect(margin, margin, Screen.width - (margin * 2), Screen.height - (margin * 2));
    Rect titleBarRect = new Rect(0, 0, 10000, 20);
    GUIContent clearLabel = new GUIContent("Clear", "Clear the contents of the console.");
    GUIContent collapseLabel = new GUIContent("Collapse", "Hide repeated messages.");
    GUIContent oneLineLabel = new GUIContent("One", "Show One Line Log.");
    GUIContent closeLabel = new GUIContent("Close", "Close console.");

    void OnEnable() {
        //Application.RegisterLogCallback(HandleLog);
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable() {
        //Application.RegisterLogCallback(null);
        Application.logMessageReceived -= HandleLog;
    }

    void Update() {
        if (EnableKeyToggle) {
            if (Input.GetKeyDown(toggleKey)) {
                show = !show;
            }
        }
    }
    public int screenWidth = Screen.width;
    public int screenHeight = Screen.height;
    void OnGUI() {
        //AutoResize(screenWidth, screenHeight);
        if (ShowOnGUIButton && !show) {
            string content = show ? "Hide Log" : "Show Log";
            var rect = new Rect(10, 10, 100, 20);
            if (GUI.Button(rect, content)) { // onclicked
                show = !show;
            }
        }

        if (!show) {
            return;
        }
        if (textStyle == null) {
            textStyle = new GUIStyle();
            textStyle.fontSize = FontSize;
        }

        windowRect = GUILayout.Window(123456, windowRect, ConsoleWindow, "Console");
    }

    public void AutoResize(int screenWidth, int screenHeight) {
        Vector2 resizeRatio = new Vector2((float)Screen.width / screenWidth, (float)Screen.height / screenHeight);
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
    }

    Dictionary<Color, Texture2D> texs = new Dictionary<Color, Texture2D>();
    private Texture2D MakeTex( int width, int height, Color col ) {
        if (texs.ContainsKey(col)) {
            return texs[col];
        }
        Color[] pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++) {
            pix[i] = col;
        }

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        texs[col] = result;
        return result;
    }
 
    void ConsoleWindow( int windowID ) {
        GUIStyle bStyle = new GUIStyle();
        var c = Color.blue;
        c.a = 0.7f;
        bStyle.normal.background = MakeTex(Screen.width, Screen.height, c);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(clearLabel, GUILayout.Height(20))) {
            logs.Clear();
        }
        if (GUILayout.Button(closeLabel, GUILayout.Height(20))) {
            show = false;
        }

        collapse = GUILayout.Toggle(collapse, collapseLabel, GUILayout.ExpandWidth(false));
        oneLineLog = GUILayout.Toggle(oneLineLog, oneLineLabel, GUILayout.ExpandWidth(false));

        GUILayout.EndHorizontal();

        //GUI.skin.verticalScrollbar.fixedWidth = Screen.width * 0.05f;
        //GUI.skin.verticalScrollbar.fixedHeight = Screen.height;

        //GUI.skin.verticalScrollbarThumb.fixedWidth = Screen.width * 0.05f;
        //GUI.skin.verticalScrollbarThumb.fixedHeight = Screen.height * 0.05f;

        //GUI.skin.horizontalScrollbar.fixedWidth = Screen.width;
        //GUI.skin.horizontalScrollbar.fixedHeight = Screen.height * 0.05f;

        //GUI.skin.horizontalScrollbarThumb.fixedWidth = Screen.width * 0.05f;
        //GUI.skin.horizontalScrollbarThumb.fixedHeight = Screen.height * 0.05f;

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, bStyle);

        // Iterate through the recorded logs.
        for (int i = 0; i < logs.Count; i++) {
            var log = logs[i];

            // Combine identical messages if collapse option is chosen.
            if (collapse) {
                var messageSameAsPrevious = i > 0 && log.message == logs[i - 1].message;
                if (messageSameAsPrevious) {
                    continue;
                }
            }

            GUI.contentColor = logTypeColors[log.type];
            textStyle.normal.textColor = logTypeColors[log.type];
            if (oneLineLog) {
                string first = log.message.Split(new[] { '\r', '\n' }).FirstOrDefault();
                GUILayout.Label(first, textStyle);
            } else {
                GUILayout.Label(log.message, textStyle);
            }
            
        }

        GUILayout.EndScrollView();

        GUI.contentColor = Color.white;


        // Allow the window to be dragged by its title bar.
        GUI.DragWindow(titleBarRect);
    }

    void HandleLog( string message, string stackTrace, LogType type ) {
        var log = new Log() {
            message = message,
            stackTrace = stackTrace,
            type = type,
        };
        //logs.Add(log);
        logs.Insert(0, log);
        if (logs.Count > MaxLog) {
            logs.RemoveAt(logs.Count - 1);
        }
    }
}