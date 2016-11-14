using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/// <summary>
/// An many-to-one AND gate.
/// </summary>
public class GateAND : Module {

    // Constructor called by the factory method
    public GateAND(int numInputs) {
        initialize(numInputs, 1);
    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        bool? output = inputs[0];
        for (int i = 1; i < inputs.Count; i++) {
            output = output & inputs[i];
        }
        return LogicUtil.oneBoolList(output);
    }

    // Notifies the output LogicObjects of a set of inputs
    override protected void notifyOutput(IList<bool?> outputList) {
        outputWires[0].notifyInput(outputList[0]);
    }
}