using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using C5;
using System.Collections.Generic;

public class LevelCreatorManager : MonoBehaviour {

    public InputField levelNameField;
    public InputField creatorNameField;
    public InputField descriptionField;

    public InputField[] starRequirementFields;
    public Toggle[] inputTerminalToggles;
    public Toggle[] outputTerminalToggles;
    public InputField[] gateRestrictionInputFields;

    public GameObject errorBox;
    public Text errorMessage;

    private GameManager gameManager;

    private void Start() {
        gameManager = GameManager.getInstance();
        gameManager.setMode(GameManager.Mode.CREATING);
    }

    public void loadBuildSolutionScene() {
        try {
            Level level = createLevelFromInputs();
            gameManager.setLevel(level);
            gameManager.loadEditor();
        } catch (ArgumentException e) {
            errorBox.SetActive(true);
            errorMessage.text = e.Message;
        }
    }

    public Level createLevelFromInputs() {
        validateFormInputs();
        Level level = new Level();
        level.setLevelName(levelNameField.text.Trim());
        level.setCreator(creatorNameField.text.Trim());
        level.setDescription(descriptionField.text.Trim());
        level.setLevelInput(getTerminalIds(inputTerminalToggles));
        level.setLevelOutput(getTerminalIds(outputTerminalToggles));
        level.setStars(getStarRequirements());
        level.setGates(new HashDictionary<BuiltinModuleController.BuiltinModules, int>());
        return level;
    }

    private int[] getStarRequirements() {
        int[] starRequirements = new int[3];
        for (int i = 0; i < starRequirements.Length; i++) {
            string text = starRequirementFields[i].text;
            if (text.Trim().Equals("")) {
                starRequirements[i] = 0;
            } else {
                starRequirements[i] = Convert.ToInt32(text);
            }
        }
        return starRequirements;
    }

    private void validateFormInputs() {
        if (levelNameField.text == null || levelNameField.text.Trim().Equals("")) {
            throw new ArgumentException("You must specify a level name.");
        }
        assertAtLeastOne(inputTerminalToggles, "You must have at least one input.");
        assertAtLeastOne(outputTerminalToggles, "You must have at least one output.");
        foreach (InputField field in starRequirementFields) {
            string value = field.text;
            if (!value.Trim().Equals("") && Convert.ToInt32(value.Trim()) < 0) {
                throw new ArgumentException("Star requirement must be a positive value.");
            }
        }
    }

    private void assertAtLeastOne(Toggle[] toggles, String errorMessage) {
        bool hasOn = false;
        foreach (Toggle toggle in inputTerminalToggles) {
            if (toggle.isOn) {
                hasOn = true;
                break;
            }
        }
        if (!hasOn) {
            throw new ArgumentException(errorMessage);
        }
    }

    private ArrayList<int> getTerminalIds(Toggle[] terminalToggles) {
        ArrayList<int> ids = new ArrayList<int>();
        for (int i = 0; i < terminalToggles.Length; i++) {
            if (terminalToggles[i].isOn) {
                ids.Add(i);
            }
        }
        return ids;
    }
}
