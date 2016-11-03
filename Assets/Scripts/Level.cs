using UnityEngine;
using System.Collections;
using C5;

public class Level {
	/*
	 * A puzzle level. After giving a set of inputs to a
	 * set of LogicObjects, it expects a set of outputs
	 * and compares whether the set of outputs is correct.
	 */

	protected ArrayList<LogicObject> inputs;

	// TODO: consider ramifications and modify.
	protected ArrayList<bool> expectedOutputs;
}
