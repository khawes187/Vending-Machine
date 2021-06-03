using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Makes change when the user puts to much money into the machine, reduces to least amount
    /// of coins necessary
    /// </summary>
    public class ChangeCalculator
    {
        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickels { get; private set; }
        public int Pennies { get; private set; }

        public ChangeCalculator (decimal balance)
        {
            int balanceInPennies = (int)(balance * 100);
            Quarters = balanceInPennies / 25;
            balanceInPennies = balanceInPennies % 25;
            Dimes = balanceInPennies / 10;
            balanceInPennies = balanceInPennies % 10;
            Nickels = balanceInPennies / 5;
            Pennies = balanceInPennies % 5;
        }
    }
}
