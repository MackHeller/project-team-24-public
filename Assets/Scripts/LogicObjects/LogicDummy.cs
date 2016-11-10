using UnityEngine;
using System.Collections.Generic;
using System;

public class LogicDummy : Module {
	/*
	 * A dummy logic object which holds logic.
	 */

	public LogicDummy() {
		initialize (1, 1);
	}

	public IList<bool?> getOutputs() {
		return outputs;
	}

	public IList<bool?> getInputs() {
		return inputs;
	}

	// Notifies the module that an input set of boolean logic has arrived
	public void notifyInput (IList<bool?> inputList) {
		inputs = inputList;
	}

	// Applys the module's logic to the input arraylist of booleans
	virtual public IList<bool> applyLogic(IList<bool> inputs) {
		throw new NotImplementedException();
	}

	// Notifies the output LogicObjects of a set of inputs
	virtual public void notifyOutput (IList<bool> outputList) {
		throw new NotImplementedException();
	}
}