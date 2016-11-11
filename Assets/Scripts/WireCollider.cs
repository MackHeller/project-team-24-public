using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WireCollider : MonoBehaviour{

	bool booltag = false;
	float mousex, mousey;
	public void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("InputTag")){
			booltag = true;
			Debug.Log ("enter trig");
		}
	}
	public void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("InputTag")){
			booltag = false;
			Debug.Log ("exit trig");
		}
	}
	public void Start(){
		mousex = WireDragHandler.mx1;
		mousey = WireDragHandler.my1;
		//Debug.Log ("Mouse set");
	}

	public void helper(float x, float y){
		if (booltag) {
			Debug.Log ("set mouse final");
		} else {
			Destroy (this.gameObject);
		}	
	}
}
