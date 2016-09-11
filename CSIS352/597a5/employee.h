// Andrey Vasilyev
// CSIS 352
// employee.h
// 03/14/2009
// Assignment 5

#ifndef _EMPLOYEE_
#define _EMPLOYEE_
#include "person.h" //base class person to keep private person information 
#include "date.h"
#include <iostream>
using namespace DateNameSpace;

//********The description of the class Employee*****************
// The class Employee is inherited from class Person and 
// allows setting and getting Employee ID for each worker. 
// The class is also considered to be the base class for 
// employee and secretary classes.
//*******************************************************

class Employee : virtual public Person
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
	  Employee(string inpName, Date& d, string inpSSN, int inpEmpID, Date& hireD, string inpDep, string inpSup) 
		  : Person(inpName, d), SSN(inpSSN), employeeID(inpEmpID), hireDate(hireD), department(inpDep), supervisor(inpSup){} 

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
 
 	//method: setSSN - sets peorson's social security number 
    //    preconditions - none
    //    postconditions - sets SSN to argument
    //    method input - string variable 
    //    method output - none
	void setSSN(string inpSSN);

	// method: getSSN - returns peorson's social security number 
	// preconditions - none
    // postconditions - returns person's SSN
    // method input - none
    // method output - the attribute SSN
	string getSSN() const;


	//method: setHireDate - sets the date when an employee was hired
	// the object of class Date is passed as a parametr 	
	// the object of class Date has attributes month, day and year
      	//    preconditions - the date in the format mm/dd/yyyy
      	//    postconditions - sets Date of employemnt to the argument
	  	//    method input - the object of the class Date
      	//    method output - none
	void setHireDate(Date &hireD);

	// method: getHireDate - returns the object of class Date, when an employee was hired 
      	// preconditions - none
      	// postconditions - none
      	// method input - none
      	// method output - the attribute hire date
	Date getHireDate() const;
	
	//method: setDepartment - sets the name of the department where the person is employed 
	   	//    preconditions - the input parameter must be string
      	//    postconditions - sets the name of the department to the argument
      	//    method input - the string variable
      	//    method output - none
	void setDepartment(string inpDep);

	//method: getDepartment - gets the name of the department where the person is employed 
	   	//    preconditions - none
      	//    postconditions - gets employee's school department
      	//    method input - none
      	//    method output - string
	string getDepartment() const;

	//method: setSupervisor - sets the supervisor's name
	   	//    preconditions - the input parameter must be string
      	//    postconditions - sets the supervisor's name to the argument
      	//    method input - the string variable
      	//    method output - none
	void setSupervisor(string inpSup); 
	
	//method: getSupervisor - gets the supervisor's name as a string value
	   	//    preconditions - none
      	//    postconditions - gets the supervisor's name as a string value
      	//    method input - none
      	//    method output - string
	string getSupervisor() const;

	// virtual method:  Report - is an abstract method that is used by 
	// inherted employee and secretary classes to output employees' information. 
	// Each inherited secretary class has personal implementation of the method Report  
	// according to type of employee like full time, part time, slaried or hourly and the 
	// different information outputs
	//    preconditions - none
    //    postconditions - none
    //    method input - none
    //    method output - none
	virtual void Report(ostream&) const=0;
private:
      int employeeID; 
      string SSN;
      Date hireDate;	
      string department; 
      string supervisor;
};
#endif
