using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Class for loading premade levels. Follows the Singleton Design Pattern.
/// </summary>
public class LevelCreationTool : MonoBehaviour{
	/*
	 * TODO: adjust after level editor is completed, require for proper implementation
	 * of these functions.
	 */ 

	public GameObject inputPrefab;
	public GameObject outputPrefab;
	public GameObject canvas;
	private float canvasWidth;
	private float canvasHeight;

	// the bottom-left x, y, z coordinates of the canvas shown on screen
	private Vector3 canvasStart;

	// singleton instance of PremadeLevels
	private static LevelCreationTool _instance;

	public static LevelCreationTool getInstance() {
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
}
