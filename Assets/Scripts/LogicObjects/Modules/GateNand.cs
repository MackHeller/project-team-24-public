using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/// <summary>
/// An many-to-one AND gate.
/// </summary>
public class GateNand : GateAnd {

    // Constructor called by the factory method
    public GateNand(int numInputs) : base(numInputs) {

    }

    public override string getName() {
        return "Nand";
    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        return LogicUtil.oneBoolList(!base.applyLogic(inputs)[0]);
    }
}