using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragEventDispatcher : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private ScrollRect scrollRect;
    private Graphic raycast;

    void Start() {
        FindScrollRect(transform);
        if (scrollRect) {
            raycast = gameObject.GetComponent<Graphic>();
        }
    }

    private void FindScrollRect(Transform tra) {
        if (tra.parent == null) {
            return;
        }
        Transform tempTran = tra.parent;
        scrollRect = tempTran.GetComponent<ScrollRect>();
        if (scrollRect) {
            return;
        }
        FindScrollRect(tempTran);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (scrollRect) {
            scrollRect.OnBeginDrag(eventData);
        }

        if (raycast) {
            raycast.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (scrollRect) {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (scrollRect) {
            scrollRect.OnEndDrag(eventData);
        }
        if (raycast) {
            raycast.raycastTarget = true;
        }
    }
}