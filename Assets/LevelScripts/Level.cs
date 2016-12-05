using UnityEngine;
using System.Collections;
using C5;
using System;
using System.Linq;
using LitJson;

/// <summary>
/// A puzzle level. After giving a set of inputs to a
/// set of LogicObjects, it expects a set of outputs
/// and compares whether the set of outputs is correct.
/// </summary>
public class Level{

    private string levelName;
    private string creator;
    private int[] stars = new int[3];
    private HashDictionary<BuiltinModuleController.BuiltinModules,int> gates;
    private ArrayList<int> input;
    private ArrayList<int> output;

    void Start() {
        // for testing only
		/*
        loadLevel("level4-Mack");
        saveLevel();
        saveAsNewLevel("mackLevel", "MackHeller2");
        */
        /*
		PremadeLevelSerializer.createFourInputAndGate ();
		PremadeLevelSerializer.createXorGate ();
		PremadeLevelSerializer.createAndIntoOr ();
		PremadeLevelSerializer.createDoubleCircuit ();
		PremadeLevelSerializer.createDeMorgans1 ();
		PremadeLevelSerializer.createDeMorgans2 ();*/
    }

    public void loadLevel(string levelName) {
        this.levelName = levelName;
        setLevelValues(LevelReader.loadNewLevel(levelName));
    }

    /// <summary>
    /// save level with level's existing file name
    /// </summary>
    public void saveLevel() {
        LevelWriter.saveAsNewLevel(getFileName(), this);
    }

    /// <summary>
    /// save level with a new file name
    /// </summary>
    public void saveAsNewLevel(string levelName, string creator) {
        string filename = createLevelName(levelName, creator);
        this.levelName = levelName;
        this.creator = creator;
        if (LevelReader.getAllLevelNames().Contains(filename))
            throw new ArgumentException("Cannot create a new File, a level with the name: " + levelName +
                " created by: " + creator + " already exists");
        else
            LevelWriter.saveAsNewLevel(filename, this);
    }

    public void setLevelValues(JsonData jsonData) {
        this.levelName = LevelReader.getLevelName(jsonData);
        this.stars = LevelReader.getStars(jsonData);
        this.gates = LevelReader.getGates(jsonData);
        this.input = LevelReader.getLevelInput(jsonData);
        this.output = LevelReader.getLevelOutput(jsonData);
        this.creator = LevelReader.getCreator(jsonData);
    }

    private String createLevelName(String level, String creator) { return level + "-" + creator; }

    #region getters

    public HashDictionary<BuiltinModuleController.BuiltinModules, int> getGates() { return gates; }
    public ArrayList<int> getLevelInput() { return input; }
    public ArrayList<int> getLevelOutput() { return output; }
    public string getLevelName() { return levelName; }
    public string getCreator() { return creator; }
    public int[] getStars() { return stars; }
    public string getFileName() { return createLevelName(this.levelName, this.creator); }

    #endregion getters

    #region setters

    public void setGates(HashDictionary<BuiltinModuleController.BuiltinModules, int> gates) { this.gates = gates; }
    public void setLevelInput(ArrayList<int> input) { this.input = input; }
    public void setLevelOutput(ArrayList<int> output) { this.output = output; }
    public void setLevelName(string levelName) { this.levelName = levelName; }
    public void setStars(int[] stars) { this.stars = stars; }
    public void setCreator(string creator) { this.creator = creator; }

    #endregion setters
}
