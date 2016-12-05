using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using C5;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public enum Mode { CREATING, SOLVING, SANDBOX };

    private static GameManager _instance;

    private Level _level;
    private Mode _mode = Mode.SANDBOX;

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
    }

    public static GameManager getInstance() {
        return _instance;
    }

    public Level getLevel() {
        return _level;
    }

    public void setLevel(Level level) {
        _level = level;
    }

    public Mode getMode() {
        return _mode;
    }

    public void setMode(Mode mode) {
        _mode = mode;
    }

    public void loadLevel(string levelName) {
        _level.loadLevel(levelName);
    }

    public void loadMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void loadEditor() {
        SceneManager.LoadScene("Editor");
    }

    public void loadLevelCreator() {
        SceneManager.LoadScene("LevelCreator");
    }
}
