using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XLua;

[LuaCallCSharp]
public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,IPointerUpHandler, IDragHandler {
    public LuaFunction onDrag;
    public LuaFunction onPointerClick;
    public LuaFunction onPointerDown;
    public LuaFunction onPointerUp;
    public LuaFunction onPointerEnter;
    public LuaFunction onPointerExit;
    public void OnDrag(PointerEventData eventData) {
        if (onDrag != null) {
            onDrag.Call(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (onPointerClick != null) {
            onPointerClick.Call(eventData);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (onPointerDown != null) {
            onPointerDown.Call(eventData);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (onPointerEnter != null) {
            onPointerEnter.Call(eventData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (onPointerExit != null) {
            onPointerExit.Call(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (onPointerUp != null) {
            onPointerUp.Call(eventData);
        }
    }
}
