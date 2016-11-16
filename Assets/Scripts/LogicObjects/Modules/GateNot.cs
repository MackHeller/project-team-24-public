using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/// <summary>
/// An one-to-one NOT gate.
/// </summary>
public class GateNot : LogicModule {

    // Constructor called by the factory method
    public GateNot() : base(1, 1) {

    }

    // Applys the module's logic to the input list of booleans
    override protected IList<bool?> applyLogic(IList<bool?> inputs) {
        return new List<bool?>(1) { !inputs[0] };
    }
}