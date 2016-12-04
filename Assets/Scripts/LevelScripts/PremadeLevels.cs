using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Class for loading premade levels. Follows the Singleton Design Pattern.
/// </summary>
public class PremadeLevels : MonoBehaviour{
	
	public GameObject inputPrefab;
	public GameObject outputPrefab;
	public GameObject canvas;
	private float canvasWidth;
	private float canvasHeight;

	// the bottom-left x, y, z coordinates of the canvas shown on screen
	private Vector3 canvasStart;

	// singleton instance of PremadeLevels
	private static PremadeLevels _instance;

	public static PremadeLevels getPremadeLevels() {
		return _instance;
	}

	void Awake() {
		_instance = this;
		canvasWidth = canvas.GetComponent<RectTransform> ().rect.width;
		canvasHeight = canvas.GetComponent<RectTransform> ().rect.height;
		Vector3 canvasPos = canvas.transform.position;
		canvasStart = new Vector3 (canvasPos.x - canvasWidth / 2, canvasPos.y - canvasHeight / 2, 0);
	}

	/// <summary>
	/// Instantiates an input at the left of the screen, at a  location
	/// based on its input. More lightweight than instantiateInputAt.
	/// </summary>
	/// <param name="index">between 1-8</param>
	public GameObject instantiateInputAtIndex (int index) {
		return this.instantiateInputAt (canvasWidth / 4, canvasHeight / 8 * index - canvasHeight / 6);
	}

	/// <summary>
	/// Instantiates an output at the left of the screen, at a  location
	/// based on its input. More lightweight than instantiateOutputAt.
	/// </summary>
	/// <param name="index">between 1-8</param>
	public GameObject instantiateOutputAtIndex (int index) {
		return this.instantiateOutputAt (canvasWidth / 8 * 7, canvasHeight / 8 * index - canvasHeight / 6);
	}

	/// <summary>
	/// Instantiates an input at x, y coordinates.
	/// </summary>
	private GameObject instantiateInputAt (float x, float y) {
		GameObject newPrefab = Instantiate (inputPrefab);
		newPrefab.transform.position = new Vector3 (canvasStart.x + x, canvasStart.y + y, 0);
		return newPrefab;
	}

	/// <summary>
	/// Instantiates an output at x, y coordinates.
	/// </summary>
	private GameObject instantiateOutputAt (float x, float y) {
		GameObject newPrefab = Instantiate (outputPrefab);
		newPrefab.transform.position = new Vector3 (canvasStart.x + x, canvasStart.y + y, 0);
		return newPrefab;
	}

	/// <summary>
	/// Create a 4-input AND gate with only 2-input and gates.
	/// Available gates: 	AND
	/// Difficulty: 		1/3
	/// Optimal Gates #:	3
	/// </summary>
	public void loadFourInputAndGate() {

		instantiateInputAtIndex (2);
		instantiateInputAtIndex (4);
		instantiateInputAtIndex (6);
		instantiateInputAtIndex (8);

		instantiateOutputAtIndex (5);
	}

	/// <summary>
	/// Create an XOR gate.
	/// Available gates: 	OR, NOT
	/// Difficulty: 		1/3
	/// Optimal Gates #:	2
	/// </summary>
	public void loadXorGatePuzzle() {
		instantiateInputAtIndex (4);
		instantiateInputAtIndex (6);

		instantiateOutputAtIndex (5);
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
	/// </summary>
	public void loadXorGatePuzzle() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Create a circuit that simulates the behaviour of
	/// f = a * b + (b + c)
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
	/// Difficulty: 		3/3
	/// Optimal Gates #:	2
	/// </summary>
	public void loadXorGatePuzzle() {
		/*
		 * Waiting on the completion of LevelEditor to implement.
		 */
		throw new NotImplementedException ();
	}


}
