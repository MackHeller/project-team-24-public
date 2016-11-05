using UnityEngine;
using System.Collections;
using System;
using System.IO;
using LitJson;

public class levelReader : MonoBehaviour
{
    private JsonData levelInformation;
    private String jsonString;
    private String fileName;
    // Use this for initialization
    void Start()
    {
        fileName = "Levels/level1.JSON";
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Reader()
    {
        StreamReader sr = null;

        try
        {
            sr = new StreamReader(fileName);
            jsonString = sr.ReadToEnd();
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
        for (int i = 0; i < levelInformation["gates"].Count; i++)
        {
            if (levelInformation["gates"][i].ToString() == name)
            {
                return levelInformation["gates"][i];
            }
        }
        return null;
    }
    ArrayList getLevelInput(String name)
    {
        for (int i = 0; i < levelInformation["gates"].Count; i++)
        {
            if (levelInformation["gates"][i].ToString() == name)
            {
                return levelInformation["gates"][i];
            }
        }
        return null;
    }


}
