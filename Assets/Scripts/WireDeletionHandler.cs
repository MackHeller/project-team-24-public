using UnityEngine;
using System.Collections;

public class WireDeletionHandler : MonoBehaviour {
	/// <summary>
	/// This class detects a mouse click and marks this
	/// gameobject for deletion
	/// </summary>

	private bool markedfordeletion = false;

	void OnMouseDown(){
		if (GameManager.getInstance().isDeleting()) {
			markedfordeletion = !markedfordeletion;
		}
	}

	void OnMouseUp(){
		if (GameManager.getInstance().isDeleting()) {
			if (markedfordeletion) {
				gameObject.GetComponent<SpriteRenderer> ().color = 
					new Color (1f, 0f, 0f, 1f);
				GameManager.getInstance().markWireForDeletion (gameObject);
			} else {
				gameObject.GetComponent<SpriteRenderer> ().color = 
					new Color (0f, 0f, 0f, 1f);
				GameManager.getInstance().unmarkWireForDeletion (gameObject);
			}
		}
	}
}
