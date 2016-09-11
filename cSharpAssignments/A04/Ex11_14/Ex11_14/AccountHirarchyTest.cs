using System;
using System.Collections.Generic;
using System.Text;
using AccountPackage;

public class AccountHirarchyTest
{
    public static void Main(string[] args)
    {
        Account[] accountObjArr = new Account[4];
                
        CheckingAccount checkingAcct1 = new CheckingAccount(1500, 25);
        SavingsAccount savingAcct1 = new SavingsAccount(3000, 20);
        CheckingAccount checkingAcct2 = new CheckingAccount(1000, 15);
        SavingsAccount savingAcct2 = new SavingsAccount(2000, 10);

        accountObjArr[0] = checkingAcct1;
        accountObjArr[1] = savingAcct1;
        accountObjArr[2] = checkingAcct2;
        accountObjArr[3] = savingAcct2;


        Console.WriteLine("TEST OF CHECKING ACCOUNT");
        //down casting to get access to methods and varibles of class CheckingAccount
        CheckingAccount currentCheckingAcct = (CheckingAccount)accountObjArr[0];

        Console.WriteLine("Current balance of Checking Account is {0:C} and \nfee charged is {1:C} ", +
            accountObjArr[0].AccontBalance, currentCheckingAcct.FeeCharged);

        Console.WriteLine("150 dollars were deposited in checking account by means of the method Credit");
        accountObjArr[0].getCredit(150);
        Console.WriteLine("Current balance of Checking Account is {0:C}", accountObjArr[0].AccontBalance);
        Console.WriteLine("350 dollars were withdrawn from checking account by means of the method Debit");
        accountObjArr[0].getDebit(350);
        Console.WriteLine("Current balance of Checking Account is {0:C}", accountObjArr[0].AccontBalance);
        Console.WriteLine("");
        Console.WriteLine("TEST OF SAVINGS ACCOUNT");
        
        //down casting to get access to methods and varibles of class SavingsAccount
        SavingsAccount currentSavingsAcct = (SavingsAccount)accountObjArr[1];
        
        Console.WriteLine("Current balance of Savings Account is {0:C} and \ninterest rate is {1}% ", +
            accountObjArr[1].AccontBalance, currentSavingsAcct.InterestRate);
        
        decimal currentInterest=currentSavingsAcct.CalculateInterest(); 
        currentSavingsAcct.getCredit(currentInterest);
         
        Console.WriteLine("Interest of saving account is {0:C} and \nbalance after calculation of interest rate is {1:C}", +
            currentInterest, accountObjArr[1].AccontBalance);

        Console.WriteLine("");
        Console.WriteLine("TEST ON TYPE OF OBJECT AND CALCULATION OF INTEREST RATE FOR SAVINGS ACCOUNT");

        for (int i = 0; i < accountObjArr.Length; i++)
        {
            if (accountObjArr[i] == checkingAcct1 || accountObjArr[i] == checkingAcct2)
            {
                Console.WriteLine("Current balance of checking account is {0:C}", accountObjArr[i].AccontBalance);
            }
            else 
            {
                Console.WriteLine("---------------");
                SavingsAccount currentSavingsAcctLoop = (SavingsAccount)accountObjArr[i];
                currentInterest = currentSavingsAcctLoop.CalculateInterest();
                
                Console.WriteLine("Current balance of savings account is {0:C} and" +
                  "\ninterest of savings account is {1:C}", accountObjArr[i].AccontBalance, currentInterest);  
                
                currentSavingsAcctLoop.getCredit(currentInterest);                                
                Console.WriteLine("This interest was added to account balance");
                Console.WriteLine("Final balance of savings account is {0:C}", accountObjArr[i].AccontBalance);
                Console.WriteLine("---------------");
               
            }
            
        }

    }
}


