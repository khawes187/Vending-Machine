using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void testCallInventory()
        {
            VendingMachine vm = new VendingMachine();
            VendingMachine readervm = new VendingMachine();
            
            string directory = "C:\\Users\\Student\\git\\dotnet-capstone-1-team-1";
            string sourceFile = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, sourceFile);
            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string eachLine = sr.ReadLine();
                    string[] item = eachLine.Split("|");
                    readervm.Inventory.Add(item[0], new VendingMachineItems(item[1], decimal.Parse(item[2]), item[3]));
                }
            }
            
            vm.CallInventory();
            Assert.AreEqual(readervm.Inventory.ToString(), vm.Inventory.ToString());
       
        }

        [TestMethod]
        public void feedMoneyTests()
        {
            VendingMachine vm = new VendingMachine();

            vm.FeedMoney(5);

            Assert.AreEqual(5.00M, vm.Balance);
        }

        [TestMethod]
        public void dispenseItemsTestsHappyRoad()
        {
            VendingMachine vm = new VendingMachine();
            
            vm.CallInventory();
            vm.FeedMoney(10);
            vm.DispenseItems("A1");
            
            Assert.AreEqual(4, vm.Inventory["A1"].Quantity);
            Assert.AreEqual(3.05M, vm.Inventory["A1"].Price);
            Assert.AreEqual(6.95M, vm.Balance);
        }

        [TestMethod]
        public void dispenseItemsTestsLater()
        {
            VendingMachine vm = new VendingMachine();

            vm.CallInventory();
            vm.FeedMoney(10);
            vm.DispenseItems("C4");
           
            Assert.AreEqual(4, vm.Inventory["C4"].Quantity);
            Assert.AreEqual(1.50M, vm.Inventory["C4"].Price);
            Assert.AreEqual(8.50M, vm.Balance);
        }

        [TestMethod]
        public void dispenseItemsTestsMultiples()
        {
            VendingMachine vm = new VendingMachine();

            vm.CallInventory();
            vm.FeedMoney(10);
            vm.DispenseItems("C4");
            vm.DispenseItems("C4");
            vm.DispenseItems("C4");
            vm.DispenseItems("C4");
            vm.DispenseItems("C4");

            Assert.AreEqual(0, vm.Inventory["C4"].Quantity);
            Assert.AreEqual(1.50M, vm.Inventory["C4"].Price);
            Assert.AreEqual(2.50M, vm.Balance);
        }

        [TestMethod]
        public void makeChangeTests()
        {
            VendingMachine vm = new VendingMachine();

            vm.MakeChange();

            Assert.AreEqual(0, vm.Balance);
        }
   
    }
}
