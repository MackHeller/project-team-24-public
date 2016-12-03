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

	private GameObject instantiateInputAt (float x, float y) {
		GameObject newPrefab = Instantiate (inputPrefab);
		newPrefab.transform.position = new Vector3 (canvasStart.x + x, canvasStart.y + y, 0);
		return newPrefab;
	}

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
		
	}

	/// <summary>
	/// Create a 4-input AND gate with only 2-input and gates.
	/// Available gates: 	AND
	/// Difficulty: 		1
	/// </summary>
	public void loadFourInputAndGate() {
		
	}
}
