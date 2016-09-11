#include<iostream>
#include <fstream>
#include "date.h"

using namespace std;

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

//determine the number of days in the month
//it is necessary to overload operator+ and operator-
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

int getMonthDifference(int inpYear, int inpMonthSmallest, int inpMonthBiggest, int inpDaySmallest, int inpDayBiggest)
{
	int numDays=0;
	do
	{
		numDays=numDays + getNumberOfDaysInMonth(inpYear, inpMonthSmallest);
		inpMonthSmallest++;

	} while(inpMonthSmallest<inpMonthBiggest);
	
	numDays=numDays + inpDayBiggest;
	numDays=numDays - inpDaySmallest;
	return numDays;
}

int getYearDifference(int yearSmallest, int yearBiggest, int monthSmallest, int monthBiggest, int daySmallest, int dayBiggest)
{

	int tmpYear=yearSmallest;
	int numDays=0;
	do{
		if (leapyear(tmpYear))
		{
			numDays=numDays+366;
		}
		else{ numDays=numDays+365; }
			
		tmpYear++;
		
	} while(tmpYear<yearBiggest);
	
	
	if(monthBiggest==1)
	{
		numDays=numDays+dayBiggest;
	}
	else if(monthBiggest>1)
	{
		int tmpMonth=1;
		do
		{
			numDays=numDays+getNumberOfDaysInMonth(yearBiggest, tmpMonth);
			tmpMonth++;
		} while(tmpMonth<monthBiggest);
	
		numDays=numDays+dayBiggest;
	}


	int numOfDaysInSmallestDate=0;
	if (monthSmallest==1)
	{
		numOfDaysInSmallestDate=numOfDaysInSmallestDate+daySmallest;
	}
	else if(monthSmallest>1)
	{
		int tmpMonth=1;
		do
		{
			numOfDaysInSmallestDate=numOfDaysInSmallestDate+getNumberOfDaysInMonth(yearSmallest, tmpMonth);
			tmpMonth++;
				
		} while(tmpMonth<monthSmallest);
			
		numOfDaysInSmallestDate=numOfDaysInSmallestDate+daySmallest; 
	}

	return numDays-numOfDaysInSmallestDate;
	
}
//*************************************************End Declaration of local functions****************************************


Date::Date(){
	month=0;
	day=0;
	year=0;
}

Date::Date(int inpMonth,int inpDay,int inpYear)
{
	month=inpMonth;
	day=inpDay;
	year=inpYear;
}

DateFormat Date::PrintFormat=NUMERIC;

void Date::setYear(int inpYear){
	year=inpYear;
}

int Date::getYear() const 
{
	return year;
}

void Date::setMonth(int inpMonth){
 month=inpMonth;
}

int Date::getMonth() const
{
	return month;
}

void Date::setDay(int inpDay){
 day=inpDay;
}

int Date::getDay() const
{
	return day;
}

void Date::setDate(int inpMonth,int inpDay,int inpYear)
{
	month=inpMonth;
	day=inpDay;
	year=inpYear;
}

// Calculate the day of the week and store the corresponding string in
// the day data attribute.
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


void Date::now()
{
	time ( &rawtime );	
	timeinfo = localtime ( &rawtime );

	year=timeinfo->tm_year+1900; 
	month=timeinfo->tm_mon+1;
	day=timeinfo->tm_mday;
}

int Date::dayDifference(const Date& d) const
{
	int numDays=0;
	int tmpYear=d.year;
	int tmpMonth=d.month; 
	int	tmpDay=d.day;

	
	if ((tmpYear==d.year) && (d.month==this->month) && (d.day==this->day))
	{
		return 0;
	}
	
	if ((d.year==this->year) && (d.month==this->month) && ((this->day<d.day) || (this->day>d.day)))
	{
		return this->day-d.day;
	}
	
	if ((d.year==this->year) && (d.month<this->month))
	{
		return getMonthDifference(this->year, d.month, this->month, d.day, this->day);
	}
	if ((d.year==this->year) && (d.month>this->month))
	{
		return -getMonthDifference(this->year, this->month, d.month, this->day, d.day);
	}
	if (d.year<this->year) 
	{
		return getYearDifference(d.year, this->year, d.month, this->month, d.day, this->day);
	}
	if (d.year>this->year)
	{
		return -getYearDifference(this->year, d.year, this->month, d.month, this->day, d.day);
	}

	return 0;
}


int Date::daysUntil() const
{
	Date tmpDate;
	tmpDate.now();

	if(this->month>tmpDate.month)
	{
		return getMonthDifference(tmpDate.year, tmpDate.month, this->month, tmpDate.day, this->day);
	}
	else if((this->month==tmpDate.month) && (this->day>=tmpDate.day))
	{
		return this->day-tmpDate.day;
	}
	else if((this->month==tmpDate.month) && (this->day<tmpDate.day))
	{
		return getYearDifference(tmpDate.year, tmpDate.year+1, tmpDate.month, tmpDate.month, tmpDate.day, this->day);
	}
	else if(this->month<tmpDate.month)
	{
		return getYearDifference(tmpDate.year, tmpDate.year+1, tmpDate.month, this->month, tmpDate.day, this->day);
	}
	
	return 0;
}

int Date::yearDifference(const Date& d) const
{
	return this->year-d.year;
}


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


ostream& operator<<(ostream& ofs, const Date& dateObj)
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


/////////////////////////////BONUS work/////////////////////////////////////////

//post increment
Date Date::operator++(int)
{
	Date temp=*this;
	
	day++;
	if (day>getNumberOfDaysInMonth(year, month)){
		cout<<"The number of "<<day<<" days is more then in "<<getNameOfMonth(this->getMonth())<<endl; 
		cout<<"The month will be chenged to the next one and the day will be set to 1"<<endl;
		day=1;
		month++;
		if (month>12){
			cout<<"The number of months is more than 12."<<endl;
			cout<<"The month will be Januray and the year will be changed to the next"<<endl;
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
		cout<<"The number of "<<day<<" days is more then in "<<getNameOfMonth(this->getMonth())<<endl; 
		cout<<"The month will be chenged to the next one and the day will be set to 1"<<endl;
		day=1;
		++month;
		if (month>12){
			cout<<"The number of months is more than 12."<<endl;
			cout<<"The month will be Januray and the year will be changed to the next"<<endl;
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
		cout<<"The number of days is less or equl to 0."<<endl; 
		cout<<"The current month will be changed to the previous one and"<<endl; 
		cout<<"the day will be set to the last day of the previous month."<<endl;
		month--;
		if(month<=0){
			cout<<"The month is less or equl to 0."<<endl; 
			cout<<"The current year will be changed to the previous and"<<endl;
			cout<<"the month will be set to December"<<endl;
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
		cout<<"The number of days is less or equl to 0."<<endl; 
		cout<<"The current month will be changed to the previous one and"<<endl; 
		cout<<"the day will be set to the last day of the previous month."<<endl;
		--month;
		if(month<=0){
			cout<<"The month is less or equl to 0."<<endl; 
			cout<<"The current year will be changed to the previous and"<<endl;
			cout<<"the month will be set to December"<<endl;
			month=12;
			--year;
		}
		day=getNumberOfDaysInMonth(year, month);
	}
	
	return *this;
}


// method: operator-  subtracts the number of days represented by
// argument from the Date object and returns a new Date
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



