using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class BuiltinModuleController : MonoBehaviour {

    public enum BuiltinModules { IN, OUT, NOT, AND, OR, XOR };

    private delegate LogicModule ModuleInstantiator();

    private static Dictionary<BuiltinModules, ModuleInstantiator> builtinModuleInstantiators = new Dictionary<BuiltinModules, ModuleInstantiator>() {
        { BuiltinModules.IN, () => new TerminalInput() },
        { BuiltinModules.OUT, () => new TerminalOutput() },
        { BuiltinModules.NOT, () => new GateNot() },
        { BuiltinModules.AND, () => new GateAnd(2) },
        { BuiltinModules.OR, () => new GateOR(2) },
        { BuiltinModules.XOR, () => new GateXOR(2) },
    };

    public BuiltinModules builtinModule;
    public GameObject[] inputJunctionLocations;
    public GameObject[] outputJunctionLocations;
    public JunctionController junctionControllerPrefab;

    public LogicModule module;

    void Start() {
        module = builtinModuleInstantiators[builtinModule]();
        if (inputJunctionLocations.Length != module.getInputCount() ||
            outputJunctionLocations.Length != module.getOutputCount()) {
            throw new IndexOutOfRangeException("Number of input/output controllers do not match gate");
        }
        for (int i = 0; i < inputJunctionLocations.Length; i++) {
            module.setInputJunction(i, instantiateJunction(inputJunctionLocations[i]));
        }
        for (int i = 0; i < outputJunctionLocations.Length; i++) {
            module.setOutputJunction(i, instantiateJunction(outputJunctionLocations[i]));
        }
    }

    private Junction instantiateJunction(GameObject location) {
        return ((GameObject)Instantiate(junctionControllerPrefab.gameObject,
                location.transform.position, Quaternion.Euler(Vector3.zero), transform))
                    .GetComponent<JunctionController>().junction;
    }


}
