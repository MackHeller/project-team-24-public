using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class LogicManagerTests
	{
		// Note: a reference (References -> Edit references) to NUnit's DDL file (find
		// online) is needed to run these tests

		[Test]
		public void andCircuitTest1() {
			// Need to use toString() to compare nullable (3-value) bools

			LogicManager manager = new LogicManager (2, 1);
			manager.setInputLogicAt (0, true);
			manager.setInputLogicAt (1, true);
			manager.setExpectedOutputLogicAt (0, true);

			GateAND gate = new GateAND(2);

			// hook up input wires to the gate
			manager.getInputWireAt (0).addOutput (gate, 0);
			manager.getInputWireAt (1).addOutput (gate, 1);

			// hook up output wires
			gate.setOutputAt (0, manager.getOutputWireAt (0));

			// run the circuit
			manager.run();

			// check if circuit was correct
			Assert.AreEqual (true, manager.checkIfOutputIsCorrect());
		}

		[Test]
		public void andCircuitTest2() {
			// Need to use toString() to compare nullable (3-value) bools

			LogicManager manager = new LogicManager (2, 1);
			manager.setInputLogicAt (0, true);
			manager.setInputLogicAt (1, false);
			manager.setExpectedOutputLogicAt (0, true);

			GateAND gate = new GateAND(2);

			// hook up input wires to the gate
			manager.getInputWireAt (0).addOutput (gate, 0);
			manager.getInputWireAt (1).addOutput (gate, 1);

			// hook up output wires
			gate.setOutputAt (0, manager.getOutputWireAt (0));

			// run the circuit
			manager.run();

			// check if circuit was correct
			Assert.AreEqual (false, manager.checkIfOutputIsCorrect());
		}
	}


}

