using UnityEngine;
using System.Collections;

public class WireDeletionHandler : MonoBehaviour {
	/// <summary>
	/// This class detects a mouse click and deletes
	/// the associated wire.
	/// </summary>

	private bool markedfordeletion = false;

	void OnMouseDown(){
		markedfordeletion = true;
	}

	void OnMouseUp(){
		if (markedfordeletion) {
			//Destroy (gameObject, 0.1f);
			//removes the gameobject
			//but the backend wire remains
			//TODO:need to remove wire from junction
		}
	}
}
