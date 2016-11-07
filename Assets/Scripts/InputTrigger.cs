using UnityEngine;
using System.Collections;

public class InputTrigger : MonoBehaviour {
	//TODO: remove debug statements when not needed
	int numInputs = 0;

	/// <summary>
	/// When the collider enters the trigger area, if it is a wire
	/// increment the number of inputs.
	/// </summary>
	/// <param name="other">could be a wire or a gate</param>
	void OnTriggerEnter (Collider other){
		Debug.Log ("Input Detected");
		if (other.tag == "WireTag") { //check if it's a wire
			numInputs += 1; //increment number of inputs
			Debug.Log ("number of inputs is: ");
			Debug.Log (numInputs);
		} else {
			Debug.Log ("This object isnt a wire.");
		}
	}

	/// <summary>
	/// While collider is in trigger area, if it is a wire
	/// make it clip onto the gate.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay(Collider other){
		if (other.tag == "WireTag") { //check if it's a wire
			Vector3 x = gameObject.transform.position;
			other.transform.position = x;
		}
	}

	/// <summary>
	/// When the collider leaves the trigger area, if it is a wire
	/// decrement the number of inputs.
	/// </summary>
	/// <param name="other">could be a wire or a gate</param>
	void OnTriggerExit (Collider other){
		Debug.Log ("Input has been disconnected");
		if (other.tag == "WireTag") { //check if it's a wire
			numInputs -= 1; //decrement number of inputs
			Debug.Log ("number of inputs is: ");
			Debug.Log (numInputs);
		} else {
			Debug.Log ("This object isnt a wire.");
		}
	}
}
