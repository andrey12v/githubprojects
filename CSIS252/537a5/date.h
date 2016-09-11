// File:      date.h
// Author:    Dan Brekke

// This file contains the specification for a date class.  The date
// can be set by providing the date to the constructor or by using the
// set methods.  The date is stored as 3 ints, one each for the month,
// day, and year.  No error checking is performed so it is up to the
// user to provide a valid date.

// Each time the state of the object is changed, the day of the week is
// calculated and stored as a string.  The day of the week is only valid
// if the date is valid.


#ifndef _DATECLASS_
#define _DATECLASS_
#include <time.h>
#include <string>
using namespace std;
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
      Date(int month=0,int day=0,int year=0); 

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
      void setYear(int year);

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

      // method: dayDifference - calculates the number of days between
      //            the object and the Date argument.  If the object
      //            occurs BEFORE the argument, the number of days will
      //            be a positive value, else it will be negative.
      //    preconditions - the object and the Date argument are valid
      //    postconditions - the number of days is returned
      //    method input - Date
      //    method output - number of days between the object and argument
      int dayDifference(const Date&) const;

      // method: daysUntil - calculates the number of days from today 
      //            until the next calendar occurance of the Date argument.
      //            I.e. the year attribute is not considered.
      //    preconditions - the object has a valid date
      //    postconditions - the number of days is returned
      //    method input - none
      //    method output - number of days from the current date until
      //            the next calendar occurance of the date
      int daysUntil() const;

      // method: yearDifference - calculates the number of years between
      //            the object and the Date argument.  If the object
      //            occurs BEFORE the argument, the number of years will
      //            be a positve value, else it will be negative.
      //    preconditions - the object and the Date argument are valid
      //    postconditions - the number of years is returned
      //    method input - Date
      //    method output - number of years between the object and argument
      int yearDifference(const Date& d) const;

   private:
      int month;       // stores the month
      int day;         // stores the day
      int year;        // stores the year
      string theday;      // stores a string for the day of the week
      struct tm *ptr;  // used for getting the current date from the system
      time_t lt;       // used for getting the current date from the system
      bool leapyear(int) const;  // determines if the year has a leapyear
      void DayOfWeek();   // calculates the day of the week
};
#endif
