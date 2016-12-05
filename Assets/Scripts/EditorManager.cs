using UnityEngine;
using System.Collections;
using C5;
using UnityEngine.UI;

public class EditorManager : MonoBehaviour {

    private static EditorManager _instance;

    private bool _isCreatingWire = false;
    private Level _level;
    private bool _isdeleting = false;
    private ArrayList<GameObject> _wiresToBeDeleted;
    private ArrayList<GameObject> _gatesToBeDeleted;
    public Text nameText;
    public Text creatorText;
    public Text scoreText;
    public StarsController starController;

    // Use this for initialization
    void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        _wiresToBeDeleted = new ArrayList<GameObject>();
        _gatesToBeDeleted = new ArrayList<GameObject>();
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

    //panel text field setters
    public void setName(string name) { nameText.text = name; }
    public void setCreator(string creator) { creatorText.text = creator; }
    public void setScore(int score) { scoreText.text = score.ToString(); }
    public void setStars(int numStars) { starController.setStars(numStars); }
}
