using BabyEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UI;
using XLua;

/// <summary>
/// xlua自定义导出
/// </summary>
public static class XLuaCustomExport {
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp2 = new List<Type>() {
                typeof(System.Object),
                typeof(UnityEngine.Object),
                typeof(Vector2),
                typeof(Vector3),
                typeof(Vector4),
                typeof(Quaternion),
                typeof(Color),
                typeof(Ray),
                typeof(Bounds),
                typeof(Ray2D),
                typeof(Time),
                typeof(GameObject),
                typeof(Component),
                typeof(Behaviour),
                typeof(Transform),
                typeof(Resources),
                typeof(TextAsset),
                typeof(Keyframe),
                typeof(AnimationCurve),
                typeof(AnimationClip),
                typeof(MonoBehaviour),
                typeof(ParticleSystem),
                typeof(SkinnedMeshRenderer),
                typeof(Renderer),
                typeof(Light),
                typeof(Mathf),
                typeof(System.Collections.Generic.List<int>),
                typeof(Action<string>),
                typeof(Action<double>),
                typeof(Action<float>),
                typeof(Action<int>),
                typeof(Action<bool>),
                typeof(UnityEngine.Debug),
                typeof(UnityEngine.PlayerPrefs),
                typeof(System.IO.StreamWriter),
                typeof(System.IO.File),
                typeof(System.IO.Directory),
                typeof(System.IO.Path),
                typeof(UnityEngine.Physics),
                typeof(UnityEngine.Physics2D),
                typeof(UnityEngine.Collider),
                typeof(UnityEngine.Collider2D),
                typeof(UnityEngine.Collision),
                typeof(UnityEngine.Collision2D),
                typeof(UnityEngine.Application),
                typeof(UnityEngine.Texture),
                typeof(UnityEngine.Texture2D),
                typeof(UnityEngine.Texture3D),
                typeof(UnityEngine.TextureFormat),
                typeof(UnityEngine.Shader),
                typeof(UnityEngine.SpriteRenderer),
                typeof(UnityEngine.Screen),
                typeof(UnityEngine.AssetBundle),
                typeof(UnityEngine.Light),
                typeof(UnityEngine.Networking.UnityWebRequest),
                typeof(UnityEngine.Networking.UnityWebRequestAssetBundle),
                typeof(UnityEngine.Networking.UnityWebRequestTexture),
                typeof(UnityEngine.Networking.UnityWebRequestMultimedia),
                typeof(UnityEngine.Networking.UnityWebRequestAsyncOperation),
                typeof(UnityEngine.Input),
                typeof(UnityEngine.AudioSource),
                typeof(UnityEngine.AudioListener),
                typeof(UnityEngine.AudioClip),
                typeof(UnityEngine.Sprite),
                typeof(UnityEngine.KeyCode),
                typeof(UnityEngine.Animation),
                typeof(UnityEngine.Animator),
                typeof(UnityEngine.AnimationEvent),
                typeof(UnityEngine.AnimationClip),
                typeof(UnityEngine.AnimatorUtility),
                typeof(UnityEngine.MeshRenderer),
                typeof(UnityEngine.Projector),

                typeof(UnityEngine.Canvas),
                typeof(UnityEngine.CanvasGroup),
                typeof(UnityEngine.CanvasRenderer),
                typeof(UnityEngine.RectTransform),
                typeof(UnityEngine.UI.Image),
                typeof(UnityEngine.UI.RawImage),
                typeof(UnityEngine.UI.Button),
                typeof(UnityEngine.UI.Toggle),
                typeof(UnityEngine.UI.Slider),
                typeof(UnityEngine.UI.Dropdown),
                typeof(UnityEngine.UI.InputField),
                typeof(UnityEngine.UI.ScrollRect),
                typeof(UnityEngine.UI.Scrollbar),
                typeof(UnityEngine.UI.VerticalLayoutGroup),
                typeof(UnityEngine.UI.HorizontalLayoutGroup),
                typeof(UnityEngine.UI.CanvasScaler),
                typeof(UnityEngine.UI.LayoutElement),
                typeof(UnityEngine.UI.ContentSizeFitter),
                typeof(UnityEngine.UI.AspectRatioFitter),

                typeof(TMPro.TextMeshProUGUI),
                typeof(TMPro.TextMeshPro),

                typeof(UnityEngine.UI.Toggle.ToggleEvent),
                typeof(UnityEngine.UI.Dropdown.DropdownEvent),
                typeof(UnityEngine.UI.Slider.SliderEvent),
                typeof(UnityEngine.UI.InputField.OnChangeEvent),
                typeof(UnityEngine.UI.InputField.SubmitEvent),
                typeof(UnityEngine.UI.Scrollbar.ScrollEvent),

                typeof(UnityEngine.EventSystems.PointerEventData),
                typeof(UnityEngine.EventSystems.EventSystem),
                typeof(UnityEngine.ParticleSystem),
                typeof(UnityEngine.UI.Shadow),
                typeof(UnityEngine.UI.Outline),
                typeof(UnityEngine.GUI),
                typeof(UnityEngine.GUIUtility),
                typeof(UnityWebRequestCachingExtensions),

                typeof(AnimationClipPlayable),
                typeof(UnityEngine.Animations.PositionConstraint),
                typeof(UnityEngine.Animations.RotationConstraint),
                typeof(UnityEngine.Animations.LookAtConstraint),
                typeof(UnityEngine.Animations.ScaleConstraint),
                typeof(UnityEngine.Animations.ParentConstraint),
                typeof(UnityEngine.Animations.ConstraintSource),
#if ENABLE_UNITY_ADS
        //Unity Ads
        typeof(UnityEngine.Advertisements.Advertisement),
                typeof(UnityEngine.Advertisements.ShowOptions),
                typeof(UnityEngine.Advertisements.ShowResult),
#endif
                // websocket
                typeof(WebSocketSharp.CloseEventArgs),
                typeof(WebSocketSharp.ErrorEventArgs),
                typeof(WebSocketSharp.MessageEventArgs),
                typeof(WebSocketSharp.WebSocket),
                //// SocketIO
                //typeof(Dpoch.SocketIO.SocketIOConnection),
                //typeof(Dpoch.SocketIO.SocketIOEvent),
                //typeof(Dpoch.SocketIO.SocketIOConnection),
                //typeof(Dpoch.SocketIO.Packet),
                //typeof(Dpoch.SocketIO.SocketIO),
                //// json
                //typeof(Newtonsoft.Json.Linq.JArray),
                //typeof(Newtonsoft.Json.Linq.JObject),
                //// callback
                //typeof(Action<Dpoch.SocketIO.SocketIOEvent>),
#if ENABLE_UNITY_IAP
                // IAP
                typeof(UnityEngine.Purchasing.IStoreController),
                typeof(UnityEngine.Purchasing.IExtensionProvider),
                typeof(UnityEngine.Purchasing.InitializationFailureReason),
                typeof(UnityEngine.Purchasing.Product),
                typeof(UnityEngine.Purchasing.PurchaseFailureReason),
                typeof(UnityEngine.Purchasing.PurchaseEventArgs),
#endif
            };

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua2 = new List<Type>() {
                typeof(Action),
                typeof(Action<int, Dictionary<string, string>, byte[]>),
                typeof(Action<int, Dictionary<string, string>, string>),
                typeof(Func<double, double, double>),
                typeof(Action<string>),
                typeof(Action<double>),
                typeof(Action<float>),
                typeof(Action<int>),
                typeof(Action<bool>),
                // 广告
                typeof(UnityAction),
                typeof(UnityEvent<float>),
                typeof(System.Collections.IEnumerator),
                //
                //typeof(Cinemachine.CinemachineVirtualCamera)
            };

