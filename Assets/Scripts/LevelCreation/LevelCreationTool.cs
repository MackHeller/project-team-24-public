using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Class for loading levels. Follows the Singleton Design Pattern.
/// </summary>
public class LevelCreationTool : MonoBehaviour{
	/*
	 * TODO: adjust after level editor is completed, require for proper implementation
	 * of these functions.
	 */ 

	// Input and output prefabs must be attached to LevelCreationTool in the scene in this implementation
	public GameObject inputPrefab;
	public GameObject outputPrefab;

	private float width;
	private float height;

	// the bottom-left x, y, z coordinates of the canvas shown on screen
	private Vector3 bottomLeft;

	// singleton instance of PremadeLevels
	private static LevelCreationTool _instance;

	public static LevelCreationTool getInstance() {
		return _instance;
	}

	void Awake() {
		_instance = this;
		width = 57.4f;
		height = 31.9f;
		bottomLeft = new Vector3 (0 - width / 2, 10 - height / 2, 0);
	}

	/// <summary>
	/// Instantiates the set of inputs/outputs from a level.
	/// 
	/// TODO: for whoever is working on the new 'LogicManager', hook these instantiated inputs/outputs up.
	/// 
	/// </summary>
	/// <param name="index">must have between 1-6 inputs and 1-6 outputs for current coordinates</param>
	public void LoadInputOutputFromLevel (Level level) {
		for (int i = 1; i < level.getLevelInput ().Count + 1; i++) {
			this.instantiateInputAtIndex (i);
		}
		for (int j = 1; j < level.getLevelOutput ().Count + 1; j++) {
			this.instantiateOutputAtIndex (j);
		}
	}

	/// <summary>
	/// Instantiates an input at the left of the screen, at a  location
	/// based on its input. More lightweight than instantiateInputAt.
	/// </summary>
	/// <param name="index">between 1-8</param>
	public GameObject instantiateInputAtIndex (int index) {
		return this.instantiateInputAt (width / 4, height / 8 * index - height / 6);
	}

	/// <summary>
	/// Instantiates an output at the left of the screen, at a  location
	/// based on its input. More lightweight than instantiateOutputAt.
	/// </summary>
	/// <param name="index">between 1-8</param>
	public GameObject instantiateOutputAtIndex (int index) {
		return this.instantiateOutputAt (width / 8 * 7, height / 8 * index - height / 6);
	}

	/// <summary>
	/// Instantiates an input at x, y coordinates.
	/// </summary>
	private GameObject instantiateInputAt (float x, float y) {
		GameObject newPrefab = Instantiate (inputPrefab);
		newPrefab.transform.position = new Vector3 (bottomLeft.x + x, bottomLeft.y + y, 0);
		return newPrefab;
	}

	/// <summary>
	/// Instantiates an output at x, y coordinates.
	/// </summary>
	private GameObject instantiateOutputAt (float x, float y) {
		GameObject newPrefab = Instantiate (outputPrefab);
		newPrefab.transform.position = new Vector3 (bottomLeft.x + x, bottomLeft.y + y, 0);
		return newPrefab;
	}
}
