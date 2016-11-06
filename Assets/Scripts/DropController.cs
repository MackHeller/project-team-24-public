using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropController : MonoBehaviour, IDropHandler {
	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		Destroy (DragController.draggable.gameObject);

	}

	#endregion



}
