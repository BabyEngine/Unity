using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BabyEngine {
    public static class GameConf {
        public static readonly string LUA_BASE_PATH = "BabyEngine/lua/";
        public static string CustomLuaGame;
        /// <summary>
        /// 
        /// </summary>
        public static void T() {
            Slider slider = null;
            slider.DOValue(1, 0.5f);
        }      
    }
}