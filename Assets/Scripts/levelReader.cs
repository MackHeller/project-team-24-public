using UnityEngine;
using System.Collections;
using System;
using System.IO;
using LitJson;
using C5;

public class levelReader : MonoBehaviour
{
    private JsonData levelInformation;
    private String jsonString;
    // Use this for initialization
    void Start()
    {
        loadNewLevel("level1");
    }
    void loadNewLevel(String fileName)
    {
        Reader(Application.dataPath + "/Levels/" + fileName +".JSON");
    }
    void Reader(String fileName)
    {
        StreamReader sr = null;

        try
        {
            sr = new StreamReader(fileName);
            jsonString = sr.ReadToEnd();
            Debug.Log(jsonString);
            levelInformation = JsonMapper.ToObject(jsonString);
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
    }

    JsonData getGate(String name)
    {
        for (int i = 0; i < levelInformation["Gates"].Count; i++)
        {
            if (levelInformation["Gates"][i].ToString() == name)
            {
                return levelInformation["Gates"][i];
            }
        }
        return null;
    }
    ArrayList<bool> getLevelInput()
    {
        ArrayList<bool> inputs = new ArrayList<bool>();
        for (int i = 0; i < levelInformation["Inputs"].Count; i++)
        {
            inputs.Add(Convert.ToBoolean(levelInformation["Inputs"][i].ToString()));
        }
        return inputs;
    }
    ArrayList<bool> getLevelOutput()
    {
        ArrayList<bool> output = new ArrayList<bool>();
        for (int i = 0; i < levelInformation["Output"].Count; i++)
        {
            output.Add(Convert.ToBoolean(levelInformation["Output"][i].ToString()));
        }
        return output;
    }


}
