using UnityEngine;
[XLua.LuaCallCSharp]
public class TransformUtility {
    /// <summary>
    /// 场景相机
    /// </summary>
    public static Camera ScenceCamera;

    /// <summary>
    /// UGUI相机
    /// </summary>
    public static Camera UGUICamera;

    #region 世界坐标转屏幕坐标

    /// <summary>
    /// 世界坐标转屏幕坐标
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Vector2 WorldToScreenPoint(Vector3 worldPoint) {
        return RectTransformUtility.WorldToScreenPoint(ScenceCamera, worldPoint);
    }

    /// <summary>
    /// 世界坐标转屏幕坐标
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint) {
        return RectTransformUtility.WorldToScreenPoint(cam, worldPoint);
    }

    #endregion

    #region 屏幕坐标转世界坐标

    /// <summary>
    /// 屏幕坐标转世界坐标
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="screenPoint"></param>
    /// <param name="worldPoint"></param>
    /// <returns></returns>
    public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, out Vector3 worldPoint) {
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPoint, UGUICamera, out worldPoint);
    }

    /// <summary>
    /// 屏幕坐标转世界坐标
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="screenPoint"></param>
    /// <param name="cam"></param>
    /// <param name="worldPoint"></param>
    /// <returns></returns>
    public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector3 worldPoint) {
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPoint, cam, out worldPoint);
    }

    #endregion

    #region 屏幕坐标转UGUI坐标
    /// <summary>
    /// 屏幕坐标转某个RectTransform下的localPosition坐标
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="screenPoint"></param>
    /// <param name="localPoint"></param>
    /// <returns></returns>
    public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, out Vector2 localPoint) {
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, UGUICamera, out localPoint);
    }

    /// <summary>
    /// 屏幕坐标转某个RectTransform下的localPosition坐标
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="screenPoint"></param>
    /// <param name="cam"></param>
    /// <param name="localPoint"></param>
    /// <returns></returns>
    public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint) {
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam, out localPoint);
    }

    #endregion
}