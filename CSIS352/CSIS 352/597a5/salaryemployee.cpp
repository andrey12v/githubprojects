// Andrey Vasilyev
// CSIS 352
// salaryemployee.cpp
// 03/14/2009
// Assignment 5

#include "salaryemployee.h"
#include <iostream>
using namespace std;

// default constructor
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
