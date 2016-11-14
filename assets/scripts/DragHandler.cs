using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public Rigidbody prefab;
    Vector3 screenpoint;
    Vector3 offset;
    Rigidbody draggable;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData evenStData) {
        draggable = Instantiate(prefab);
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData) {
        float disttoscreen = Camera.main.WorldToScreenPoint(draggable.transform.position).z;
        Vector3 posmove = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, disttoscreen));
        draggable.transform.position = new Vector3(posmove.x, transform.position.y, posmove.z);
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData) {
        //throw new System.NotImplementedException ();
    }

    #endregion
}


