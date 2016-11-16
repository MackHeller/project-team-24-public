using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(JunctionController))]
public class WireDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public WireController wirePrefab;
    public WirePlacementCollider wirePlacementColliderPrefab;
    private WireController wire;
    private WirePlacementCollider wirePlacementCollider;
    float zDistFromCamera;

    private Vector3 getDragPos() {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera));
    }

    #region DragHandler

    public void OnBeginDrag(PointerEventData evenStData) {
        wire = Instantiate(wirePrefab);
        Vector3 startPos = transform.position;
        JunctionController inputJunction = GetComponent<JunctionController>();
        wire.setInputJunction(inputJunction);
        inputJunction.setUninteractableOverride(true);
        zDistFromCamera = Mathf.Abs(startPos.z - Camera.main.transform.position.z);

        wirePlacementCollider = Instantiate(wirePlacementColliderPrefab);
        wirePlacementCollider.transform.position = startPos;

        GameManager.setCreatingWire(true);
    }

    public void OnDrag(PointerEventData eventData) {
        Vector3 dragPos = getDragPos();
        wirePlacementCollider.transform.position = dragPos;

        // Snap to junction
        JunctionController collidingJunction = wirePlacementCollider.getCollidingJunction();
        wire.tempEndPos = collidingJunction ? collidingJunction.transform.position : dragPos;
    }

    public void OnEndDrag(PointerEventData eventData) {
        JunctionController outputJunction = wirePlacementCollider.getCollidingJunction();
        if (!outputJunction) {
            outputJunction = Instantiate(gameObject).GetComponent<JunctionController>();
            outputJunction.transform.position = getDragPos();
        }
        wire.setOutputJunction(outputJunction);
        wire.getInputJunction().setUninteractableOverride(false);

        Object.Destroy(wirePlacementCollider.gameObject);
        GameManager.setCreatingWire(false);
    }

    #endregion
}
