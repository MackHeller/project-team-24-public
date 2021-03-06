﻿using UnityEngine;
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
	public static void loadFourInputAndGate() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Create an XOR gate.
	/// Available gates: 	OR, NOT
	/// Difficulty: 		1/3
	/// Optimal Gates #:	2
	/// 
	/// HINT: How does XOR's truth table compare to an OR's?
	/// </summary>
	public static void loadXorGatePuzzle() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
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
	public static void loadAndIntoOrPuzzle() {
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
	public static void loadDoubleCircuitPuzzle() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}
}
