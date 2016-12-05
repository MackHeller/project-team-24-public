using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class BuiltinModuleController : MonoBehaviour {

    public enum BuiltinModules { IN, OUT, NOT, AND, OR, XOR, NAND, NOR, NXOR };

    private static Dictionary<BuiltinModules, Func<LogicModule>> builtinModuleInstantiators = new Dictionary<BuiltinModules, Func<LogicModule>>() {
        { BuiltinModules.IN, () => new TerminalInput() },
        { BuiltinModules.OUT, () => new TerminalOutput() },
        { BuiltinModules.NOT, () => new GateNot() },
        { BuiltinModules.AND, () => new GateAnd(2) },
        { BuiltinModules.OR, () => new GateOr(2) },
        { BuiltinModules.XOR, () => new GateXor(2) },
        { BuiltinModules.NAND, () => new GateNand(2) },
        { BuiltinModules.NOR, () => new GateNor(2) },
        { BuiltinModules.NXOR, () => new GateNxor(2) },
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
        if (!isTerminal()) {
            EditorManager.getInstance().incrementScore();
        }
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

    public bool isTerminal() {
        return builtinModule == BuiltinModules.IN || builtinModule == BuiltinModules.OUT;
    }

    void OnDestroy() {
        if (!isTerminal()) {
            EditorManager.getInstance().decrementScore();
        }
        // Destroy all input junctions if they are not connected to anything else
        for (int i = 0; i < inputJunctionControllers.Length; i++) {
            JunctionController jc = inputJunctionControllers[i];
            jc.junction.removeObserver(module, i);
            jc.destroyIfDisconnected();
        }
        // Destroy all output junctions if they are not connected to anything else
        for (int i = 0; i < outputJunctionControllers.Length; i++) {
            JunctionController jc = outputJunctionControllers[i];
            jc.junction.setInputModule(null);
            jc.destroyIfDisconnected();
        }
    }
}
