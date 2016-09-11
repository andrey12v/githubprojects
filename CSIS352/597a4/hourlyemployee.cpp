// Andrey Vasilyev
// CSIS 352
// hourlyemployee.cpp
// 03/01/2009
// Assignment 4

#include "hourlyemployee.h"
#include <iostream>
// the library is used to output data in fixed columns,
// by means of the function setw() 
#include <iomanip>
using namespace std;

HourlyEmployee::HourlyEmployee()
{
	wage=0.0;
    hours=0.0;
}

void HourlyEmployee::setWage(double inpWage)
{
	wage=inpWage;
}

void HourlyEmployee::setHours(double inpHours)
{
	hours=inpHours;
}

double HourlyEmployee::getWage() const
{
	return wage;
}

double HourlyEmployee::getHours() const
{
	return hours;
}

double HourlyEmployee::getGrossPay() const
{
	return wage*hours;
}

// implementation of the abstract virtual method of class Employee
// the method outputs Employee's payroll information to the file
void HourlyEmployee::displayPayroll(ostream& os) const
{
	os<<setfill(' ');
	os<<left<<setw(25)<<Person::getName()<<setw(8)<<Employee::getEmployeeID()
		<<setw(7)<<getHours()<<setw(10)<<getWage()<<setw(12)<<getGrossPay()<<endl;
}
