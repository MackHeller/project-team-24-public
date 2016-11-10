using UnityEngine;
using System;
using System.Collections.Generic;

public interface LogicObject {
	/*
	 * A LogicObject can be notified about an ordered set of 
	 * boolean inputs and notifies an ordered set of outputs
	 * 
	 * Not currently in use, but likely will be in the future.
	 */

	void notifyInput (IList<bool> inputList);

	void notifyOutput (IList<bool> outputList);
}
