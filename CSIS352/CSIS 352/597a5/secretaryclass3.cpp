// Andrey Vasilyev
// CSIS 352
// secretaryclass3.cpp
// 03/14/2009
// Assignment 5

#include <string>
#include <list>
#include <iomanip>
#include <iterator>
#include <iostream>
#include "person.h"
#include "secretary.h"
#include "fulltimeemployee.h"
#include "salaryemployee.h"
#include "secretaryclass3.h"
using namespace std;

// declaration of static list of basic duties in implementation file
list<string> SecretaryClass3::duties;

// declaration and initialization of static variable in implementation file
string SecretaryClass3::classification="Secretary Class 3";

void SecretaryClass3::addDuty(const string& inpStr)
{
	duties.push_back(inpStr);
}

void SecretaryClass3::printDuties(ostream& os)
{
	list<string>::iterator iter;
	iter = duties.begin();
	for(iter = duties.begin(); iter!=duties.end(); ++iter)
	{
		os<<"   "<<*iter<<endl;
	}
}

void SecretaryClass3::addSpecificDuty(const string& inpStr)
{
	specificduties.push_back(inpStr);
}

void SecretaryClass3::printSpecificDuties(ostream& os) const
{
	list<string>::const_iterator p = specificduties.begin();
	for(p = specificduties.begin(); p!=specificduties.end(); ++p)
	{
		os<<"   "<<*p<<endl;
	}
}

// the method Report prints secretary's basic and specific duties
// the Report uses the method of the secretary classes from which it was inherited 
void SecretaryClass3::Report(ostream& os) const
{
	os<<"Name: "<<getName()<<endl;
	os<<"SSN: "<<getSSN()<<endl;
	os<<"Classification: "<<SecretaryClass3::classification<<endl;
	os<<"Department: "<<getDepartment()<<endl;
	os<<"Hire Date: "<<getHireDate()<<endl;
	os<<"Max Hours: "<<getMaxHours()<<endl;
	os<<"Hours: "<<getHours()<<"  "<<getWage()<<"  "<<getGrossPay()<<endl;
	os<<"Assigned Duties"<<endl;
	Secretary::printDuties(os);
	printDuties(os);
	printSpecificDuties(os);
	os<<"Supervisor: "<<getSupervisor()<<endl;	
}
