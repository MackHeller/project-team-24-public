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
	protected int input_bool_count;
	protected int output_object_count;

	public void set_outputs(IList<LogicObject> outputObjects) {
		outputs = outputObjects;
	}

	// Notifies the module that an input set of boolean logic has arrived
	public void notify_input (IList<bool> input_list) {
		if (input_list.Count != input_bool_count || outputs.Count != output_object_count) {
			throw new System.ArgumentOutOfRangeException ();
		}
		notify_output (apply_logic(input_list));
	}

	// Applys the module's logic to the input arraylist of booleans
	virtual public IList<bool> apply_logic(IList<bool> inputs) {
		throw new NotImplementedException();
	}

	// Notifies the output LogicObjects of a set of inputs
	virtual public void notify_output (IList<bool> output_list) {
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