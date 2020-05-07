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
    [MenuItem("Tools/Build/SubGame/UpdateCase/lua")]
    public static void BuildLuaSrc() {
        Packer.makeLuaAssetBundle("Game/UpdateCase/lua/", $"{GameConf.AB_PATH}updatecase/src.unity3d");

    }

    [MenuItem("Tools/Build/SubGame/UpdateCase/iOS Resource", false, 101)]
    public static void BuildiPhoneResource() {
        Packer.BuildAssetResource(BuildTarget.iOS, "Game/UpdateCase/res/", $"{GameConf.AB_PATH}updatecase/ios/");
    }

    [MenuItem("Tools/Build/SubGame/UpdateCase/Win Resource", false, 102)]
    public static void BuildWindowsResource() {
        Packer.BuildAssetResource(BuildTarget.StandaloneWindows, "Game/UpdateCase/res/", $"{GameConf.AB_PATH}/win/");
    }

    [MenuItem("Tools/Build/SubGame/UpdateCase/Build Hash File", false, 103)]
    public static void GenerateHashFile() {
        Packer.BuildHashFile();
    }

    [MenuItem("Tools/Build/SubGame/UpdateCase/Win 全套打包", false, 102)]
    public static void BuildAllWindows() {
        Packer.ResetHashFile();
        Packer.BuildLua();
        BuildLuaSrc();
        BuildWindowsResource();
        Packer.BuildHashFile();
    }
}
