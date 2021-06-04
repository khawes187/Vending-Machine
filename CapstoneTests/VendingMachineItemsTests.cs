using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineItemsTests
    {      
        [TestMethod]
        public void testUpdateQuantityHappyRoad()
        {
            VendingMachineItems vmItems = new VendingMachineItems("Chips", 5, "Chip");
            vmItems.Quantity = 5;
            int expected = 4;
            vmItems.UpdateQuantity();
            Assert.AreEqual(expected, vmItems.Quantity);
        }

        [TestMethod]
        public void testUpdateQuantityNegative()
        {
            VendingMachineItems vmItems = new VendingMachineItems("Chips", 5, "Chip");
            vmItems.Quantity = 0;
            int expected = 0;
            vmItems.UpdateQuantity();
            Assert.AreEqual(expected, vmItems.Quantity);
        }

        [TestMethod]
        public void testUpdateQuantityOneLeft()
        {
            VendingMachineItems vmItems = new VendingMachineItems("Chips", 5, "Chip");
            vmItems.Quantity = 1;
            int expected = 0;
            vmItems.UpdateQuantity();
            Assert.AreEqual(expected, vmItems.Quantity);
        }
    }
}
