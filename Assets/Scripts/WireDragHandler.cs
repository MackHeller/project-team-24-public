using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WireDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public GameObject wirePrefab;
    private GameObject wire;
    private WireController wireController;
    float zDistFromCamera;

    #region DragHandler

    public void OnBeginDrag(PointerEventData evenStData) {
        wire = Instantiate(wirePrefab);
        wireController = wire.GetComponent<WireController>();
        Vector3 startPos = transform.position;
        wireController.startPos = startPos;
        zDistFromCamera = Mathf.Abs(startPos.z - Camera.main.transform.position.z);
    }

    public void OnDrag(PointerEventData eventData) {
        wireController.endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera));
    }

    public void OnEndDrag(PointerEventData eventData) {
        WireCollider script;
        script = wire.GetComponentInChildren<WireCollider>();
        script.helper(wireController.endPos.x, wireController.endPos.y);
    }
    #endregion
}
