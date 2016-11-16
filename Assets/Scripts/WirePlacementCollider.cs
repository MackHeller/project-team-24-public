using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WirePlacementCollider : MonoBehaviour {

    JunctionController junction;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Junction")) {
            junction = other.gameObject.GetComponent<JunctionController>();
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        junction = null;
    }

    public JunctionController getCollidingJunction() {
        return junction;
    }
}
