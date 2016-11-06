using UnityEngine;
using System.Collections;

public class OutputTrigger : MonoBehaviour {
	//TODO: remove debug statements when not needed
	int numOutputs = 0;

	/// <summary>
	/// When the collider enters the trigger area, if it is a wire
	/// increment the number of inputs.
	/// </summary>
	/// <param name="other">could be a wire or a gate</param>
	void OnTriggerEnter (Collider other){
		Debug.Log ("Output Detected");
		if (other.tag == "WireTag") { //check if it's a wire
			numOutputs += 1; //increment number of outputs
			Debug.Log ("number of outputs is: ");
			Debug.Log (numOutputs);
		} else {
			Debug.Log ("This object isnt a wire.");
		}

	}

	/// <summary>
	/// While collider is in trigger area, if it is a wire
	/// make it clip onto the gate.
	/// </summary>
	/// <param name="other">could be a wire or a gate</param>
	void OnTriggerStay(Collider other){
		//NOTE:placed objects can't be moved right now
		if (other.tag == "WireTag") { //check if it's a wire
			Vector3 x = gameObject.transform.position;
			other.transform.position = x;
		}
	}

	/// <summary>
	/// When the collider leaves the trigger area, if it is a wire
	/// decrement the number of outputs.
	/// </summary>
	/// <param name="other">could be a wire or a gate</param>
	void OnTriggerExit (Collider other){
		Debug.Log ("Output has been disconnected");
		if (other.tag == "WireTag") { //check if it's a wire
			numOutputs -= 1; //decrement number of outputs
			Debug.Log ("number of outputs is: ");
			Debug.Log (numOutputs);
		} else {
			Debug.Log ("This object isnt a wire.");
		}
	}
}
