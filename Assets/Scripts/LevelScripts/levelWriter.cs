using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

public class LevelWriter {
    public static void saveAsNewLevel(string levelName, Level level)
    {
        writerLevel(Application.dataPath + "/Levels/" + levelName + ".JSON", level);
        saveNewMetaData(getLevelNames());
    }
    public static void saveNewMetaData(String[] allLevelNames)
    {
        writerMetaData(Application.dataPath + "/Levels/levelMetaData.JSON", allLevelNames);
    }
    private static String[] getLevelNames()
    {
        String[] allfiles = System.IO.Directory.GetFiles(Application.dataPath + "/Levels/", "*.JSON", System.IO.SearchOption.TopDirectoryOnly);
        for (int i =0; i < allfiles.Length;i++)
        {
            int startIndex = (Application.dataPath + "/Levels/").Length;
            int endIndex = allfiles[i].Length - 5;
            allfiles[i] = allfiles[i].Substring(startIndex, endIndex - startIndex);
            Debug.Log(allfiles[i]);
        }
        return allfiles;
    }
    private static void writerMetaData(string filePath, String[] allLevelNames) {
        StreamWriter sw = null;
        string json = "";
        if (allLevelNames.Length > 0)
            json = json + "{\"level\": [";
        for (int i = 0; i < allLevelNames.Length; i++)
        {
            json = json + "{\"Name\": \"" + allLevelNames[i] + "\"},\n";
        }
        if (allLevelNames.Length > 0)
            json = json.Remove(json.Length - 2) + "\n]";
        try
        {
            sw = new StreamWriter(filePath);
            sw.WriteLine(json);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (sw != null) sw.Dispose();
        }
    }
    private static void writerLevel(string filePath, Level level)
    {
        StreamWriter sw = null;
        string json = "{\"LevelName\": \"" + level.getLevelName() + "\",\n\"Creator\": " + level.getCreator() + "\",\n\"Par\": " + level.getLevelPar() + ",\n\"MinScore\":" + level.getMinScore();
        //do gates
        ArrayList<Module> gates = level.getGates();
        if (gates.Count > 0)
            json = json + ",\n\"Gates\": [";
        for (int i=0;i< gates.Count; i++)
        {
            json = json + "{\"Name\": \""+ gates[i].getName() + "\",\n\"Amount\": "+ convertMaxValue(gates[i].getAmount()) + "},\n";
        }
        if (gates.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do inputs
        ArrayList<bool> inputs = level.getLevelInput();
        if (inputs.Count > 0)
            json = json + ",\n\"Inputs\": [";
        for (int i = 0; i < inputs.Count; i++)
        {
            json = json + "{\"Id\": "+i+",\n\"Value\": \""+ inputs[i] + "\"},\n";
        }
        if (inputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do outputs
        ArrayList<bool> outputs = level.getLevelOutput();
        if (outputs.Count > 0)
            json = json + ",\n\"Outputs\": [";
        for (int i = 0; i < outputs.Count; i++)
        {
            json = json + "{\"Id\": " + i + ",\n\"Value\": \"" + outputs[i] + "\"},\n";
        }
        if (outputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";
        json = json + "}";
        try
        {
            sw = new StreamWriter(filePath);
            sw.WriteLine(json);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (sw != null) sw.Dispose();
        }
    }
    private static int convertMaxValue(int i)
    {
        if (i.Equals(Int32.MaxValue))
            return -1;
        return i;
            
    }
}
