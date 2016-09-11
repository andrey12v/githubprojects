using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPackage
{

    public class Account
    {

        private decimal accontBalance;

        public Account(decimal inpBalance)
        {
            accontBalance = inpBalance;
        }


        public decimal AccontBalance
        {
            get
            {
                return accontBalance;
            }
            set
            {
                if (value < 0)
                {
                    accontBalance = 0;
                    Console.WriteLine("Balance {0} {1}", value, "is not correct");
                }
                else
                {
                    accontBalance = value;
                }
            }
        }

        public virtual void getCredit(decimal amount)
        {
            accontBalance = accontBalance + amount;
        }

        public virtual bool getDebit(decimal amount)
        {
            if (amount > accontBalance)
            {
                Console.WriteLine("Debit amount exceeded account balance");
                return false;
            }
            else
            {
                accontBalance = accontBalance - amount;
                return true;
            }

        }

        
    }

}
