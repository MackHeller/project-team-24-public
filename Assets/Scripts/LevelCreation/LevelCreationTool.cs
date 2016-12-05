using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Class for loading levels. Follows the Singleton Design Pattern.
/// </summary>
public class LevelCreationTool : MonoBehaviour {

    private static string[] inputLabels = { "A", "B", "C", "D", "E", "F" };
    private static string[] outputLabels = { "U", "V", "W", "X", "Y", "Z" };

    // Input and output prefabs must be attached to LevelCreationTool in the scene in this implementation
    public TerminalController inputPrefab;
    public TerminalController outputPrefab;

    public GameObject inputPositionsParent;
    public GameObject outputPositionsParent;

    private List<Vector3> inputPositions;
    private List<Vector3> outputPositions;

    private List<TerminalController> instantiatedInputs;
    private List<TerminalController> instantiatedOutputs;

    // the bottom-left x, y, z coordinates of the canvas shown on screen
    private Vector3 bottomLeft;

    // singleton instance of PremadeLevels
    private static LevelCreationTool _instance;

    private Transform gateParent;

    public static LevelCreationTool getInstance() {
        return _instance;
    }

    void Awake() {
        _instance = this;
    }

    private void Start() {
        gateParent = EditorManager.getInstance().getGateCanvas().gameObject.transform;
        inputPositions = getChildPositions(inputPositionsParent);
        outputPositions = getChildPositions(outputPositionsParent);
        instantiatedInputs = new List<TerminalController>();
        instantiatedOutputs = new List<TerminalController>();
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

    public List<TerminalController> getInstantiatedInputs() {
        return instantiatedInputs;
    }

    public List<TerminalController> getInstantiatedOutputs() {
        return instantiatedOutputs;
    }

    /// <summary>
    /// Instantiates the set of inputs/outputs from a level.
    /// 
    /// TODO: for whoever is working on the new 'LogicManager', hook these instantiated inputs/outputs up.
    /// 
    /// </summary>
    /// <param name="index">must have between 1-6 inputs and 1-6 outputs for current coordinates</param>
    public void LoadInputOutputFromLevel(Level level) {
        foreach (int inputId in level.getLevelInput()) {
            instantiatedInputs.Add(instantiateInputAtIndex(inputId));
        }
        foreach (int outputId in level.getLevelOutput()) {
            instantiatedOutputs.Add(instantiateOutputAtIndex(outputId));
        }
    }

    /// <summary>
    /// Instantiates an input at the left of the screen, at a  location
    /// based on its input. More lightweight than instantiateInputAt.
    /// </summary>
    /// <param name="index">between 1-8</param>
    public TerminalController instantiateInputAtIndex(int id) {
        TerminalController outputTerminal = Instantiate(inputPrefab, gateParent) as TerminalController;
        outputTerminal.setLabel(inputLabels[id]);
        outputTerminal.transform.position = inputPositions[id];
        return outputTerminal;
    }

    /// <summary>
    /// Instantiates an output at the left of the screen, at a  location
    /// based on its input. More lightweight than instantiateOutputAt.
    /// </summary>
    /// <param name="index">between 1-8</param>
    public TerminalController instantiateOutputAtIndex(int id) {
        TerminalController inputTerminal = Instantiate(outputPrefab, gateParent) as TerminalController;
        inputTerminal.setLabel(outputLabels[id]);
        inputTerminal.transform.position = outputPositions[id];
        return inputTerminal;
    }
}
