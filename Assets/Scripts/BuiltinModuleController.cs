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

    private JunctionController[] inputJunctionControllers;
    private JunctionController[] outputJunctionControllers;

    public LogicModule module;

    void Start() {
        module = builtinModuleInstantiators[builtinModule]();
        if (inputJunctionLocations.Length != module.getInputCount() ||
            outputJunctionLocations.Length != module.getOutputCount()) {
            throw new IndexOutOfRangeException("Number of input/output controllers do not match gate");
        }
        inputJunctionControllers = instantiateJunctionControllers(inputJunctionLocations, i => module.getInputJunction(i));
        outputJunctionControllers = instantiateJunctionControllers(outputJunctionLocations, i => module.getOutputJunction(i));
    }

    private JunctionController[] instantiateJunctionControllers(GameObject[] locations, Func<int, Junction> junctionGetter) {
        JunctionController[] junctionControllers = new JunctionController[locations.Length];
        for (int i = 0; i < locations.Length; i++) {
            JunctionController jc = ((GameObject)Instantiate(junctionControllerPrefab.gameObject,
                locations[i].transform.position, Quaternion.Euler(Vector3.zero), transform))
                    .GetComponent<JunctionController>();
            jc.junction = junctionGetter(i);
            junctionControllers[i] = jc;
        }
        return junctionControllers;
    }
}
