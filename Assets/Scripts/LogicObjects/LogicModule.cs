using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Superclass of all modules. Modules can be gates, muxes, or
/// any logic device, including wires and terminals.
/// Modules can contain other modules.
/// </summary>
public abstract class LogicModule : LogicObject {

    protected IList<bool?> inputValues;
    protected IList<Junction> inputJunctions;
    protected IList<Junction> outputJunctions;
    private int numInputs;
    private int numOutputs;

    protected LogicModule(int numInputs, int numOutputs) {
        this.numInputs = numInputs;
        this.numOutputs = numOutputs;

        inputValues = new List<bool?>(numInputs);
        inputJunctions = new List<Junction>(numInputs);
        for (int i = 0; i < numInputs; i++) {
            inputJunctions.Add(null);
            inputValues.Add(null);
            setInputJunction(i, new Junction());
        }

        outputJunctions = new List<Junction>(numOutputs);
        for (int i = 0; i < numOutputs; i++) {
            Junction output = new Junction();
            output.setInputModule(this);
            outputJunctions.Add(output);
        }

    }

    public int getInputCount() {
        return numInputs;
    }

    public int getOutputCount() {
        return numOutputs;
    }

    public void setInputAt(int inputIndex, bool? value) {
        if (inputValues[inputIndex] != value) {
            inputValues[inputIndex] = value;
            notifyOutputs();
        }
    }

    public bool? getOutputAt(int outputIndex) {
        return outputJunctions[outputIndex].getValue();
    }

    public Junction getInputJunction(int inputIndex) {
        return inputJunctions[inputIndex];
    }

    public void setInputJunction(int inputIndex, Junction inputJunction) {
        if (inputJunctions[inputIndex] != null) {
            inputJunctions[inputIndex].removeObserver(this, inputIndex);
        }
        inputJunctions[inputIndex] = inputJunction;
        if (inputJunction != null) {
            inputJunction.addObserver(this, inputIndex);
            setInputAt(inputIndex, inputJunction.getValue());
        }
    }

    public Junction getOutputJunction(int outputIndex) {
        return outputJunctions[outputIndex];
    }

    public void setOutputJunction(int outputIndex, Junction outputJunction) {
        if (outputJunctions[outputIndex] != null) {
            outputJunctions[outputIndex].setInputModule(null);
        }
        outputJunctions[outputIndex] = outputJunction;
        if (outputJunction != null) {
            outputJunction.setInputModule(this);
            notifyOutput(outputIndex);
        }
    }

    protected void notifyOutput(int outputIndex) {
        outputJunctions[outputIndex].setValue(applyLogic(inputValues)[outputIndex]);
    }

    // Notifies the module that an input set of boolean logic has arrived
    protected void notifyOutputs() {
        IList<bool?> outputValues = applyLogic(inputValues);
        for (int i = 0; i < outputValues.Count; i++) {
            outputJunctions[i].setValue(outputValues[i]);
        }
    }

    // Applys the module's logic to the input list of booleans
    protected abstract IList<bool?> applyLogic(IList<bool?> inputs);

    public string getName() {
        //TODO
        return "Name";
    }

    public int getAmount() {
        //TODO
        return -1;
    }
}