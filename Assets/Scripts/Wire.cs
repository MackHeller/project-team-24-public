using UnityEngine;
using System.Collections;
using C5;
using System;

public class Wire : LogicObject {
	/*
	 * A wire which takes one input and can have several outputs.
	 */

	// The list of boolean inputs that the module takes in
	bool input;

	// The list of boolean outputs that the module outputs
	ArrayList<bool> outputs;

    public ArrayList<bool> notify_input(ArrayList<bool> input_set)
    {
        throw new NotImplementedException();
    }

    public void notify_output(ArrayList<LogicObject> outputObjects)
    {
        throw new NotImplementedException();
    }
}
