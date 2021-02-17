using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[XLua.LuaCallCSharp]
public class TweenTextNumber : MonoBehaviour {
    
    public float duration = 0.3f;
    public Text text;
    public TextMeshProUGUI textMesh;
    public bool enableFormatNumber = true;
    List<AnimData> animActions = new List<AnimData>();
    struct AnimData {
        public long startVal;
        public long endVal;
    }
    bool isRunning = false;

    void SetText(string t) {
        if (textMesh != null) {
            textMesh.text = t;
        }
        if (text != null) {
            text.text = t;
        }
    }
    bool IsAcitve() {
        if (textMesh != null) {
            return textMesh.gameObject.activeInHierarchy;
        }
        if (text != null) {
            return text.gameObject.activeInHierarchy;
        }
        return false;
    }
    IEnumerator TweenOne(AnimData data, Action cb) {
        long dtVal = data.endVal - data.startVal;
        float timeSum = 0;
        while(timeSum < duration) {
            timeSum += Time.deltaTime;
            long val = data.startVal + (long)(dtVal * (timeSum / duration));
            SetText(FormatNumber(val));
            yield return null;
        }
        if (animActions.Count == 0) {
            SetText(FormatNumber(data.endVal));
        }
        
        cb();
    }
    IEnumerator StartTween() {
        while (true) {
            if (animActions.Count == 0) {
                break;
            }
            var data = animActions[0];
            animActions.RemoveAt(0);

            StartCoroutine(TweenOne(data, () => {
                StartCoroutine(StartTween());
            }));
            yield break;
        }
        isRunning = false;
    }
    public void TweenTo(long delta, long finalValue) {
        if (!IsAcitve()) {
            SetText(FormatNumber(finalValue));
            return;
        }
        var a = new AnimData();
        a.startVal = finalValue - delta;
        a.endVal = finalValue;
        
        animActions.Add(a);
        if (isRunning) {
            return;
        }
        StartCoroutine(StartTween());
    }

    string FormatNumber(long n) {
        if (!enableFormatNumber) {
            return String.Format("{0:n0}", n);
        }
        if (n < 1000)
            return n.ToString();

        if (n < 10000)
            return String.Format("{0:#,.##}K", n - 5);

        if (n < 100000)
            return String.Format("{0:#,.#}K", n - 50);

        if (n < 1000000)
            return String.Format("{0:#,.}K", n - 500);

        if (n < 10000000)
            return String.Format("{0:#,,.##}M", n - 5000);

        if (n < 100000000)
            return String.Format("{0:#,,.#}M", n - 50000);

        if (n < 1000000000)
            return String.Format("{0:#,,.}M", n - 500000);

        return String.Format("{0:#,,,.##}B", n - 5000000);
    }
}
