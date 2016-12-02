using UnityEngine;
using System.Collections;
using System;

public class levelCreationMenu : MonoBehaviour {
    public GameObject terminal;
    public void toggleChanged(bool newValue)
    {
        terminal.SetActive(newValue);
    }
}
