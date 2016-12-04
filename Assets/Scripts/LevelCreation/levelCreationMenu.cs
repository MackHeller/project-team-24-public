using UnityEngine;
using System.Collections;

public class LevelCreationMenu : MonoBehaviour {
    public GameObject startbutton;
    public GameObject levelNameField;
    public GameObject personNameField;
    private Level levelBeingMade;
    // Use this for initialization
    void Start () {
        levelBeingMade = new Level();
    }
	
	// Update is called once per frame
	public void startButtonClicked () {
        string levelName = levelNameField.GetComponent<UnityEngine.UI.Text>().text;
        string personname = personNameField.GetComponent<UnityEngine.UI.Text>().text;
        levelBeingMade.saveAsNewLevel(levelName, personname);

        //levelBeingMade.saveAsNewLevel("","");

    }
}
