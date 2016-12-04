using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Class for loading basic premade levels (i.e. only require boolean algebra
/// and basic truth table knowledge to solve efficiently).
/// </summary>
public class BasicLevels {
	/*
	 * TODO: adjust after level editor is completed, require for proper implementation
	 * of these functions.
	 */ 

	/// <summary>
	/// Create a 4-input AND gate with only 2-input and gates.
	/// Available gates: 	AND
	/// Difficulty: 		1/3
	/// Optimal Gates #:	3
	/// 
	/// HINT: You can hook up the results of 2-input circuits into
	/// 	  another 2-input circuit.
	/// </summary>
	public void loadFourInputAndGate() {
		LevelCreationTool ltc = LevelCreationTool.getInstance ();

		ltc.instantiateInputAtIndex (2);
		ltc.instantiateInputAtIndex (4);
		ltc.instantiateInputAtIndex (6);
		ltc.instantiateInputAtIndex (8);

		ltc.instantiateOutputAtIndex (5);
	}

	/// <summary>
	/// Create an XOR gate.
	/// Available gates: 	OR, NOT
	/// Difficulty: 		1/3
	/// Optimal Gates #:	2
	/// 
	/// HINT: How does XOR's truth table compare to an OR's?
	/// </summary>
	public void loadXorGatePuzzle() {
		LevelCreationTool ltc = LevelCreationTool.getInstance ();

		ltc.instantiateInputAtIndex (4);
		ltc.instantiateInputAtIndex (6);

		ltc.instantiateOutputAtIndex (5);
	}

	/// <summary>
	/// Create a circuit with 3 inputs, which requires 
	/// an AND gates into an OR gate.
	/// 
	/// OR 	AND	Result
	/// 0	00	0
	/// 0  	01	0
	/// 0  	10	0
	/// 0  	11	1
	/// 1  	00	1
	/// 1  	01	1
	/// 1  	10	1
	/// 1	11	1
	/// 
	/// Available gates: 	OR, NOT
	/// Difficulty: 		2/3
	/// Optimal Gates #:	2
	/// 
	/// HINT: You can hook up the results of 2-input circuits into
	/// 	  another 2-input circuit.
	/// </summary>
	public void loadAndIntoOrPuzzle() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Create a circuit that simulates the behaviour of
	/// f = a * b + (b + c)
	/// Note that b is used in both circuits.
	/// 
	/// a	b	c	a*b	b+c	f
	/// 0	0	0	0	0	0
	/// 0	0	1	0	1	1
	/// 0	1	0	0	1	1
	/// 0	1	1	0	1	1
	/// 1	0	0	0	0	0
	/// 1	0	1	0	1	1
	/// 1	1	0	1	1	1
	/// 1	1	1	1	1	1
	/// 
	/// Available gates: 	All gates.
	/// Difficulty: 		2/3
	/// Optimal Gates #:	3
	/// 
	/// HINT: Inputs can be used in multiple circuits
	/// </summary>
	public void loadDoubleCircuitPuzzle() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Create a NOR gate with only AND and NOT gates.
	/// Requires the use of DeMorgan's laws.
	/// 
	/// Available gates: 	AND, NOT
	/// Difficulty: 		2/3
	/// Optimal Gates #:	3
	/// 
	/// HINT: Recall DeMorgan's Law.
	/// </summary>
	public void loadDeMorgans1() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Consider 2 AND gates hooked into an OR gate and their
	/// state table.
	/// Create a circuit with only AND and NOT gates that simulates
	/// this behaviour.
	/// Requires DeMorgan's Law.
	/// 
	/// Available gates: 	AND, NOT
	/// Difficulty: 		3/3
	/// Optimal Gates #:	6
	/// 
	/// HINT: Recall DeMorgan's Law. Which gate(s) in this circuit
	/// 	  could it be applied to?
	/// </summary>
	public void loadDeMorgans2() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}
}
