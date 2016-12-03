using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool _isCreatingWire = false;
	private static Level _level;

	void Start() {

		_level = new Level ();
		_level.loadLevel ("FourInputAndGate-Freddy");

		/*
		 * NOTE: not sure if due to a gitIgnore, the prefabs placed in LevelCreationTool
		 * are removed on pulls.
		 */ 
		LevelCreationTool.getInstance ().LoadInputOutputFromLevel (_level);
	}

	public static Level getLevel() {
		return _level;
	}

	public static void loadLevel(string levelName) {
		_level.loadLevel (levelName);
	}

    public static bool isCreatingWire() {
        return _isCreatingWire;
    }

    public static void setCreatingWire(bool isCreatingWire) {
        _isCreatingWire = isCreatingWire;
    }

}
