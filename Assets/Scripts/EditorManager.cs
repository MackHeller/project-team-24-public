using UnityEngine;
using System.Collections;
using C5;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EditorManager : MonoBehaviour {

    private static string[] CORRECTNESS_MESSAGES = new string[] { "Incorrect Solution", "Good", "Great", "Excellent!" };

    private static EditorManager _instance;

    private GameManager gameManager;
    private Canvas gatesCanvas;

    private bool _isCreatingWire = false;
    private Level _level;
    private bool _isdeleting = false;
    private ArrayList<GameObject> _wiresToBeDeleted = new ArrayList<GameObject>();
    private ArrayList<GameObject> _gatesToBeDeleted = new ArrayList<GameObject>();

    private int score;

    public GameObject[] sandboxModeOnlyObjects;
    public GameObject[] solvingModeOnlyObjects;
    public GameObject[] creatorModeOnlyObjects;
    public Text scoreText;
    public StarsController starsController;
    public Text correctnessText;

    private bool isCorrect = false;

    // Use this for initialization
    void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(this);
        }
        gatesCanvas = GameObject.FindGameObjectWithTag("Gates").GetComponent<Canvas>();
    }

    public void checkForCorrectness() {
        Solution userSolution = generateSolution();
        isCorrect = userSolution.Equals(_level.getSolution());
    }

    public Solution generateSolution() {
        Solution solution = new Solution(gameManager.getLevel());
        List<TerminalController> inputs = LevelCreationTool.getInstance().getInstantiatedInputs();
        List<TerminalController> outputs = LevelCreationTool.getInstance().getInstantiatedOutputs();

        // Save inputs to reset after the following simulation
        List<bool?> originalInputValues = new List<bool?>();
        foreach (TerminalController terminal in inputs) {
            originalInputValues.Add(terminal.getTerminalValue());
        }

        // Simulate every possible input permutation and record outputs for each
        int numRows = (int)Math.Pow(2, inputs.Count);
        for (int i = 0; i < numRows; i++) {
            ArrayList<bool?> inputValues = new ArrayList<bool?>(inputs.Count);
            for (int j = 0; j < inputs.Count; j++) {
                bool inputValue = bitmaskCheck(i, j);
                inputValues.Add(inputValue);
                inputs[j].setTerminalValue(inputValue);
            }
            ArrayList<bool?> outputValues = new ArrayList<bool?>(outputs.Count);
            for (int j = 0; j < outputs.Count; j++) {
                outputValues.Add(outputs[j].getTerminalValue());
            }
            solution.addARowToSolution(inputValues, outputValues);
        }

        // Reset inputs to original values
        for (int i = 0; i < inputs.Count; i++) {
            inputs[i].setTerminalValue(originalInputValues[i]);
        }
        return solution;
    }

    void Start() {
        gameManager = GameManager.getInstance();
        enableOnlyInMode(GameManager.Mode.SOLVING, solvingModeOnlyObjects);
        enableOnlyInMode(GameManager.Mode.CREATING, creatorModeOnlyObjects);
        enableOnlyInMode(GameManager.Mode.SANDBOX, sandboxModeOnlyObjects);
    }

    private void enableOnlyInMode(GameManager.Mode mode, GameObject[] objects) {
        if (gameManager.getMode() != mode) {
            foreach (GameObject obj in objects) {
                obj.SetActive(false);
            }
        }
    }

    public Canvas getGateCanvas() {
        return gatesCanvas;
    }

    public int getStars() {
        return isSolutionCorrect() ? gameManager.getLevel().getStarsForScore(score) : 0;
    }

    public string getCorrectnessMessage() {
        return CORRECTNESS_MESSAGES[getStars()];
    }

    public void incrementScore() {
        setScore(score + 1);
    }

    public void decrementScore() {
        setScore(score - 1);
    }

    public void setScore(int score) {
        this.score = score;
        scoreText.text = score.ToString();
        starsController.setStars(getStars());
        correctnessText.text = getCorrectnessMessage();
    }

    public int getScore() {
        return score;
    }

    public bool isSolutionCorrect() {
        return true; //TODO
    }

    public static EditorManager getInstance() {
        return _instance;
    }

    public bool isCreatingWire() {
        return _isCreatingWire;
    }

    public void setCreatingWire(bool isCreatingWire) {
        _isCreatingWire = isCreatingWire;
    }

    public bool isDeleting() {
        return _isdeleting;
    }

    public void setIsDelting(bool isdeleting) {
        _isdeleting = isdeleting;
    }

    public void markWireForDeletion(GameObject wire) {
        _wiresToBeDeleted.Add(wire);
    }

    public void unmarkWireForDeletion(GameObject wire) {
        _wiresToBeDeleted.Remove(wire);
    }

    public ArrayList<GameObject> getWiresToBeDeleted() {
        return _wiresToBeDeleted;
    }

    public void markGateForDeletion(GameObject gate) {
        _gatesToBeDeleted.Add(gate);
    }

    public void unmarkGateForDeletion(GameObject gate) {
        _gatesToBeDeleted.Remove(gate);
    }

    public ArrayList<GameObject> getGatesToBeDeleted() {
        return _gatesToBeDeleted;
    }

    public bool bitmaskCheck(int mask, int n) {
        return ((mask >> n) & 1) == 1;
    }
}
