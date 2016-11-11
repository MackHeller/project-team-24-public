using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler {
	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		WireDragHandler.draggable.transform.SetParent (transform);
	}

	#endregion



}
