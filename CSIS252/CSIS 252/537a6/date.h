#ifndef _DATECLASS_
#define _DATECLASS_
#include <time.h>
#include <string>
using namespace std;

enum DateFormat {TEXT, NUMERIC, FULLTEXT, FULLNUMERIC};

class Date
{
   public:
      // constructor
      //    preconditions - no validity checking is performed
      //       - month must be in range of 1 to 12
      //       - day must be in the proper range for the month
      //       - year must include all digits.  For example, 98 is
      //         not assumed to be 1998, but the year 98.
      //    postconditions
      //       - month, day, and year attribute are set to the arguments.
      //         if no arguments are given, the date is set to the
      //         date of 0/0/0
      //    method input - month, day, and year
      //    method output - none
      Date(); 

      // method: getMonth - returns the month attribute
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the attribute month
      int getMonth() const; 

      // method: getDay - returns the day attribute
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the attribute day
      int getDay() const;  

      // method: getYear - returns the year attribute
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the attribute year
      int getYear() const;  

      // method: setMonth - sets the month attribute
      //    preconditions - the month is in the range of 1 to 12
      //    postconditions - state of the month attribute has been updated
      //    method input - month
      //    method output - none
      void setMonth(int month); 

      // method: setDay - sets the day attribute
      //    preconditions - the date is in the range proper range for month
      //    postconditions - state of the day attribute has been updated
      //    method input - day
      //    method output - none
      void setDay(int day);  

      // method: setYear - sets the year attribute
      //    preconditions - the year is the full year.  For example
      //          98 is not assumed to be 1998, but the year 98.
      //    postconditions - state of the year attribute has been updated
      //    method input - year
      //    method output - none
      void setYear(int);

      // method: getDayOfWeek - return a string for the day of the week
      //          for the date of the object
      //    preconditions - the object is a valid date
      //    postconditions - none
      //    method input - none
      //    method output - a string of the day of the week (Monday - Sunday)
      string getDayOfWeek() const;

      // method: now - assigns the object data attributes to the current date
      //    preconditions - none
      //    postconditions - the data attributes contain the current date
      //    method input - none
      //    method output - none
      void now();              

      // method: operator++  post increments the day to the next day
      //    preconditions - the object is a valid date
      //    postconditions - the date is incremented to the next day
      //    method input - none
      //    method output - original value of the Date object
      Date operator++(int);

      // method: operator++  pre increments the day to the next day
      //    preconditions - the object is a valid date
      //    postconditions - the date is incremented to the next day
      //    method input - none
      //    method output - value of the incremented Date object
      Date operator++();

      // method: operator--  post decrements the day to the previous day
      //    preconditions - the object is a valid date
      //    postconditions - the date is decremented to the previous day
      //    method input - none
      //    method output - original value of the Date object
      Date operator--(int);

      // method: operator--  pre decrements the day to the previous day
      //    preconditions - the object is a valid date
      //    postconditions - the date is decremented to the previous day
      //    method input - none
      //    method output - value of the decremented Date object
      Date operator--();

  	// method: operator-  subtracts the number of days represented by
      //            argument from the Date object and returns a new Date
      //    preconditions - the object is a valid date
      //    postconditions - the method returns a new Date that is the
      //            argument days less than the object
      //    method input - the number of days to subtract
      //    method output - the new Date after the argument is subtracted
      Date operator-(int) const;

      // method: operator+  adds the number of days represented by
      //            argument to the Date object and returns a new Date
      //    preconditions - the object is a valid date
      //    postconditions - the method returns a new Date that is the
      //            argument days plus the object
      //    method input - the number of days to add
      //    method output - the new Date after the argument is added
      Date operator+(int) const;      

	// method: operator==  compares the object to an argument
      //    preconditions - the object and argument are valid dates
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object and argument are equal
      bool operator==(const Date&) const;

      // method: operator!=  compares the object to an argument
      //    preconditions - the object and argument are valid dates
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object and argument are not equal
      bool operator!=(const Date&) const;

      // method: operator<=  compares the object to an argument
      //    preconditions - the object and argument are valid dates
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object is <= to argument
      bool operator<=(const Date&) const;

      // method: operator>=  compares the object to an argument
      //    preconditions - the object and argument are valid dates
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object is >= to argument
      bool operator>=(const Date&) const;

      // method: operator<  compares the object to an argument
      //    preconditions - the object and argument are valid dates
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object is < argument
      bool operator<(const Date&) const;

      // method: operator>  compares the object to an argument
      //    preconditions - the object and argument are valid dates
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object is > argument
      bool operator>(const Date&) const;

      // method: setDate  - sets the object to a new date
      //    preconditions - the arguments are valid
      //    postconditions - the object is a new Date
      //    method input - month, day, year
      //    method output - none
      void setDate(int,int,int);

      // method: print - outputs object to screen according to argument
      //    preconditions - the object is a valid Date
      //    postconditions - the object has been output to screen
      //    method input - DateFormat which includes 
      //             TEXT, NUMERIC, FULLTEXT, FULLNUMERIC
      //    method output - none
      void print(DateFormat=NUMERIC) const;

      // method: print - outputs object to stream according to argument
      //    preconditions - the object is a valid Date
      //    postconditions - the object has been output to stream
      //    method input - the output stream and DateFormat which 
      //             includes TEXT, NUMERIC, FULLTEXT, FULLNUMERIC
      //    method output - none
      void print(ostream&, DateFormat=NUMERIC) const;
	
	// method: getNameOfMonth - return a string for the name of the month
      //          for the date of the object
      //    preconditions - the object is a valid date
      //    postconditions - none
      //    method input - none
      //    method output - a string of the name of the month (January - December)
	  string getNameOfMonth() const;
   
	// method: getNumberOfDaysInMonth() - return the quantity of days for definite month
      //    preconditions - the object is a valid date
      //    postconditions - none
      //    method input - none
      //    method output - a int number of days in the month
	  int getNumberOfDaysInMonth() const;

private:
      int month;       // stores the month
      int day;         // stores the day
      int year;        // stores the year
      struct tm *ptr;  // used for getting the current date from the system
      time_t lt;       // used for getting the current date from the system

};

ostream& operator << (ostream&, const Date&);
istream& operator >> (istream&, Date&);

//the function displays the date of the class Date
//the function is necessary to check the work of pointer
void FuncPointer(Date a1);

#endif


