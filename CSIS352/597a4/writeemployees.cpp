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

// The file writeemployees.cpp contains the implementation of the 
// function writeEmployeesToFile(). The function is used to read employees from 
// the file people and save them in the array as pointers of classes 
// Hourly Employee and Salary Employee. The function is used to save employees’ 
// private information in the file employees and employees’ payroll data 
// in the file payroll. When the function writeEmployeesToFile() calls 
// the function displayPayroll() it output appropriate data about Hourly or 
// Salary Employees to the file payroll according the main principles of 
// polymorphism

void writeEmployeesToFiles(int& count, Employees& emps)
{
	ofstream ofs;
	ofs.open("payroll");
	if (ofs.is_open())
	{	
		ofs<<setfill(' ');
		ofs<<left<<setw(25)<<"Name"<<setw(8)<<"Emp ID"<<setw(7)<<"Hours"
		<<setw(10)<<"Wage"<<setw(12)<<"Gross Pay"<<endl;
		
		for(int i=0; i<count; i++)
		{
			emps.getEmployee(i)->displayPayroll(ofs);
		}
		ofs.close();
	}
	else cout << "Unable to open file \"payroll\"";

	ofs.open("employees");
	if (ofs.is_open())
	{	
		ofs<<setfill(' ');
		ofs<<left<<setw(25)<<"Name"<<setw(13)<<"SSN"
		<<setw(12)<<"Birthday"<<setw(4)<<"Age"<<endl;
		
		for(int i=0; i<count; i++)
		{
			emps.getEmployee(i)->displayEmployee(ofs);
		}
		ofs.close();
	}
	else cout << "Unable to open file";
}
