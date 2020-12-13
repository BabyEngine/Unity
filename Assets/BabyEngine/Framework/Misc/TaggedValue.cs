using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[XLua.LuaCallCSharp]
public class TaggedValue : MonoBehaviour {
    public TaggedInt[] IntValue;
    public TaggedFloat[] FloatValue;
    public TaggedString[] StringValue;
    public TaggedVector2[] Vector2Value;
    public TaggedVector3[] Vector3Value;
    public TaggedGameObject[] GameObjectValue;
    public TaggedSprite[] SpriteValue;
    public TaggedTexture[] TextureValue;
    public TaggedAudioClip[] AudioClipValue;
}
[System.Serializable]
public class TaggedInt {
    public string Name;
    public int Value;
}
[System.Serializable]
public class TaggedFloat {
    public string Name;
    public float Value;
}

[System.Serializable]
public class TaggedString {
    public string Name;
    public string Value;
}
[System.Serializable]
public class TaggedVector2 {
    public string Name;
    public Vector2 Value;
}

[System.Serializable]
public class TaggedVector3 {
    public string Name;
    public Vector3 Value;
}
[System.Serializable]
public class TaggedGameObject {
    public string Name;
    public GameObject Value;
}
[System.Serializable]
public class TaggedSprite {
    public string Name;
    public Sprite Value;
}
public class TaggedTexture {
    public string Name;
    public Texture Value;
}
[System.Serializable]
public class TaggedAudioClip {
    public string Name;
    public AudioClip Value;
}
