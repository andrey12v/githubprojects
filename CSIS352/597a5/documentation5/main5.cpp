#include "SecretaryClass1.h"
#include "SecretaryClass2.h"
#include "SecretaryClass3.h"
#include <iostream>
#include <list>
#include <iterator>
using namespace std;

int main()
{
   Secretary::addDuty("answer phone");
   Secretary::addDuty("greet office visitors");
   SecretaryClass3::addDuty("typing");
   SecretaryClass3::addDuty("photocopying");
   SecretaryClass2::addDuty("hire student office help");
   SecretaryClass2::addDuty("supervise student help");
   SecretaryClass2::addDuty("submit student payroll");
   SecretaryClass1::addDuty("assist with department budget planning");
   SecretaryClass1::addDuty("assist with department scheduling");

   SecretaryClass1* c1 = new SecretaryClass1;
   SecretaryClass2* c2 = new SecretaryClass2;
   SecretaryClass3* c3 = new SecretaryClass3;

   c3->setName("Student Secretary");
   c3->setSSN("777-77-7777");
   c3->setDepartment("CSIS");
   c3->setHireDate(Date(1,9,2007));
   c3->setHours(15);
   c3->setWage(6.50);
   c3->setMaxHours(20);
   c3->addSpecificDuty("make signage for department");
   c3->setSupervisor("Super Secretary");

   c2->setName("Good Secretary");
   c2->setSSN("888-88-8888");
   c2->setDepartment("Chemistry");
   c2->setHireDate(Date(8,25,1999));
   c2->setHours(40);
   c2->setWage(12);
   c2->setBenefits(Benefits(50,20,0));
   c2->addSpecificDuty("liason with Dean's office");
   c2->setSupervisor("Good Boss");

   c1->setName("Super Secretary");
   c1->setSSN("999-99-9999");
   c1->setDepartment("CSIS");
   c1->setHireDate(Date(8,28,1990));
   c1->setSalary(700);
   c1->setBenefits(Benefits(50,20,8));
   c1->addSpecificDuty("monitor lab and contact IT with problems");
   c1->addSpecificDuty("assist department LAN administrator");
   c1->setSupervisor("Super Boss");

   list<Employee*> emplist;
   emplist.insert(emplist.end(),c3);
   emplist.insert(emplist.end(),c2);
   emplist.insert(emplist.end(),c1);

   for (list<Employee*>::iterator i=emplist.begin(); i!=emplist.end(); i++)
   {
      (*i)->Report(cout);
      cout << "-----------------------------------------------\n";
   }

   return 0;
}

