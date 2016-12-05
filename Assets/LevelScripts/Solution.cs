using UnityEngine;
using System.Collections;
using C5;

public class Solution {
    private ArrayList<int> inputs;
    private ArrayList<int> outputs;
    private ArrayList<ArrayList<bool>> listOfInputSolutions;
    private ArrayList<ArrayList<bool>> listOfOutputSolutions;

    void start(Level level)
    {
        inputs = new ArrayList<int>();
        outputs = new ArrayList<int>();
        listOfInputSolutions = new ArrayList<ArrayList<bool>>();
        listOfOutputSolutions = new ArrayList<ArrayList<bool>>();
    }
    public void saveSolution(Level level)
    {
        SolutionWriter.
    }

    public void setInputsAndOutputs(ArrayList<int> inputs, ArrayList<int> outputs)
    {
        this.inputs = inputs;
        this.outputs = outputs;
    }

    public void addARowToSolution(ArrayList<bool> inputSolution, ArrayList<bool> outputSolution)
    {
        //if the amount of bools equals the amount of input and outputs correctly
        if(inputSolution.Count == inputs.Count && outputSolution.Count == outputs.Count)
        {
            listOfInputSolutions.Add(inputSolution);
            listOfOutputSolutions.Add(outputSolution);
        }
    }
    public ArrayList<int> getInput() { return inputs; }
    public ArrayList<int> getOutput() { return outputs; }
    public ArrayList<ArrayList<bool>> getInputSolutions() { return listOfInputSolutions; }
    public ArrayList<ArrayList<bool>> getOutputSolutions() { return listOfOutputSolutions; }
}
