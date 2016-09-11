// Andrey Vasilyev
// CSIS 352
// employee.cpp
// 03/14/2009
// Assignment 5

#include "person.h"  
#include "employee.h"
#include <iostream>
#include "date.h"
using namespace DateNameSpace;
using namespace std;

Employee::Employee()
{
	employeeID=0;
	SSN="";
	hireDate.now();	
	department=""; 
	supervisor="";
}

void Employee::setEmployeeID(int inpEmpID)
{
	employeeID=inpEmpID;
}

int Employee::getEmployeeID() const
{
	return employeeID;
}

void Employee::setSSN(string inpSSN)
{
	SSN=inpSSN;
}

string Employee::getSSN() const
{
	return SSN;
}

void Employee::setHireDate(Date& hireD)
{
	hireDate=hireD;
}

Date Employee::getHireDate() const
{
	return hireDate;
}
	
void Employee::setDepartment(string inpDep)
{
	department=inpDep;
}

string Employee::getDepartment() const
{
	return department;
}

void Employee::setSupervisor(string inpSup)
{
	supervisor=inpSup;
} 

string Employee::getSupervisor() const
{
	return supervisor;
}
