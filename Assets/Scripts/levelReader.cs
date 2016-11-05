using UnityEngine;
using System.Collections;
using System;
using System.IO;
using LitJson;
using C5;

public class levelReader 
{
    // Use this for initialization
    void Start()
    {
        //for testing purposes only
        loadNewLevel("level1");
    }
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
        String jsonString = "";
        try
        {
            sr = new StreamReader(filePath);
            jsonString = sr.ReadToEnd();
            //for testing purposes only
            Debug.Log(jsonString);
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
        return JsonMapper.ToObject(jsonString);
    }
    
}
