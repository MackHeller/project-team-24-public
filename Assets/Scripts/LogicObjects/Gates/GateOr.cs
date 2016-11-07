using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GateOr : Module {
	/*
	 * An many-to-one AND gate.
	 * 
	 * TODO: adjust module to wait on multiple inputs.
	 */

	// Constructor called by the factory method
	public GateOr (int num_inputs, IList<LogicObject> output_objects) {
		input_bool_count = num_inputs;
		output_object_count = 1;
		if (output_objects.Count > 1) {
			throw new ArgumentException ();
		}
		outputs = output_objects;
	}

	// Applys the module's logic to the input arraylist of booleans
	override public IList<bool> apply_logic(IList<bool> inputs) {
		bool output = inputs [0];
		for (int i = 1; i < inputs.Count; i++) {
			output = output | inputs [i];
		}
		List<bool> ls = new List<bool> ();
		ls.Add (output);
		return ls;
	}

	// Notifies the output LogicObjects of a set of inputs
	override public void notify_output (IList<bool> output_list) {
		outputs [0].notify_input (output_list);
	}
}
