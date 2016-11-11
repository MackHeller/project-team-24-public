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
		 * Tests whether the LogicManager runs and correctly checks the output
		 * for a bigger level containing two OR gates hooked into an AND gate.
		 */
		[Test]
		public void threeGateTest() {
			// Need to use toString() to compare nullable (3-value) bools

			LogicManager manager = new LogicManager (4, 1);
			manager.setInputLogicAt (0, true);
			manager.setInputLogicAt (1, false);
			manager.setInputLogicAt (2, true);
			manager.setInputLogicAt (3, false);
			manager.setExpectedOutputLogicAt (0, true);

			GateOR or1 = new GateOR (2);
			GateOR or2 = new GateOR (2);
			Wire wire1 = new Wire ();
			Wire wire2 = new Wire ();
			GateAND and = new GateAND (2);

			// hook up the input wires 
			manager.getInputWireAt (0).addOutput (or1, 0);
			manager.getInputWireAt (1).addOutput (or1, 1);
			manager.getInputWireAt (2).addOutput (or2, 0);
			manager.getInputWireAt (3).addOutput (or2, 1);

			// hook up the OR gate outputs to 2 wires
			or1.setOutputAt (0, wire1);
			or2.setOutputAt (0, wire2);

			// hook up the 2 wire outputs into the AND gate
			wire1.addOutput (and, 0);
			wire2.addOutput (and, 1);

			// hook up AND gate output to the output wire
			and.setOutputAt (0, manager.getOutputWireAt (0));


			// 10 10 -> 1
			manager.run ();
			Assert.IsTrue(manager.checkIfOutputIsCorrect());

			// 00 10 -> 0
			manager.setInputLogicAt (0, false);
			manager.setExpectedOutputLogicAt (0, false);
			manager.run ();
			Assert.IsTrue(manager.checkIfOutputIsCorrect());

			// 10 00 -> 0
			manager.setInputLogicAt (0, true);
			manager.setInputLogicAt (2, false);
			manager.setExpectedOutputLogicAt (0, false);
			manager.run ();
			Assert.IsTrue(manager.checkIfOutputIsCorrect());

			// 11 11 -> 1
			manager.setInputLogicAt (0, true);
			manager.setInputLogicAt (1, true);
			manager.setInputLogicAt (2, true);
			manager.setInputLogicAt (3, true);
			manager.setExpectedOutputLogicAt (0, true);
			manager.run ();
			Assert.IsTrue(manager.checkIfOutputIsCorrect());
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

