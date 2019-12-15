using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BabyEngine {
    [XLua.LuaCallCSharp]
    public static class Utility {
        public static Sprite TextureToSprite(Texture texture) {
            return Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        public static Sprite ToSprite(this Texture2D texture) {
            if (texture == null) { return null; }
            return TextureToSprite(texture);
        }
    }
}
