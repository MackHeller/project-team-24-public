using UnityEngine;
using System.Collections;
using System;
using System.IO;
using LitJson;
using C5;

public class LevelReader 
{
    /*
     *  Takes the name of a level, makes a filepath to that level and calls loadNewLevel
     *  If you already have the full filepath you can call Reader directly
     *  levelName = name of a valid level 
     */
    public static JsonData loadNewLevel(String levelName)
    {
        return Reader(Application.dataPath + "/Levels/" + levelName + ".JSON");
    }
    /*
     * Sets levelInformation as the JSON that is read in from the given filePath 
     * filePath = location of a valid JSON file
     * */
    private static JsonData Reader(String filePath)
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(filePath);
            return JsonMapper.ToObject(sr.ReadToEnd());
        }
        catch (IOException e)
        {
            Console.WriteLine("Cannot read file");
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Cannot access file");
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (sr != null) sr.Dispose();
        }
        return null;
    }
    
    /*
    * Checks if gate exists in the current level
    * name = name of a valid gate
    * */
    public static ArrayList<Module> getGates(JsonData levelInformation)
    {
        ArrayList<Module> gates = new ArrayList<Module>();
        if (jsonDataContainsKey(levelInformation, "Gates"))
        {
            for (int i = 0; i < levelInformation["Gates"].Count; i++)
            {
                //TODO 
            }
        }
        return gates;
    }
    /*
     * gets all of the inputs. Returns as an array of booleans
     * */
    public static ArrayList<bool> getLevelInput(JsonData levelInformation)
    {
        ArrayList<bool> inputs = new ArrayList<bool>();
        if (jsonDataContainsKey(levelInformation, "Inputs"))
        {
            for (int i = 0; i < levelInformation["Inputs"].Count; i++)
            {
                inputs.Add(Convert.ToBoolean(levelInformation["Inputs"][i]["Value"].ToString()));
            }
        }
        return inputs;
    }
    /*
     * gets all of the outputs. Returns as an array of booleans
     * */
    public static ArrayList<bool> getLevelOutput(JsonData levelInformation)
    {
        ArrayList<bool> output = new ArrayList<bool>();
        if (jsonDataContainsKey(levelInformation, "Outputs"))
        {
            for (int i = 0; i < levelInformation["Outputs"].Count; i++)
            {
                output.Add(Convert.ToBoolean(levelInformation["Outputs"][i]["Value"].ToString()));
            }
        }
        return output;
    }
    public static String getLevelName(JsonData levelInformation) { return levelInformation["LevelName"].ToString(); }
    public static int getLevelPar(JsonData levelInformation) { return Convert.ToInt32(levelInformation["Par"].ToString()); }
    public static int getMinScore(JsonData levelInformation) { return Convert.ToInt32(levelInformation["MinScore"].ToString()); }
    public static JsonData getAllLevelInformation(JsonData levelInformation) { return levelInformation; }

    /*
     * Taken from 
     * https://gist.github.com/sinergy/5626704
     * */
    public static bool jsonDataContainsKey(JsonData data, string key)
    {
        bool result = false;
        if (data == null)
            return result;
        if (!data.IsObject)
        {
            return result;
        }
        IDictionary tdictionary = data as IDictionary;
        if (tdictionary == null)
            return result;
        if (tdictionary.Contains(key))
        {
            result = true;
        }
        return result;
    }

}
