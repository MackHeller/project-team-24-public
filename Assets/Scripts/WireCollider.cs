using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WireCollider : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	bool booltag = false;
	public void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("InputTag")){
			booltag = true;
		}
	}
	public void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("InputTag")){
			booltag = false;
		}
	}
		
	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
