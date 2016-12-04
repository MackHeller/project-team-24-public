using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// A many-to-one OR gate.
/// </summary>
public class GateNor : GateOr {

    public GateNor(int numInputs) : base(numInputs) {

    }

    public override string getName() {
        return "Nor";
    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        return LogicUtil.oneBoolList(!base.applyLogic(inputs)[0]);
    }
}
