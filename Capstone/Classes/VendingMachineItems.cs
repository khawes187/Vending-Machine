using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// The items in the vending machine that are stocked
    /// Starts with 5 of the product and goes down as purchased
    /// </summary>
    public class VendingMachineItems
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string PurchaseMessage
        {
            get
            {
                switch(Type)
                {
                    case "Chip":
                        return "Crunch, Crunch, Yum!";
                    case "Drink":
                        return "Glug, Glug, Yum!";
                    case "Candy":
                        return "Munch, Munch, Yum!";
                    case "Gum":
                        return "Chew, Chew, Yum!";
                    default:
                        return "Yum Yum!";
                }
            }
        }



        //Constructors
        public VendingMachineItems(string name, decimal price, string type)
        {
            this.ProductName = name;
            this.Price = price;
            this.Type = type;
            this.Quantity = 5;
        }

        //Methods
        public void UpdateQuantity()
        {
            this.Quantity -= 1;
        }
    }
}
