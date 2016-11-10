using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WireCollider : MonoBehaviour {

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
		
}
