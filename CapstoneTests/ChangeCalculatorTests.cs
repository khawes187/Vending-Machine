using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeCalculatorTests
    {
        [DataTestMethod]
        public void zeroDollarsReturnsZeroChange()
        {
            ChangeCalculator change = new ChangeCalculator(0M);

            Assert.AreEqual(0, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(0, change.Dimes);
            Assert.AreEqual(0, change.Quarters);
        }

        [TestMethod]
        public void smallChangeTests()
        {
            ChangeCalculator change = new ChangeCalculator(0.03M);

            Assert.AreEqual(3, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(0, change.Dimes);
            Assert.AreEqual(0, change.Quarters);

            change = new ChangeCalculator(0.17M);

            Assert.AreEqual(2, change.Pennies);
            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(0, change.Quarters);

            change = new ChangeCalculator(0.60M);

            Assert.AreEqual(0, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(2, change.Quarters);

            change = new ChangeCalculator(1.99M);
            Assert.AreEqual(4, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(2, change.Dimes);
            Assert.AreEqual(7, change.Quarters);
        }

        [TestMethod]
        public void largeChangeTests()
        {
            ChangeCalculator change = new ChangeCalculator(105.69M);

            Assert.AreEqual(4, change.Pennies);
            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(422, change.Quarters);
        }
    }
}
