using UnityEngine;
using System.Collections;
using System;

public class dumbyTerminalController : MonoBehaviour {
    private bool charge;
    private SpriteRenderer _renderer;
    void Start() {
        charge = false;
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update() {
        switch (charge) {
            case true:
                _renderer.color = Color.green;
                break;
            case false:
                _renderer.color = Color.red;
                break;
            default:
                _renderer.color = Color.white;
                break;
        }
    }

    public void OnMouseDown() {
        charge = !charge;
    }
}
