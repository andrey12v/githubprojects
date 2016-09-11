// Andrey Vasilyev 
// date.cpp
// 02/03/2009
// CSIS 352
// Assignment 2

#include<iostream>
#include "date.h"

using namespace std;
namespace DateNameSpace
{
//*****************************************Begin Declaration of local functions*****************************************

// Determine whether the year is a leapyear.  This is necessary for
// calculating the day of the week
bool leapyear(int year) 
{
   if (year % 4 == 0 && year % 100 != 0)
      return true;
   if (year % 100 == 0 && year % 400 == 0)
      return true;
   return false;
}

//Return the number od days in common and leap year 
//according to entered year
int getNumberOfDaysInYear(int year)
{
	if (leapyear(year))
	{
		return 366;
	}
	else
	{
		return 365; 
	}

	return 0;
}

//determine the number of days in the month
//it is used to overload operator+ and operator-
int getNumberOfDaysInMonth(int inpYear,int inpMonth){
	
	
	switch(inpMonth){
	case 1: return 31; break;
	case 2: if (leapyear(inpYear)){ return 29; break; }
			else {return 28; break; }
	case 3: return 31; break;
	case 4: return 30; break;
	case 5: return 31; break;
	case 6: return 30; break;
	case 7: return 31; break;
	case 8: return 31; break;
	case 9: return 30; break;
	case 10: return 31; break;
	case 11: return 30; break;
	case 12: return 31; break;
	}
	
	return 0;
}

//the method returns the name of the month
string getNameOfMonth(int month)
{
	switch (month)
	{
		case 1:  return "January";  break;
		case 2:  return "February"; break;
		case 3:  return "March";	break;
		case 4:  return "April";	break;
		case 5:  return "May";	break;
		case 6:  return "June";	break;
		case 7:  return "July";	break;
		case 8:  return "August";	break;
		case 9:  return "September"; break;
		case 10: return "October";	 break;					
		case 11: return "November"; break;
		case 12: return "December"; break;
	}

	return "";
}

//*************************************************End Declaration of local functions****************************************

//Default Constructor to set the current date 
Date::Date(){
	time ( &rawtime );	
	timeinfo = localtime ( &rawtime );
	
	year=timeinfo->tm_year+1900; 
	month=timeinfo->tm_mon+1;
	day=timeinfo->tm_mday;
}

// Parameter list constructor 
// set month, day and year accoroding to input data.
// If the date is invalid the exception will catch the error
Date::Date(int inpMonth,int inpDay,int inpYear)
{
	this->setDate(inpMonth, inpDay, inpYear);
}

// Static variable is used to output date in NUMERIC format 1/13/2009
// outpit format set by default to Numeric
DateFormat Date::PrintFormat=NUMERIC;

int Date::getYear() const 
{
	return year;
}

int Date::getMonth() const
{
	return month;
}

int Date::getDay() const
{
	return day;
}

// method to set the date according to input month, day and year
// the exception will be thrown if the date is invalid 
void Date::setDate(int inpMonth,int inpDay,int inpYear)
{
	
	if ((inpMonth<=0) || (inpMonth>12))
	{
		throw DateException("Month must be more than zero and less than 13");
	}
	else if (inpDay<=0)
	{
		throw DateException("Day must be more than zero");
	}
	else if (inpDay>getNumberOfDaysInMonth(inpYear,inpMonth))
	{
		throw DateException("The number of days entered exceeds the number of days in " + getNameOfMonth(inpMonth));
	}
	
	else if (inpYear<=0)
	{
		throw DateException("Year must be more than zero");
	}
	else
	{
		month=inpMonth;
		day=inpDay;
		year=inpYear;
	}
}

// Return the day of the week
string Date::getDayOfWeek() const
{
   int centuries;
   int years;
   int months;
   int dayofweek;
   centuries = (3-year/100%4)*2;
   years = year/100+year/4;
   switch (month)
   {
      case 1  : if (leapyear(year))
                   months = 6;
                else
                   months = 0; break;
      case 2  : if (leapyear(year))
                   months = 2;
                else
                   months = 3; break;
      case 3  : months = 3; break;
      case 4  : months = 6; break;
      case 5  : months = 1; break;
      case 6  : months = 4; break;
      case 7  : months = 6; break;
      case 8  : months = 2; break;
      case 9  : months = 5; break;
      case 10 : months = 0; break;
      case 11 : months = 3; break;
      case 12 : months = 5; break;
   }
   dayofweek = (centuries+year%100+year%100/4+months+day)%7;

   switch (dayofweek)
   {
      case 0 : return "Sunday"; break;
      case 1 : return "Monday"; break;
      case 2 : return "Tuesday"; break;
      case 3 : return "Wednesday"; break;
      case 4 : return "Thursday"; break;
      case 5 : return "Friday"; break;
      case 6 : return "Saturday"; break;
   }

	return "";
}

// Set an obect of the class Date to the current date
void Date::now()
{
	time ( &rawtime );	
	timeinfo = localtime ( &rawtime );
	
	year=timeinfo->tm_year+1900; 
	month=timeinfo->tm_mon+1;
	day=timeinfo->tm_mday;
}

// Return the difference in days between two objects of the class Date
int Date::dayDifference(const Date& d) const
{
	Date d1=d;
	Date dthis=*this;
	int count=0;
	
	if(*this<d1)
	{
		while(dthis<d1)
		{
			dthis++;
			count++;
		}	
	}	
	else if(*this>d1)
	{
		while(dthis>d1)
		{
			dthis--;
			count--;
		}		
	}

	return count;
}
 
// Calculate the number of days from the current date until
// the next occurance of the date argument
int Date::daysUntil() const
{
	Date dNow;
	dNow.now();
	
	Date dthis;
	dthis=*this;
	int count=0;

	if (dthis.year<dNow.year) 
	{	
		dthis.year=dNow.year;
		while(dNow<dthis)
		{
			dNow++;
			count++;
		}
		//count=count*(-1);
	}
	else if(dthis>dNow)
	{
		while(dNow<dthis)
		{
			dNow++;
			count++;
		}
		count=count*(-1);
	}

	return count;

}

// Calculate the difference in years two objects of the class Date
int Date::yearDifference(const Date& d) const
{
	int count=0;	
	int numDays=0;
	int numYears=0;
	bool leapYearExist=false;

	Date dateSmallest;
	Date dateBiggest;

	if (d<*this)
	{
		dateSmallest=d;
		dateBiggest=*this;
	}
	else if(d>*this)
	{
		dateSmallest=*this;
		dateBiggest=d;
	}

	while(dateSmallest.year<dateBiggest.year)
	{
		if((dateSmallest.month==12) && (dateSmallest.day==31) && (count<getNumberOfDaysInYear(dateSmallest.year)))
		{
			if( (leapyear(dateSmallest.year)) && (dateSmallest.month<=2))
			{
				leapYearExist=true;
			}
			numDays=count;
			count=0;
		}
		if((dateSmallest.month==12) && (dateSmallest.day==31) && (count==getNumberOfDaysInYear(dateSmallest.year)))
		{
			numYears++;
			count=0;
		}
		count++;
		dateSmallest++;
	}
	
	while(dateSmallest<=dateBiggest)
	{
		dateSmallest++;
		numDays++;
	}
	
	if((leapYearExist==true) && (numDays>=366))
	{
		numYears++;
	}
	else if((leapYearExist==false) && (numDays>=365))
	{
		numYears++;
	}

	if(d<*this)
	{
		numYears=numYears*(-1);
	}

	return numYears;

}

// set the output format according to entered data 
void Date::outputFormat(DateFormat outDFormat)
{
	
	switch (outDFormat)
	{
			case TEXT : Date::PrintFormat=TEXT; break; 
			case NUMERIC : Date::PrintFormat=NUMERIC; break;
			case FULLTEXT : Date::PrintFormat=FULLTEXT; break;	
			case FULLNUMERIC : Date::PrintFormat=FULLNUMERIC; break;
	}
}

//operator overload for output operator<<
std::ostream& operator<<(std::ostream& ofs, const Date& dateObj)
{
	switch (Date::PrintFormat)
	{
		case TEXT : ofs<<getNameOfMonth(dateObj.getMonth())<<" "<<dateObj.getDay()<<", "<<dateObj.getYear(); break;
		case NUMERIC : ofs<<dateObj.getMonth()<<"/"<<dateObj.getDay()<<"/"<<dateObj.getYear() ; break;
		case FULLTEXT : ofs<<dateObj.getDayOfWeek()<<", "<<getNameOfMonth(dateObj.getMonth())<<" "<<dateObj.getDay()<<", "<<dateObj.getYear(); break;	
		case FULLNUMERIC : ofs<<dateObj.getDayOfWeek()<<", "<<dateObj.getMonth()<<"/ "<<dateObj.getDay()<<"/ "<<dateObj.getYear(); break;
	}
	return ofs;
}


bool Date::operator==(const Date& argDate) const
{
	return (month==argDate.month && day==argDate.day 
			 && year==argDate.year);
}


bool Date::operator<(const Date& argDate) const
{
	return (year<argDate.year || 
		(year==argDate.year && month<argDate.month) ||
		(year==argDate.year && month==argDate.month && day<argDate.day));
}


bool Date::operator!=(const Date& argDate) const
{
	return (!this->operator ==(argDate));
}


bool Date::operator<=(const Date& argDate) const
{
	return (this->operator<(argDate) || this->operator==(argDate));
}


bool Date::operator>(const Date& argDate) const
{
	return ((!this->operator<(argDate)) && (!this->operator==(argDate)));
}

bool Date::operator>=(const Date& argDate) const
{
	return (this->operator>(argDate) || this->operator==(argDate));
}

//post increment
Date Date::operator++(int)
{
	Date temp=*this;
	
	day++;
	if (day>getNumberOfDaysInMonth(year, month)){
		day=1;
		month++;
		if (month>12){
			month=1;
			year++;
		
		}
		
	}
		
	return temp;
	
}

//pre increment
Date Date::operator++()
{
	++day; 
	if (day>getNumberOfDaysInMonth(year, month)){
		day=1;
		++month;
		if (month>12){
			month=1;
			++year;
		}
		
	}
	
	return *this;
}

//post decrement
Date Date::operator--(int)
{
	Date temp=*this;
	day--;
	if (day<=0){
		month--;
		if(month<=0){
			month=12;
			year--;
		}
		day=getNumberOfDaysInMonth(year, month);
	}
	
	return temp;
}

//pre decrement
Date Date::operator--()
{
	--day;
	if (day<=0){
		--month;
		if(month<=0){
			month=12;
			--year;
		}
		day=getNumberOfDaysInMonth(year, month);
	}
	
	return *this;
}


// method: operator-  subtracts the number of days represented by
//            argument to the Date object and returns a new Date
Date Date::operator-(int numDays) const
{
	Date tmpDate;
	
	int tmpNumDays=numDays;
	int tmpDay=this->day;
	int tmpMonth=this->month;
	int tmpYear=this->year;

	do
	{
		if(tmpDay==0)
		{
			tmpMonth--;
			if(tmpMonth==0)
			{
				tmpMonth=12;
				tmpYear--;
			}
			tmpDay=getNumberOfDaysInMonth(tmpYear, tmpMonth);
		}
		
		tmpNumDays--;
		tmpDay--;

	} while (tmpNumDays>0);	
	
	tmpDate.setDate(tmpMonth, tmpDay, tmpYear);
	
	return tmpDate;

}

// method: operator+  adds the number of days represented by
//            argument to the Date object and returns a new Date
Date Date::operator+(int numDays) const
{
	
	Date tmpDate;
	int tmpNumDays=numDays;
	int tmpDay=this->day;
	int tmpMonth=this->month;
	int tmpYear=this->year;

	do
	{
		if(tmpDay>=getNumberOfDaysInMonth(tmpYear, tmpMonth))
		{
			if(tmpMonth==12)
			{
				tmpMonth=1;
				tmpYear++;
			}	
			else if(tmpMonth<12)
			{
				tmpMonth++;
			}
			tmpDay=1;	
			
		}
		else
		{
			tmpDay++;
		}
		tmpNumDays--;

	} while(tmpNumDays>0);

	tmpDate.setDate(tmpMonth, tmpDay, tmpYear);
	return tmpDate;
}


// method: operator-  subtract the date represented by date object from
// the date argument
int Date::operator-(const Date& d) const
{
	Date d1=d;
	Date dthis=*this;
	int count=0;
	
	if(*this<d1)
	{
		while(dthis<d1)
		{
			dthis++;
			count++;
		}	
	}	
	else if(*this>d1)
	{
		while(dthis>d1)
		{
			dthis--;
			count--;
		}		
		count=count*(-1);
	}

	return count;	
	
}


}
