using UnityEngine;
using XLua;

[LuaCallCSharp]
public class MouseEventHandler : MonoBehaviour
{
    public static MouseEventHandler GetMouseEventHandler(GameObject go)
    {
        MouseEventHandler com = go.GetComponent<MouseEventHandler>();
        if (com == null)
            com = go.AddComponent<MouseEventHandler>();
        return com;
    }

    public static void SetMouseUpAsButtonEvent(GameObject go,LuaFunction luaFunction)
    {
        MouseEventHandler com = GetMouseEventHandler(go);
        com.onMouseUpAsButton = luaFunction;
    }

    public LuaFunction onMouseDown;
    public LuaFunction onMouseUp;
    public LuaFunction onMouseUpAsButton;
    private void OnMouseDown()
    {
        onMouseDown?.Call();
    }

    private void OnMouseUp()
    {
        onMouseUp?.Call();
    }

    private void OnMouseUpAsButton()
    {
        onMouseUpAsButton?.Call();
    }
}
