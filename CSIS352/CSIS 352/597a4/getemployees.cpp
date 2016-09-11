// Andrey Vasilyev
// CSIS 352
// getemployees.cpp
// 03/01/2009
// Assignment 4

#include <iostream>
#include <iomanip>
#include <fstream> 
#include <string>
#include "date.h"
#include "array.h"
#include "employees.h"
#include "hourlyemployee.h"
#include "salaryemployee.h"
using namespace std;  
using namespace ArrayNameSpace;

// The file getemployees.cpp contains the implementation of the 
// function getEmployeesFromFile(). The function is used to read employees from 
// the file people and save them in the array as pointers of classes 
// Hourly Employee and Salary Employee

void getEmployeesFromFile(ifstream& inputFile, int& count, Employees& emps)
{
    int month;
	int day;
	int year;
	string name;
	string ssn;
	int empID;
	char type; //variable to choose the type of employee: salary of hourly 
	Date d1;
	double wage;
	double hours;
	double salary;
	//declaration of pointers 
	HourlyEmployee* HEmp;
	SalaryEmployee* SEmp;
	
	// the cycle reads from the file until it reaches the end of the file or 
	// the size of the becomes equal to 99 elements 
	while(!inputFile.eof() && count<100)
	{
		getline(inputFile, name);
		inputFile >> month;
		inputFile.ignore(1,'/');
		inputFile >> day;
		inputFile.ignore(1,'/');
		inputFile >> year;
		inputFile.ignore(100,'\n');
		d1.setDate(month,day,year);
		getline(inputFile, ssn);
		inputFile >> empID;
		inputFile >> type;
		inputFile.ignore(100,'\n');
		
		if(type == 'H')
		{
			inputFile >> hours;
			inputFile.ignore(100,'\n');
			inputFile >> wage;
			inputFile.ignore(100,'\n');
			HEmp = new HourlyEmployee(name, d1, ssn, empID, wage, hours);
			emps.addEmployee(HEmp, count);
			count++;
		}
		else if(type == 'S')
		{
			inputFile >> salary;
			inputFile.ignore(100,'\n');
			SEmp = new SalaryEmployee(name, d1, ssn, empID, salary);
			emps.addEmployee(SEmp, count);
			count++;
		}
		else{
			cout << "Invalid data in the input file" << endl;
		} 
	}
	inputFile.close();
	//this is the small test of the methods from the classes
	HEmp = new HourlyEmployee();
	HEmp->setName("Andrey Vasilyev");
	d1.setDate(9, 10, 1982);
	HEmp->setBirthday(d1);
	HEmp->setSSN("555-55-5555");
	HEmp->setEmployeeID(55555);
	HEmp->setWage(12.0);
	HEmp->setHours(20.0);
	emps.addEmployee(HEmp, count);
	count++;
}
