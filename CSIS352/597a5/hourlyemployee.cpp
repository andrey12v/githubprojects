// Andrey Vasilyev
// CSIS 352
// hourlyemployee.cpp
// 03/14/2009
// Assignment 5

#include "hourlyemployee.h"
#include <iostream>
// the library is used to output data in fixed columns,
// by means of the function setw() 
#include <iomanip>
using namespace std;

// default constructor
HourlyEmployee::HourlyEmployee()
{
	wage=0.0;
    hours=0.0;
}

// parametr list constructor
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
