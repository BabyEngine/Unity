using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BabyEngine {
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
    }
}
