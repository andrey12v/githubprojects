// Andrey Vasilyev
// CSIS 352
// parttimeemployee.h
// 03/14/2009
// Assignment 5

#include "parttimeemployee.h"
#include "benefits.h"
#include <iostream>
using namespace std;

PartTimeEmployee::PartTimeEmployee()
{
	maxHours=0.0;
}

void PartTimeEmployee::setMaxHours(double inpMaxHours)
{
	maxHours=inpMaxHours;
}

double PartTimeEmployee::getMaxHours() const
{
	return maxHours;
}
