// Andrey Vasilyev
// CSIS 352
// employee.h
// 04/19/2009
// Assignment 6

#ifndef _EMPLOYEE_
#define _EMPLOYEE_

#include <string>
#include <iostream>
using namespace std;
const int TABLE_SIZE_EMPLOYEE=13;  // declaration of the hash table size

//********The description of the class Employee*************************
// The class Employee is designed to keep employees’ social security 
// number and name. Objects of the class Employee are saved in the hash 
// table of the class DynamicHashTable
//**********************************************************************

class Employee
{
   public:
	  
	  // method: setSSN sets employee's social security number 
	  //   preconditions - no validity checking is performed
      //     - employee's SSN must be represented as a string with numbers and dashes
	  //    postconditions
      //       - employee's SSN attribute is set to the argument.
	  //    method input - string
      //    method output - none
	  void setSSN(const string&);
      
	  // method: getSSN - returns employee's social security number
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - employee's SSN a string
	  string getSSN() const;
      
	  // method: setName sets employee's name 
	  //   preconditions - no validity checking is performed
      //     - employee's name must be string
	  //    postconditions
      //       - employee's name attribute is set to the argument.
	  //    method input - string
      //    method output - none
	  void setName(const string&);
	  
	  // method: getName - returns employee's name
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - employee's name as a string 
	  string getName() const;
      
	  // method: operator==  compares the object to an argument
      //    preconditions - the object and argument are valid 
	  //                 employee's variables: SSN, Name 
      //    postconditions - result of comparison is returned
      //    method input - object of class Employee
      //    method output - true if object and argument are equal
      bool operator==(const Employee& inpEmployee) const;
        
	  // method: hash() - generates hash value as an integer number 
	  // from Social Security Number. The hash value is used as an 
	  // index in a hash table to insert or get elements. The hash() 
	  // converts characters of SSN into ASCII codes and adds them 
	  // together. Then the hash value is returned as modulus between 
	  // sum of SACII codes and the size of the hash table.   
	  //  preconditions - the size of hash table must be assigned and 
	  //				     must be more than zero
      //  postconditions - hashed value of SSN is returned
      //  method input - none
      //  method output - hash value as an integer number
	  int hash() const;

private:
      string ssn; // the key, and what will be hashed
      string name;
};

// method: operator <<  outputs employee's data in the set format to the
//         output stream
//  preconditions - employee's data variables are valid
//  postconditions - Employee object outputs in the proper format
//    method input - the output stream and object of the class Employee
//    method output - the output stream
ostream& operator<<(ostream&,const Employee&);

#endif
