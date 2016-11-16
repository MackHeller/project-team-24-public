using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// A wire which takes one input and can have several outputs.
/// </summary>
public class Wire : LogicModule {

    public Wire() : base(1, 1) {

    }

    public void setInput(bool? value) {
        setInputAt(0, value);
    }

    public bool? getOutput() {
        return getOutputAt(0);
    }

    public Junction getInputJunction() {
        return getInputJunction(0);
    }

    public void setInputJunction(Junction inputJunction) {
        setInputJunction(0, inputJunction);
    }

    public Junction getOutputJunction() {
        return getOutputJunction(0);
    }

    public void setOutputJunction(Junction outputJunction) {
        setOutputJunction(0, outputJunction);
    }

    protected void notifyOutput() {
        notifyOutput(0);
    }

    protected override IList<bool?> applyLogic(IList<bool?> inputs) {
        return new List<bool?>(1) { inputs[0] };
    }
}
