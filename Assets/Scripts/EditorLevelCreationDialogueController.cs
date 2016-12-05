using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditorLevelCreationDialogueController : MonoBehaviour {

    public Text levelNameField;
    public Text creatorNameField;
    public Text levelDescriptionField;

    private GameManager gameManager;

    void Start() {
        gameManager = GameManager.getInstance();
        if (gameManager.getMode() == GameManager.Mode.SANDBOX) {
            return;
        }
        Level level = gameManager.getLevel();
        levelNameField.text = level.getLevelName();
        creatorNameField.text = level.getCreator();
        levelDescriptionField.text = level.getDescription();
    }
}
