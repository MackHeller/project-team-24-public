using UnityEngine;
using System.Collections.Generic;
using System;

	public class Module : LogicObject {
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
	protected IList<LogicObject> outputs;
	protected IList<bool> inputs;

	// Limitations for input/outputs. Not for all modules, may abstract to
	// a separate class.
	protected int inputBoolCount;
	protected int outputObjectCount;

	public void setOutputs(IList<LogicObject> outputObjects) {
		outputs = outputObjects;
	}

	public void setInputs(IList<bool> inputBools) {
		inputs = inputBools;
	}

	// Notifies the module that an input set of boolean logic has arrived
	public void notifyInput (IList<bool> inputList) {
		if (inputList.Count != inputBoolCount || outputs.Count != outputObjectCount) {
			throw new System.ArgumentOutOfRangeException ();
		}
		notifyOutput (applyLogic(inputList));
	}

	// Applys the module's logic to the input arraylist of booleans
	virtual public IList<bool> applyLogic(IList<bool> inputs) {
		throw new NotImplementedException();
	}

	// Notifies the output LogicObjects of a set of inputs
	virtual public void notifyOutput (IList<bool> outputList) {
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