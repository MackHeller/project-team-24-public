using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// An many-to-one XOR gate.
/// </summary>
public class GateNxor : GateXor {

    public GateNxor(int numInputs) : base(numInputs) {

    }

    public override string getName() {
        return "Nxor";
    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        return LogicUtil.oneBoolList(!base.applyLogic(inputs)[0]);
    }
}
