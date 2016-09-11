// Andrey Vasilyev
// CSIS 352
// fulltimeemployee.h
// 03/14/2009
// Assignment 5

#include "fulltimeemployee.h"
#include "benefits.h"
#include <iostream>
using namespace std;

// default constructor
FullTimeEmployee::FullTimeEmployee()
{
	empBenefits.setBenefits(0, 0, 0);
}

// the methpod to set employee's benefits
void FullTimeEmployee::setBenefits(Benefits& b)
{
	empBenefits=b;
}

// the method to return employee benefits 
Benefits FullTimeEmployee::getBenefits() const
{
	return empBenefits;
}
