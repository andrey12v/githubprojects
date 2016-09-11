#include<iostream>
#include <time.h>
#include <string>
#include <math.h>
#include "date.h"
using namespace std;


string Date::DayOfWeek(int DayDiffer){

Date DateNow;
DateNow.now();
double NumOfWeeks;
modf(DayDiffer/7, &NumOfWeeks);
int NumOfDaysToFind; //the number of days which is necessary to find the day of week 
NumOfDaysToFind=DayDiffer-static_cast<int>(NumOfWeeks)*7;

int NumOfBDayInWeek; //number of days in birthday week 


if(DateNow.week>NumOfDaysToFind){
NumOfBDayInWeek=DateNow.week-NumOfDaysToFind;
}
else if(DateNow.week<NumOfDaysToFind){
NumOfBDayInWeek=(7+DateNow.week)-NumOfDaysToFind;
}

string NameOfBDayinWeek;  //name of day in birthday week 

switch (NumOfBDayInWeek) {
  case 1:
  NameOfBDayinWeek="Sun";
  break;
  case 2:
  NameOfBDayinWeek="Mon";
  break;
  case 3:
  NameOfBDayinWeek="Tue";
  break;
  case 4:
  NameOfBDayinWeek="Wed";
  break;
  case 5:
  NameOfBDayinWeek="Thu";
  break;
  case 6:
  NameOfBDayinWeek="Fri";
  break;
  case 7:
  NameOfBDayinWeek="Sat";
  break;
  }

return NameOfBDayinWeek;
}

int Date::daysUntil() const
{
	int NumOfMonths; //the number of months between current date and the next birthday
	int NumberOfDaysInMonths=0; //the number of days between current month to the next birthday
//	int NowMonth; //the month offers to begin count of months
	int TotalNumOfDays; //total number of days between current date and the next birthday

	Date DateNow;
	DateNow.now();

if ((DateNow.month==month) && (DateNow.day==day)){
	cout<<"HAPPY BIRTHDAY! \n";
	return 0;
}
if(DateNow.month==month && DateNow.day>day){
	return 365-(DateNow.day-day);
}
if(DateNow.month==month && DateNow.day<day){
	return (day-DateNow.day);
}


//count the number of days between the month of birthday and the current month 	
int k=0;
if(DateNow.month>month){
	for(int i=month; i<=DateNow.month; i++)
	{
		if ((month+k)==1||(month+k)==3||(month+k)==5||(month+k)==7||(month+k)==8||(month+k)==10||(month+k)==12){
			NumberOfDaysInMonths=NumberOfDaysInMonths+31;
		}
		else if ((month+k)==9||(month+k)==4||(month+k)==6||(month+k)==11){
			NumberOfDaysInMonths=NumberOfDaysInMonths+30;
		}
    		else{
			NumberOfDaysInMonths=NumberOfDaysInMonths+28;
		}	
	k++;
	}														
}
k=0;
if(DateNow.month<month){
	for(int i=DateNow.month; i<=month; i++)
	{
		if ((DateNow.month+k)==1||(DateNow.month+k)==3||(DateNow.month+k)==5||(DateNow.month+k)==7||
		(DateNow.month+k)==8||(DateNow.month+k)==10||(DateNow.month+k)==12){
			NumberOfDaysInMonths=NumberOfDaysInMonths+31;
		}
		else if ((DateNow.month+k)==9||(DateNow.month+k)==4||(DateNow.month+k)==6||(DateNow.month+k)==11){
			NumberOfDaysInMonths=NumberOfDaysInMonths+30;
		}
    		else{
			NumberOfDaysInMonths=NumberOfDaysInMonths+28;
		}	
	k++;
	}														
}


//count the number of days in current month	
int NumOfDaysInCurrentMonth;
	if (DateNow.month==1||DateNow.month==3||DateNow.month==5||DateNow.month==7||DateNow.month==8||DateNow.month==10||DateNow.month==12){
		NumOfDaysInCurrentMonth=31;
	}
	else if (DateNow.month==9||DateNow.month==4||DateNow.month==6||DateNow.month==11){
		NumOfDaysInCurrentMonth=30;
	}
    	else{
		NumOfDaysInCurrentMonth=28;
	}	






//count the number of days in birthday month	
int NumOfDaysInBDayMonth;
	if (month==1||month==3||month==5||month==7||month==8||month==10||month==12){
		NumOfDaysInBDayMonth=31;
	}
	else if (month==9||month==4||month==6||month==11){
		NumOfDaysInBDayMonth=30;
	}
    	else{
		NumOfDaysInBDayMonth=28;
	}		
	
int TotalNumOfDaysBDay; //count total number of days from current date to the next birthday
//Count total numbers days between birthday and current day or vise versa	

if(DateNow.month>month){
TotalNumOfDays=NumberOfDaysInMonths-day-(NumOfDaysInCurrentMonth-DateNow.day);	
TotalNumOfDaysBDay=365-TotalNumOfDays;
return TotalNumOfDaysBDay;
}
else if(DateNow.month<month){
TotalNumOfDays=NumberOfDaysInMonths-DateNow.day-(NumOfDaysInBDayMonth-day);
TotalNumOfDaysBDay=TotalNumOfDays;
return TotalNumOfDaysBDay;
}

}


int main(){
int inpMonth, inpDay, inpYear;
char ch;
char name[100];
cout<<"Enter your name: ";
cin.getline(name,100);
cout<<"Enter your birthday in the following format \'mm/dd/yyyy\' \n";
cin>>inpMonth;
cin.get(ch);
cin>>inpDay;
cin.get(ch);
cin>>inpYear;
Date d;
d.setYear(inpYear);
d.setMonth(inpMonth);
d.setDay(inpDay);

Date d2;
d2.now();
cout<<name<<", you are "<<d2.yearDifference(d)<<" years old. \n";
cout<<"There has been "<<d2.dayDifference(d)<<" days since you were born. \n";
int DayDiffer=d2.dayDifference(d);
cout<<"You were born on a "<<d2.DayOfWeek(DayDiffer)<<"day. (where "<<d2.DayOfWeek(DayDiffer)<<" day is the day of the week) \n";
cout<<"There are "<<d.daysUntil()<<" days until your next birthday. \n";

return 0;
}