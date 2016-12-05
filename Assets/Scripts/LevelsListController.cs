using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelsListController : MonoBehaviour {

    // Use this for initialization
    public LevelSelectButtonController buttonPrefab;

    void Start() {
        string[] levels = LevelReader.getAllLevelNames();
        foreach (string levelName in levels) {
            Level level = new Level();
            level.loadLevel(levelName);
            LevelSelectButtonController button = (LevelSelectButtonController)Instantiate(buttonPrefab, this.transform, false);
            button.setLevel(level);
        }
    }

}