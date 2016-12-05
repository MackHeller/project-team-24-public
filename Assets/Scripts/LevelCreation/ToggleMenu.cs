using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour {
    public GameObject terminal;
    public void toggleChanged(bool newValue)
    {
        terminal.SetActiveRecursively(newValue);
    }
    public void toggleChangedFlip()
    {
        terminal.SetActiveRecursively(!terminal.activeSelf);
    }
    public void clickTerminal()
    {
        int rotation = 0;
        if (terminal.transform.eulerAngles.z == rotation)
            rotation = 180;
        terminal.transform.localEulerAngles = new Vector3(0, 0, rotation);

    }
}
