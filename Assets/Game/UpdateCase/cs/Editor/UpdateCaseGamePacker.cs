using BabyEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 游戏打包器
/// </summary>
public class UpdateCaseGamePacker : MonoBehaviour {
 

    [MenuItem("Tools/Build/SubGame/UpdateCase/Win 打包", false, 101)]
    public static void BuildAllWindows() {
        Packer.BuildAll(BuildTarget.StandaloneWindows, "UpdateCase");
    }

    [MenuItem("Tools/Build/SubGame/UpdateCase/Android 打包", false, 102)]
    public static void BuildAllAndroid() {
        Packer.BuildAll(BuildTarget.Android, "UpdateCase");
    }

}
