using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(BuiltinModuleController))]
public class TerminalController : MonoBehaviour {

    private BuiltinModuleController moduleController;
    private SpriteRenderer _renderer;
    private LogicModule module;
    private bool isInput;
    private bool clicked;

    public Text labelText;

    public void setLabel(string label) {
        labelText.text = label;
    }

    public string getLabel() {
        return labelText.text;
    }

    void Start() {
        moduleController = GetComponent<BuiltinModuleController>();
        _renderer = moduleController.gameObject.GetComponent<SpriteRenderer>();
        module = moduleController.module;
        isInput = moduleController.builtinModule == BuiltinModuleController.BuiltinModules.IN;
    }

    void Update() {
        bool? value = isInput ? ((TerminalInput)module).getOutput() : ((TerminalOutput)module).getValue();
        switch (value) {
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

    private TerminalInput asInput() {
        if (!isInput) {
            throw new ArgumentException("terminal is not an input");
        }
        return ((TerminalInput)module);
    }

    private TerminalOutput asOutput() {
        if (isInput) {
            throw new ArgumentException("terminal is not an output");
        }
        return ((TerminalOutput)module);
    }

    public void setTerminalValue(bool? value) {
        asInput().setValue(value);
    }

    public bool? getTerminalValue() {
        return isInput ? asInput().getOutput() : asOutput().getValue();
    }

    public void OnMouseOver() {
        if (!isInput) {
            return;
        }
        TerminalInput terminalInput = ((TerminalInput)module);
        if (Input.GetMouseButtonDown(0)) {
            if (!clicked) {
                clicked = true;
                bool? val = terminalInput.getOutput();
                terminalInput.setValue(val == null ? false : !val);
            }
        } else {
            clicked = false;
        }
    }
}
