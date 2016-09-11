// Andrey Vasilyev
// CSIS 352
// salaryemployee.cpp
// 03/14/2009
// Assignment 5

#ifndef _SALARYEMPLOYEE_
#define _SALARYEMPLOYEE_
#include "employee.h"

// ************ The description of class Hourly Employee **************
// The class Salary Employee is inherited from the class Employee and allows 
// setting and getting employee's salary.  
//**********************************************************************

class SalaryEmployee : virtual public Employee
{
   public:
      // default constructor
      //    preconditions - no validity checking is performed
      //	   - date must have valid format; month, days and year must be in the proper range
      //       - employee ID must be in range of 10000 to 99999 tha is 5 digits 
      //    postconditions
      //       - employee's salary is set to zero by default
      //    method input - none 
      //    method output - none
      SalaryEmployee();
      
      // parameter list constructor
      // constructor inherits parameters from the classes employee and person
	  //    preconditions - no validity checking is performed
	  //    - date must have valid format; month, days and year must be in the proper range	
	  //	- employee ID must be in the range  of 10000 to 99999 tha is 5 digits
	  //    postconditions
      //	- employee's name, birthday, social security number, ID number, hire date, department, 
	  //		supervisor, salary are set toarguments
	  //    method input - name, birthday date, social security number, employee ID, department,  
	  //		supervisor, salary
	  //    method output - none
      SalaryEmployee(string inpName, Date& d, string inpSSN, int inpEmpID, Date& empD, string inpDep, string inpSup, double inpSalary)
		  : Employee(inpName, d, inpSSN, inpEmpID, empD, inpDep, inpSup), salary(inpSalary){}

      //method: setSalary sets employee's salary 
      //   preconditions - none 
      //   postconditions - salary is set to arguments
      //   method input - salary
      //   method output - none
      void setSalary(double inpSalary);
      
	  // method: getSalary - returns employee's salary
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - salary as a double data type
	  double getSalary() const;
	  	  
   private:
      double salary;
};
#endif
