using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //Properties
        public decimal Balance { get; set; }
        public Dictionary<string, VendingMachineItems> Inventory { get; } = new Dictionary<string, VendingMachineItems>();


        public List<string> auditList = new List<string>();


        //Methods
        public void CallInventory()
        {
            try
            {
                string directory = Directory.GetCurrentDirectory();
                string sourceFile = @"..\..\..\..\vendingmachine.csv";
                string fullPath = Path.Combine(directory, sourceFile);
                using(StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string eachLine = sr.ReadLine();
                        string[] item = eachLine.Split("|");
                        Inventory.Add(item[0], new VendingMachineItems(item[1], decimal.Parse(item[2]), item[3]));
                    }
                }
            }
            catch(Exception)
            {
                Console.WriteLine("An error occured while gathering the inventory from vendingmachine.csv. Please restart program and try again");
            }
        }

        public void DisplayItems()
        {
            foreach (KeyValuePair<string, VendingMachineItems> kvp in Inventory)
            {
                string splitValue = kvp.Value.ToString();
                splitValue.Split(" ");
                if (splitValue[1] == 0)
                {
                    Console.WriteLine($"Slot:{kvp.Key}  Name:{splitValue[0]}  Amount Remaining: SOLD OUT  Type:{splitValue[2]}");
                }
                else
                {
                    Console.WriteLine($"Slot:{kvp.Key}  Name:{splitValue[0]}  Amount Remaining:{splitValue[1]}  Type:{splitValue[2]}");
                }
                
            }
        }
        
        public void DispenseItems(string selection)
        {
            Balance -= Inventory[selection].Price;
            Inventory[selection].Quantity--;
            //Audit below
            auditList.Add($"{DateTime.Now} {Inventory[selection].ProductName} {selection} ${this.Balance + Inventory[selection].Price} ${this.Balance}");
        }

        public void FeedMoney(int money)
        {
            Balance += money;
            //Audit Below
            auditList.Add($"{DateTime.Now} FEED MONEY: ${money} ${this.Balance}");
        }

        public void MakeChange()
        {
            decimal balanceToReturn = Balance;
            Balance = 0;
            //Audit Below
            auditList.Add($"{DateTime.Now} GIVE CHANGE: ${balanceToReturn} ${Balance}");

        }

        public void Audit() //Write auditList to file at the close of main menu
        {
            string directory = Directory.GetCurrentDirectory();
            string sourceFile = @"..\..\..\..\Log.txt";
            string fullPath = Path.Combine(directory, sourceFile);           
                try
                {
                    using (StreamWriter sw = new StreamWriter(fullPath,true))
                    {
                        foreach (string item in auditList)
                        {
                            sw.WriteLine(item);
                        }                           
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("An error occured while writing the audit to Log.txt. Please restart program and try again");
                }
        }

    }
}
