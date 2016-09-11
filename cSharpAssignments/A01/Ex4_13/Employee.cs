using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string firstname;
    private string lastname;
    private decimal monthlysalary;

    public Employee()
    {
        firstname = "";
        lastname = "";
        monthlysalary = 0;
    }
    
    public Employee(string inpFirstName, string inpLastName, decimal inpMonthlySalary)
    {
        firstname = inpFirstName;
        lastname = inpLastName;
        monthlysalary = inpMonthlySalary;
    }
    
    public double IncreaseSalary(int inpPercent) 
    {
        return (double)monthlysalary + (double)monthlysalary*((double)inpPercent / 100);
    }


    public string FirstName
    {
        get
        {
            return firstname;
        }
        set
        {
            firstname = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastname;
        }
        set
        {
            lastname = value;
        }
    }

    public decimal MonthlySalary
    {
        get
        {
            return monthlysalary;
        }
        set
        {

            if (monthlysalary >= 0)
            {
                monthlysalary = value;
            }
            else
            {
                monthlysalary = 0;
            }
        }
    }


}
