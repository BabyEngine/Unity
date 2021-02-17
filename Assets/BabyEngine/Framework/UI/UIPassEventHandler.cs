using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIPassEventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
    // 监听按下
    public void OnPointerDown(PointerEventData eventData) {
        PassEvent(eventData, ExecuteEvents.pointerDownHandler);
    }

    // 监听抬起
    public void OnPointerUp(PointerEventData eventData) {
        PassEvent(eventData, ExecuteEvents.pointerUpHandler);
    }

    // 监听点击
    public void OnPointerClick(PointerEventData eventData) {
        PassEvent(eventData, ExecuteEvents.submitHandler);
        PassEvent(eventData, ExecuteEvents.pointerClickHandler);
    }

    // 把事件透下去
    public void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function)
        where T : IEventSystemHandler {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        GameObject current = data.pointerCurrentRaycast.gameObject;
        for (int i = 0; i < results.Count; ++i) {
            if (current != results[i].gameObject) {
                ExecuteEvents.Execute(results[i].gameObject, data, function);
                // RaycastAll后ugui会自己排序，如果你只想响应透下去的最近的一个响应，
                // 这里ExecuteEvents.Execute后直接break就行。
                // break;
            }
        }
    }
    Vector3 touchPosition;
    public bool isRaycastTesting;
    public void Update() {
        // 获取当前点击点的位置
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0)) {
            touchPosition = Input.mousePosition;
#else
    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)  
    {
        touchPosition = Input.touches[0].position;
#endif

            // 手动调用 EventSystem.RaycastAll 
            var data = new PointerEventData(EventSystem.current);
            data.position = touchPosition;
            data.delta = Vector2.zero;
            data.button = PointerEventData.InputButton.Left;
            var results = new List<RaycastResult>();

            isRaycastTesting = true;
            EventSystem.current.RaycastAll(data, results);
            isRaycastTesting = false;

            // 判断是否是队首 UI 
            bool isFirstObj = false;
            for (int i = 0; i < results.Count; ++i) {
                if (results[i].gameObject != null) {
                    isFirstObj = (results[i].gameObject == gameObject);
                    break;
                }
            }
            // 如果是，进行事件处理
            if (isFirstObj) {
                // do sth.
                Debug.Log($"XXX:{results[0]}");
            }
             
        }
    }

}
