// Andrey Vasilyev
// CSIS 352
// secretaryclass3.h
// 03/14/2009
// Assignment 5

#ifndef _SECRETARYCLASS3_
#define _SECRETARYCLASS3_
#include <string>
#include <list>
#include <iterator>
#include <iostream>
#include "secretary.h"
#include "hourlyemployee.h"
#include "parttimeemployee.h"
using namespace std;

// ************** The description of the class Secretary 1 *****************
// The class Secretary 3 is inherited from the classes Secretary, Part 
// Time Employee and Hourly Employee and uses the methods of the employee 
// classes. The class has methods to add basic as well as specific duties 
// assigned to the secretary. The class Secretary 2 has two template lists 
// from STL. One list is declared as a static data type so that it is accessible 
// without an object. 
// The class Secretary 3 has virtual inheritance which helps to solve the problems of 
// multiple inheritance. Without virtual inheritance method calls would not 
// be recognized which class they belong to because most of classes have 
// the same name of methods. The class Secretary 3 has the method Report() 
// that outputs basic duties of the classes Secretary and specific
// duties of the class Secretary 3 
// **************************************************************************

class SecretaryClass3 : virtual public Secretary, virtual public PartTimeEmployee, 
			virtual public HourlyEmployee
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
	  // method Report in Employee class. The methods outputs basic and 
	  // specific duties of class Secretary 3. The method also outputs 
	  // basic duties of the classe Secretary. 
	  // The method was declared as a virtual in order to call appropriate 
	  // method Report from the array of Secretary classes. Since the 
	  // method was declared as a virtual it uses the principles of polymorphism
	  //    preconditions -  input parametr must be valid output stream
      //    postconditions - none
      //    method input - reference to an object of type osteram
      //    method output - outputs secretary's basic and specifc duties
	  //		as a list of strings
	  virtual void Report(ostream&) const;
      
	  // declaration of static variable classification to
	  // output the secretary's classification as Secretary 3
	  static string classification;
   private:
      
      // static list of secretary's basic duties is declared
	  static list<string> duties;
	  // list of secretary's specific duties is declared
	  list<string> specificduties;
};

#endif
