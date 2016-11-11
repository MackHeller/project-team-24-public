using UnityEngine;
using System.Collections.Generic;
using System;

	public class Module {
	/*
	 * Superclass of all modules. Modules can be gates, muxes, or
	 * any logic device. Wires are not modules.
	 * Modules can contain other modules.
	 * 
	 * TODO: modify interface and code to handle multiple inputs (wait on
	 * all inputs if existent), currently only one-to-many, need many-to-many.
	 * Looking for an efficient implementation via directed graphs.
	 */
	
	// The list of logicObject outputs
	protected IList<Wire> outputWires;
	protected IList<bool?> outputs;
	protected IList<bool?> inputs;
	protected int inputsSetCount;

	protected void initialize(int numInputs, int numOutputs) {
		inputs = new List<bool?> (numInputs);
		LogicUtil.initializeNullList (inputs, numInputs);

		outputs = new List<bool?> (numOutputs);
		LogicUtil.initializeNullList (outputs, numOutputs);

		outputWires = new List<Wire> (numOutputs);
		LogicUtil.initializeNullWireList (outputWires, numOutputs);

		inputsSetCount = 0;
	}

	public void setOutputAt(int outputIndex, Wire wire) {
		outputWires [outputIndex] = wire;
	}

	public void setInputAt(int inputIndex, bool? val) {
		if (inputs [inputIndex] == null && val != null) {
			inputsSetCount++;
		}
		inputs [inputIndex] = val;
	}

	// Notifies the module that an input set of boolean logic has arrived
	public void notifyInput (int inputIndex, bool? val) {
		setInputAt (inputIndex, val);
		if (inputsSetCount == inputs.Count) {
			notifyOutput (applyLogic (inputs));
		}
	}

	// Applys the module's logic to the input list of booleans
	virtual protected IList<bool?> applyLogic(IList<bool?> inputs) {
		throw new NotImplementedException();
	}

	// Notifies the output LogicObjects of a set of inputs
	virtual protected void notifyOutput (IList<bool?> outputList) {
		throw new NotImplementedException();
	}

    public string getName()
    {
        //TODO
        return "Name";
    }

    public int getAmount()
    {
        //TODO
        return -1;
    }
}