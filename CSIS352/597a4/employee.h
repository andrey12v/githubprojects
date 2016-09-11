// Andrey Vasilyev
// CSIS 352
// employee.h
// 03/01/2009
// Assignment 4

#ifndef _EMPLOYEE_
#define _EMPLOYEE_
#include "person.h" //base class person to keep private person information 
#include <iostream>

//********Description of class Employee*****************
// The class Employee is inherited from class Person and 
// allows setting and getting Employee ID for each worker. 
// The class is also considered to be the base class for 
// Hourly, Salary Employee classes and is used as a data 
// type in class Employees.   
//*******************************************************

class Employee : public Person
{
   public:
      // default constructor
      //    preconditions - no validity checking is performed
      //       - emplouyee ID must be in range of 10000 to 99999 tha is 5 digits 
      //    postconditions
      //       - employee ID is set to zero by default
	  //         if no arguments are given, the date is set to the zero
      //    method input - employee ID
      //    method output - none
	  Employee();
	  
	  // parameter list constructor
      // constructor inherits parameters from the base class Person
	  //    preconditions - no validity checking is performed
	  //    - date must have valid format; month, days and year must be in the proper range	
	  //	- employee ID must be in the range  of 10000 to 99999 tha is 5 digits
	  //    postconditions
      //	- employee's name, birthday, social security number and ID number are 
	  //	  set to arguments
	  //    method input - name, date,social security number and employee ID
      //    method output - none
	  Employee(string inpName, Date& d, string inpSSN, int inpEmpID) : Person(inpName, d, inpSSN), employeeID(inpEmpID){} 

	  // virtual method:  displayPayroll - is an abstract method that is used by 
	  // inherted classes Hourly Employee and Salary employee to output 
	  // employees' personal information, their work hours, wage, salary and  
	  // gross pay
	  //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - none
	  virtual void displayPayroll(ostream&) const=0;
	  
	  //method: setEmployeeID sets employee's ID 
	  //   preconditions - no validity checking is performed
      //     - employee ID must be in the range of 10000 to 99999, 5 digits
	  //    postconditions
      //       - employee's ID attribute are set to the argument.
	  //    method input - employee ID
      //    method output - none
	  void setEmployeeID(int);
      
	  // method: getEmployeeID - returns employee's ID
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - employee ID
	  int getEmployeeID() const;
	  
	  // method: displayEmployee outputs employee's name, social security number, 
	  // birthday and age in lined columns to the file employees
	  //   preconditions - no validity checking is performed
      //	   - object of class ostream must be valid
	  //    postconditions - outputs employee's private information into the file employees
	  //    method input - none
      //    method output - employee's personal data: name, SSN, birthday, age
	  void displayEmployee(ostream& os);
   private:
      int employeeID; 
};
#endif
