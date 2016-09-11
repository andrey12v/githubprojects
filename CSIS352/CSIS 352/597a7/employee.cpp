// Andrey Vasilyev
// CSIS 352
// employee.cpp
// 04/19/2009
// Assignment 6

#include <string>
#include <iostream>
#include "employee.h"
using namespace std;

string Employee::getSSN() const
{
	return ssn;
}

void Employee::setSSN(const string& inpSSN)
{
	ssn=inpSSN;
}

string Employee::getName() const
{
	return name;
}

void Employee::setName(const string& inpName)
{
	name=inpName;
}

bool Employee::operator==(const Employee& inpEmployee) const
{
	return (ssn==inpEmployee.getSSN());
}

// method to output employee's object in set format
ostream& operator<<(ostream& ofs,const Employee& eObj)
{
	ofs<<"Name: "<<eObj.getName();
	return ofs;
}
