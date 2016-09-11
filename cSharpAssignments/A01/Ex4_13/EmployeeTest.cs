using System;
using System.Collections.Generic;
using System.Text;

public class EmployeeTest
{
   public static void Main( string[] args )
   {
       Employee objEmployee1 = new Employee("Andrey", "Vasilyev", 5567);
       Employee objEmployee2 = new Employee();
       objEmployee2.FirstName = "Bill";
       objEmployee2.LastName = "Gates";
       objEmployee2.MonthlySalary = 987453;

       Console.WriteLine("The first employee is {0} {1}", objEmployee1.FirstName, objEmployee1.LastName);
       Console.WriteLine("{0} {1}'s yearly salary is {2:C}", objEmployee1.FirstName, objEmployee1.LastName, objEmployee1.MonthlySalary*12);
       
       Console.WriteLine("The second employee is {0} {1}", objEmployee2.FirstName, objEmployee2.LastName);
       Console.WriteLine("{0} {1}'s yearly salary is {2:C}", objEmployee2.FirstName, objEmployee2.LastName, objEmployee2.MonthlySalary*12);
       Console.WriteLine("");
       Console.WriteLine("Yearly salary raised on 10% is displayed below.");
      
       Console.WriteLine("{0} {1}'s salary is {2:C}", objEmployee1.FirstName, objEmployee1.LastName, 12 * objEmployee1.IncreaseSalary(10));
       Console.WriteLine("{0} {1}'s salary is {2:C}", objEmployee2.FirstName, objEmployee2.LastName, 12 * objEmployee2.IncreaseSalary(10));
   }
}
