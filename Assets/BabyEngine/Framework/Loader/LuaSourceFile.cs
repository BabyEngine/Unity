using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LuaSourceFile {
    public string code;
    public string OutFile;

    public override string ToString() {
        return JsonUtility.ToJson(this);
    }
    public static LuaSourceFile FromJson(string json) {
        return JsonUtility.FromJson<LuaSourceFile>(json);
    }
}
