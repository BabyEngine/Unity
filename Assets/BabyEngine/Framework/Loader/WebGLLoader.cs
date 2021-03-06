﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BabyEngine {
    public class WebGLLoader : Loader {
        public override byte[] Load(ref string filepath) {
            filepath = filepath.Replace(".", "/");
            var path = Application.dataPath + "/" + GameConf.LUA_BASE_PATH + filepath + ".lua";
            if (File.Exists(path)) {
                var code = File.ReadAllBytes(path);
                return code;
            }
            return null;
        }
    }
}
