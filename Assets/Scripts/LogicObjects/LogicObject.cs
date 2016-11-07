using UnityEngine;
using System;
using System.Collections.Generic;

public interface LogicObject {
	/*
	 * A LogicObject can be notified about an ordered set of 
	 * boolean inputs and notifies an ordered set of outputs
	 */

	void notify_input (IList<bool> input_list);

	void notify_output (IList<bool> output_list);
}
