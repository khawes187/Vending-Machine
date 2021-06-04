using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.MenuOptions
{
    /// <summary>
    /// The main menu that allows the user to select the items they want and lets them purchase said items
    /// </summary>
    public class MainMenu
    {
        public VendingMachine VM { get; }

        public MainMenu(VendingMachine vm)
        {
            this.VM = vm;
        }
        public void DisplayMainMenu()
        {
            VM.CallInventory();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("3) Exit");
                Console.Write("Please Enter Selection: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1"://Calls display items
                        Dictionary<string, VendingMachineItems> items = VM.Inventory;
                        DisplayItems(items);
                        Console.WriteLine("\nPress Enter to Return to The Main Manu Selection.");
                        Console.ReadLine();
                        break;

                    case "2"://Calls Purchase Menu
                        PurchaseMenu menu = new PurchaseMenu(VM);
                        menu.DisplayPurchaseMenu();
                        Console.WriteLine("\nPress Enter to Return to The Main Manu Selection.");
                        Console.ReadLine();
                        break;

                    case "3"://Exits Program
                        VM.theAudit();
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Menu Option. Please Try Again.");
                        Console.ReadLine();
                        continue;
                }
            }
        }
        public void DisplayItems(Dictionary<string, VendingMachineItems> items)
        {
            Console.WriteLine("\n\t\t-----------------------------------------------");
            Console.WriteLine("\t\t|{0, 0} | {1, -20} | {2, 5} | {3, 8} |", "ID", "ITEM", "PRICE", "REMAINING");
            Console.WriteLine("\t\t-----------------------------------------------");
            foreach (KeyValuePair<string, VendingMachineItems> kvp in items)
            {
                string quantity = "";

                if (kvp.Value.Quantity == 0)
                {
                    quantity = "Sold Out";
                }
                else
                {
                    quantity = kvp.Value.Quantity.ToString();
                }
                Console.WriteLine($"\t\t|{kvp.Key,0} | {kvp.Value.ProductName,20} | {kvp.Value.Price,5} | {quantity,8} |");
            }
            Console.WriteLine("\t\t-----------------------------------------------");
        }
    }
}
