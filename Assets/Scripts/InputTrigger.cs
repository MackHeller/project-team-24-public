using UnityEngine;
using System.Collections;

public class InputTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		Debug.Log ("Input Detected");
	}
	void OnTriggerExit (Collider other){
		Debug.Log ("Input has been disconnected");
	}
}
