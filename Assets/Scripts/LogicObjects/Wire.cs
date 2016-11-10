using UnityEngine;
using System.Collections.Generic;
using System;

public class Wire : LogicObject {
	/*
	 * A wire which takes one input and can have several outputs.
	 */

	// The boolean input that the wire takes in
	private bool input;

	// The list of boolean outputs that is wired to
	private IList<LogicObject> outputs;


	public void notifyInput(IList<bool> inputList)
    {
		if (inputList.Count != 1) {
			throw new ArgumentException ();
		}
		input = inputList [0];
		notify_output (inputList);
    }

	/*
	 * Notifies each of the objects that the wire leads to that logic 
	 * is being sent.
	 * 
	 * @param output_list: list of LogicObjects that the wire leads to
	 */
	public void notify_output(IList<bool> output_list)
    {
		for (int i = 0; i < output_list.Count; i++) {
			obj.notifyInput (LogicUtil.oneBoolList (output_list [i]));
		}
    }
}
