using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class TerminalToggleHandler : MonoBehaviour {

    private Toggle toggle;

    public Image terminalImage;
    public Color toggleOnColor;
    public Color toggleOffColor;

    private void Start() {
        toggle = GetComponent<Toggle>();
        OnToggle();
    }

    public void OnToggle() {
        terminalImage.color = toggle.isOn ? toggleOnColor : toggleOffColor;
    }
}
