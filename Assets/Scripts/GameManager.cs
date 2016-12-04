using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    private bool _isCreatingWire = false;
    private Level _level;

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

}
