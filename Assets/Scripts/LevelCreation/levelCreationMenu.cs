using UnityEngine;
using System;
using C5;

public class LevelCreationMenu : MonoBehaviour {
    public GameObject startbutton;
    public GameObject levelNameField;
    public GameObject personNameField;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private ArrayList<Int32> inputs;
    private ArrayList<Int32> outputs;
    private Level levelBeingMade;
    // Use this for initialization
    void Start() {
        levelBeingMade = new Level();
    }

    // Update is called once per frame
    public void startButtonClicked() {
        string levelName = levelNameField.GetComponent<UnityEngine.UI.Text>().text;
        string personname = personNameField.GetComponent<UnityEngine.UI.Text>().text;
        setTerminalsInfo();
        levelBeingMade.setStars(getStars());
        levelBeingMade.setLevelInput(inputs);
        levelBeingMade.setLevelOutput(outputs);
        levelBeingMade.saveAsNewLevel(levelName, personname);
    }
    private int[] getStars()
    {
        return new int[] { Convert.ToInt32(star1.GetComponent<UnityEngine.UI.Text>().text),
                            Convert.ToInt32(star2.GetComponent<UnityEngine.UI.Text>().text),
                            Convert.ToInt32(star3.GetComponent<UnityEngine.UI.Text>().text)};
    }
    private void setTerminalsInfo()
    {
        GameObject[] terminals = GameObject.FindGameObjectsWithTag("TerminalField");
        inputs = new ArrayList<int>();
        outputs = new ArrayList<int>();
        int i = 0;
        foreach (GameObject terminal in terminals)
        {
            if (terminal.activeSelf)
            {
                if (terminal.transform.eulerAngles.z == 0)
                {
                    inputs.Add(i);
                }
                else
                {
                    outputs.Add(i);
                }
                i++;
            }
        }
    }
}
