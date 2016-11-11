using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class LogicManagerTests
	{

		/*
		 * Tests whether the LogicManager runs and correctly checks the output
		 * for a simple level containing an AND gate.
		 */
		[Test]
		public void simpleAndTest() {
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

		/*
		 * Tests whether add, remove, contains, and get for wires works
		 * properly.
		 */
		[Test]
		public void addRemoveWiresTest() {
			LogicManager manager = new LogicManager (2, 1);
			Wire addedWire  = manager.addWire (new Wire ());
			Wire addedWire2 = manager.addWire (new Wire ());

			Wire foundWire = manager.getWireAtId (addedWire.getId());
			Wire foundWire2 = manager.getWireAtId (addedWire2.getId ());

			Assert.AreEqual (addedWire, foundWire);
			Assert.AreNotEqual (addedWire2, foundWire);
			Assert.AreEqual (addedWire2, foundWire2);

			Assert.IsTrue (manager.containsWireAtId (addedWire.getId ()));
			manager.removeWireAtId (addedWire.getId());
			Assert.IsFalse (manager.containsWireAtId (addedWire.getId ()));
		}

		/*
		 * Tests whether add, remove, contains, and get for modules works
		 * properly.
		 */
		[Test]
		public void addRemoveModulesTest() {
			LogicManager manager = new LogicManager (2, 1);
			Module addedModule  = manager.addModule (new GateOR(10));
			Module addedModule2 = manager.addModule (new GateXOR(3));

			Module foundModule = manager.getModuleAtId (addedModule.getId());
			Module foundModule2 = manager.getModuleAtId (addedModule2.getId ());

			Assert.AreEqual (addedModule, foundModule);
			Assert.AreNotEqual (addedModule2, foundModule);
			Assert.AreEqual (addedModule2, foundModule2);

			Assert.IsTrue (manager.containsModuleAtId (addedModule.getId ()));
			manager.removeModuleAtId (addedModule.getId());
			Assert.IsFalse (manager.containsModuleAtId (addedModule.getId ()));
		}
	}


}

