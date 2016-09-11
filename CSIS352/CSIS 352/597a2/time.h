//Andrey Vasilyev
//date.h
//02/02/2009
//Assignment 2

#ifndef _TIMECLASS_
#define _TIMECLASS_
#include <time.h>
#include <string>

using namespace std;

namespace TimeNameSpace {

	enum TimeFormat {CIVILIAN, MILITARY, DETAILED};
   // TEXT: January 13, 2009
   // NUMERIC: 1/13/2009
   // FULLTEXT: Tuesday, January 13, 2009
   // FULLNUMERIC: Tuesday, 1/13/2009

//Date Exception is an exception class that catches errors occured in the methods of the class Date
class TimeException 
{
public:	

	// default constructor
	//    method input - none
	//    method output - string with an error message
	TimeException()
	{
		message="Input is wrong";
	}
	
// parametr list constructor
//    preconditions - valid string 
//    postconditions - input string is assigned to string variable
//    method input - string with error message
//    method output - outputs the message about the error that was caught by the exception
	TimeException(string str)	
	{
		message=str;
	}
	string what()
	{
		return message;
	}
private:
	string message;
};
	

class Time
{
	public:
      // default constructor
      //    preconditions - no validity checking is performed
      //       - hour must be in range of 1 to 23
      //       - minute must be in the range of 1 to 60
      //       - second must be in the range of 1 to 60 
	  //    postconditions
      //       - hour, minute, and second attributes are set to the arguments.
      //         if no arguments are given, the time is set to the current time
      //    method input - hour, minute, and second
      //    method output - none
      Time(); 

	  
	  // parameter list constructor with one parameter hour 
	  // the other parameters minute and second are set to zero by default
	  //    preconditions - validity checking is performed
      //	   - hour must be in range of 1 to 23
      //       - minute must be in the range of 1 to 60
      //       - second must be in the range of 1 to 60 
	  //    postconditions
      //       - hour, minute, and second attributes are set to the arguments.
      //    the exception will be thrown if the hour entered is invalid
	  //    method input - hour, minute, and second
      //    method output - none
	  Time(int);
	  
	  // parameter list constructor with two parameters hour and minute 
	  // another parameter second is set to zero by default
	  //    preconditions - validity checking is performed
      //	   - hour must be in the range of 1 to 23
      //       - minute must be in the range of 1 to 60
      //       - second must be in the range of 1 to 60 
	  //    postconditions
      //       - hour, minute, and second attributes are set to the arguments.
      //         if no arguments are given, the time is set to the current time
      //    the exception will be thrown if the hour or minute are invalid
	  //    method input - hour, minute, and second
      //    method output - none
	  Time(int, int);
	  
	  // parameter list constructor with three parameters hour, minute and second 
	  //    preconditions - validity checking is performed
      //	   - hour must be in the range of 1 to 23
      //       - minute must be in the range of 1 to 60
      //       - second must be in the range of 1 to 60 
	  //    postconditions
      //       - hour, minute, and second attributes are set to the arguments.
      //         if no arguments are given, the time is set to the current time
      //    the exception will be thrown if the hour, minute or second are invalid
	  //    method input - hour, minute, and second
      //    method output - none
	  Time(int, int, int);

      // method: getHour - returns the hour attribute
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the attribute hour
      int getHour() const; 

	  // method: setHour - sets the hour attribute
      //    preconditions - 
      //    postconditions - state of the hour attribute has been updated
      //    method input - hour
      //    method output - none
      void setHour(int hour);

	  // method: getMinute - returns the minute attribute
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the attribute minute
      int getMinute() const; 

	  // method: setMinute - sets the minute attribute
      //    preconditions - 
      //    postconditions - state of the minute attribute has been updated
      //    method input - minute
      //    method output - none
      void setMinute(int minute);
	  	  
	  // method: getHour - returns the second attribute
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - the attribute second
      int getSecond() const; 

	  // method: setHour - sets the second attribute
      //    preconditions - 
      //    postconditions - state of the second attribute has been updated
      //    method input - second
      //    method output - none
      void setSecond(int second);

	  // method: set the date arguments: hour, minute, second
	  //    preconditions - validity checking is performed
	  //       - hour must be in range of 1 to 23
      //       - minute must be in the range of 1 to 60
      //       - second must be in the range of 1 to 60.  
      //    postconditions
      //       - hour, minute, and second attributes are set to the arguments.
      //	if the attributes hour, minute or second are invalid the exception will catch the error
      //    method input - hour, minute, and second
      //    method output - none
	  void setTime(int,int,int);

	  // method: now - assigns the object time attributes to the current time
      //    preconditions - none
      //    postconditions - the time attributes contain the current time
      //    method input - none
      //    method output - none
      void now();         

      // method: operator==  compares the object to an argument
      //    preconditions - the object and argument are valid time sets
      //    postconditions - result of comparison is returned
      //    method input - a time argument
      //    method output - true if object and argument are equal
      bool operator==(const Time&) const;

      // method: operator!=  compares the object to an argument
      //    preconditions - the object and argument are valid time sets
      //    postconditions - result of comparison is returned
      //    method input - a time argument
      //    method output - true if object and argument are not equal
      bool operator!=(const Time&) const;

      // method: operator<=  compares the object to an argument
      //    preconditions - the object and argument are valid time sets
      //    postconditions - result of comparison is returned
      //    method input - a time argument
      //    method output - true if object is <= to argument
      bool operator<=(const Time&) const;

      // method: operator>=  compares the object to an argument
      //    preconditions - the object and argument are valid time sets
      //    postconditions - result of comparison is returned
      //    method input - a time argument
      //    method output - true if object is >= to argument
      bool operator>=(const Time&) const;

      // method: operator<  compares the object to an argument
      //    preconditions - the object and argument are valid time sets
      //    postconditions - result of comparison is returned
      //    method input - a time argument
      //    method output - true if object is < argument
      bool operator<(const Time&) const;

      // method: operator>  compares the object to an argument
      //    preconditions - the object and argument are valid time sets
      //    postconditions - result of comparison is returned
      //    method input - a time argument
      //    method output - true if object is > argument
      bool operator>(const Time&) const;

      // method: outputFormat  sets the output format for objects of Time class
      //            being output using the << insertion operator.
      //            The default output format is CIVILIAN.
      //    preconditions - none
      //    postconditions - the output format is set for all time objects
      //    method input - TimeFormat
      //    method output - none
      static void outputFormat(TimeFormat);

	  // method: operator <<  outputs the date in the set format to the
      //            output stream
      //    preconditions - Time object is valid
      //    postconditions - Time object is output in the proper format
      //            as determined by a static variable in the Time class
      //    method input - the output stream and the Time object
      //    method output - the output stream
      friend ostream& operator << (ostream&, const Time&);

	  // declaration of static variable of enumiration type 
	  // the following time formats could be assigned to static variable TimePrintFormat:
	  // CIVILIAN, MILITARY, DETAILED
	  static TimeFormat TimePrintFormat;

private:
     
	 int hour;       // stores the hour
     int minute;         // stores the minute
     int second;        // stores the second
     
	 //the variables are used to get the current system time
	 time_t rawtime; 
	 struct tm * timeinfo;
	  
};
};
#endif
