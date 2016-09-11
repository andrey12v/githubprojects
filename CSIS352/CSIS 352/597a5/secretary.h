// Andrey Vasilyev
// CSIS 352
// secretary.h
// 03/14/2009
// Assignment 5

#ifndef _SECRETARY_
#define _SECRETARY_
#include <string>
#include <list>
#include "employee.h"

//****************** The description of the class Secretary ***********************
// The class Secretary is inherited from the person and employee classes. 
// The class allows setting and getting secretary’s basic duties. The class 
// also has a static list from the Standard Template Library to keep all secretary’s duties. 
// Since the list is declared as a static data type it is accessible without an 
// object. The Secretary class is also used as the base class for the Secretary 
// Classes 1, 2 and 3. 
//*********************************************************************************

class Secretary : virtual public Employee
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
      //      - input parametr must be valid output stream, object of class ostream
	  //    postconditions - secretary'd duties outputs as a list of strings
      //    method input - reference to an object of type osteram 
      //    method output - secretary's duties outputs
	  static void printDuties(ostream& os);
   private:
      // The list of duties is declared as a static templated list with
	  // string elements  
	  static list<string> duties;
};
#endif