    //黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
                new List<string>(){"System.Xml.XmlNodeList", "ItemOf"},
                new List<string>(){"UnityEngine.WWW", "movie"},
#if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
#endif
                new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
                new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
                new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
                new List<string>(){"UnityEngine.Light", "areaSize"},
                new List<string>(){"UnityEngine.Light", "lightmapBakeType"},
                new List<string>(){"UnityEngine.WWW", "MovieTexture"},
                new List<string>(){"UnityEngine.WWW", "GetMovieTexture"},
                new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
#if !UNITY_WEBPLAYER
                new List<string>(){"UnityEngine.Application", "ExternalEval"},
#endif
                new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
                new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
                new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},
#region 2019 not support
                new List<string>(){ "UnityEngine.Light", "SetLightDirty"},
                new List<string>(){ "UnityEngine.Light", "shadowRadius"},
                new List<string>(){ "UnityEngine.Light", "shadowAngle"},
#endregion
                new List<string>(){ "UnityEngine.Input", "IsJoystickPreconfigured", "System.String"},
                new List<string>(){ "UnityEngine.Texture", "imageContentsHash"},
                new List<string>(){ "UnityEngine.AssetBundle", "SetAssetBundleDecryptKey", "System.String"},

                new List<string>(){ "UnityEngine.MeshRenderer", "scaleInLightmap"},
                new List<string>(){ "UnityEngine.MeshRenderer", "receiveGI"},
                new List<string>(){ "UnityEngine.MeshRenderer", "stitchLightmapSeams"},
    };

    /// <summary>
    /// dotween的扩展方法在lua中调用
    /// </summary>
    [LuaCallCSharp]
    [ReflectionUse]
    public static List<Type> dotween_lua_call_cs_list = new List<Type>()
    {
        typeof(DG.Tweening.AutoPlay),
        typeof(DG.Tweening.AxisConstraint),
        typeof(DG.Tweening.Ease),
        typeof(DG.Tweening.LogBehaviour),
        typeof(DG.Tweening.LoopType),
        typeof(DG.Tweening.PathMode),
        typeof(DG.Tweening.PathType),
        typeof(DG.Tweening.RotateMode),
        typeof(DG.Tweening.ScrambleMode),
        typeof(DG.Tweening.TweenType),
        typeof(DG.Tweening.UpdateType),

        typeof(DG.Tweening.DOTween),
        typeof(DG.Tweening.DOVirtual),
        typeof(DG.Tweening.EaseFactory),
        typeof(DG.Tweening.Tweener),
        typeof(DG.Tweening.Tween),
        typeof(DG.Tweening.Sequence),
        typeof(DG.Tweening.TweenParams),
        typeof(DG.Tweening.Core.ABSSequentiable),

        typeof(DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions>),

        typeof(DG.Tweening.TweenCallback),
        typeof(DG.Tweening.TweenExtensions),
        typeof(DG.Tweening.TweenSettingsExtensions),
        typeof(DG.Tweening.ShortcutExtensions),
        

        typeof(DG.Tweening.DOTweenModuleUI),
       
        //dotween pro 的功能
        typeof(DG.Tweening.DOTweenPath),
        typeof(DG.Tweening.DOTweenVisualManager),
        typeof(DG.Tweening.DOTweenProShortcuts),
    };
}