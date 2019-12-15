using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BabyEngine {
    public static class Extendsion {
        public static string ToUTF8String(this byte[] bytes) {
            if (bytes == null) { return null; }
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] GetUTF8Bytes(this string str) {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
