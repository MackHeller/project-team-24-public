using UnityEngine;
using System.Collections;

/// <summary>
/// Class for loading premade levels.
/// </summary>
public class PremadeLevels : MonoBehaviour{

	public GameObject inputPrefab;
	public GameObject outputPrefab;
	public GameObject canvas;
	private float canvasWidth;
	private float canvasHeight;

	// the bottom-left x, y, z coordinates of the canvas shown on screen
	private Vector3 canvasStart;

	void Start() {
		canvasWidth = canvas.GetComponent<RectTransform> ().rect.width;
		canvasHeight = canvas.GetComponent<RectTransform> ().rect.height;
		Vector3 canvasPos = canvas.transform.position;
		canvasStart = new Vector3 (canvasPos.x - canvasWidth / 2, canvasPos.y - canvasHeight / 2, 0);

		this.loadFourInputAndGate ();
	}

	/// <summary>
	/// Instantiates an input at the left of the screen, at a  location
	/// based on its input. More lightweight than instantiateInputAt.
	/// </summary>
	/// <param name="index">between 1-8</param>
	private GameObject instantiateInputAtIndex (int index) {
		return instantiateInputAt (canvasWidth / 4, canvasHeight / 8 * index - canvasHeight / 6);
	}

	/// <summary>
	/// Instantiates an output at the left of the screen, at a  location
	/// based on its input. More lightweight than instantiateOutputAt.
	/// </summary>
	/// <param name="index">between 1-8</param>
	private GameObject instantiateOutputAtIndex (int index) {
		return instantiateOutputAt (canvasWidth / 8 * 7, canvasHeight / 8 * index - canvasHeight / 6);
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
	/// Create an XOR gate.
	/// Available gates: 	OR, NOT
	/// Difficulty: 		1
	/// </summary>
	public void loadXorGatePuzzle() {
		instantiateInputAtIndex (4);
		instantiateInputAtIndex (6);

		instantiateOutputAtIndex (5);
	}

	/// <summary>
	/// Create a 4-input AND gate with only 2-input and gates.
	/// Available gates: 	AND
	/// Difficulty: 		1
	/// </summary>
	public void loadFourInputAndGate() {
		instantiateInputAtIndex (2);
		instantiateInputAtIndex (4);
		instantiateInputAtIndex (6);
		instantiateInputAtIndex (8);

		instantiateOutputAtIndex (5);
	}
}
