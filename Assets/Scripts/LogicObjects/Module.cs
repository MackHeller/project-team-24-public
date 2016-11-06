using UnityEngine;
using System.Collections.Generic;
using System;

	public class Module : LogicObject {
	/*
	 * Superclass of all modules. Modules can be gates, muxes, or
	 * any logic device. Wires are not modules.
	 * Modules can contain other modules.
	 */
	
	// The list of logicObject outputs
	protected IList<LogicObject> outputs;
	protected int input_bool_count;
	protected int output_object_count;

	public void set_outputs(IList<LogicObject> outputObjects) {
		if (outputObjects.Count != output_object_count) {
			throw new System.ArgumentOutOfRangeException ();
		}
		outputs = outputObjects;
	}

	// Notifies the module that an input set of boolean logic has arrived
	public void notify_input (IList<bool> input_set) {
		if (input_set.Count != input_bool_count || outputs.Count != output_object_count) {
			throw new System.ArgumentOutOfRangeException ();
		}
		notify_output (apply_logic(input_set));
	}

	// Applys the module's logic to the input arraylist of booleans
	virtual public IList<LogicObject> apply_logic(IList<bool> inputs) {
		throw new NotImplementedException();
	}

	// Notifies the output LogicObjects of a set of inputs
	virtual public void notify_output (IList<LogicObject> outputObjects) {
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