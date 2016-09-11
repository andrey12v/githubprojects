// Andrey Vasilyev
// CSIS 352
// secretaryclass1.cpp
// 03/14/2009
// Assignment 5

#ifndef _SECRETARYCLASS1_
#define _SECRETARYCLASS1_
#include <string>
#include <list>
// the libarary is used to declare the iterator for the list
#include <iterator>
#include <iostream>
#include "secretary.h"
#include "salaryemployee.h"
#include "fulltimeemployee.h"
using namespace std;

// ************** The description of the class Secretary 1 *****************
// The class Secretary 1 is inherited from the classes Secretary, Full 
// Time Employee and Salary Employee and uses the methods of the employee 
// classes. The class has methods to add basic as well as specific duties 
// assigned to the secretary. The class Secretary 1 has two template lists 
// from STL. One list is declared as a static data type so that it is accessible 
// without object. 
// The class Secretary has virtual inheritance which helps to solve the problems of 
// multiple inheritance. Without virtual inheritance method calls would not 
// be recognized which class they belong to because most of classes have 
// the same name of methods. The class Secretary 1 has the method Report() 
// that outputs basic duties of the classes Secretary, Secretary 2 and 3. 
// The method Report also outputs specific duties of the class Secretary 1. 
// **************************************************************************

class SecretaryClass1 : virtual public Secretary, virtual public FullTimeEmployee, 
			virtual public SalaryEmployee
{
   public:
      // method: addDuty - adds secretary's basic duties 
	  //    preconditions - no validity checking is performed
      //      - input parametr must be string 
	  //    postconditions
      //       - duty is added to the list
      //    method input - secretary's duty as a string data type 
      //    method output - none
	  static void addDuty(const string& inpStr);
      
	  // method: printDuties - outputs secretary's basic duties 
	  //    preconditions - no validity checking is performed
      //      - input parametr must be valid output stream
	  //    postconditions - secretary'd duties outputs as a list of strings
      //    method input - reference to an object of type osteram 
      //    method output - secretary's duties outputs
	  static void printDuties(ostream& os);
      
	  // method: addspecificDuty - adds secretary's specific duties 
	  //    preconditions - no validity checking is performed
      //      - input parametr must be string 
	  //    postconditions
      //       - duty is added to the list
      //    method input - secretary's duty as a string data type 
      //    method output - none
	  void addSpecificDuty(const string& inpStr);
      
	  // method: printDuties - outputs secretary's specific duties 
	  //    preconditions - no validity checking is performed
      //      - input parametr must be valid output stream
	  //    postconditions - secretary'd duties outputs as a list of strings
      //    method input - reference to an object of type osteram 
      //    method output - secretary's duties outputs
	  void printSpecificDuties(ostream& os) const;
      
	  // virtual method:  Report - is implementation of the abstract 
	  // method Report in Employee class the methods outputs basic and 
	  // specific duties of class Secretary 1. The method also outputs 
	  // basic duties of the classes Secretary, Secretary 2 and 3. The 
	  // method was declared as a virtual in order to call appropriate 
	  // method Report from the array of Secretary classes. Since the 
	  // method was declared as a virtual it uses the principles of polymorphism
	  //    preconditions -  input parametr must be valid output stream
      //    postconditions - none
      //    method input - reference to an object of type osteram
      //    method output - outputs secretary's basic and specifc duties
	  //		as a list of strings
	  virtual void Report(ostream&) const;
      
	  // declaration of static variable classification to
	  // output the secretary's classification as Secretary 1
	  static string classification;
   private:
      // static list of secretary's basic duties is declared
	  static list<string> duties;
      // list of secretary's specific duties is declared
	  list<string> specificduties;
};
#endif
