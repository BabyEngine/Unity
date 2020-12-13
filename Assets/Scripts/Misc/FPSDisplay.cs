using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {
    public Text mFPSText;

    //private float mDeltaTime = 0.0f;
    //private float msec = 0;
    //private float mFPS = 0.0f;

    //private void Start() {
    //    StartCoroutine(UpdateUI(0.5f));
    //}

    //void Update() {
    //    mDeltaTime += (Time.deltaTime - mDeltaTime) * 0.1f;
    //    msec = mDeltaTime * 1000.0f;
    //    mFPS = 1.0f / mDeltaTime;


    //}

    //IEnumerator UpdateUI(float sec) {
    //    yield return null;
    //    var wait = new WaitForSeconds(sec);
    //    while (true) {
    //        mFPSText.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, mFPS);
    //        yield return wait;
    //    }
    //}
    float deltaTime = 0.0f;

    void Update() {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI() {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(255.0f, 255.0f, 255.0f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}