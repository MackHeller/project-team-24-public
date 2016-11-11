using UnityEngine;
using System.Collections.Generic;
using System;

public class LogicManager {
	/*
	 * Class containing utility function for LogicObjects.
	 */

	private IList<Wire> inputs;
	private IList<Wire> outputs;
	private IList<bool?> inputLogic;
	private IList<bool?> expectedOutputLogic;

	private int notNullInputCount;
	private int notNullOutputCount;

	public LogicManager(int inputCount, int outputCount) {

		inputs = new List<Wire> (inputCount);
		LogicUtil.initializeWireList (inputs, inputCount);
		outputs = new List<Wire> (outputCount);
		LogicUtil.initializeWireList (outputs, outputCount);

		inputLogic = new List<bool?> (inputCount);
		LogicUtil.initializeNullList (inputLogic, inputCount);
		expectedOutputLogic = new List<bool?> (outputCount);
		LogicUtil.initializeNullList (expectedOutputLogic, outputCount);

		notNullInputCount = 0;
		notNullOutputCount = 0;
	}

	public void setInputLogicAt(int index, bool? val) {
		if (0 > index || index > inputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}
		if (inputLogic [index] == null) {
			notNullInputCount++;
		}
		inputLogic [index] = val;
	}

	public void setExpectedOutputLogicAt(int index, bool? val) {
		if (0 > index || index > outputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}
		if (expectedOutputLogic [index] == null) {
			notNullOutputCount++;
		}
		expectedOutputLogic [index] = val;
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

	// loads logic into wires and lets the circuit run
	public void run() {
		if (notNullInputCount < inputLogic.Count) {
			throw new ArgumentException ("Need more input values");
		}
		for (int i = 0; i < inputs.Count; i++) {
			inputs [i].notifyInput (inputLogic[i]);
		}
	}

	// compares logic outputs and expected logic one-by-one
	public bool checkIfOutputIsCorrect() {
		if (notNullOutputCount < expectedOutputLogic.Count) {
			throw new ArgumentException ("Need more expected output values");
		}
		for (int i = 0; i < outputs.Count; i++) {
			if (outputs [i].getBooleanValue() != expectedOutputLogic [i]) {
				return false;
			}
		}
		return true;
	}
}