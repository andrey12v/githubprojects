// Andrey Vasilyev
// CSIS 352
// fulltimeemployee.h
// 03/14/2009
// Assignment 5

#ifndef _FULLTIMEEMPLOYEE_
#define _FULLTIMEEMPLOYEE_
#include "employee.h" //base class employee
#include "benefits.h" //class that declares full time employee's benefits 
#include <iostream>

//************** The description of the class Full Time Employee ****************
// The class Full Time Employee is inherited from the classes Person and Employee. 
// The class allows keeping and getting the information about employee’s benefits. 
// The secretary classes use the class full time employee in the program 
// to set the type of employee
//*******************************************************************************

class FullTimeEmployee : virtual public Employee 
{
   public:
      // default constructor
      //    preconditions - no validity checking is performed
      //	    - object of the class Benefits must be valid
	  //    	- arguments of the object of the class benefits must be valid, 
	  //			must have double data type  
	  //    postconditions
      //       - employee's health, dental, life expenses are set to zero by default
      //    method input - none 
      //    method output - none
	  FullTimeEmployee();
	  
	  // parameter list constructor
      // constructor inherits parameters from the class employee
	  //    preconditions - no validity checking is performed
	  //    	- arguments of the object of the class benefits must be valid, 
	  //			must have double data type
	  //    postconditions
	  //	- employee's name, birthday, social security number, ID number,
	  //		hire date, school department, supervisor, benefits are set to arguments
	  //    method input - name, birthday date, social security number, employee ID, hire date,
	  //		school department, supervisor, benefits 
      //    method output - none
	  FullTimeEmployee(string inpName, Date& d, string inpSSN, int inpEmpID, Date& empD, string inpDep, string inpSup, Benefits& b)
		  : Employee(inpName, d, inpSSN, inpEmpID, empD, inpDep, inpSup), empBenefits(b){}
	  
	  //method: setBenefits sets employee's full time employee's benefits 
	  //   preconditions - no validity checking is performed
      //     - object of class Benefits must be valid
	  //	 - arguments of class Benefits must have double data type
	  //    postconditions
      //     - object of class Benefits is set to argument
	  //    method input - object of class Benefits
	  //    method output - none
	  void setBenefits(Benefits& b);

	  // method: getBenefits - returns the object of class Benefits 
	  	// preconditions - none
      	// postconditions - employee's benefits are returned as an object
      	// method input - none
      	// method output - the object of the class Benefits
	  Benefits getBenefits() const;

	private:
      Benefits empBenefits; //the object of the class Benefits is declared  
};
#endif
