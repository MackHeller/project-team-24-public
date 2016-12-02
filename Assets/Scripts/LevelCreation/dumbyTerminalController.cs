using UnityEngine;
using System.Collections;
using System;

public class dumbyTerminalController : MonoBehaviour {
    private bool charge;
    private SpriteRenderer renderer;
    void Start()
    {
        charge = false;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        switch (charge)
        {
            case true:
                renderer.color = Color.green;
                break;
            case false:
                renderer.color = Color.red;
                break;
            default:
                renderer.color = Color.white;
                break;
        }
    }

    public void OnMouseDown()
    {
        charge = !charge;
    }
}
