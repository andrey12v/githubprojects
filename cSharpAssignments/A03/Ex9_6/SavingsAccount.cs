using System;
using System.Collections.Generic;
using System.Text;

public class SavingsAccount
{
    private static double annualInterestRate;
    private double savingsBalance;

    public SavingsAccount(double inpBalance)
    {
        savingsBalance = inpBalance;
    }

    public void CalculateMonthlyInterest()
    {
        savingsBalance = savingsBalance + savingsBalance * annualInterestRate / 12;
    }

    public static void ModifyInterestRate(double inpIntRate)
    {
        annualInterestRate = inpIntRate;
    }

    public double SavingsBalance
    {
        get
        {
            return savingsBalance;
        }
        set
        {
            savingsBalance = value;
        }
    }

}
