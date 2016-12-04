using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    // Use this for initialization
    public LevelSelectButtonController buttonPrefab;
    void Start() {
        string[] levels = LevelReader.getAllLevelNames();
        Vector3 pos = this.transform.position;
        foreach (string s in levels) {
            LevelSelectButtonController button = (LevelSelectButtonController)Instantiate(buttonPrefab, this.transform, false);
            //TODO: change this so it loads each level as a LevelScripts.Level object because the files won't always be named in this format
            string[] s1 = s.Split('-');
            button.setName(s1[0]);
            button.setCreator(s1[1]);
        }
    }

}