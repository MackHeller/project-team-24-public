using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

public class PremadeJsonWriter {

	/// <summary>
	/// Creates a JSON file for the puzzle level FourInputAndGate.
	/// </summary>
	public static void createFourInputAndGate() {
		Level lv = new Level ();
		lv.setLevelName ("FourInputAndGate");
		lv.setCreator ("Freddy");
		lv.setMinScore (1);

		ArrayList<bool> arrIn = new ArrayList<bool>();
		arrIn.Add (true);
		arrIn.Add (true);
		arrIn.Add (true);
		arrIn.Add (true);
		lv.setLevelInput (arrIn);

		ArrayList<bool> arrOut = new ArrayList<bool> ();
		arrOut.Add (true);
		lv.setLevelOutput (arrOut);

		ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
		lv.setGates (gates);

		lv.saveLevel ();
	}

	/// <summary>
	/// Creates a JSON file for the puzzle level XorGatePuzzle.
	/// </summary>
	public static void createXorGate() {
		Level lv = new Level ();
		lv.setLevelName ("XorGatePuzzle");
		lv.setCreator ("Freddy");
		lv.setMinScore (1);

		ArrayList<bool> arrIn = new ArrayList<bool>();
		arrIn.Add (true);
		arrIn.Add (true);
		lv.setLevelInput (arrIn);

		ArrayList<bool> arrOut = new ArrayList<bool> ();
		arrOut.Add (false);
		lv.setLevelOutput (arrOut);

		ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
		lv.setGates (gates);

		lv.saveLevel ();
	}
}
