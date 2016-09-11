// Andrey Vasilyev
// CSIS 352
// maim.cpp
// 03/01/2009
// Assignment 5

#include <list>
#include <iomanip>
#include <iostream>
#include <string>
#include "date.h"
#include "employee.h"
#include "secretary.h"
#include "fulltimeemployee.h"
#include "salaryemployee.h"
#include "secretaryclass3.h"
#include "secretaryclass2.h"
#include "secretaryclass1.h"

using namespace DateNameSpace;
using namespace std;  

// ****************** The description of the class Secretary *********************
// The file main.cpp contains the implementation of the function main that tests 
// secretary and employee classes. The pointers of type secretary class are declared in 
// the main function and their methods are used to add basic and specific duties
// Then secretary pointers are added to the list of type Employee in order to the method 
// Report and output appropriate information about each secretary.  
// The method Report outputs information based on the principles of polimorphism
// ************************************************************************************

int main()
{
	try
	{
   		// add basic duties in static lists of secretary classes 
		Secretary::addDuty("answer phone");
   		Secretary::addDuty("greet office visitors");
   		SecretaryClass3::addDuty("typing");
   		SecretaryClass3::addDuty("photocopying");
		SecretaryClass2::addDuty("hire student office help");
		SecretaryClass2::addDuty("supervise student help");
		SecretaryClass1::addDuty("assist with department budget planning");
		SecretaryClass1::addDuty("assist with department scheduling");

		// pointers of secretary classes are allocated
		SecretaryClass3* c3 = new SecretaryClass3;
		SecretaryClass2* c2 = new SecretaryClass2;
		SecretaryClass1* c1 = new SecretaryClass1;

		// set the arguments of secretary pointers
   		c3->setName("Student Secretary");
   		c3->setSSN("777-77-7777");
   		c3->setDepartment("CSIS");
   		Date d;
		d.setDate(1,9,2007);
		c3->setHireDate(d);
   		c3->setHours(15);
   		c3->setWage(6.50);
   		c3->setMaxHours(20);
   		c3->addSpecificDuty("make signage for department");
   		c3->setSupervisor("Super Secretary");

		c2->setName("Good Secretary");
		c2->setSSN("888-88-8888");
		c2->setDepartment("Chemistry");
		d.setDate(8,25,1999);
		c2->setHireDate(d);
		c2->setHours(40);
		c2->setWage(12);
		Benefits b;
		b.setBenefits(50, 20, 0);
		c2->setBenefits(b);
		c2->addSpecificDuty("liason with Dean's office");
		c2->setSupervisor("Good Boss");

		c1->setName("Super Secretary");
		c1->setSSN("999-99-9999");
		c1->setDepartment("CSIS");
		d.setDate(8,28,1990);
		c1->setHireDate(d);
		c1->setSalary(700);
		b.setBenefits(50,20,8);
		c1->setBenefits(b);
		c1->addSpecificDuty("monitor lab and contact IT with problems");
		c1->addSpecificDuty("assist department LAN administrator");
		c1->setSupervisor("Super Boss");

		// the list of employee pointers is allocated
		// the list is used from STL
		list<Employee*> emplist;
   		// secretary pointers are added to the list
		// standard methods of list are used to add pointers 
		emplist.insert(emplist.end(),c3);
   		emplist.insert(emplist.end(),c2);
		emplist.insert(emplist.end(),c1);

   		for (list<Employee*>::iterator i=emplist.begin(); i!=emplist.end(); i++)
   		{
      		(*i)->Report(cout);
      		cout << "-----------------------------------------------\n";
   		}
	}
	catch(DateException de)
	{
			cout<<de.what()<<endl;
	}
	catch(...)
	{	
			cout<<"Attention! The program got the error."<<endl;
	}

	return 0;
}
