using UnityEngine;
using System.Collections;
using C5;
using System;

public class Solution {
    private ArrayList<ArrayList<bool?>> listOfInputSolutions = new ArrayList<ArrayList<bool?>>();
    private ArrayList<ArrayList<bool?>> listOfOutputSolutions = new ArrayList<ArrayList<bool?>>();

    private int inputCount;
    private int outputCount;

    public Solution(int inputCount, int outputCount) {
        this.inputCount = inputCount;
        this.outputCount = outputCount;
    }

    public void addARowToSolution(ArrayList<bool?> inputSolution, ArrayList<bool?> outputSolution) {
        //if the amount of bools equals the amount of input and outputs correctly
        if (inputSolution.Count == inputCount && outputSolution.Count == outputCount) {
            listOfInputSolutions.Add(inputSolution);
            listOfOutputSolutions.Add(outputSolution);
        }
    }

    public override bool Equals(object other) {
        Solution otherSolution = other as Solution;
        if (otherSolution == null) {
            return false;
        }
        if (inputCount != otherSolution.inputCount
            || outputCount != otherSolution.outputCount
            || getInputSolutions().Count != otherSolution.getInputSolutions().Count
            || getOutputSolutions().Count != otherSolution.getOutputSolutions().Count) {
            return false;
        }
        for (int i = 0; i < getInputSolutions().Count; i++) {
            if (!boolArrayEquals(getInputSolutions()[i], otherSolution.getInputSolutions()[i])) {
                return false;
            }
        }
        for (int i = 0; i < getOutputSolutions().Count; i++) {
            if (!boolArrayEquals(getOutputSolutions()[i], otherSolution.getOutputSolutions()[i])) {
                return false;
            }
        }
        return true;
    }

    private bool boolArrayEquals(ArrayList<bool?> array1, ArrayList<bool?> array2) {
        if (array1.Count != array2.Count) {
            return false;
        }
        for (int i = 0; i < array1.Count; i++) {
            if (!array1[i].Equals(array2[i])) {
                return false;
            }
        }
        return true;
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

    public override string ToString() {
        string json = "[\n";
        for (int j = 0; j < listOfInputSolutions.Count; j++) {
            json += "[[";

            //do inputs
            ArrayList<bool?> inputSolution = listOfInputSolutions[j];
            for (int i = 0; i < inputSolution.Count; i++) {
                json += "\"" + inputSolution[i] + "\",";
            }
            if (inputSolution.Count > 0)
                json = json.Remove(json.Length - 1);

            json += "],[";

            //do outputs
            ArrayList<bool?> outputSolution = listOfOutputSolutions[j];
            for (int i = 0; i < outputSolution.Count; i++) {
                json += "\"" + outputSolution[i] + "\",";
            }
            if (outputSolution.Count > 0)
                json = json.Remove(json.Length - 1);

            json += "]]";
        }
        return json + "\n]";
    }

    public ArrayList<ArrayList<bool?>> getInputSolutions() { return listOfInputSolutions; }
    public ArrayList<ArrayList<bool?>> getOutputSolutions() { return listOfOutputSolutions; }
}
