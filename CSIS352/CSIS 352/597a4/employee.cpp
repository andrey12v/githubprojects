// Andrey Vasilyev
// CSIS 352
// employee.cpp
// 03/14/2009
// Assignment 5

// the base class person to keep person's name, birthday, SSN
#include "person.h"  
#include "employee.h"
#include <iostream>
// the library is used to output data in fixed columns,
// by means of the function setw()
#include <iomanip> 
#include "date.h"
using namespace DateNameSpace;
using namespace std;

Employee::Employee()
{
	employeeID=0;
}

void Employee::setEmployeeID(int inpEmpID)
{
	employeeID=inpEmpID;
}

int Employee::getEmployeeID() const
{
	return employeeID;
}

// the method outputs employee's personal information to the file employees
void Employee::displayEmployee(ostream& os)
{
	os<<setfill(' ');
	os<<left<<setw(25)<<Person::getName()<<left<<setw(13)<<Person::getSSN()
		<<left<<setw(12)<<Person::getBirthday().dateString()<<setw(4)<<Person::getAge()<<endl;
}
