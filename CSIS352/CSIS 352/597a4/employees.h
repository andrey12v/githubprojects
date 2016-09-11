// Andrey Vasilyev
// CSIS 352
// employees.h
// 03/01/2009
// Assignment 4

#ifndef _EMPLOYEES_
#define _EMPLOYEES_
#include "employee.h"
#include "array.h"
#include "date.h"
#include <iostream>
using namespace std;
using namespace ArrayNameSpace;

//************ The description of the class Employees*************************
// The class Employees is used to allocate array of type Employee and 
// keep array of pointers to Hourly and Salary employee objects. The 
// class has the main methods to add new Hourly or Salary employees in 
// the array and get required employee by number.  The method allows checking 
// polymorphism on the example of the method displayPayroll()
//**************************************************************************** 

class Employees
{
   public:
     
	 // method: addEmployee adds Hourly and Salary employee pointers to the array
	 // the array is allocated as a dynamic array of pointers of type Employee 
	 //   preconditions - no validity checking is performed
    	 //	   - must be valid Hourly or Salary employee pointers
	 //    - index must be integer number from 0 to 100
	 //    postconditions - adds Hourly or Salary employee pointers to the array
	 //    method input - none
     	 //    method output - adds hourly and salary employee pointers to the array of Employee
	 void addEmployee(Employee*, int index);
     
     // method: getEmployee returns Hourly and Salary employee pointers from the array of type Employee
	 //   preconditions - no validity checking is performed
 	 //    - index must be integer number from 0 to 100
	 //    postconditions - returns Hourly and Salary employee pointers from the array of type Employee
	 //    method input - none
     //    method output - returns hourly and salary employee pointers from the array of Employee
	 Employee* getEmployee(int index);    
  private:
     	//declaration of a dynamic array as an array of Employee pointers 
	Array<Employee*> emps;
};
#endif
