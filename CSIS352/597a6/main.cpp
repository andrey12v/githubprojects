// Andrey Vasilyev
// CSIS 352
// main.cpp
// 04/19/2009
// Assignment 6

#include <iostream>
#include "dynamichashtable.h"
#include "employee.h"
using namespace std;

//****************** Description of the function Main() *************************
// The file main.cpp contains implementation of the function main(). The 
// function includes declarations of the objects of class Employee. Appropriate 
// values are assigned to the employee objects and the objects inserted in the 
// hash table. The function main demonstrates efficiency to use hash table how to 
// insert and retrieve entries in the table.  
//********************************************************************************

int main()
{
  cout<<"TEST OF THE DYNAMIC HASH TABLE and CLASS EMPLOYEE"<<endl;
  DynamicHashTable<Employee> dhashtable(TABLE_SIZE_EMPLOYEE);
  Employee e1;
  e1.setSSN("403-23-1234");
  e1.setName("Jody Anderson");
  
  cout<<"TEST OF THE METHOD addEntry() IN THE HASH TABLE"<<endl;
  cout<<"The following elements are added in the hash table:"<<endl;
  
  if (dhashtable.addEntry(e1)==true)
  {
  	cout<<"The SSN \""<<e1.getSSN()<<"\", the hash value = \""<<e1.hash()<<"\", name "
		<<e1.getName()<<endl;
  }

  Employee e2;
  e2.setSSN("333-33-3333");
  e2.setName("John Medison");

  if(dhashtable.addEntry(e2)==true)
  {
	  cout<<"The SSN \""<<e2.getSSN()<<"\", the hash value = \""<<e2.hash()<<"\", name "
		  <<e2.getName()<<endl;
  }

  Employee e3;
  e3.setSSN("123-33-9213");
  e3.setName("Andrey Vasilyev");
  if(dhashtable.addEntry(e3)==true)
  {
	cout<<"The SSN \""<<e3.getSSN()<<"\", the hash value = \""<<e3.hash()<<"\", name "
		  <<e3.getName()<<endl;
  }

  Employee e4;
  e4.setSSN("403-23-1234");
  e4.setName("Jody Anderson");

  if(dhashtable.addEntry(e4)==false)
  {
	cout<<"The employee \""<<e4.getName()<<"\" with SSN \""<<e4.getSSN()<<"\" cannot be"<<endl;
	cout<<"inserted in the hash table"<<endl;
	cout<<"The employee is already in the table"<<endl;	
  }
  cout<<endl;
  cout<<"TEST OF THE METHOD retrieveEntry() IN THE HASH TABLE."<<endl;
  cout<<"The employees saved in the hash table are the following:"<<endl;
  cout<<"Name "<<dhashtable.retrieveEntry(e1).getName()<<", SSN "<<
	  dhashtable.retrieveEntry(e1).getSSN()<<";"<<endl;
  cout<<"Name "<<dhashtable.retrieveEntry(e2).getName()<<", SSN "<<
	  dhashtable.retrieveEntry(e2).getSSN()<<";"<<endl;
  cout<<"Name "<<dhashtable.retrieveEntry(e3).getName()<<", SSN "<<
	  dhashtable.retrieveEntry(e3).getSSN()<<";"<<endl;
  cout<<endl;
  cout<<"TEST OF THE METHOD inTable() IN THE HASH TABLE"<<endl;
  cout<<"The employee "<<e1.getName();
  if (dhashtable.inTable(e1))
  {
	cout<<" is in the hash table"<<endl;
  }
  else
  {
  	cout<<" is not in the hash table"<<endl;
  }
  
  cout<<endl;
  cout<<"The number of collisions "<<dhashtable.getCollisions()<<endl;
  
  return 0;
}

