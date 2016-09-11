// Andrey Vasilyev
// CSIS 352
// hourlyemployee.cpp
// 03/01/2009
// Assignment 4

#include "salaryemployee.h"
#include <iostream>
// the library is used to output data in fixed columns,
// by means of the function setw() 
#include <iomanip>
using namespace std;

SalaryEmployee::SalaryEmployee()
{
	salary=0.0;
}

void SalaryEmployee::setSalary(double inpSalary)
{
	salary=inpSalary;
}

double SalaryEmployee::getSalary() const
{
	return salary;
}

// implementation of the abstract virtual method of class Employee
// the method outputs Employee's payroll information to the file
void SalaryEmployee::displayPayroll(ostream& os) const
{
	os<<setfill(' ');
	os<<left<<setw(25)<<Person::getName()<<setw(8)<<Employee::getEmployeeID()
		<<setw(7)<<""<<setw(10)<<""<<setw(12)<<getSalary()<<endl;
}
