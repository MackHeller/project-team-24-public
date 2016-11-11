using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class LogicManager {
	/*
	 * Manages the backend logic of all logicObjects in a level.
	 */

	// hashtable of wires and modules for accessibility
	Hashtable wires;
	int wireCount;
	Hashtable modules;
	int moduleCount;

	// wires which serve as input and output
	private IList<Wire> inputs;
	private IList<Wire> outputs;

	// boolean inputs when level is run and expected boolean output
	private IList<bool?> inputLogic;
	private IList<bool?> expectedOutputLogic;

	// the number of set input and outputs, used to check when running
	private int notNullInputCount;
	private int notNullOutputCount;

	public LogicManager(int inputCount, int outputCount) {
		wires = new Hashtable ();
		wireCount = 0;
		modules = new Hashtable ();
		moduleCount = 0;

		// The input and output wires are not stored in the hashtable
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

	/// <summary>
	/// Loads the logic of the level from the input wires and runs
	/// the level. The results can be checked at the output wires.
	/// </summary>
	public void run() {
		if (notNullInputCount < inputLogic.Count) {
			throw new ArgumentException ("Need more input values");
		}
		for (int i = 0; i < inputs.Count; i++) {
			inputs [i].notifyInput (inputLogic[i]);
		}
	}

	/// <summary>
	/// Checks whether the output logic is equivalent to what is expected.
	/// </summary>
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

	/// <summary>
	/// Sets the logic of an input wire.
	/// </summary>
	/// <param name="index">index of the input wire to be modified.</param>
	/// <param name="val">nullable boolean to set the input wire's value to.</param>
	public void setInputLogicAt(int index, bool? val) {
		if (0 > index || index > inputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}
		if (inputLogic [index] == null) {
			notNullInputCount++;
		}
		inputLogic [index] = val;
	}

	/// <summary>
	/// Sets the logic that the logicManager expects from an output wire when 
	/// checking.
	/// </summary>
	/// <param name="index">index of the output wire to be modified.</param>
	/// <param name="val">nullable boolean to set the output wire's expected 
	/// boolean value to.</param>
	public void setExpectedOutputLogicAt(int index, bool? val) {
		if (0 > index || index > outputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}
		if (expectedOutputLogic [index] == null) {
			notNullOutputCount++;
		}
		expectedOutputLogic [index] = val;
	}

	/// <summary>
	/// Returns an input wire object.
	/// </summary>
	/// <param name="index">index of the input wire to be returned.</param>
	public Wire getInputWireAt(int index) {
		if (0 > index || index > inputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}
		return inputs [index];
	}

	/// <summary>
	/// Returns an output wire object.
	/// </summary>
	/// <param name="index">index of the output wire to be returned.</param>
	public Wire getOutputWireAt(int index) {
		if (0 > index || index > outputs.Count - 1) {
			throw new IndexOutOfRangeException ();
		}
		return outputs [index];
	}

	/// <summary>
	/// Adds a wire to this LogicManager.
	/// </summary>
	/// <param name="wire">the wire to be added.</param>
	public Wire addWire(Wire wire) {
		wire.setId (wireCount);
		wires.Add (wireCount, wire);
		wireCount++;
		return wire;
	}

	/// <summary>
	/// Returns a wire from this LogicManager.
	/// </summary>
	/// <param name="wireId">the id of the wire to be returned.</param>
	public Wire getWireAtId (int wireId) {
		if (wires.ContainsKey (wireId)) {
			return (Wire) wires [wireId];
		} else
			throw new ArgumentException ();
	}

	/// <summary>
	/// Removes a wire from this LogicManager.
	/// </summary>
	/// <param name="wireId">the id of the wire to be removed.</param>
	public void removeWireAtId (int wireId) {
		if (wires.ContainsKey (wireId)) {
			wires.Remove (wireId);
		} else
			throw new ArgumentException ();
	}

	/// <summary>
	/// Returns whether the LogicManager contains a wire with a certain id.
	/// </summary>
	/// <param name="wireId">the id of the wire to check.</param>
	public bool containsWireAtId(int wireId) {
		return wires.ContainsKey (wireId);
	}

	/// <summary>
	/// Adds a module to this LogicManager.
	/// </summary>
	/// <param name="module">the module to be added.</param>
	public Module addModule(Module module) {
		module.setId (moduleCount);
		modules.Add (moduleCount, module);
		moduleCount++;
		return module;
	}

	/// <summary>
	/// Returns a module from this LogicManager.
	/// </summary>
	/// <param name="wireId">the id of the module to be returned.</param>
	public Module getModuleAtId (int moduleId) {
		if (modules.ContainsKey (moduleId)) {
			return (Module) modules [moduleId];
		} else
			throw new ArgumentException ();
	}

	/// <summary>
	/// Removes a module from this LogicManager.
	/// </summary>
	/// <param name="moduleId">the id of the module to be removed.</param>
	public void removeModuleAtId(int moduleId) {
		if (modules.ContainsKey (moduleId)) {
			modules.Remove (moduleId);
		} else
			throw new ArgumentException ();
	}

	/// <summary>
	/// Returns whether the LogicManager contains a module with a certain id.
	/// </summary>
	/// <param name="wireId">the id of the module to check.</param>
	public bool containsModuleAtId(int moduleId) {
		return modules.ContainsKey (moduleId);
	}
}