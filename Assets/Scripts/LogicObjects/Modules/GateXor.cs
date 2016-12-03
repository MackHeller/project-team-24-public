using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// An many-to-one XOR gate.
/// </summary>
public class GateXor : LogicModule {

    public GateXor(int numInputs) : base(numInputs, 1) {

    }

    public override string getName() {
        return "Xor";
    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        bool? output = inputs[0];
        for (int i = 1; i < inputs.Count; i++) {
            if (output == null || inputs[i] == null) {
                return LogicUtil.oneBoolList(null);
            } else {
                output = output.Value ^ inputs[i].Value;
            }
            //output = output ^ inputs[i];
        }
        return LogicUtil.oneBoolList(output);
    }
}
