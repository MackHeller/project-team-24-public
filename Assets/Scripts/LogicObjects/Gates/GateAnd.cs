using UnityEngine;
using System;
using System.Collections.Generic;

public class GateAnd : Module {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Applys the module's logic to the input arraylist of booleans
	override public IList<LogicObject> apply_logic(IList<bool> inputs) {
		throw new NotImplementedException();
	}

	// Notifies the output LogicObjects of a set of inputs
	override public void notify_output (IList<LogicObject> outputObjects) {
		throw new NotImplementedException();
	}
}
