using UnityEngine;
using System.Collections;

public class GateDeletionHandler : MonoBehaviour {
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
				GameManager.getInstance().markGateForDeletion (gameObject);
			} else {
				gameObject.GetComponent<SpriteRenderer> ().color = 
					new Color (0.4117647f, 0.8352941f, 0.9647059f, 1f);
				GameManager.getInstance().unmarkGateForDeletion (gameObject);
			}
		}
	}
}
