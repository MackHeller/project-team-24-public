using UnityEngine;
using System.Collections;

public class WireDeletionHandler : MonoBehaviour {
    /// <summary>
    /// This class detects a mouse click and marks this
    /// gameobject for deletion
    /// </summary>

    private bool markedfordeletion = false;
    private EditorManager editorManager;

    private void Awake() {
        editorManager = EditorManager.getInstance();
    }

    void OnMouseDown() {
        if (editorManager.isDeleting()) {
            markedfordeletion = !markedfordeletion;
        }
    }

    void OnMouseUp() {
        if (editorManager.isDeleting()) {
            if (markedfordeletion) {
                gameObject.GetComponent<SpriteRenderer>().color =
                    new Color(1f, 0f, 0f, 1f);
                editorManager.markWireForDeletion(gameObject);
            } else {
                gameObject.GetComponent<SpriteRenderer>().color =
                    new Color(0f, 0f, 0f, 1f);
                editorManager.unmarkWireForDeletion(gameObject);
            }
        }
    }
}
