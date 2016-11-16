using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/// <summary>
/// An many-to-one AND gate.
/// </summary>
public class GateAnd : LogicModule {

    // Constructor called by the factory method
    public GateAnd(int numInputs) : base(numInputs, 1) {

    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        bool? output = inputs[0];
        for (int i = 1; i < inputs.Count; i++) {
            if (output != true)
                break;
            output = output & inputs[i];
        }
        return LogicUtil.oneBoolList(output);
    }
}