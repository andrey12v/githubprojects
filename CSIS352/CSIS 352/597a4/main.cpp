// Andrey Vasilyev
// CSIS 352
// maim.cpp
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

//****************The description of the main.cpp file****************
// The file main.cpp contains the function main that read employees� 
// information from the file people, and stores all the information in 
// the pointers of classes Hourly Employee and Salary Employee. Then 
// employees� private information outputs to the file employees and 
// employees� payroll data is saved in the file payroll. 
// The file main.cpp also contains the declaration of the functions 
// getEmployeesFromFile() and writeEmployeesToFile that are used to read and 
// write employees� data. The executable file prog4 and input file people 
// must be typed from the keyboard
//**********************************************************************

// function: getEmployeesFromFile � is implemented in the separate 
// file �getemployees.cpp�. The function is used to read employees from 
// the file people and save them in the array as pointers of classes 
// Hourly Employee and Salary Employee
//   preconditions - no validity checking is performed
//     - object of class ifstream must be valid
//	   - object of class Employees must be valid, 
//		 the size of the array must be less or equal to 100 elements
//    postconditions
//		- get employees� information from the file employees
//		- save employees� information as a pointers of classes 
//		  Hourly Employee and Salary Employee
//		- add pointers Hourly Employee and Salary Employee to 
//		  the array of type Employee
//    method input - employees' data
//    method output - none
void getEmployeesFromFile(ifstream& inputFile, int& count, Employees& emps);

// function: writeEmployeesToFile() � is implemented in the separate 
// file �writeemployees.cpp�. The function is used to save employees� 
// private information in the file employees and employees� payroll data 
// in the file payroll. When the function writeEmployeesToFile() calls 
// the function displayPayroll() it output appropriate data about Hourly or 
// Salary Employees to the file payroll according the main principles of 
// polymorphism
//  preconditions - no validity checking is performed
//	   - object of class Employees must be valid, 
//		 the size of the array must be less or equal to 100 elements
//    postconditions 
//     � employee�s private information: name, social security number, birthday, age outputs to the file employees 
//     - employee�s payroll information: name, employee ID, hours, wage, gross pay outputs to the file payroll
//    method input - employees' data
//    method output 
//   	� employees� private information is saved in the file employees
//  	- employees� payroll information is stored in the file payroll
void writeEmployeesToFiles(int& count, Employees& emps);

// parameters argc is used to count the number of parametr typed from the keyboard
// parametr argv[] ius used to get the name of typed parametrs
int main(int argc, char *argv[])
{
   
   try{
   	if (argc != 2)
   	{
      		cout << "usage: " << argv[0] << " <inputfile>\n";
      	return 0;
   	}

    	int count=0; //variable to count the number of elements in the array
    	Employees emps;

	ifstream ifs;
	ifs.open (argv[1]);
	//the function to read employees' data from the file
	getEmployeesFromFile(ifs, count, emps);
	//the function to write employee's data to the files 
	writeEmployeesToFiles(count, emps);
    }
    catch(DateException e)
    {
	cout<<e.what()<<endl;
    }
    catch(ArrayException ar)
    {
    	cout<<ar.what()<<endl;
    }
    catch(...)
    {
		cout<<"Attention! The program got the error."<<endl;
    }


	return 0;
}
