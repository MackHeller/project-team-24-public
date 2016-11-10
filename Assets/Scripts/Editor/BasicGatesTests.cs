﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class BasicGatesTests
	{
		// Note: a reference (References -> Edit references) to NUnit's DDL file (find
		// online) is needed to run these tests

		[Test]
		public void andTest() {
			// Need to use toString() to compare nullable (3-value) bools

			GateAND gate = new GateAND(2);
			Wire wire1 = new Wire ();
			gate.setOutput (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			Assert.AreEqual (true.ToString(), wire1.getInput().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getInput().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (false.ToString (), wire1.getInput().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getInput().ToString());
		}

		[Test]
		public void orTest() {
			GateOR gate = new GateOR(2);
			Wire wire1 = new Wire ();
			gate.setOutput (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			Assert.AreEqual (true.ToString(), wire1.getInput().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (true.ToString (), wire1.getInput().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (true.ToString (), wire1.getInput().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getInput().ToString());
		}

		[Test]
		public void xorTest() {
			GateXOR gate = new GateXOR(2);
			Wire wire1 = new Wire ();
			gate.setOutput (0, wire1);

			gate.notifyInput (0, true);
			gate.notifyInput (1, true);
			Assert.AreEqual (false.ToString(), wire1.getInput().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (true.ToString (), wire1.getInput().ToString());

			gate.notifyInput (0, true);
			gate.notifyInput (1, false);
			Assert.AreEqual (true.ToString (), wire1.getInput().ToString());

			gate.notifyInput (0, false);
			Assert.AreEqual (false.ToString (), wire1.getInput().ToString());
		}
	}


}

