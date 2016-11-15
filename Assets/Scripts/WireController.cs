using UnityEngine;
using System.Collections;

public class WireController : MonoBehaviour {
    
    private Wire wireLogic;

    public Vector3 startPos;
    public Vector3 endPos;
    private float wireSize;

    public void Start() {
        wireSize = (float)gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

	// Update is called once per frame
	void Update () {
        Vector3 diff = endPos - startPos;
        transform.position = (diff * 0.5f) + startPos;

        float length = diff.magnitude / wireSize;
        transform.localScale = new Vector3(length, transform.localScale.y);

        float rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
