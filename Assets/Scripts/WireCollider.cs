using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WireCollider : MonoBehaviour {

    bool booltag = false;
    bool booltag2 = false;
    bool dropped = false;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("InputTag")) {
            booltag = true;
        }
        if (other.gameObject.CompareTag("OutputTag")) {
            booltag2 = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("InputTag")) {
            booltag = false;
        }
        if (other.gameObject.CompareTag("OutputTag")) {
            booltag2 = false;
        }
    }

    public void helper(float x, float y) {
        if (!booltag) {
            Destroy(this.gameObject);
        }
        dropped = true;
    }

    public void FixedUpdate() {
        if (dropped) {
            if (!booltag || !booltag2) {
                Destroy(this.gameObject);
            }
        }
    }
}
