using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using C5;

/// <summary>
/// Contains methods to create the deserialized files for the premade levels.
/// </summary>
public class PremadeLevelSerializer {
    /*
	 * TODO: adjust after level editor is completed, require for proper implementation
	 * of these functions.
	 */
    /*
   /// <summary>
   /// Creates a serialized file for the puzzle level FourInputAndGate.
   /// </summary>
   public static void createFourInputAndGate() {
       Level lv = new Level ();
       lv.setLevelName ("FourInputAndGate");
       lv.setCreator ("Freddy");
       lv.setMinScore (1);

       ArrayList<bool> arrIn = new ArrayList<bool>();
       arrIn.Add (true);
       arrIn.Add (true);
       arrIn.Add (true);
       arrIn.Add (true);
       lv.setLevelInput (arrIn);

       ArrayList<bool> arrOut = new ArrayList<bool> ();
       arrOut.Add (true);
       lv.setLevelOutput (arrOut);

       ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
       lv.setGates (gates);

       lv.saveLevel ();
   }

   /// <summary>
   /// Creates a serialized file for the puzzle level XorGatePuzzle.
   /// </summary>
   public static void createXorGate() {
       Level lv = new Level ();
       lv.setLevelName ("XorGatePuzzle");
       lv.setCreator ("Freddy");
       lv.setMinScore (1);

       ArrayList<bool> arrIn = new ArrayList<bool>();
       arrIn.Add (true);
       arrIn.Add (true);
       lv.setLevelInput (arrIn);

       ArrayList<bool> arrOut = new ArrayList<bool> ();
       arrOut.Add (false);
       lv.setLevelOutput (arrOut);

       ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
       lv.setGates (gates);

       lv.saveLevel ();
   }

   /// <summary>
   /// Creates a serialized file for the puzzle level AndIntoOrPuzzle.
   /// </summary>
   public static void createAndIntoOr() {
       Level lv = new Level ();
       lv.setLevelName ("AndIntoOrPuzzle");
       lv.setCreator ("Freddy");
       lv.setMinScore (1);

       ArrayList<bool> arrIn = new ArrayList<bool>();
       arrIn.Add (true);
       arrIn.Add (true);
       arrIn.Add (true);
       lv.setLevelInput (arrIn);

       ArrayList<bool> arrOut = new ArrayList<bool> ();
       arrOut.Add (true);
       lv.setLevelOutput (arrOut);

       ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
       lv.setGates (gates);

       lv.saveLevel ();
   }

   /// <summary>
   /// Creates a serialized file for the puzzle level DoubleCircuitPuzzle.
   /// </summary>
   public static void createDoubleCircuit() {
       Level lv = new Level ();
       lv.setLevelName ("DoubleCircuitPuzzle");
       lv.setCreator ("Freddy");
       lv.setMinScore (1);

       ArrayList<bool> arrIn = new ArrayList<bool>();
       arrIn.Add (true);
       arrIn.Add (true);
       arrIn.Add (true);
       lv.setLevelInput (arrIn);

       ArrayList<bool> arrOut = new ArrayList<bool> ();
       arrOut.Add (true);
       lv.setLevelOutput (arrOut);

       ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
       lv.setGates (gates);

       lv.saveLevel ();
   }

   /// <summary>
   /// Creates a serialized file for the puzzle level DeMorgans1.
   /// </summary>
   public static void createDeMorgans1() {
       Level lv = new Level ();
       lv.setLevelName ("DeMorgans1");
       lv.setCreator ("Freddy");
       lv.setMinScore (1);

       ArrayList<bool> arrIn = new ArrayList<bool>();
       arrIn.Add (true);
       arrIn.Add (true);
       lv.setLevelInput (arrIn);

       ArrayList<bool> arrOut = new ArrayList<bool> ();
       arrOut.Add (false);
       lv.setLevelOutput (arrOut);

       ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
       lv.setGates (gates);

       lv.saveLevel ();
   }

   /// <summary>
   /// Creates a serialized file for the puzzle level DeMorgans2.
   /// </summary>
   public static void createDeMorgans2() {
       Level lv = new Level ();
       lv.setLevelName ("DeMorgans2");
       lv.setCreator ("Freddy");
       lv.setMinScore (1);

       ArrayList<bool> arrIn = new ArrayList<bool>();
       arrIn.Add (true);
       arrIn.Add (true);
       arrIn.Add (true);
       arrIn.Add (true);
       lv.setLevelInput (arrIn);

       ArrayList<bool> arrOut = new ArrayList<bool> ();
       arrOut.Add (true);
       lv.setLevelOutput (arrOut);

       ArrayList<LogicModule> gates = new ArrayList<LogicModule> ();
       lv.setGates (gates);

       lv.saveLevel ();
   }*/
}
