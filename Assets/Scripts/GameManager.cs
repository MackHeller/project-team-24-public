using UnityEngine;
using System.Collections;
using C5;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    private bool _isCreatingWire = false;
    private Level _level;
	private bool _isdeleting = false;
	private ArrayList<GameObject> _wiresToBeDeleted;
	private ArrayList<GameObject> _gatesToBeDeleted;

    void Awake() {
        if (_instance == null) {
            DontDestroyOnLoad(this);
            _instance = this;
        } else {
            Destroy(this);
        }
    }

    void Start() {

        _level = new Level();
        _level.loadLevel("FourInputAndGate-Freddy");
		_wiresToBeDeleted = new ArrayList<GameObject> ();
		_gatesToBeDeleted = new ArrayList<GameObject> ();
        /*
		 * NOTE: not sure if due to a gitIgnore, the prefabs placed in LevelCreationTool
		 * are removed on pulls.
		 */
        LevelCreationTool.getInstance().LoadInputOutputFromLevel(_level);


    }

    public static GameManager getInstance() {
        return _instance;
    }

    public Level getLevel() {
        return _level;
    }

    public void loadLevel(string levelName) {
        _level.loadLevel(levelName);
    }

    public bool isCreatingWire() {
        return _isCreatingWire;
    }

    public void setCreatingWire(bool isCreatingWire) {
        _isCreatingWire = isCreatingWire;
    }

	public bool isDeleting(){
		return _isdeleting;
	}

	public void setIsDelting(bool isdeleting){
		_isdeleting = isdeleting;
	}

	public void markWireForDeletion(GameObject wire){
		_wiresToBeDeleted.Add (wire);
	}

	public void unmarkWireForDeletion(GameObject wire){
		_wiresToBeDeleted.Remove (wire);
	}

	public ArrayList<GameObject> getWiresToBeDeleted(){
		return _wiresToBeDeleted;
	}

	public void markGateForDeletion(GameObject gate){
		_gatesToBeDeleted.Add (gate);
	}

	public void unmarkGateForDeletion(GameObject gate){
		_gatesToBeDeleted.Remove (gate);
	}

	public ArrayList<GameObject> getGatesToBeDeleted(){
		return _gatesToBeDeleted;
	}
}
