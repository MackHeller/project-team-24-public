using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WireDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public GameObject prefab;
    Vector3 screenpoint;
    Vector3 offset;
    public static GameObject draggable;
    float mx2, my2;
    public static float mx1, my1;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData evenStData) {
        mx1 = Input.mousePosition.x;
        my1 = Input.mousePosition.y;
        //mp1 = Input.mousePosition;
        draggable = Instantiate(prefab);
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData) {
        //float disttoscreen = Camera.main.WorldToScreenPoint(draggable.transform.position).z;
        //Vector3 posmove = Camera.main.ScreenToWorldPoint (
        //	new Vector3 (Input.mousePosition.x, Input.mousePosition.y, disttoscreen));
        //draggable.transform.position = new Vector3 (posmove.x, transform.position.y, posmove.z);
        //Vector3 offset = Input.mousePosition - mp1;
        float hyp;
        mx2 = Input.mousePosition.x;
        my2 = Input.mousePosition.y;
        float xdiff, ydiff, xpos, ypos, rotation;
        xpos = (mx1 + mx2) / 2.0f;
        ypos = (my1 + my2) / 2.0f;
        xdiff = mx1 - mx2;
        ydiff = my1 - my2;
        hyp = Mathf.Sqrt((xdiff * xdiff) + (ydiff * ydiff));
        rotation = Mathf.Atan2(xdiff, ydiff);
        float disttoscreen = Camera.main.WorldToScreenPoint(draggable.transform.position).z;
        Vector3 posmove = Camera.main.ScreenToWorldPoint(
            new Vector3(xpos, ypos, disttoscreen));
        draggable.transform.position = new Vector3(posmove.x, draggable.transform.position.y, posmove.z);
        draggable.transform.rotation = Quaternion.Euler(0, rotation * Mathf.Rad2Deg + 90, 0);
        draggable.transform.localScale = new Vector3(hyp / 30.0f, 0.1f, 0.1f);
    }

    #endregion

    #region IEndDragHandler implementation
    public void OnEndDrag(PointerEventData eventData) {
        WireCollider script;
        script = draggable.GetComponent<WireCollider>();
        script.helper(mx2, my2);
    }
    #endregion
}
