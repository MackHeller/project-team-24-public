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

	public void setOutputs(IList<LogicObject> outputObjects) {
		outputs = outputObjects;
	}

	public IList<LogicObject> getOutputs() {
		return outputs;
	}

	public void setInput(bool boolean) {
		input = boolean;
	}

	public bool getInput() {
		return input;
	}

	public void notifyInput(IList<bool> inputList)
    {
		if (inputList.Count != 1) {
			throw new ArgumentException ();
		}
		setInput (inputList [0]);
		notifyOutput (inputList);
    }

	/*
	 * Notifies each of the objects that the wire leads to that logic 
	 * is being sent.
	 * 
	 * @param outputList: list of LogicObjects that the wire leads to
	 */
	public void notifyOutput (IList<bool> outputList)
    {
		for (int i = 0; i < outputList.Count; i++) {
			outputs[i].notifyInput (LogicUtil.oneBoolList (outputList [i]));
		}
    }
}
