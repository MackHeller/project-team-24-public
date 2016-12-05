using UnityEngine;
using System.Collections;

public class WireController : MonoBehaviour {

    public Vector3 tempEndPos;

    private Wire wireLogic;

    private float wireSize;
    private JunctionController inputJunction;
    private JunctionController outputJunction;

    public void Awake() {
        wireSize = (float)gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        wireLogic = new Wire();
    }

    // Update is called once per frame
    void Update() {
        Vector3 startPos = inputJunction.transform.position;
        Vector3 endPos = outputJunction ? outputJunction.transform.position : tempEndPos;
        Vector3 diff = endPos - startPos;
        transform.position = (diff * 0.5f) + startPos;

        float length = diff.magnitude / wireSize;
        transform.localScale = new Vector3(length, transform.localScale.y);

        float rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    void OnDestroy() {
        inputJunction.junction.removeObserver(wireLogic, 0);
        inputJunction.destroyIfDisconnected();
        outputJunction.junction.setInputModule(null);
        outputJunction.destroyIfDisconnected();
    }

    public void setInputJunction(JunctionController inputJunction) {
        this.inputJunction = inputJunction;
        wireLogic.setInputJunction(inputJunction ? inputJunction.junction : null);
        EditorManager.getInstance().checkForCorrectness();
    }

    public void setOutputJunction(JunctionController outputJunction) {
        this.outputJunction = outputJunction;
        wireLogic.setOutputJunction(outputJunction ? outputJunction.junction : null);
        EditorManager.getInstance().checkForCorrectness();
    }

    public JunctionController getInputJunction() {
        return inputJunction;
    }

    public JunctionController getOutputJunction() {
        return outputJunction;
    }
}
