using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// A many-to-one OR gate.
/// </summary>
public class GateOR : LogicModule {

    public GateOR(int numInputs) : base(numInputs, 1) {

    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        bool? output = inputs[0];
        for (int i = 1; i < inputs.Count; i++) {
            if (output == true)
                break;
            output = output | inputs[i];
        }
        return LogicUtil.oneBoolList(output);
    }
}
