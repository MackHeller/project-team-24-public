using UnityEngine;
using System.Collections;
using C5;
using System;

public class Module : LogicObject {
	/*
	 * Superclass of all modules. Modules can be gates, muxes, or
	 * any logic device.
	 * Modules can contain other modules.
	 * 
	 * Will potentially change into an interface.
	 */
	
	// The list of logicObject outputs
	protected ArrayList<LogicObject> outputs;

	void set_outputs(ArrayList<LogicObject> outputObjects) {
		outputs = outputObjects;
	}

	// Notifies the module that an input set of boolean logic has arrived
	void notify_input (ArrayList<bool> input_set) {
		notify_output (apply_logic(input_set));
	}

	// Applys the module's logic to the input arraylist of booleans
	ArrayList<LogicObject> apply_logic(ArrayList<bool> inputs) {
        return null;
	}

	// Notifies the output LogicObjects of a set of inputs
	void notify_output (ArrayList<LogicObject> outputObjects) {

	}

    ArrayList<bool> LogicObject.notify_input(ArrayList<bool> input_set)
    {
        throw new NotImplementedException();
    }

    void LogicObject.notify_output(ArrayList<LogicObject> outputObjects)
    {
        throw new NotImplementedException();
    }
}