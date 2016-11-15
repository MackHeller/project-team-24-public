using UnityEngine;
using System.Collections;

public class OnHoverShow : MonoBehaviour {

    public SpriteRenderer spriteOnHover;
    public SpriteRenderer spriteOffHover;

    public void OnMouseEnter() {
        toggleSprites(true);
    }

    public void OnMouseExit() {
        toggleSprites(false);
    }

    private void toggleSprites(bool on) {
        if (spriteOnHover != null) {
            spriteOnHover.enabled = on;
        }
        if (spriteOffHover != null) {
            spriteOffHover.enabled = !on;
        }
    }
}
