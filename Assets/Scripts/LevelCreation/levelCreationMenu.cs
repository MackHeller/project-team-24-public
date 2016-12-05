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
    private HashDictionary<BuiltinModuleController.BuiltinModules, int> gates;
    private Level levelBeingMade;
    private GameObject[] gateFields;
    // Use this for initialization
    void Start() {
        levelBeingMade = new Level();
        gateFields = GameObject.FindGameObjectsWithTag("GateField");
    }

    // Update is called once per frame
    public void startButtonClicked() {
        levelBeingMade.setLevelName(levelNameField.GetComponent<UnityEngine.UI.Text>().text);
        levelBeingMade.setCreator(personNameField.GetComponent<UnityEngine.UI.Text>().text);
        setTerminalsInfo();
        setBuiltinGateInfo();
        levelBeingMade.setStars(getStars());
        levelBeingMade.setLevelInput(inputs);
        levelBeingMade.setLevelOutput(outputs);
        levelBeingMade.setGates(gates);
        levelBeingMade.saveAsNewLevel();
    }
    private int[] getStars() {
        return new int[] { Convert.ToInt32(star1.GetComponent<UnityEngine.UI.Text>().text),
                            Convert.ToInt32(star2.GetComponent<UnityEngine.UI.Text>().text),
                            Convert.ToInt32(star3.GetComponent<UnityEngine.UI.Text>().text)};
    }
    private void setTerminalsInfo() {
        GameObject[] terminals = GameObject.FindGameObjectsWithTag("TerminalField");
        inputs = new ArrayList<int>();
        outputs = new ArrayList<int>();
        int i = 0;
        foreach (GameObject terminal in terminals) {
            if (terminal.transform.eulerAngles.z == 0)
                inputs.Add(i);
            else
                outputs.Add(i);
            i++;
        }
    }
    private void setBuiltinGateInfo() {
        gates = new HashDictionary<BuiltinModuleController.BuiltinModules, int>();
        foreach (GameObject field in gateFields) {
            int fieldValue = -1; //default value
            String fieldName;
            if (field.activeSelf) {
                fieldValue = Convert.ToInt32(field.GetComponent<UnityEngine.UI.Text>().text);
                fieldName = field.transform.name;
            } else {
                field.SetActive(true);
                fieldName = field.transform.name;
                field.SetActive(false);
            }
            switch (fieldName) {
                case "AndText":
                    gates.Add(BuiltinModuleController.BuiltinModules.AND, fieldValue);
                    break;
                case "NandText":
                    gates.Add(BuiltinModuleController.BuiltinModules.NAND, fieldValue);
                    break;
                case "OrText":
                    gates.Add(BuiltinModuleController.BuiltinModules.OR, fieldValue);
                    break;
                case "NorText":
                    gates.Add(BuiltinModuleController.BuiltinModules.NOR, fieldValue);
                    break;
                case "NotText":
                    gates.Add(BuiltinModuleController.BuiltinModules.NOT, fieldValue);
                    break;
                case "XorText":
                    gates.Add(BuiltinModuleController.BuiltinModules.XOR, fieldValue);
                    break;
                case "NxorText":
                    gates.Add(BuiltinModuleController.BuiltinModules.NXOR, fieldValue);
                    break;
                default:
                    throw new Exception("Cannot find given gate" + field.transform.name);
            }

        }
    }
}
