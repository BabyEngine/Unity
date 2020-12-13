using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XLua;

namespace BabyEngine {
	[LuaCallCSharp]
    public static class Extendsion {
        public static string ToDefaultString(this byte[] bytes) {
            if (bytes == null) { return null; }
            return Encoding.Default.GetString(bytes);
        }

        public static string GetDefaultBytes(this byte[] bytes) {
            if (bytes == null) { return null; }
            return Encoding.Default.GetString(bytes);
        }

        public static string ToUTF8String(this byte[] bytes) {
            if (bytes == null) { return null; }
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] GetUTF8Bytes(this string str) {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ToByteSize(this int val) {
            long vv = val;
            return vv.ToByteSize();
        }

        public static string RemoveSuffix(this string s, string suffix) {
            if (s.EndsWith(suffix)) {
                return s.Substring(0, s.Length - suffix.Length);
            } else {
                return s;
            }
        }

        public static string ToByteSize(this long val) {
            string unit = "";
            float v = val;
            if (val < 1024) {
                unit = "B";
            } else if (val >= (1 << 10)) { // K
                unit = "K";
                v = v / (1 << 10);
            } else if (val >= (1 << 20)) { // M
                unit = "M";
                v = v / (1 << 20);
            } else if (val >= (1 << 30)) { // G
                unit = "G";
                v = v / (1 << 30);
            } else if (val >= (1 << 40)) { // T
                unit = "T";
                v = v / (1 << 40);
            }

            return string.Format("{0:N2} {1}", v, unit);
        }
        #region DOTween
        public static Tween UITextDOToValue(this Text text, float value, float delta, float duration, string format) {
            return DOTween.To(() => value, x => value = x, delta, duration).OnUpdate(() => text.text = string.Format(format, value));
        }

        public static Tween UITextDOToValuei(this Text text, int value, int delta, float duration, string format) {
            return DOTween.To(() => value, x => value = x, delta, duration).OnUpdate(() => text.text = string.Format(format, value));
        }
        public static Tween TextMeshDOToValue(this TextMesh text, float value, float delta, float duration, string format) {
            return DOTween.To(() => value, x => value = x, delta, duration).OnUpdate(() => text.text = string.Format(format, value));
        }

        public static Tween TextMeshDOToValuei(this TextMesh text, int value, int delta, float duration, string format) {
            return DOTween.To(() => value, x => value = x, delta, duration).OnUpdate(() => text.text = string.Format(format, value));
        }

        public static Tween DOText(this Text text, string val, float duration) {
            return DOTweenModuleUI.DOText(text, val, duration);
        }
        #endregion

        public static bool Raycast(Ray ray, out RaycastHit hit, int length) {
            return Physics.Raycast(ray, out hit, length);
        }

        public static string Format(this string fmt, params object[] args) {
            return string.Format(fmt, args);
        }

        public static bool IsDestroyed(this GameObject gameObject) {
            return gameObject == null && !ReferenceEquals(gameObject, null);
        }

        public static bool IsActive(this GameObject gameObject) {
            if (!IsDestroyed(gameObject) && gameObject.activeInHierarchy) {
                return true;
            }
            return false;
        }
        public static void SetActiveAllChild(this GameObject gameObject, bool b) {
            if (gameObject == null) return;
            foreach(Transform tra in gameObject.transform) {
                tra.gameObject.SetActive(b);
            }
        }
        public static void DestroyAllChild(this GameObject gameObject) {
            if (gameObject == null) return;
            foreach (Transform tra in gameObject.transform) {
                UnityEngine.Object.Destroy(tra.gameObject);
            }
        }
        public static string ToJson<T>(this T obj) {
            return JsonUtility.ToJson(obj);
        }
        private static System.Random random = new System.Random();
        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static long RandomInt(int length) {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()).ToInt();
        }

        public static string RandomString(int length, string chars) {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static long ToInt(this string val) {
            return long.Parse(val);
        }
        public static byte[] FromHexString(this string str) {
            if (string.IsNullOrEmpty(str)) { return null; }
            var hex = str.ToLower();
            return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
        }
        public static string ToHexString(this byte[] data) {
            if (data == null) { return null; }
            return string.Join(string.Empty, Array.ConvertAll(data, b => b.ToString("x2"))).ToUpper();
        }
    }
}


public class SpriteFuncs {
    public void ResizeSpriteToScreen(GameObject theSprite, Camera theCamera, int fitToScreenWidth, int fitToScreenHeight) {
        SpriteRenderer sr = theSprite.GetComponent<SpriteRenderer>();
        if (!theCamera) {
            theCamera = Camera.main;
        }

        theSprite.transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = (float)(theCamera.orthographicSize * 2.0);
        float worldScreenWidth = (float)(worldScreenHeight / Screen.height * Screen.width);

        if (fitToScreenWidth != 0) {
            Vector2 sizeX = new Vector2(worldScreenWidth / width / fitToScreenWidth, theSprite.transform.localScale.y);
            theSprite.transform.localScale = sizeX;
        }

        if (fitToScreenHeight != 0) {
            Vector2 sizeY = new Vector2(theSprite.transform.localScale.x, worldScreenHeight / height / fitToScreenHeight);
            theSprite.transform.localScale = sizeY;
        }
    }
}