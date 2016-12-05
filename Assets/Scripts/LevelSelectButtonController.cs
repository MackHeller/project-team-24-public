using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButtonController : MonoBehaviour {

    private Level level;
    public Text nameText;
    public Text creatorText;
    public Text scoreText;
    public Text descriptionText;
    public StarsController starController;

    private GameManager gameManager;

    private void Awake() {
        gameManager = GameManager.getInstance();
    }

    public void OnClick() {
        gameManager.setLevel(level);
        gameManager.setMode(GameManager.Mode.SOLVING);
        SceneManager.LoadScene("Editor");
    }

    public void setLevel(Level level) {
        this.level = level;
        nameText.text = level.getLevelName();
        creatorText.text = level.getCreator();
        descriptionText.text = level.getDescription();
    }

    public Level getLevel() {
        return level;
    }
}
