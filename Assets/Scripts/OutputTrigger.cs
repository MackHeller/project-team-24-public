using UnityEngine;
using System.Collections;

public class OutputTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		Debug.Log ("Output Detected");
	}
	void OnTriggerExit (Collider other){
		Debug.Log ("Output has been disconnected");
	}
}
