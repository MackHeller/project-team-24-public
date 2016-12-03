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
public class Level : MonoBehaviour {

    private String levelName;
    private String creator;
    private int levelPar;
    private int minScore;
    private ArrayList<LogicModule> gates;
    private ArrayList<bool> input;
    private ArrayList<bool> output;

    void Start() {
        // for testing only
        loadLevel("level4-Mack");
        saveLevel();
        saveAsNewLevel("mackLevel", "MackHeller2");
    }

    public void loadLevel(string levelName) {
        this.levelName = levelName;
        setLevelValues(LevelReader.loadNewLevel(levelName));
    }

    /// <summary>
    /// save level with level's existing file name
    /// </summary>
    public void saveLevel() {
        LevelWriter.saveAsNewLevel(createLevelName(this.levelName, this.creator), this);
    }

    /// <summary>
    /// save level with a new file name
    /// </summary>
    public void saveAsNewLevel(string levelName, string creator) {
        String filename = createLevelName(levelName, creator);
        if (LevelReader.getAllLevelNames().Contains(filename))
            throw new ArgumentException("Cannot create a new File, a level with the name: " + levelName +
                " created by: " + creator + " already exists");
        else
            LevelWriter.saveAsNewLevel(filename, this);
    }

    public void setLevelValues(JsonData jsonData) {
        this.levelName = LevelReader.getLevelName(jsonData);
        this.levelPar = LevelReader.getLevelPar(jsonData);
        this.minScore = LevelReader.getMinScore(jsonData);
        this.gates = LevelReader.getGates(jsonData);
        this.input = LevelReader.getLevelInput(jsonData);
        this.output = LevelReader.getLevelOutput(jsonData);
        this.creator = LevelReader.getCreator(jsonData);
    }

    private String createLevelName(String level, String creator) { return level + "-" + creator; }

    #region getters

    public ArrayList<LogicModule> getGates() { return gates; }
    public ArrayList<bool> getLevelInput() { return input; }
    public ArrayList<bool> getLevelOutput() { return output; }
    public String getLevelName() { return levelName; }
    public String getCreator() { return creator; }
    public int getLevelPar() { return levelPar; }
    public int getMinScore() { return minScore; }

    #endregion getters

    #region setters

    public void setGates(ArrayList<LogicModule> gates) { this.gates = gates; }
    public void setLevelInput(ArrayList<bool> input) { this.input = input; }
    public void setLevelOutput(ArrayList<bool> output) { this.output = output; }
    public void setLevelName(String levelName) { this.levelName = levelName; }
    public void setLevelPar(int levelPar) { this.levelPar = levelPar; }
    public void setMinScore(int minScore) { this.minScore = minScore; }
    public void setCreator(String creator) { this.creator = creator; }

    #endregion setters
}
