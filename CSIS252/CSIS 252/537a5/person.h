// File:      person.h
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 5
// Date:      10/04/07

// This file contains the specification for a Person class.  The information about people
// can be set by providing their names and birthday to the set methods.  
//The person is stored as one string variable for name and one data variable for birthday. 
//String and Data are classes used in the class Person.  
//No error checking is performed so it is up to the user to provide a valid people's name and birthday. 
//Birthday is the object of class Date. The birthday calls methods of the class Date. 
//This methods are the following: setMonth() - set the moth of birthday, 
//setDay() - set the day of birthday, setYear()-set the year of birthday , 
//now()-determines current date, dayDifference()-calculate the quantity of 
//years between the current date and the day of birth which is used to calculation the age of people


#ifndef _PERSON_
#define _PERSON_
#include<string>
#include"date.h"

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

private:
	string name; 	// stores person's name
	Date birthday;	//stores the arguments of class Data in the object birthday

};
#endif