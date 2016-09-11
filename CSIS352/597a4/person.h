// Andrey Vasilyev
// CSIS 352
// employee.h
// 03/01/2009
// Assignment 4

//******************* The description of the class Person***************************
// This file contains the specification for a Person class.  The information 
// about people can be set by providing their names and birthday to the set methods.  
// No error checking is performed so it is up to the user to provide a valid people's 
// name and birthday. Birthday is the object of class Date. The birthday calls methods 
// of the class Date. 
//**********************************************************************************

#ifndef _PERSON_
#define _PERSON_
#include<string>
// the class is used to declare and use birthday variable
#include "date.h"  
using namespace DateNameSpace; 

class Person
{

public:
	// default constructor
    //    preconditions - no validity checking is performed
    //       - name must be string variable of 25 characters
    //       - birthday must include the date of birthday in the format mm/dd/year
    //    postconditions
	//       - name and date attributes are set to the arguments.
	//         if no arguments are given, the name veraible is set to empty 
	//the birthday is equal to zero
	//    method input - name, birthday
	//    method output - none
	Person();
	
	// parameter list constructor
    //    preconditions - no validity checking is performed
	//      - date must have valid format; month, days and year must be in the proper range	
	//		- month must be in range of 1 to 12
    //       - day must be in the proper range for the month
    //       - year must include all digits.  For example, 98 is
    //         not assumed to be 1998, but the year 98.
	//    postconditions
    //	- employee's name, birthday, social security number and ID number are 
	//	  set to arguments
	//    method input - name, date,social security number and employee ID
    //    method output - none
	Person(string inpName, Date& d, string inpSSN) : name(inpName), birthday(d), SSN(inpSSN){}
	
	//method: setBirthday - sets the date of birthday by means of Data class methods. 
	//These methods are setMonth(), setDay(), setYear()
      	//    preconditions - the date in the format mm/dd/yyyy
      	//    postconditions - state of the date of class Person attribute has been updated
      	//    method input - the object of the class Date
      	//    method output - none
	void setBirthday(Date &d);

	//method: setName - sets the name of person. 
      	//    preconditions - person's name no more than 25 characters
      	//    postconditions - state of the name of class Person attribute has been updated
      	//    method input - string variable 
      	//    method output - none

	void setName(string);
	
	// method: getName - returns the name attribute
      	// preconditions - none
      	// postconditions - none
      	// method input - none
      	// method output - the attribute name
	string getName() const;
		
	// method: getBirthday - returns the object of class Date. 
	// Date arguments and methods can be used through this method
      	// preconditions - none
      	// postconditions - none
      	// method input - none
      	// method output - the attribute birthday
	Date getBirthday();
	
	// method: getAge - returns the age aatribute 
	// the method getAge calculates the quantity of years btween the current day and the day of birth
      	// preconditions - none
      	// postconditions - none
      	// method input - none
      	// method output - the attribute age
	int getAge() const;

	//method: setSSN - sets peorson's social security number 
    //    preconditions - none
    //    postconditions - sets SSN to argument
    //    method input - string variable 
    //    method output - none
	void setSSN(string inpSSN);

	// method: getSSN - returns peorson's social security number 
	// preconditions - none
    // postconditions - returns person's SSN
    // method input - none
    // method output - the attribute SSN
	string getSSN() const;

private:
	string name; 	// stores person's name
	Date birthday;	//stores the arguments of class Data in the object birthday
	string SSN;
};
#endif

