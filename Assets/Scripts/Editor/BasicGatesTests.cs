using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssemblyCSharp {

    public class BasicGatesTests {
        // Tests a series of 2-to-1 gates for all values.
        // Note: a reference (References -> Edit references) to NUnit's DDL file (find
        // online) is needed to run these tests


        /*
		 * Checks the correctness of the AND gate on 2 inputs.
		 */
        [Test]
        public void andTest() {
            // Need to use toString() to compare nullable (3-value) bools

            GateAnd gate = new GateAnd(2);

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(true);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());
        }

        /*
		 * Checks the correctness of the AND gate on 5 inputs.
		 */
        [Test]
        public void and5InputsTest() {
            GateAnd gate = new GateAnd(5);

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(true);
            gate.getInputJunction(2).setValue(true);
            gate.getInputJunction(3).setValue(true);
            gate.getInputJunction(4).setValue(true);

            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(1).setValue(true);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());
        }

        /*
		 * Checks the correctness of the OR gate on 2 inputs.
		 */
        [Test]
        public void orTest() {
            GateOr gate = new GateOr(2);

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(true);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(false);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());
        }

        /*
		 * Checks the correctness of the XOR gate on 2 inputs.
		 */
        [Test]
        public void xorTest() {
            GateXor gate = new GateXor(2);

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(true);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(true);
            gate.getInputJunction(1).setValue(false);
            Assert.AreEqual(true.ToString(), gate.getOutputJunction(0).getValue().ToString());

            gate.getInputJunction(0).setValue(false);
            Assert.AreEqual(false.ToString(), gate.getOutputJunction(0).getValue().ToString());
        }
    }


}

