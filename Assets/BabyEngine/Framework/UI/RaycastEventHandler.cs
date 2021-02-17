using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[XLua.LuaCallCSharp]
public class RaycastEventHandler : MonoBehaviour {
    private static RaycastEventHandler _cur;
    public static RaycastEventHandler current {
        get {
            if (_cur == null) {
                var go = new GameObject("RaycastEventHandler");
                DontDestroyOnLoad(go);
                _cur = go.AddComponent<RaycastEventHandler>();
            }
            return _cur;
        }
    }
    Dictionary<GameObject, XLua.LuaFunction> listeners = new Dictionary<GameObject, XLua.LuaFunction>();
    public LayerMask layerMask;
    public float maxDistance = float.MaxValue;
    public Camera cam;
    Camera Cam {
        get {
            if (cam != null) {
                //cam = Camera.main;
            }
            return cam;
        }
    }
    private void Awake() {
        _cur = GetComponent<RaycastEventHandler>();
    }
    enum ActionPhase {
        None,
        Up,
        Down
    }
    struct State {
        public ActionPhase phase;
        public Vector3 position;
    }
    State state = new State {
        phase = ActionPhase.None,
        position = Vector3.zero,
    };
    void checkState() {

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            state.phase = ActionPhase.Down;
            state.position = Input.mousePosition;
            return;
        } else if (Input.GetMouseButtonUp(0)) {
            state.phase = ActionPhase.Up;
            state.position = Input.mousePosition;
            return;
        }
#elif UNITY_ANDROID || UNITY_IOS
        //
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                state.phase = ActionPhase.Down;
                state.position = touch.position;
                return;
            } else if(touch.phase == TouchPhase.Ended) {
                state.phase = ActionPhase.Up;
                state.position = touch.position;
                return;
            }
        }
#endif
        state.phase = ActionPhase.None;
        state.position = Vector3.zero;
    }

    void LateUpdate() {
        checkState();
        if (state.phase == ActionPhase.Down) {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) {
                return;
            }
            
            Ray ray = Cam.ScreenPointToRay(state.position);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            for(int i=0;i<hits.Length;i++) {
                GameObject go = hits[i].collider.gameObject;
                if (listeners.ContainsKey(go)) {
                    listeners[go]?.Call(i);
                }
            }
            }
    }
    public void AddListener(GameObject go, XLua.LuaFunction cb) {
        if (listeners.ContainsKey(go)) {
            listeners.Remove(go);
        }
        listeners.Add(go, cb);
    }
    public void RemoveListener(GameObject go) {
        if (listeners.ContainsKey(go)) {
            listeners.Remove(go);
        }
    }
}
