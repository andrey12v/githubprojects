enum DateFormat {TEXT, NUMERIC, FULLTEXT, FULLNUMERIC};
      // TEXT: January 13, 2009
      // NUMERIC: 1/13/2009
      // FULLTEXT: Tuesday, January 13, 2009
      // FULLNUMERIC: Tuesday, 1/13/2009

Public methods for the Date class
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
      int dayDifference(const Date& d) const;

      // method: daysUntil - calculates the number of days from today 
      //            until the next calendar occurance of this Date object.
      //            I.e. the year attribute is not considered (except if
      //            leap year occurs in between.
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

      // method: operator-   calculates the number of days between
      //            the object and the Date argument.  The number of
      //            days is an absolute value.
      //    preconditions - the object and the Date argument are valid
      //    postconditions - the number of days is returned
      //    method input - Date
      //    method output - number of days between the object and argument
      //              the object and the Date argument
      int operator-(const Date&) const;

      // method: operator-  subtracts the number of days represented by
      //            argument from the Date object and returns a new Date
      //    preconditions - the object is a valid date
      //    postconditions - the method returns a new Date that is the
      //            argument days less than the object
      //    method input - the number of days to subtract
      Date operator-(int) const;

      // method: operator+  adds the number of days represented by
      //            argument to the Date object and returns a new Date
      //    preconditions - the object is a valid date
      //    postconditions - the method returns a new Date that is the
      //            argument days plus the object
      //    method input - the number of days to add
      //    method output - the new Date after the argument is added
      Date operator+(int) const;

      // method: outputFormat  sets the format for output of all Date objects
      //            being output using the << insertion operator.
      //            The default output format is NUMERIC.
      //    preconditions - none
      //    postconditions - the output format is set for all Date objects
      //    method input - DateFormat
      //    method output - none
      static void outputFormat(DateFormat);

      // method: operator <<  outputs the date in the set format to the
      //            output stream
      //    preconditions - Date object is valid
      //    postconditions - Date object is output in the proper format
      //            as determined by a static variable in the Date class
      //    method input - the output stream and the Date object
      //    method output - the output stream
      friend ostream& operator << (ostream&,const Date&);

