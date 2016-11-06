using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

	public static GameObject draggable;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		draggable = gameObject;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		//transform.position = Input.mousePosition;

		// Vector3.up makes it move in the world x/z plane.
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = eventData.pressEventCamera.ScreenPointToRay(eventData.position);
		float distamce;
		if (plane.Raycast (ray, out distamce)) {
			transform.position = ray.origin + ray.direction * distamce;
		}

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		draggable = null;
		transform.position = Input.mousePosition;
	}

	#endregion

}
