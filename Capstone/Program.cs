using Capstone.Classes;
using Capstone.MenuOptions;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine test = new VendingMachine();
            MainMenu testMenu = new MainMenu(test);
            testMenu.DisplayMainMenu();
            
        }
    }
}
