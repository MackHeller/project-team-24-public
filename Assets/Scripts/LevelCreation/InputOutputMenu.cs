using UnityEngine;
using System.Collections;
using System;

public class InputOutputMenu : MonoBehaviour {
    public GameObject terminal;
    public void toggleChanged(bool newValue)
    {
        terminal.SetActive(newValue);
    }
    public void clickTerminal()
    {
        int rotation = 0;
        if (terminal.transform.eulerAngles.z == rotation)
            rotation = 180;
        terminal.transform.localEulerAngles = new Vector3(0, 0, rotation);

    }
}
