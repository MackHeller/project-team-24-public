using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

public class SolutionWriter
{

    public static void saveAsNewSolution(Level level, Solution solution)
    {
        writerSolution(Application.dataPath + "/Solutions/" + level.getFileName() + "-solution.JSON", level, solution);
    }

    private static void writerSolution(string filePath, Level level, Solution solution)
    {
        StreamWriter sw = null;
        string json = "{\"LevelName\": \"" + level.getLevelName() + "\",\n\"Creator\": \"" + level.getCreator();

        //do inputs
        ArrayList<Int32> inputs = solution.getInput();
        if (inputs.Count > 0)
            json = json + ",\n\"Inputs\": [";
        for (int i = 0; i < inputs.Count; i++)
        {
            json = json + "{\"Id\": " + inputs[i] + "},\n";
        }
        if (inputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do outputs
        ArrayList<Int32> outputs = solution.getOutput();
        if (outputs.Count > 0)
            json = json + ",\n\"Outputs\": [";
        for (int i = 0; i < outputs.Count; i++)
        {
            json = json + "{\"Id\": " + outputs[i] + "},\n";
        }
        if (outputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";
        json = json + "}";

        ArrayList<ArrayList<bool>> listOfInputSolutions = solution.getInputSolutions();
        ArrayList<ArrayList<bool>> listOfOutputSolutions = solution.getOutputSolutions();
        for (int j=0;j< listOfInputSolutions.Count;j++) {
            //do inputs
            ArrayList<bool> inputSolution = listOfInputSolutions[j];
            if (inputSolution.Count > 0)
                json = json + ",\n\"InputSolution\": [";
            for (int i = 0; i < inputSolution.Count; i++)
            {
                json = json + "{\"Value\": " + inputSolution[i] + "},\n";
            }
            if (inputSolution.Count > 0)
                json = json.Remove(json.Length - 2) + "\n]";

            //do outputs
            ArrayList<bool> outputSolution = listOfOutputSolutions[j];
            if (outputSolution.Count > 0)
                json = json + ",\n\"OutputSolution\": [";
            for (int i = 0; i < outputSolution.Count; i++)
            {
                json = json + "{\"Value\": " + outputSolution[i] + "},\n";
            }
            if (outputSolution.Count > 0)
                json = json.Remove(json.Length - 2) + "\n]";
            json = json + "}";
        }
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
            if (sw != null)
                sw.Dispose();
        }
    }
}
