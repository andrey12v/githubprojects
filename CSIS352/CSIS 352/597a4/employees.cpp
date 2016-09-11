// Andrey Vasilyev
// CSIS 352
// employees.cpp
// 03/01/2009
// Assignment 4

#include "employees.h"
#include <iostream>
using namespace std;

// method to add Employee pointers in the array
void Employees::addEmployee(Employee* e, int index)
{
	emps[index]=e;
}

// method to get Employee pointers from the array
Employee* Employees::getEmployee(int index)
{
	return emps[index];
}
