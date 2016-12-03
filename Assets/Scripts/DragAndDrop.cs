using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    /// <summary>
    /// If non-null, drag and drop an instantiation of this instead of the object this script is attached to.
    /// </summary>
    public DragAndDrop prefab;
    private Vector3 offset;
    private float zDistFromCamera;
    private DragAndDrop instantiated;
    private bool collisionWithInstantiated;

    #region Draghandler

    public void OnBeginDrag(PointerEventData eventData) {
        if (prefab != null) {
            instantiated = Instantiate(prefab.gameObject).GetComponent<DragAndDrop>();
            instantiated.transform.position = transform.position;
            instantiated.OnBeginDrag(eventData);
        } else {
            Vector3 startPos = transform.position;
            zDistFromCamera = Mathf.Abs(startPos.z - Camera.main.transform.position.z);
            Vector3 posTouched = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera);
            offset = startPos - Camera.main.ScreenToWorldPoint(posTouched);
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (instantiated) {
            instantiated.OnDrag(eventData);
        } else {
            Vector3 posTouched = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera);
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(posTouched) + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (instantiated) {
            // Destroy instantiated object if it's intersecting with the original
            if (gameObject.GetComponent<Collider2D>().bounds.Intersects(instantiated.gameObject.GetComponent<Collider2D>().bounds)) {
                Object.Destroy(instantiated.gameObject);
            }
            instantiated.OnEndDrag(eventData);
        } else {
            offset = Vector3.zero;
        }
    }

    #endregion
}


