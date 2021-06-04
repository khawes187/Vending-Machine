using Capstone.Classes;
using Capstone.MenuOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    /// <summary>
    /// Purchase menu is a Main menu which guides the user through the purchase process flow
    /// of adding money, selecting their option(s), and finishing the transaction.
    /// </summary>
    public class PurchaseMenu : MainMenu
    {
        public PurchaseMenu(VendingMachine vm) : base(vm)
        {
        }

        public void DisplayPurchaseMenu()
        {
            string input;
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();

                Console.WriteLine("1) Feed Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine("\n");

                Console.WriteLine($"Current Money Provided: {VM.Balance:c}");
                Console.Write("Please Enter Selection: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Feedmoney
                        GetUsersPayment();
                        continue;
                    case "2": //Select product
                        Dictionary<string, VendingMachineItems> items = VM.Inventory;
                        DisplayItems(items);
                        SelectItem(items);
                        break;
                    case "3": //Finish Transaction
                        ChangeCalculator change = new ChangeCalculator(VM.Balance);
                        VM.MakeChange();
                        PrintChange(change);
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option. Please Try Again.");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        public void SelectItem(Dictionary<string, VendingMachineItems> items)
        {
            Console.Write("Please select item: ");
            string selection = Console.ReadLine().ToUpper();

            if (!items.ContainsKey(selection))
            {
                Console.WriteLine("Invalid Selection. Try Again.");
                Console.ReadLine();
            }
            else if (items[selection].Quantity < 1)
            {
                Console.WriteLine("Out of stock. Please make a different selection.");
                Console.ReadLine();
            }
            else if (VM.Balance < items[selection].Price)
            {
                Console.WriteLine($"You have insufficient funds. Please try again");
                Console.ReadLine();
            }
            else
            {
                VM.DispenseItems(selection);
                DisplayDispenseMessage(selection, items[selection]);
            }
        }

        public void DisplayDispenseMessage(string selection, VendingMachineItems item)
        {
            Console.Clear();
            Console.WriteLine($"{item.ProductName} is yours for only {item.Price:C}.");
            Console.WriteLine($"{item.PurchaseMessage}");
            Console.WriteLine($"You have {VM.Balance:C} remaining.");
            Console.WriteLine($"Press Enter to Return to Menu.");
            Console.ReadLine();
            Console.Clear();
        }


        public void GetUsersPayment()
        {
            Console.Write("Please deposit money. (Whole Dollar Only): ");
            string input = Console.ReadLine();



            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine($"Feed error. Please enter a whole dollar amount.");               
            }
            if (value < 0)
            {
                Console.WriteLine($"Feed error. Please enter a whole dollar amount.");               
            }
            else
            {
                VM.FeedMoney(value);
                Console.WriteLine($"{value:C} added.");
            }
            Console.ReadLine();
        }

        public void PrintChange(ChangeCalculator change)
        {
            Console.WriteLine($"Here is your change: {change.Quarters} Quarters, {change.Dimes} Dimes, {change.Nickels} Nickels, and {change.Pennies} Pennies");
        }
    }
}
