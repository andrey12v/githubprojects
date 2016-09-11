using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPackage
{
    public class CheckingAccount:Account
    {
        
        private decimal feeCharged;

        public CheckingAccount(decimal inpBalance, decimal inpfeeCharged)
            : base(inpBalance)
        {
            feeCharged = inpfeeCharged;
        }

        public decimal FeeCharged
        {
            get
            {
                return feeCharged;
            }
            set
            {
                feeCharged = value;
            }
        }

        private void getFeeCharged()
        {
            base.AccontBalance = base.AccontBalance - FeeCharged;
        }


        public override bool getDebit(decimal amount)
        {
            if (base.getDebit(amount) == true)
            {
                getFeeCharged();
            }
            return true;

        }


        public override void getCredit(decimal amount)
        {
            base.getCredit(amount);
            getFeeCharged();
        }
    
    }
}
