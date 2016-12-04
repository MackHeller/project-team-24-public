using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BuiltinModuleController))]
public class TerminalController : MonoBehaviour {

    private BuiltinModuleController moduleController;
    private SpriteRenderer _renderer;
    private LogicModule module;
    private bool isInput;
    private bool clicked;

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
                _renderer.color = Color.green;
                break;
        }
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
