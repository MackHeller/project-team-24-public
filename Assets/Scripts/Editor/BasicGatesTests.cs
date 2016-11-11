using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class BasicGatesTests
	{
		// Tests a series of 2-to-1 gates for all values.
		// Note: a reference (References -> Edit references) to NUnit's DDL file (find
		// online) is needed to run these tests


		/*
		 * Checks the correctness of the AND gate on 2 inputs.
		 */
		[Test]
		public void andTest() {
			// Need to use toString() to compare nullable (3-value) bools

			GateAND gate = new GateAND(2);
			Wire wire1 = new Wire ();
			gate.setOutputAt (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			Assert.AreEqual (true.ToString(), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());
		}

		/*
		 * Checks the correctness of the AND gate on 5 inputs.
		 */
		[Test]
		public void and5InputsTest() {
			GateAND gate = new GateAND(5);
			Wire wire1 = new Wire ();
			gate.setOutputAt (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			gate.notifyInput (2, true);
			gate.notifyInput (3, true);
			gate.notifyInput (4, true);

			Assert.AreEqual (true.ToString(), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (1, true);
			Assert.AreEqual (true.ToString (), wire1.getBooleanValue().ToString());
		}

		/*
		 * Checks the correctness of the OR gate on 2 inputs.
		 */
		[Test]
		public void orTest() {
			GateOR gate = new GateOR(2);
			Wire wire1 = new Wire ();
			gate.setOutputAt (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			Assert.AreEqual (true.ToString(), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (true.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (true.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());
		}

		/*
		 * Checks the correctness of the XOR gate on 2 inputs.
		 */
		[Test]
		public void xorTest() {
			GateXOR gate = new GateXOR(2);
			Wire wire1 = new Wire ();
			gate.setOutputAt (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			Assert.AreEqual (false.ToString(), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (true.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (true.ToString (), wire1.getBooleanValue().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getBooleanValue().ToString());
		}
	}


}

