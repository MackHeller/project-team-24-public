using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Class for loading levels. Follows the Singleton Design Pattern.
/// </summary>
public class LevelCreationTool : MonoBehaviour {
    /*
	 * TODO: adjust after level editor is completed, require for proper implementation
	 * of these functions.
	 */

    // Input and output prefabs must be attached to LevelCreationTool in the scene in this implementation
    public GameObject inputPrefab;
    public GameObject outputPrefab;

    public GameObject inputPositionsParent;
    public GameObject outputPositionsParent;

    private List<Vector3> inputPositions;
    private List<Vector3> outputPositions;

    // the bottom-left x, y, z coordinates of the canvas shown on screen
    private Vector3 bottomLeft;

    // singleton instance of PremadeLevels
    private static LevelCreationTool _instance;

    public static LevelCreationTool getInstance() {
        return _instance;
    }

    void Awake() {
        _instance = this;
    }

    private void Start() {
        inputPositions = getChildPositions(inputPositionsParent);
        outputPositions = getChildPositions(outputPositionsParent);
        if (GameManager.getInstance().getMode() != GameManager.Mode.SANDBOX) {
            LoadInputOutputFromLevel(GameManager.getInstance().getLevel());
        }
    }

    private List<Vector3> getChildPositions(GameObject parent) {
        List<Vector3> positions = new List<Vector3>(parent.transform.childCount);
        foreach (Transform child in parent.transform) {
            positions.Add(child.position);
        }
        return positions;
    }

    /// <summary>
    /// Instantiates the set of inputs/outputs from a level.
    /// 
    /// TODO: for whoever is working on the new 'LogicManager', hook these instantiated inputs/outputs up.
    /// 
    /// </summary>
    /// <param name="index">must have between 1-6 inputs and 1-6 outputs for current coordinates</param>
    public void LoadInputOutputFromLevel(Level level) {
        for (int i = 0; i < level.getLevelInput().Count; i++) {
            this.instantiateInputAtIndex(i);
        }
        for (int j = 0; j < level.getLevelOutput().Count; j++) {
            this.instantiateOutputAtIndex(j);
        }
    }

    /// <summary>
    /// Instantiates an input at the left of the screen, at a  location
    /// based on its input. More lightweight than instantiateInputAt.
    /// </summary>
    /// <param name="index">between 1-8</param>
    public GameObject instantiateInputAtIndex(int index) {
        return this.instantiateInputAt(inputPositions[index]);
    }

    /// <summary>
    /// Instantiates an output at the left of the screen, at a  location
    /// based on its input. More lightweight than instantiateOutputAt.
    /// </summary>
    /// <param name="index">between 1-8</param>
    public GameObject instantiateOutputAtIndex(int index) {
        return this.instantiateOutputAt(outputPositions[index]);
    }

    /// <summary>
    /// Instantiates an input at x, y coordinates.
    /// </summary>
    private GameObject instantiateInputAt(Vector3 position) {
        GameObject newPrefab = Instantiate(inputPrefab);
        newPrefab.transform.position = position;
        return newPrefab;
    }

    /// <summary>
    /// Instantiates an output at x, y coordinates.
    /// </summary>
    private GameObject instantiateOutputAt(Vector3 position) {
        GameObject newPrefab = Instantiate(outputPrefab);
        newPrefab.transform.position = position;
        return newPrefab;
    }
}
