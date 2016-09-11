using System;
using System.Collections.Generic;
using System.Text;
using AccountPackage;

public class TestAccount
{
        static void Main(string[] args)
        {
            Account accountObj = new Account(5000);
            Console.WriteLine("TEST OF THE CLASS ACCOUNT");
            Console.WriteLine("Current balance of class account is {0:C}", accountObj.AccontBalance);
            Console.WriteLine("Add 200 dollars to the balance by means of method credit");
            accountObj.getCredit(200);
            Console.WriteLine("Current balance of class account is {0:C}", accountObj.AccontBalance);
            Console.WriteLine("Subtract 5600 dollars from the balance by means of method debit");
            accountObj.getDebit(5600);
            Console.WriteLine("Subtract 700 dollars from the balance by means of method debit");
            accountObj.getDebit(700);
            Console.WriteLine("Current balance of class account is {0:C}", accountObj.AccontBalance);
            Console.WriteLine("");

            Console.WriteLine("TEST OF THE CLASS SAVINGS ACCOUNT");
            SavingsAccount savingAcct = new SavingsAccount(2500, 13);
           
            Console.WriteLine("Current balance of class Savings Account is {0:C}", savingAcct.AccontBalance);
            Console.WriteLine("Interest earned by account is {0:C}", savingAcct.CalculateInterest());
            decimal calculatedInterest = savingAcct.CalculateInterest();
            savingAcct.getCredit(calculatedInterest);
            Console.WriteLine("Curent balance after addition of interest rate {0:C}", savingAcct.AccontBalance);

            Console.WriteLine("");
            Console.WriteLine("TEST OF THE CLASS CHECKING ACCOUNT"); 
            CheckingAccount checkingAcct = new CheckingAccount(1890, 34);
            Console.WriteLine("Current balance of class Checking Account is {0:C} and \nFee per transaction is {1:C}", checkingAcct.AccontBalance, checkingAcct.FeeCharged);
            checkingAcct.getCredit(350);
            Console.WriteLine("350 dollars were deposited by means of the method credit");
            Console.WriteLine("Current balance after credit transaction is {0:C}", checkingAcct.AccontBalance);
            Console.WriteLine("100 dollars were withdrawn by means of the method debit");
            checkingAcct.getDebit(100);
            Console.WriteLine("Current balance after debit transaction {0:C}", checkingAcct.AccontBalance);
                
        }
}

