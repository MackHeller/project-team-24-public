using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

public class LevelWriter {

    public static string saveAsNewLevel(Level level) {
        string filePath = Application.dataPath + "/Levels/" + level.getFileName() + ".JSON";
        writerLevel(filePath, level);
        return filePath;
    }

    private static void writerLevel(string filePath, Level level) {
        StreamWriter sw = null;
        string json = "{\"LevelName\": \"" + level.getLevelName() + "\",\n\"Creator\": \"" + level.getCreator() + "\",\n\"Description\": \"" + level.getDescription() +
            "\",\n\"star1\": " + level.getStars()[0] + ",\n\"star2\": " + level.getStars()[1] + ",\n\"star3\": " + level.getStars()[2];
        //do gates
        HashDictionary<BuiltinModuleController.BuiltinModules, int> gates = level.getGates();
        if (gates.Count > 0)
            json = json + ",\n\"Gates\": [";
        foreach (KeyValuePair<BuiltinModuleController.BuiltinModules, int> entry in gates)
            json = json + "{\"Name\": \"" + getBuildinGate(entry.Key) + "\",\n\"Amount\": " + entry.Value + "},\n";
        if (gates.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do inputs
        ArrayList<Int32> inputs = level.getLevelInput();
        if (inputs.Count > 0)
            json = json + ",\n\"Inputs\": [";
        for (int i = 0; i < inputs.Count; i++) {
            json = json + "{\"Id\": " + inputs[i] + "},\n";
        }
        if (inputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do outputs
        ArrayList<Int32> outputs = level.getLevelOutput();
        if (outputs.Count > 0)
            json = json + ",\n\"Outputs\": [";
        for (int i = 0; i < outputs.Count; i++) {
            json = json + "{\"Id\": " + outputs[i] + "},\n";
        }
        if (outputs.Count > 0)
            json = json.Remove(json.Length - 2) + "\n]";

        //do solution
        json += ",\n\"Solution\": [";
        ArrayList<ArrayList<bool?>> listOfInputSolutions = level.getSolution().getInputSolutions();
        ArrayList<ArrayList<bool?>> listOfOutputSolutions = level.getSolution().getOutputSolutions();
        for (int j = 0; j < listOfInputSolutions.Count; j++) {
            if (listOfInputSolutions.Count != listOfOutputSolutions.Count) {
                throw new ArgumentException("input and output solution values must be equal in number");
            }
            json += "\n[";
            //do inputs
            ArrayList<bool?> inputSolution = listOfInputSolutions[j];
            if (inputSolution.Count > 0)
                json += "[";
            for (int i = 0; i < inputSolution.Count; i++) {
                json += "\"" + inputSolution[i] + "\",";
            }
            if (inputSolution.Count > 0)
                json = json.Remove(json.Length - 1) + "],";

            //do outputs
            ArrayList<bool?> outputSolution = listOfOutputSolutions[j];
            if (outputSolution.Count > 0)
                json += "[";
            for (int i = 0; i < outputSolution.Count; i++) {
                json += "\"" + outputSolution[i] + "\",";
            }
            if (outputSolution.Count > 0)
                json = json.Remove(json.Length - 1) + "]";
            json += "],";
        }
        json = json.Remove(json.Length - 1) + "\n]";

        json = json + "\n}";
        try {
            sw = new StreamWriter(filePath);
            sw.WriteLine(json);
        } catch (IOException e) {
            Console.WriteLine(e.Message);
        } finally {
            if (sw != null)
                sw.Dispose();
        }
    }
    private static string getBuildinGate(BuiltinModuleController.BuiltinModules builtin) {
        switch (builtin) {
            case BuiltinModuleController.BuiltinModules.AND:
                return "And";
            case BuiltinModuleController.BuiltinModules.NAND:
                return "Nand";
            case BuiltinModuleController.BuiltinModules.OR:
                return "Or";
            case BuiltinModuleController.BuiltinModules.NOR:
                return "Nor";
            case BuiltinModuleController.BuiltinModules.NOT:
                return "Not";
            case BuiltinModuleController.BuiltinModules.XOR:
                return "Xor";
            case BuiltinModuleController.BuiltinModules.NXOR:
                return "Nxor";
            default:
                throw new Exception("Cannot find given gate" + builtin);
        }
    }
}
