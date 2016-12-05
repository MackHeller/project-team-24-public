using UnityEngine;
using System.Collections;
using C5;

public class Solution {
    private ArrayList<ArrayList<bool?>> listOfInputSolutions = new ArrayList<ArrayList<bool?>>();
    private ArrayList<ArrayList<bool?>> listOfOutputSolutions = new ArrayList<ArrayList<bool?>>();

    private Level level;

    public Solution(Level levelSolutionIsFor) {
        level = levelSolutionIsFor;
    }

    public void addARowToSolution(ArrayList<bool?> inputSolution, ArrayList<bool?> outputSolution) {
        //if the amount of bools equals the amount of input and outputs correctly
        if (inputSolution.Count == level.getLevelInput().Count && outputSolution.Count == level.getLevelOutput().Count) {
            listOfInputSolutions.Add(inputSolution);
            listOfOutputSolutions.Add(outputSolution);
        }
    }

    public override bool Equals(object other) {
        var otherSolution = other as Solution;
        if (otherSolution == null) {
            return false;
        }
        return getInputSolutions().Equals(otherSolution.getInputSolutions())
            && getOutputSolutions().Equals(otherSolution.getOutputSolutions());
    }

    public ArrayList<ArrayList<bool?>> getInputSolutions() { return listOfInputSolutions; }
    public ArrayList<ArrayList<bool?>> getOutputSolutions() { return listOfOutputSolutions; }
}
