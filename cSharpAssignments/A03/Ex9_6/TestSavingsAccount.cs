using System;
using System.Collections.Generic;
using System.Text;


public class TestSavingsAccount
{
    public static void Main(string[] args)
    {
        SavingsAccount sever1 = new SavingsAccount(2000.00);
        SavingsAccount sever2 = new SavingsAccount(3000.00);
        Console.WriteLine("Current balace of the saver1 = {0:C}", sever1.SavingsBalance);
        Console.WriteLine("Current balace of the saver2 = {0:C}", sever2.SavingsBalance);
        Console.WriteLine("");
        SavingsAccount.ModifyInterestRate(0.04);
        Console.WriteLine("Balances of saver1 and saver2 in case of Annual Interest Rate = 4%");
        sever1.CalculateMonthlyInterest();
        Console.WriteLine("The balace of saver1 = {0:C}", sever1.SavingsBalance);
        sever2.CalculateMonthlyInterest();
        Console.WriteLine("The balace of saver2 = {0:C}", sever2.SavingsBalance);
        Console.WriteLine("");
        Console.WriteLine("Balances of saver1 and saver2 in case of Annual Interest Rate = 5%");
        SavingsAccount.ModifyInterestRate(0.05);
        sever1.CalculateMonthlyInterest();
        Console.WriteLine("The balace of sever1 = {0:C}", sever1.SavingsBalance);
        sever2.CalculateMonthlyInterest();
        Console.WriteLine("The balace of sever2 = {0:C}", sever2.SavingsBalance);
        
    }
}

