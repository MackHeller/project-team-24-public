using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using C5;

public class DeletionHandler : MonoBehaviour {
	/// <summary>
	/// This class deletes all objects marked for deletion
	/// </summary>


	public void OnDeletionClick(){
		bool deletionstatus = GameManager.getInstance().isDeleting ();
		GameManager.getInstance().setIsDelting (!deletionstatus);
		if (GameManager.getInstance().isDeleting()) {
			gameObject.GetComponent<Button>().image.color = Color.red;
		} else {
			ArrayList<GameObject> wires = GameManager.getInstance().getWiresToBeDeleted ();
			foreach (GameObject wire in wires) {
				Destroy (wire, 0.0f);
			}
			for (int i = 0; i < wires.Count; i++) {
				Debug.Log ("wire removed");
				GameManager.getInstance().unmarkWireForDeletion (wires [i]);
			}
			ArrayList<GameObject> gates = GameManager.getInstance ().getGatesToBeDeleted ();
			foreach (GameObject gate in gates) {
				Destroy (gate, 0.0f);
			}
			for (int j = 0; j < gates.Count; j++) {
				Debug.Log ("gate removed");
				GameManager.getInstance ().unmarkGateForDeletion (gates [j]);
			}
			gameObject.GetComponent<Button> ().image.color = 
				new Color(1f, 0f, 0f, 0.5f);
		}
	}
}
