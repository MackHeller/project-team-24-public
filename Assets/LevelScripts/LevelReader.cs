using UnityEngine;
using System.Collections;
using System;
using System.IO;
using LitJson;
using C5;

/// <summary>
/// Takes the name of a level, makes a filepath to that level and calls loadNewLevel
/// If you already have the full filepath you can call Reader directly
/// levelName = name of a valid level - the levelCreator
/// </summary>
public class LevelReader {

    public static JsonData loadNewLevel(String levelName) {
        return Reader(Application.dataPath + "/Levels/" + levelName + ".JSON");
    }

    public static JsonData loadLevelMetaData(String levelName) {
        return Reader(Application.dataPath + "/Levels/levelMetaData.JSON");
    }

    /// <summary>
    /// Sets levelInformation as the JSON that is read in from the given filePath 
    /// filePath = location of a valid JSON file
    /// </summary>
    private static JsonData Reader(String filePath) {
        StreamReader sr = null;
        try {
            sr = new StreamReader(filePath);
            return JsonMapper.ToObject(sr.ReadToEnd());
        } catch (IOException e) {
            Console.WriteLine("Cannot read file");
            Console.WriteLine(e.Message);
        } catch (UnauthorizedAccessException e) {
            Console.WriteLine("Cannot access file");
            Console.WriteLine(e.Message);
        } finally {
            if (sr != null)
                sr.Dispose();
        }
        return null;
    }

    /// <summary>
    /// Checks if gate exists in the current level
    /// name = name of a valid gate
    /// </summary>
    public static ArrayList<LogicModule> getGates(JsonData levelInformation) {
        ArrayList<LogicModule> gates = new ArrayList<LogicModule>();
        if (jsonDataContainsKey(levelInformation, "Gates")) {
            for (int i = 0; i < levelInformation["Gates"].Count; i++) {
                LogicModule temp;
                switch (levelInformation["Gates"][i]["Name"].ToString())
                {
                    case "And":
                        temp = new GateAnd(2);
                        break;
                    case "Or":
                        temp = new GateOR(2);
                        break;
                    case "Not":
                        temp = new GateNot();
                        break;
                    case "Xor":
                        temp = new GateXOR(2);
                        break;
                    default:
                        throw new Exception("Cannot find given gate"+ levelInformation["Gates"][i]["Name"].ToString());
                }
                temp.setAmountAllowed(Convert.ToInt32(levelInformation["Gates"][i]["Amount"].ToString()));
                gates.Add(temp);
            }
        }
        return gates;
    }

    /// <summary>
    /// gets all of the inputs. Returns as an array of booleans
    /// </summary>
    public static ArrayList<bool> getLevelInput(JsonData levelInformation) {
        ArrayList<bool> inputs = new ArrayList<bool>();
        if (jsonDataContainsKey(levelInformation, "Inputs")) {
            for (int i = 0; i < levelInformation["Inputs"].Count; i++) {
                inputs.Add(Convert.ToBoolean(levelInformation["Inputs"][i]["Value"].ToString()));
            }
        }
        return inputs;
    }

    /// <summary>
    /// gets all of the outputs. Returns as an array of booleans
    /// </summary>
    public static ArrayList<bool> getLevelOutput(JsonData levelInformation) {
        ArrayList<bool> output = new ArrayList<bool>();
        if (jsonDataContainsKey(levelInformation, "Outputs")) {
            for (int i = 0; i < levelInformation["Outputs"].Count; i++) {
                output.Add(Convert.ToBoolean(levelInformation["Outputs"][i]["Value"].ToString()));
            }
        }
        return output;
    }

    #region getters

    public static String getLevelName(JsonData levelInformation) { return levelInformation["LevelName"].ToString(); }
    public static String getCreator(JsonData levelInformation) { return levelInformation["Creator"].ToString(); }
    public static int getLevelPar(JsonData levelInformation) { return Convert.ToInt32(levelInformation["Par"].ToString()); }
    public static int getMinScore(JsonData levelInformation) { return Convert.ToInt32(levelInformation["MinScore"].ToString()); }
    public static JsonData getAllLevelInformation(JsonData levelInformation) { return levelInformation; }

    #endregion getters

    /// <summary>
    /// get a list of all level names
    /// </summary>
    public static String[] getAllLevelNames() {
        String[] allfiles = System.IO.Directory.GetFiles(Application.dataPath + "/Levels/", "*.JSON", System.IO.SearchOption.TopDirectoryOnly);
        for (int i = 0; i < allfiles.Length; i++) {
            int startIndex = (Application.dataPath + "/Levels/").Length;
            int endIndex = allfiles[i].Length - 5;
            allfiles[i] = allfiles[i].Substring(startIndex, endIndex - startIndex);
            Debug.Log(allfiles[i]);
        }
        return allfiles;
    }
    /// <summary>
    /// Taken from 
    /// https://gist.github.com/sinergy/5626704
    /// </summary>
    public static bool jsonDataContainsKey(JsonData data, string key) {
        bool result = false;
        if (data == null)
            return result;
        if (!data.IsObject) {
            return result;
        }
        IDictionary tdictionary = data as IDictionary;
        if (tdictionary == null)
            return result;
        if (tdictionary.Contains(key)) {
            result = true;
        }
        return result;
    }

}
