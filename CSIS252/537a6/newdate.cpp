#include<iostream>
#include <fstream>
#include "date.h"

using namespace std;

void FuncPointer(Date a1){
	cout<<"The value of pointer array in function is ";
	a1.print(FULLTEXT);
	cout<<endl;
}

Date::Date(){
	month=0;
	day=0;
	year=0;
}

void Date::setDate(int inpMonth,int inpDay,int inpYear)
{
	month=inpMonth;
	day=inpDay;
	year=inpYear;
}


/////////////////////////////////////////////////////////////////////////////////////////////////////////
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

////////////////////////////////////////////////////////////////////////////////////////////////////////
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

// Calculate the day of the week and store the corresponding string in
// theday data attribute.
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

}


//the method returns the name of the month
string Date::getNameOfMonth() const
{
	switch (month)
	{
		case 1:  return "January";  break;
		case 2:  return "February"; break;
		case 3:  return "March";	break;
		case 4:  return "April";	break;
		case 5:  return "May";		break;
		case 6:  return "June";		break;
		case 7:  return "July";		break;
		case 8:  return "August";	break;
		case 9:  return "September"; break;
		case 10: return "October";	break;					
		case 11: return "November"; break;
		case 12: return "December"; break;
	}

}



//the method returns the number of days in month
int Date::getNumberOfDaysInMonth() const
{
	switch(month)
	{
		case 1:  return 31; break;
		case 2:  if (leapyear(year)){return 29; break;}
				 else {return 28; break;}
		case 3:  return 31;	break;
		case 4:  return 30;	break;
		case 5:  return 31;	break;
		case 6:  return 30;	break;
		case 7:  return 31;	break;
		case 8:  return 31;	break;
		case 9:  return 30; break;
		case 10: return 31;	break;					
		case 11: return 30; break;
		case 12: return 31; break;
	
	
	}


}

