using UnityEngine;
using System.Collections.Generic;
using System;

public class Wire : LogicObject {
	/*
	 * A wire which takes one input and can have several outputs.
	 */

	// The boolean input that the wire takes in
	bool input;

	// The list of boolean outputs that is wired to
	IList<bool> outputs;

	public void notify_input(IList<bool> input_set)
    {
        throw new NotImplementedException();
    }

    public void notify_output(IList<LogicObject> outputObjects)
    {
        throw new NotImplementedException();
    }
}
