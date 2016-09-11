// Andrey Vasilyev
// CSIS 352
// hourlyemployee.h
// 03/14/2009
// Assignment 5

//************* The description of the class Part Time Employee ***************************
// The class Part Time Employee is inherited from the class Employee. The class allows 
// setting and getting the maximum work hours that is spent by part time employee. The class 
// Part Time Employee is used by secretary classes. 
//******************************************************************************************

#ifndef _PARTTIMEEMPLOYEE_
#define _PARTTIMEEMPLOYEE_
#include "employee.h"
#include <iostream>

class PartTimeEmployee : virtual public Employee 
{
   public:
      // default constructor
      //    preconditions - no validity checking is performed
      //		- the argument maximum hours must be double variable 
	  //          if the argument is not given, the maximum hours are set to zero		
	  //    postconditions
      //       - employee's maximum work hours are set to zero by default
      //    method input - none 
      //    method output - none
	  PartTimeEmployee();
	  
	  // parameter list constructor
      // constructor inherits parameters from the classes person and employee
	  //    preconditions - no validity checking is performed
	  //    - date must have valid format; month, days and year must be in the proper range	
	  //	- employee ID must be in the range  of 10000 to 99999 tha is 5 digits
	  //    postconditions
      //	- employee's name, birthday, social security number, ID number, department, 
	  //       supervisor, maximum work hours are set to arguments 
	  //    method input - name, birthday date, social security number, employee ID, 
	  //			department, supervisor, maximum work hours
      //    method output - none
      PartTimeEmployee(string inpName, Date& d, string inpSSN, int inpEmpID, Date& empD, string inpDep, string inpSup, double inpMaxHours)
		  : Employee(inpName, d, inpSSN, inpEmpID, empD, inpDep, inpSup), maxHours(inpMaxHours){}

	  // method: setWage sets employee's allowed maximum work hours 
	  // the method is used only for part time employees
	  //   preconditions - none
	  //   postconditions - maximum work hours are set to argument
      //   method input - maximum hours as a double data type
      //   method output - none
	  void setMaxHours(double inpMaxHours);

	  // method: getMaxHours - returns employee's maximum work hours
      //    preconditions - none
      //    postconditions - employee's maximum hours
      //    method input - none
      //    method output - maximum hours as a double data type
	  double getMaxHours() const;

	private:
      	double maxHours;
};
#endif
