using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// A wire which takes one input and can have several outputs.
/// </summary>
public class Wire : LogicObject {

    // The boolean input that the wire takes in
    protected bool? boolVal;

    // The list of boolean outputs that is wired to and their
    // input indexes. Would use a map, can't find atm.
    protected IList<Module> outputs;
    protected IList<int> outputsInputIndices;

    public Wire() {
        outputs = new List<Module>();
        outputsInputIndices = new List<int>();
    }

    public void addOutput(Module outputObject, int wiredToIndex) {
        outputs.Add(outputObject);
        outputsInputIndices.Add(wiredToIndex);
    }

    public IList<Module> getOutputs() {
        return outputs;
    }

    public void setInput(bool? boolean) {
        boolVal = boolean;
    }

    public bool? getBooleanValue() {
        return boolVal;
    }

    public void notifyInput(bool? givenInput) {
        setInput(givenInput);
        notifyOutput(givenInput);
    }

    /// <summary>
	/// Notifies each of the objects that the wire leads to that logic 
	/// is being sent.
	/// </summary>
	/// <param name="givenInput">true if given list of LogicObjects that the wire leads to</param>
    protected void notifyOutput(bool? givenInput) {
        for (int i = 0; i < outputs.Count; i++) {
            int objectInputIndex = outputsInputIndices[i];
            outputs[i].notifyInput(objectInputIndex, givenInput);
        }
    }
}
