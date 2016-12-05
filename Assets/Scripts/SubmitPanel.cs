using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubmitPanel : MonoBehaviour {

    private EditorManager editorManager;
    private GameManager gameManager;

    public GameObject displayWhenSolving;
    public GameObject displayWhenCreating;

    public Text levelNameText;
    public Text levelCreatorText;
    public Text scoreText;
    public StarsController starsController;
    public InputField saveLocationField;

    void Awake() {
        editorManager = EditorManager.getInstance();
        gameManager = GameManager.getInstance();
    }

    public void Show() {
        gameObject.SetActive(true);
        if (gameManager.getMode() == GameManager.Mode.SOLVING) {
            displayWhenSolving.SetActive(true);
            Level level = gameManager.getLevel();
            levelNameText.text = level.getLevelName();
            levelCreatorText.text = level.getCreator();
            scoreText.text = editorManager.getScore().ToString();
            starsController.setStars(editorManager.getStars());
        } else if (gameManager.getMode() == GameManager.Mode.CREATING) {
            displayWhenCreating.SetActive(true);
            // Save created level
            // Set saveLocationField.text to saved levels file location
        }
    }
}
