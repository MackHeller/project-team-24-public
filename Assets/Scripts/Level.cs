using UnityEngine;
using System.Collections;
using C5;
using System;
using LitJson;

public class Level {
    /*
	 * A puzzle level. After giving a set of inputs to a
	 * set of LogicObjects, it expects a set of outputs
	 * and compares whether the set of outputs is correct.
	 */
    protected JsonData levelInformation;
    public void loadLevel(string levelName)
    {
        levelInformation = levelReader.loadNewLevel(levelName);
    }
    /*
     * Checks if gate exists in the current level
     * name = name of a valid gate
     * */
    public bool hasGate(String name)
    {
        for (int i = 0; i < levelInformation["Gates"].Count; i++)
        {
            if (levelInformation["Gates"][i].ToString() == name)
            {
                return true;
            }
        }
        return false;
    }
    /*
     * TODO: do we want the functionality to return MaxValue for Unlimited gates?
     * get the max amount of a certain gate the level allows. If there is no limit it returns the MaxValue.
     * Throws Exception if gate does not exist
     * name = name of a valid gate
     * */
    public int getGateAmount(String name)
    {
        for (int i = 0; i < levelInformation["Gates"].Count; i++)
        {
            if (levelInformation["Gates"][i].ToString() == name)
            {
                //In the case that we have an unlimited amount of gates
                if (levelInformation["Gates"][i]["Amount"].ToString() == "Unlimited")
                {
                    return Int32.MaxValue;
                }
                else
                {
                    return Convert.ToInt32(levelInformation["Gates"][i]["Amount"].ToString());
                }
            }
        }
        throw new System.
            Exception("Tried to request gate that does not exist in the current level");
    }
    /*
     * gets all of the inputs. Returns as an array of booleans
     * */
    public ArrayList<bool> getLevelInput()
    {
        ArrayList<bool> inputs = new ArrayList<bool>();
        for (int i = 0; i < levelInformation["Inputs"].Count; i++)
        {
            inputs.Add(Convert.ToBoolean(levelInformation["Inputs"][i].ToString()));
        }
        return inputs;
    }
    /*
     * gets all of the outputs. Returns as an array of booleans
     * */
    public ArrayList<bool> getLevelOutput()
    {
        ArrayList<bool> output = new ArrayList<bool>();
        for (int i = 0; i < levelInformation["Output"].Count; i++)
        {
            output.Add(Convert.ToBoolean(levelInformation["Output"][i].ToString()));
        }
        return output;
    }
    public String getLevelName() { return levelInformation["LevelName"].ToString();}
    public int getLevelPar() { return Convert.ToInt32(levelInformation["Par"].ToString()); }
    public int getMinScore() { return Convert.ToInt32(levelInformation["MinScore"].ToString()); }
    public JsonData getAllLevelInformation() { return levelInformation; }
}
