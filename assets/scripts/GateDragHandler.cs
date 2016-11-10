using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GateDragHandler : MonoBehaviour, IDragHandler {

	Vector3 screenpoint;
	Vector3 offset;

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		float disttoscreen = Camera.main.WorldToScreenPoint(transform.position).z;
		Vector3 posmove = Camera.main.ScreenToWorldPoint (
			new Vector3 (Input.mousePosition.x, Input.mousePosition.y, disttoscreen));
		transform.position = new Vector3 (posmove.x, transform.position.y, posmove.z);
	}

	#endregion
}
