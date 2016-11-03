using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using C5;

public interface LogicObject {
	/*
	 * A LogicObject can be notified about an ordered set of 
	 * boolean inputs and notifies an ordered set of outputs.
	 * 
	 * TODO: consider if there's a better set object than arraylist.
	 */

	ArrayList<bool> notify_input (ArrayList<bool> input_set);

	void notify_output (ArrayList<LogicObject> outputObjects);
}
