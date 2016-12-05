using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class JunctionController : MonoBehaviour {

    public Junction junction;

    private EditorManager editorManager;
    private SpriteRenderer _sprite;
    private Collider2D _collider;
    private bool uninteractableOverride = false;

    public void Awake() {
        editorManager = EditorManager.getInstance();
        junction = new Junction();
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private Vector3 getPointerPos() {
        float zDistFromCamera = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistFromCamera));
    }

    public void FixedUpdate() {
        if (editorManager.isCreatingWire()) {
            toggleInteractable(!junction.hasInputModule());
        } else {
            toggleInteractable(junction.hasInputModule());
        }
        bool hovering = _collider.bounds.Contains(getPointerPos());
        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, hovering ? 1f : 0.5f);
    }

    private void toggleInteractable(bool on) {
        on = on && !uninteractableOverride;
        _sprite.enabled = on;
        _collider.enabled = on;
    }

    public void setUninteractableOverride(bool uninteractableOverride) {
        this.uninteractableOverride = uninteractableOverride;
    }

    /**
     * <summary>Destroys this junction game object if it is not connected to any logic modules.</summary>
     * <returns>true, if this object was destroyed</returns>
     */
    public bool destroyIfDisconnected() {
        if (!(junction.hasInputModule() || junction.hasObservers())) {
            Destroy(gameObject);
            return true;
        }
        return false;
    }

}
