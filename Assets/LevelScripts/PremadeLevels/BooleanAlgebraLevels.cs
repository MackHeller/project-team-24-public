using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Class for loading levels which require knowledge of boolean laws and identities
/// to solve (DeMorgan's, Simplification, Consensus, etc)
/// </summary>
public class BooleanAlgebraLevels {
	/*
	 * TODO: adjust after level editor is completed, require for proper implementation
	 * of these functions.
	 */ 

	/// <summary>
	/// Create a NOR gate with only AND and NOT gates.
	/// Requires the use of DeMorgan's laws.
	/// 
	/// Available gates: 	AND, NOT
	/// Difficulty: 		1/3
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
	/// Difficulty: 		2/3
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

	/// <summary>
	/// Construct an equivalent circuit f = x + (x! * y).
	/// You should try to use only 1 gate.
	/// 
	/// Available gates: 	AND, NOT
	/// Difficulty: 		2/3
	/// Optimal Gates #:	1
	/// 
	/// HINT: Recall the simplification law.
	/// </summary>
	public void loadSimplification1() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Construct an equivalent circuit to f = x * y + x! * z + y * z.
	/// You should try to use 4 gates.
	/// 
	/// Available gates: 	AND, NOT
	/// Difficulty: 		3/3
	/// Optimal Gates #:	4
	/// 
	/// HINT: Recall the consensus law.
	/// </summary>
	public void loadConsensus1() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}
}
