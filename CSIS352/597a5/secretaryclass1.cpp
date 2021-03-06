// Andrey Vasilyev
// CSIS 352
// secretaryclass1.cpp
// 03/14/2009
// Assignment 5

#include <string>
#include <list>
#include <iterator>
#include <iostream>
#include "person.h"
#include "secretary.h"
#include "benefits.h"
#include "fulltimeemployee.h"
#include "salaryemployee.h"
#include "secretaryclass1.h"
#include "secretaryclass2.h"
#include "secretaryclass3.h"
using namespace std;

// declaration of static list of basic duties in implementation file
list<string> SecretaryClass1::duties;

// declaration and initialization of static variable in implementation file
string SecretaryClass1::classification="Secretary Class 1";


void SecretaryClass1::addDuty(const string& inpStr)
{
	duties.push_back(inpStr);
}

void SecretaryClass1::printDuties(ostream& os)
{
	/*ostream_iterator<string> screen(cout, " ");
	copy(duties.begin(), duties.end(), screen);
	cout<<endl;*/
	list<string>::iterator iter;
	iter = duties.begin();
	for(iter = duties.begin(); iter!=duties.end(); ++iter)
	{
		os<<"   "<<*iter<<endl;
	}
}

void SecretaryClass1::addSpecificDuty(const string& inpStr)
{
	specificduties.push_back(inpStr);
}

void SecretaryClass1::printSpecificDuties(ostream& os) const
{
	list<string>::const_iterator p = specificduties.begin();
	for(p = specificduties.begin(); p!=specificduties.end(); ++p)
	{
		os<<"   "<<*p<<endl;
	}
}

// the method Report prints secretary's basic and specific duties
// the Report uses the method of the secretary classes from which it was inherited 
void SecretaryClass1::Report(ostream& os) const
{
	os<<"Name: "<<getName()<<endl; 
	os<<"SSN: "<<getSSN()<<endl;
	os<<"Classification: "<<SecretaryClass2::classification<<endl;
	os<<"Department: "<<getDepartment()<<endl;
	os<<"Hire Date: "<<getHireDate()<<endl;
	os<<"Salary: "<<getSalary()<<endl;
	os<<"Benefits: "<<endl;
	os<<"  Health: "<<getBenefits().getHealth()<<" Dental: "<<getBenefits().getDental()<<" Life: "<<getBenefits().getLife()<<endl;
	os<<"Assigned Duties"<<endl;
	Secretary::printDuties(os);
	SecretaryClass3::printDuties(os);
	SecretaryClass2::printDuties(os);
	SecretaryClass1::printDuties(os);
	printDuties(os);
	printSpecificDuties(os);
	os<<"Supervisor: "<<getSupervisor()<<endl;	
}
