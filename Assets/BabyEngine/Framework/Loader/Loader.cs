using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace BabyEngine {
    public abstract class Loader {
        static Loader currentLoader;
        public static LuaEnv.CustomLoader Create() {
#if UNITY_EDITOR
            if (currentLoader == null) {
                currentLoader = new EditorLoader();
            }
#elif UNITY_ANDROID
            if (currentLoader == null) {
                currentLoader = new AndroidLoader();
            }
#elif UNITY_WEBGL
            if (currentLoader == null) {
                currentLoader = new WebGLLoader();
            }
#endif
            return currentLoader.Load;
        }
        public abstract byte[] Load(ref string filepath);
    }
}