//determine the number of days in the month
//it is necessary to overload operator+ and operator-
int getNumOfDaysInMonth(int inpYear,int inpMonth){
	
	
	switch(inpMonth){
	case 1: return 31; break;
	case 2: 
		if (leapyear(inpYear)){
		return 29; break;}
		else{return 28; break;}
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



//the method prints the date in the definite format according to enum variable  

void Date::print(DateFormat outDFormat) const
{
	
	switch (outDFormat)
		{
			case TEXT : cout<<this->getNameOfMonth()<<" "<<day<<", "<<year; break; 
			case NUMERIC : cout<<month<<"/"<<day<<"/"<<year ; break;
			case FULLTEXT : cout<<this->getDayOfWeek()<<", "<<this->getNameOfMonth()<<" "<<day<<", "<<year; break;	
			case FULLNUMERIC : cout<<this->getDayOfWeek()<<", "<<month<<" "<<day<<", "<<year; break;	
		}
}


void Date::print(ostream& ofs, DateFormat outDFormat) const
{

 switch (outDFormat)
   {
			case TEXT : ofs<<this->getNameOfMonth()<<" "<<day<<", "<<year; break; 
			case NUMERIC : ofs<<month<<"/"<<day<<"/"<<year ; break;
			case FULLTEXT : ofs<<this->getDayOfWeek()<<", "<<this->getNameOfMonth()<<" "<<day<<", "<<year; break;	
			case FULLNUMERIC : ofs<<this->getDayOfWeek()<<", "<<month<<" "<<day<<", "<<year; break;	
	}

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

istream& operator >> (istream& inpStr, Date& argDate)
{
	int tmpMonth;
	int tmpDay;
	int tmpYear;
	char ch;

	inpStr>>tmpMonth;
	inpStr.get(ch);
	inpStr>>tmpDay;
	inpStr.get(ch);
	inpStr>>tmpYear;
	inpStr.get(ch);  //keep the input pointer where it is following 
					 //reading of the year for greatest flexibility

	argDate.setMonth(tmpMonth);
	argDate.setDay(tmpDay);
	argDate.setYear(tmpYear);
	
	return inpStr;
}

ostream& operator << (ostream& outStr, const Date& argDate)
{
	outStr<<argDate.getMonth()<<"/"<<argDate.getDay()<<"/"<<argDate.getYear();
	return outStr;
}


/////////////////////////////BONUS work/////////////////////////////////////////

//post increment
Date Date::operator++(int)
{
	Date temp=*this;
	month++;
	if (month>12){
	cout<<"The quantity of months is more than 12. Now month will be set to January."<<endl;
	month=1;
	}
	
	day++;
	if (day>this->getNumberOfDaysInMonth()){
	cout<<"The quantity of "<<day<<" days is more then in "<<this->getMonth()<<" month. Now the day will be set to 1."<<endl;
	day=1;
	}
		
	year++;
	return temp;
}

//pre increment
Date Date::operator++()
{
	++month;  
	if (month>12){
	cout<<"The quantity of months is more than 12. Now month will be set to January."<<endl;
	month=1;
	}
	
	++day;
	if (day>this->getNumberOfDaysInMonth()){
	cout<<"The quantity of "<<day<<" days is more then in "<<this->getMonth()<<" month. Now the day will be set to 1."<<endl;
	day=1;
	}
	
	++year;
	return *this;
}

//post decrement
Date Date::operator--(int)
{
	Date temp=*this;
	month--;
	if (month<=0){
		cout<<"The quantity of months <= 0. Now month will be set to January."<<endl;
		month=1;
	}
	
	
	day--;
	if (day<=0){
		cout<<"The quantity of days <= 0. Now the day will be set to 1."<<endl;
		day=1;
	}
	
	year--;
	if (year<=0){
		cout<<"The year is <= 0. Now the year will be set to 2007."<<endl;
		year=2007;
	}
	
	return temp;
}

//pre decrement
Date Date::operator--()
{
	--month;  
	if (month<=0){
		cout<<"The quantity of months <= 0. Now month will be set to January."<<endl;
		month=1;
	}

	--day;
	if (day<=0){
		cout<<"The quantity of days <= 0. Now the day will be set to 1."<<endl;
		day=1;
	}

	--year;
	if (year<=0){
		cout<<"The year is <= 0. Now the year will be set to 2007."<<endl;
		year=2007;
	}
	
	return *this;
}




// method: operator-  subtracts the number of days represented by
//            argument from the Date object and returns a new DatDate Date::operator-(int numDays) const
Date Date::operator-(int numDays) const
{
	Date tmpDate;

	int numYears, i, numMonths;
	int tmpNumDays=numDays;
	int tmpMonth, tmpDay, tmpYear;

	int tmpNum; //variable is necessary for determine leapyear 
	tmpYear=this->getYear();
	if ((numDays>365 && leapyear(tmpYear)==0) || (numDays>366 && leapyear(tmpYear)==1)){
		
		do {
			if(leapyear(tmpYear)){
				tmpNumDays=tmpNumDays-366;
				tmpNum=366;}
			else{	tmpNumDays=tmpNumDays-365;
				tmpNum=365;}
			
			tmpYear=tmpYear-1;
		
		}
		while(tmpNumDays>tmpNum);
	}


	tmpMonth=this->getMonth();
	tmpDay=this->getDay();
	

	int tmpCountMonth;  //variable is necessary to count quantity of months
	if(tmpNumDays<getNumOfDaysInMonth(tmpYear,tmpMonth)){
	
		if(tmpDay-tmpNumDays>0){
			tmpDay=tmpDay-tmpNumDays;}
		else{	tmpDay=tmpDay+getNumOfDaysInMonth(tmpYear,tmpMonth)-tmpNumDays;
				
		if(tmpMonth-1<=0){
			tmpYear=tmpYear-1;
			tmpMonth=12;}
		else{tmpMonth=tmpMonth-1;}

		}

	}
	else if(tmpNumDays>getNumOfDaysInMonth(tmpYear,tmpMonth)){
		
		
		do{			
			tmpNumDays=tmpNumDays-getNumOfDaysInMonth(tmpYear,tmpMonth);
			
			if(tmpMonth-1<=0){
				tmpYear=tmpYear-1;
				tmpMonth=12;}
			else{tmpMonth=tmpMonth-1;}

		}while(tmpNumDays>getNumOfDaysInMonth(tmpYear,tmpMonth));
		

		
		if(tmpDay-tmpNumDays>0){
			tmpDay=tmpDay-tmpNumDays;}
		else{	tmpDay=tmpDay+getNumOfDaysInMonth(tmpYear,tmpMonth)-tmpNumDays;
			if(tmpMonth-1<=0){
				tmpYear=tmpYear-1;
				tmpMonth=12;}
			else{tmpMonth=tmpMonth-1;}
		}
	}
	else{
		
		if(tmpMonth-1<=0){
			tmpYear=tmpYear-1;
			tmpMonth=12;}
		else{tmpMonth=tmpMonth-1;}
		tmpDay=getNumOfDaysInMonth(tmpYear,tmpMonth);
	}
	tmpDate.setDate(tmpMonth,tmpDay,tmpYear);
	
	return tmpDate;

}

// method: operator+  adds the number of days represented by
//            argument to the Date object and returns a new Date
Date Date::operator+(int numDays) const
{
	
	Date tmpDate;
	int tmpMonth, tmpDay, tmpYear, tmpNum;
	
	tmpMonth=this->getMonth();
	tmpDay=this->getDay();
	tmpYear=this->getYear();

	if((numDays>366 && leapyear(tmpYear)==1) || (numDays>365 && leapyear(tmpYear)==0)){
		do{
		
			if(leapyear(tmpYear)){
			tmpNum=366;			
			numDays=numDays-366;
			tmpYear=tmpYear+1;}
			else{
			tmpNum=365;
			numDays=numDays-365;
			tmpYear=tmpYear+1;}
			
			}while(numDays>tmpNum);

	};



	if(numDays>getNumOfDaysInMonth(tmpYear,tmpMonth)){
	
		do{
			

			if (tmpMonth+1>=13){
				tmpYear=tmpYear+1;
				tmpMonth=1;}
			else{ tmpMonth=tmpMonth+1;}
			
			numDays=numDays-getNumOfDaysInMonth(tmpYear,tmpMonth);
		}while(numDays>getNumOfDaysInMonth(tmpYear,tmpMonth));
	}
	

	
	if((tmpDay+numDays)>getNumOfDaysInMonth(tmpYear,tmpMonth)){
			
		if (tmpMonth+1>=13){
			tmpYear=tmpYear+1;
			tmpMonth=1;}
		else{ tmpMonth=tmpMonth+1;}
		
		tmpDay=tmpDay+numDays-getNumOfDaysInMonth(tmpYear,tmpMonth);
		}
	else{
		tmpDay=tmpDay+numDays;
	
	}

	tmpDate.setDate(tmpMonth,tmpDay,tmpYear);

	return tmpDate;
}

//////////////////////////////////////////////////////////////////////////////////////////////




