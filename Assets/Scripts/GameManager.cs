using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool _isCreatingWire = false;
	private static Level _level;

	void Start() {
		/*
		 * Not functional, putting this here since the level editor will need to
		 * allow a centralized way to load levels.
		 */ 
		_level = new Level ();

		PremadeJsonWriter.createFourInputAndGate ();
		PremadeJsonWriter.createXorGate ();

		PremadeLevels.getPremadeLevels ().loadFourInputAndGate ();
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
