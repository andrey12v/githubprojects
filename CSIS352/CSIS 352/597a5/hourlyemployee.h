// Andrey Vasilyev
// CSIS 352
// hourlyemployee.h
// 03/14/2009
// Assignment 5

#ifndef _HOURLYEMPLOYEE_
#define _HOURLYEMPLOYEE_
#include "employee.h"
#include <iostream>

// ************ The description of class Hourly Employee **************
// The class Hourly Employee is inherited from the class Person and Employee 
// The class Hourly Employee allows setting work hours, wage and getting hours, 
// wage, gross pay. The gross pay is calculated by multipling hours on wage for 
// Hourly Employee.   
//**********************************************************************

class HourlyEmployee : virtual public Employee 
{
   public:
      // default constructor
      //    preconditions - no validity checking is performed
      //	   - date must have valid format; month, days and year must be in the proper range
	  //       - employee ID must be in range of 10000 to 99999 that is 5 digits 
      //    postconditions
      //       - employee's wage and hours are set to zero by default
      //    method input - wage, hours 
      //    method output - none
	  HourlyEmployee();
	  
	  // parameter list constructor
      // constructor inherits parameters from the classes person and employee
	  //    preconditions - no validity checking is performed
	  //    - date must have valid format; month, days and year must be in the proper range	
	  //	- employee ID must be in the range  of 10000 to 99999 that is 5 digits
	  //    postconditions
      //	- employee's name, birthday, social security number, ID number, hire date, department, supervisor,
	  //	  work hours and wage are set to arguments
	  //    method input - name, birthday date, social security number, employee ID, hire date, department, supervisor,
	  //    work hours and wage
      //    method output - none
	  HourlyEmployee(string inpName, Date& d, string inpSSN, int inpEmpID, Date& empD, string inpDep, string inpSup, double inpWage, double inpHours)
		  : Employee(inpName, d, inpSSN, inpEmpID, empD, inpDep, inpSup), wage(inpWage), hours(inpHours){}

	  // method: setWage sets employee's wage 
	  // the method is used only for employees who are payed by hours
	  //   preconditions - none
	  //   postconditions - wage is set to argument
      //   method input - wage
      //   method output - none
	  void setWage(double inpWage);
      
	  // method: setHours sets employee's work hours 
	  // the method is used only for employees who are payed by hours
	  //   preconditions -  none
	  //   postconditions - work hours are set to argument
      //   method input - the number of hours
      //   method output - none
	  void setHours(double inpHours);
      
	  // method: getWage - returns employee's wage
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - wage
	  double getWage() const;
      
	  // method: getWage - returns employee's work hours
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the number of hours
	  double getHours() const;
	  
	  // method: getGrossPay - returns employee's gross pay
      //   the gross pay for hourly employee is calculated by
	  //   multiplying hours and wage
	  //   preconditions - none
      //   postconditions - hours and wage are multiplied and gross pay outputs 
      //   method input - none
      //   method output - gross pay
	  double getGrossPay() const;
	  
	private:
      double wage;
      double hours;
};
#endif
