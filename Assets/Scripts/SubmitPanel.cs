using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using C5;

public class SubmitPanel : MonoBehaviour {

    private EditorManager editorManager;
    private GameManager gameManager;

    public GameObject displayWhenSolving;
    public GameObject displayWhenCreating;

    public Text levelNameText;
    public Text levelCreatorText;
    public Text scoreText;
    public StarsController starsController;
    public Text correctnessText;
    public InputField saveLocationField;

    public void Submit() {
        editorManager = EditorManager.getInstance();
        gameManager = GameManager.getInstance();
        Level level = gameManager.getLevel();
        levelNameText.text = level.getLevelName();
        levelCreatorText.text = level.getCreator();
        gameObject.SetActive(true);

        if (gameManager.getMode() == GameManager.Mode.SOLVING) {
            displayWhenSolving.SetActive(true);
            scoreText.text = editorManager.getScore().ToString();
            starsController.setStars(editorManager.getStars());
            correctnessText.text = editorManager.getCorrectnessMessage();

        } else if (gameManager.getMode() == GameManager.Mode.CREATING) {
            displayWhenCreating.SetActive(true);
            Solution solution = editorManager.generateSolution();
            level.setSolution(solution);
            string saveLocation = level.saveAsNewLevel();
            saveLocationField.text = saveLocation;
        } else {
            gameManager.loadMainMenu();
        }
    }
}
