using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XLua;

[LuaCallCSharp]
public class UIEventHandler :  EventTrigger {
    // drag
    public LuaFunction onInitializePotentialDrag;
    public LuaFunction onBeginDrag; 
    public LuaFunction onDrag;
    public LuaFunction onEndDrag;
    public LuaFunction onDrop;
    // pointer
    public LuaFunction onPointerClick;
    public LuaFunction onPointerDown;
    public LuaFunction onPointerUp;
    public LuaFunction onPointerEnter;
    public LuaFunction onPointerExit;

    // select
    public LuaFunction onSelect = null;
    public LuaFunction onUpdateSelected = null;
    public LuaFunction onDeselect = null;
    public LuaFunction onSubmit = null;
    public LuaFunction onCancel = null;
    public LuaFunction onScroll = null;
    public LuaFunction onMove = null;

    #region drag
    public override void OnInitializePotentialDrag(PointerEventData eventData) {
        if (onInitializePotentialDrag != null) {
            onInitializePotentialDrag.Call(eventData);
        }
    }
    public override void OnBeginDrag(PointerEventData eventData) {
        if (onBeginDrag != null) {
            onBeginDrag.Call(eventData);
        }
    }

    public override void OnDrag(PointerEventData eventData) {
        if (onDrag != null) {
            onDrag.Call(eventData);
        }
    }
    public override void OnEndDrag(PointerEventData eventData) {
        if (onEndDrag != null) {
            onEndDrag.Call(eventData);
        }
    }
    public override void OnDrop(PointerEventData eventData) {
        if (onDrop != null) {
            onDrop.Call(eventData);
        }
    }
    #endregion
    #region pointer
    public override void OnPointerClick(PointerEventData eventData) {
        if (onPointerClick != null) {
            onPointerClick.Call(eventData);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        if (onPointerDown != null) {
            onPointerDown.Call(eventData);
        }
    }

    public override void OnPointerEnter(PointerEventData eventData) {
        if (onPointerEnter != null) {
            onPointerEnter.Call(eventData);
        }
    }

    public override void OnPointerExit(PointerEventData eventData) {
        if (onPointerExit != null) {
            onPointerExit.Call(eventData);
        }
    }

    public override void OnPointerUp(PointerEventData eventData) {
        if (onPointerUp != null) {
            onPointerUp.Call(eventData);
        }
    }
    #endregion pointer

    #region select
    public override void OnSelect(BaseEventData eventData) {
        if (onSelect != null) {
            onSelect.Call(eventData);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData) {
        if (onUpdateSelected != null) {
            onUpdateSelected.Call(eventData);
        }
    }
    public override void OnDeselect(BaseEventData eventData) {
        if (onDeselect != null) {
            onDeselect.Call(eventData);
        }
    }
    public override void OnSubmit(BaseEventData eventData) {
        if (onSubmit != null) {
            onSubmit.Call(eventData);
        }
    }
    public override void OnCancel(BaseEventData eventData) {
        if (onCancel != null) {
            onCancel.Call(eventData);
        }
    }
    public override void OnScroll(PointerEventData eventData) {
        if (onScroll != null) {
            onScroll.Call(eventData);
        }
    }
    public override void OnMove(AxisEventData eventData) {
        if (onMove != null) {
            onMove.Call(eventData);
        }
    }
    #endregion
}
