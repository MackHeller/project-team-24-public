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
    public static HashDictionary<BuiltinModuleController.BuiltinModules, int> getGates(JsonData levelInformation) {
        HashDictionary<BuiltinModuleController.BuiltinModules, int> gates = new HashDictionary<BuiltinModuleController.BuiltinModules, int>();
        if (jsonDataContainsKey(levelInformation, "Gates")) {
            for (int i = 0; i < levelInformation["Gates"].Count; i++) {
                BuiltinModuleController.BuiltinModules temp;
                switch (levelInformation["Gates"][i]["Name"].ToString())
                {
                    case "And":
                        temp = BuiltinModuleController.BuiltinModules.AND;
                        break;
                    case "Nand":
                        temp = BuiltinModuleController.BuiltinModules.NAND;
                        break;
                    case "Or":
                        temp = BuiltinModuleController.BuiltinModules.OR;
                        break;
                    case "Nor":
                        temp = BuiltinModuleController.BuiltinModules.NOR;
                        break;
                    case "Not":
                        temp = BuiltinModuleController.BuiltinModules.NOT;
                        break;
                    case "Xor":
                        temp = BuiltinModuleController.BuiltinModules.XOR;
                        break;
                    case "Nxor":
                        temp = BuiltinModuleController.BuiltinModules.NXOR;
                        break;
                    default:
                        throw new Exception("Cannot find given gate"+ levelInformation["Gates"][i]["Name"].ToString());
                }
                gates.Add(temp,Convert.ToInt32(levelInformation["Gates"][i]["Amount"].ToString()));
            }
        }
        return gates;
    }

    /// <summary>
    /// gets all of the inputs. Returns as an array of booleans
    /// </summary>
    public static ArrayList<Int32> getLevelInput(JsonData levelInformation) {
        ArrayList<Int32> inputs = new ArrayList<Int32>();
        if (jsonDataContainsKey(levelInformation, "Inputs")) {
            for (int i = 0; i < levelInformation["Inputs"].Count; i++) {
                inputs.Add(Convert.ToInt32(levelInformation["Inputs"][i]["Id"].ToString()));
            }
        }
        return inputs;
    }

    /// <summary>
    /// gets all of the outputs. Returns as an array of booleans
    /// </summary>
    public static ArrayList<Int32> getLevelOutput(JsonData levelInformation) {
        ArrayList<Int32> output = new ArrayList<Int32>();
        if (jsonDataContainsKey(levelInformation, "Outputs")) {
            for (int i = 0; i < levelInformation["Outputs"].Count; i++) {
                output.Add(Convert.ToInt32(levelInformation["Outputs"][i]["Id"].ToString()));
            }
        }
        return output;
    }

    #region getters

    public static String getLevelName(JsonData levelInformation) { return levelInformation["LevelName"].ToString(); }
    public static String getCreator(JsonData levelInformation) { return levelInformation["Creator"].ToString(); }
    public static int[] getStars(JsonData levelInformation) {
        int[] stars = new int[] { Convert.ToInt32(levelInformation["star1"].ToString()),
            Convert.ToInt32(levelInformation["star2"].ToString()),
        Convert.ToInt32(levelInformation["star3"].ToString())};
        return stars;
    }
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
