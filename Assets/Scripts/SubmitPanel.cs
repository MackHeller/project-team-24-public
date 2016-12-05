using UnityEngine;
using System.Collections;

public class SubmitPanel : MonoBehaviour {

    private EditorManager editorManager;
    private GameManager gameManager;

    void Awake() {
        editorManager = EditorManager.getInstance();
        gameManager = GameManager.getInstance();
    }

    void OnEnable() {
        Level lvl = gameManager.getLevel();
        string lvlname = lvl.getLevelName();
        string lvlcreator = lvl.getCreator();
        editorManager.setName(lvlname);
        editorManager.setCreator(lvlcreator);
        //TODO:get score for completed level and
        //get stars for completed level
        editorManager.setScore(0); //to be changed
        editorManager.setStars(0); //to be changed
    }
}
