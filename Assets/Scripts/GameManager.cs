using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool _isCreatingWire = false;
	private static Level _level;

	void Awake() {
		_level = new Level ();
		// level.loadLevel ("");
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
