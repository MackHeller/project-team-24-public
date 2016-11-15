using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public GameObject prefab;
    private Vector3 offset;
    private float zDistFromCamera;
    private GameObject draggable;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData evenStData) {
        if (prefab == null) {
            draggable = gameObject;
        } else {
            draggable = Instantiate(prefab);
        }

        Vector3 startPos = transform.position;
        zDistFromCamera = Mathf.Abs(startPos.z - Camera.main.transform.position.z);
        Vector3 posTouched = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera);
        offset = startPos - Camera.main.ScreenToWorldPoint(posTouched);
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData) {
        Vector3 posTouched = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera);
        draggable.transform.position = Camera.main.ScreenToWorldPoint(posTouched) + offset;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData) {
        offset = Vector3.zero;
        draggable = null;
    }

    #endregion
}


