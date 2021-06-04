using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void FillSlotsTests()
        {
            VendingMachine vm = new VendingMachine();

            vm.FillSlots(new string[] { "A1|Potato Crisps|3.05|Chip" });

            Assert.AreEqual(true, vm.Inventory.ContainsKey("A1"));
            Assert.AreEqual(false, vm.Inventory.ContainsKey("E3"));
        }

        [TestMethod]
        public void FeedMoneyTests()
        {
            VendingMachine vm = new VendingMachine();

            vm.FeedMoney(5);

            Assert.AreEqual(5.00M, vm.Balance);
        }

        [TestMethod]
        public void DispenseItemsTests()
        {
            VendingMachine vm = new VendingMachine();
            
            vm.FillSlots(new string[] {"A1|Potato Crisps|3.05|Chip"});
            vm.DispenseItems("A1");

            Assert.AreEqual(4, vm.Inventory["A1"].Quantity);
            Assert.AreEqual(3.05M, vm.Inventory["A1"].Price);
            Assert.AreEqual(-3.05M, vm.Balance);
        }

        [TestMethod]
        public void MakeChangeTests()
        {
            VendingMachine vm = new VendingMachine();

            vm.MakeChange();

            Assert.AreEqual(0, vm.Balance);
        }
    }
}
