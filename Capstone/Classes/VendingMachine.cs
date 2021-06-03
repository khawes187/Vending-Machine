using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //Properties
        public decimal Balance { get; set; }
        public Dictionary<string, VendingMachineItems> Inventory { get; } = new Dictionary<string, VendingMachineItems>();

        //Methods
        public void FillSlots(string[] stockList)
        {
            foreach (string line in stockList)
            {
                string[] item = line.Split("|");
                Inventory.Add(item[0], new VendingMachineItems(item[1], decimal.Parse(item[2]), item[3]));
            }
        }

        public void DispenseItems(string selection)
        {
            Balance -= Inventory[selection].Price;
            Inventory[selection].Quantity--;
            //insert audit here
        }

        public void FeedMoney(int money)
        {
            Balance += money;
            //insert audit here
        }
        public void MakeChange()
        {
            decimal balanceToReturn = Balance;
            Balance = 0;
            //insert audit here
        }
    }
}
