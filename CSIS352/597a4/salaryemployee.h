// Andrey Vasilyev
// CSIS 352
// salaryemployee.cpp
// 03/01/2009
// Assignment 4

#ifndef _SALARYEMPLOYEE_
#define _SALARYEMPLOYEE_
#include "employee.h"

// ************ The description of class Hourly Employee **************
// The class Salary Employee is inherited from the class Employee and allows 
// setting salary and getting salary, gross pay. The gross pay is based on a 
// salary of Salaried Employee. The class has method displayPayroll() that outputs 
// payroll data about employee in the separate file payroll.  
//**********************************************************************

class SalaryEmployee : public Employee
{
   public:
      // default constructor
      //    preconditions - no validity checking is performed
      //	   - date must have valid format; month, days and year must be in the proper range
      //       - employee ID must be in range of 10000 to 99999 tha is 5 digits 
      //    postconditions
      //       - employee's salary is set to zero by default
      //    method input - salary 
      //    method output - none
      SalaryEmployee();
      
      // parameter list constructor
      // constructor inherits parameters from the class person
	  //    preconditions - no validity checking is performed
	  //    - date must have valid format; month, days and year must be in the proper range	
	  //	- employee ID must be in the range  of 10000 to 99999 tha is 5 digits
	  //    postconditions
      //	- employee's name, birthday, social security number, ID number and
	  //	  salary are set to argument
	  //    method input - name, date, social security number, employee ID and salary
      //    method output - none
      SalaryEmployee(string inpName, Date & d, string inpSSN, int inpEmpID, double inpSalary) 
		  : Employee(inpName, d, inpSSN, inpEmpID), salary(inpSalary){}
      
      //method: setSalary sets employee's salary 
      //   preconditions - none 
      //   postconditions - salary is set to argument
      //   method input - salary
      //   method output - none
      void setSalary(double inpSalary);
      
	  // method: getSalary - returns employee's salary
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - salary
	  double getSalary() const;
	  	  
	  // method: displayPayroll() - outputs employee's payroll information: name,  
	  // employee ID, salary, gross pay to the file payroll
	  // the method is implemented from the abstract virtual method of the class Employee 
	  // the method can be used by classes Hourly Employee and Salary Employee 
	  // the method displayPayroll() demonstrates the principles of polymorphism 
	  //   preconditions - no validity checking is performed
	  //	 - the object of class ostream must be valid
	  //   postconditions - outputs employee's payroll information into the file payroll 
      //   method input - none
      //   method output - outputs to the file: name, employee ID, salary, gross pay
	  void displayPayroll(ostream& os) const;
   private:
      double salary;
};
#endif
