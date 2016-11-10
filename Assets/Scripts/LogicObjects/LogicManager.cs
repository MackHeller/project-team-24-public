using UnityEngine;
using System.Collections.Generic;
using System;

public class LogicManager {
	/*
	 * Class containing utility function for LogicObjects.
	 */

	private IList<Wire> inputs;
	private IList<Wire> outputs;
	private IList<bool?> expectedOutputLogic;

	public LogicManager(int inputCount, int outputCount, IList<bool?> expectedOutLogic) {
		if (outputCount != expectedOutLogic.Count) {
			throw new ArgumentException ();
		}

		inputs = new List<Wire> ();
		LogicUtil.initializeWireList (inputs, inputCount);
		outputs = new List<Wire> ();
		LogicUtil.initializeWireList (outputs, inputCount);
		expectedOutputLogic = expectedOutLogic;
	}
	
	public void setExpectedOutputLogic(IList<bool?> expectedOutLogic) {
		expectedOutputLogic = expectedOutLogic;
	}

	public Wire getInputWireAt(int index) {
		if (0 > index || index > inputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}

		return inputs [index];
	}

	public Wire getOutputWireAt(int index) {
		if (0 > index || index > outputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}

		return outputs [index];
	}

	public void setLogicAtInput(int index, bool? val) {
		if (0 > index || index > inputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}

		inputs [index].notifyInput (val);
	}

	// compares logic outputs and expected logic one-by-one
	public bool checkIfOutputIsCorrect() {
		if (outputs.Count != expectedOutputLogic.Count) {
			throw new ArgumentException ();
		}

		for (int i = 0; i < outputs.Count; i++) {
			if (outputs [i].getInput() != expectedOutputLogic [i]) {
				return false;
			}
		}
		return true;
	}
}