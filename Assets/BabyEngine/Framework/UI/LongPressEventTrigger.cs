
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[XLua.LuaCallCSharp]
public class LongPressEventTrigger : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    public float longThreshold = 1.0f;
    public float shortThreshold = 0.3f;
    public UnityEvent onLongPress = new UnityEvent();
    public UnityEvent onLongPressPrepare = new UnityEvent();
    public UnityEvent onShortPress = new UnityEvent();
    public UnityEvent onPressLeave = new UnityEvent();

    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private bool longPressPrepareTriggered = false;
    private float timePressStarted;
    private float timeLongPressStarted;
    public float Progress;

    private void Update() {
        if (isPointerDown && !longPressTriggered) {
            var dt = Time.time - timePressStarted;
            // 长按预备
            if (dt > shortThreshold && !longPressPrepareTriggered) {
                timeLongPressStarted = Time.time;
                longPressPrepareTriggered = true;
                onLongPressPrepare?.Invoke();
                return;
            }
            // 长按逻辑
            dt = Time.time - timeLongPressStarted;
            Progress = Mathf.Clamp01(dt / longThreshold);
            if (dt > longThreshold) {
                longPressTriggered = true;
                Progress = 1;
                onLongPress?.Invoke();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        timePressStarted = Time.time;
        timeLongPressStarted = Time.time + shortThreshold;
        isPointerDown = true;
        longPressTriggered = false;
        longPressPrepareTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isPointerDown = false;
        Progress = 0;
        var dt = Time.time - timePressStarted;
        if (dt < shortThreshold) {
            onShortPress?.Invoke();
        }
    }


    public void OnPointerExit(PointerEventData eventData) {
        isPointerDown = false;
        Progress = 0;
        onPressLeave?.Invoke();
    }
}