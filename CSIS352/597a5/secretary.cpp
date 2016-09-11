// Andrey Vasilyev
// CSIS 352
// secretary.cpp
// 03/14/2009
// Assignment 5

#include <string>
#include <list>
// the libarray <iterator> is used to declare the iterator that could
// go through the list of elements
// the list and iterator are used from STL
// Standard Template Library
#include <iterator>
#include <iostream>
// the header file secretary that is used as a base class 
#include "secretary.h"
#include "employee.h"

using namespace std;

// declaration of static data variable duties in the implementation file 
list<string> Secretary::duties;

// the method adds duties to the list from Standard Template Library
void Secretary::addDuty(const string& inpStr)
{
	//the standard method push_back is used to add new string in the list
	duties.push_back(inpStr); 
}

// the method prints basic secretary's duties
void Secretary::printDuties(ostream& os)
{
	// declaration of the iterator to go through the list
	list<string>::iterator iter;
	iter = duties.begin();
	// the standard methods begin() and end() from the list are used
	// to assign the first and the last elements of the list to the iterator 
	for(iter = duties.begin(); iter!=duties.end(); ++iter)
	{
		os<<"   "<<*iter<<endl;
	}
}
