using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPackage
{
    public class SavingsAccount:Account
    {

        private decimal interestRate;
        public SavingsAccount(decimal inpBalance, decimal inpIntRate)
            : base(inpBalance)
        {
            interestRate = inpIntRate;
        }

        public decimal InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value;
            }
        }

        public decimal CalculateInterest()
        {
            return base.AccontBalance * (interestRate / 100);
        }
        
    }
}
