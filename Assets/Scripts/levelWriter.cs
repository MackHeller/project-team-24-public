using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

public class LevelWriter {
    public static void saveAsNewLevel(string levelName, Level level)
    {
        writer(Application.dataPath + "/Levels/" + levelName + ".JSON", level);
    }
    private static void writer(string filePath, Level level)
    {
        StreamWriter sw = null;
        string json = String.Format(@"{
	                                    ""LevelName"": ""{0}"",
                                        ""Par"": {1},
	                                    ""MinScore"": {2}",
                                        level.getLevelName(),level.getLevelPar(),level.getMinScore());
        //do gates
        ArrayList<Module> gates = level.getGates();
        if (gates.Count > 0)
            json = json + @",""Gates"": [";
        for (int i=0;i< gates.Count; i++)
        {
            json = String.Format(json + @"{
                                        ""Name"": {0},
		                                ""Amount"": {1}},", gates[i].getName(), convertMaxValue(gates[i].getAmount()));
        }
        if (gates.Count > 0)
            json = json.Remove(json.Length - 1) + "]";

        //do inputs
        ArrayList<bool> inputs = level.getLevelInput();
        if (inputs.Count > 0)
            json = json + @",""Inputs"": [";
        for (int i = 0; i < inputs.Count; i++)
        {
            json = String.Format(json + @"{
                                        ""Id"": {0},
		                                ""Value"": {1}},", i, inputs[i]);
        }
        if (inputs.Count > 0)
            json = json.Remove(json.Length - 1) + "]";

        //do outputs
        ArrayList<bool> outputs = level.getLevelOutput();
        if (outputs.Count > 0)
            json = json + @",""Outputs"": [";
        for (int i = 0; i < outputs.Count; i++)
        {
            json = String.Format(json + @"{
                                        ""Id"": {0},
		                                ""Value"": {1}},", i, outputs[i]);
        }
        if (outputs.Count > 0)
            json = json.Remove(json.Length - 1) + "]";

        //for testing
        Debug.Log(json);
        try
        {
            sw = new StreamWriter(filePath);
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
