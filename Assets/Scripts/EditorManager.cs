using UnityEngine;
using System.Collections;
using C5;
using UnityEngine.UI;

public class EditorManager : MonoBehaviour {

    private static string[] CORRECTNESS_MESSAGES = new string[] { "Incorrect Solution", "Good", "Great", "Excellent!" };

    private static EditorManager _instance;

    private GameManager gameManager;

    private bool _isCreatingWire = false;
    private Level _level;
    private bool _isdeleting = false;
    private ArrayList<GameObject> _wiresToBeDeleted = new ArrayList<GameObject>();
    private ArrayList<GameObject> _gatesToBeDeleted = new ArrayList<GameObject>();

    private int score;

    public GameObject[] sandboxModeOnlyObjects;
    public GameObject[] solvingModeOnlyObjects;
    public Text scoreText;
    public StarsController starsController;
    public Text correctnessText;

    // Use this for initialization
    void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(this);
        }
    }

    void Start() {
        gameManager = GameManager.getInstance();
        enableOnlyInMode(GameManager.Mode.SANDBOX, sandboxModeOnlyObjects);
        enableOnlyInMode(GameManager.Mode.SOLVING, solvingModeOnlyObjects);
    }

    private void enableOnlyInMode(GameManager.Mode mode, GameObject[] objects) {
        if (gameManager.getMode() != mode) {
            foreach (GameObject obj in objects) {
                obj.SetActive(false);
            }
        }
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
}
