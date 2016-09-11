#include<iostream>
#include <time.h>
#include <string>
#include <math.h>
#include "date.h"
using namespace std;

void Date::setYear(int inpYear){
year=inpYear;
}


void Date::setMonth(int inpMonth){
	month=inpMonth;
	if(inpMonth>12){
	cout<<"Incorrect the number of month. It should not be more than 12. \n";
	month=1;
	}
}


void Date::setDay(int inpDay)
{
	if (inpDay>NumOfDaysInMonth(month)){
	cout<<"Incorrect the number of days in "<<month<<" month. It should be less than "<<NumOfDaysInMonth(month)<<" days. \n";
	day=1;
	}
	else{
	day=inpDay;
	}
}


int Date::getMonth() const
{ return month;
}


int Date::getDay() const
{ return day;
}


int Date::getYear() const
{
return year;
}


void Date::now(){
time ( &lt );
ptr = localtime ( &lt );
month=ptr->tm_mon+1;
day=ptr->tm_mday;
year=1900+ptr->tm_year;
week=ptr->tm_wday+1;
}


int Date::dayDifference(const Date& d) const
{

//////////////Count the number of days between current year and the year of birthday
int NumOfYears;
NumOfYears=year-d.year;

//Find the number of leap years between current year and birthday
int NumOfLeapYears=0;
for(int i=0; i<=NumOfYears; i++){
	if (leapyear(year-i)){
	NumOfLeapYears=NumOfLeapYears+1;
	}
}
int NumberOfDaysBYears; //number of days betweeen current year and birthday year
NumberOfDaysBYears=(NumOfYears-NumOfLeapYears)*365+(NumOfLeapYears*366);	
	

///////////////Count the number of days between current month and the month of birthday
//Count the number of months between current month and the month of birthday
int NumOfMonths=0;
int NumOfDaysBMonths=0; //number of days between current month and the month of birthday	


if (month>d.month){
NumOfMonths=month-d.month;

	for(int j=0; j<=NumOfMonths; j++){
		if ((month-j)==1||(month-j)==3||(month-j)==5||(month-j)==7||(month-j)==8||(month-j)==10||(month-j)==12){
			NumOfDaysBMonths=NumOfDaysBMonths+31;
		}
		else if ((month-j)==9||(month-j)==4||(month-j)==6||(month-j)==11){
			NumOfDaysBMonths=NumOfDaysBMonths+30;
		}
    		else if(leapyear(year)){
			NumOfDaysBMonths=NumOfDaysBMonths+29;
		} 
		else{
			NumOfDaysBMonths=NumOfDaysBMonths+28;
		}	
	}
}

if(month<d.month){
NumOfMonths=d.month-month;

	for(int l=1; l<NumOfMonths; l++){

		if ((month+l)==1||(month+l)==3||(month+l)==5||(month+l)==7||(month+l)==8||(month+l)==10||(month+l)==12){
			NumOfDaysBMonths=NumOfDaysBMonths+31;
		}
		else if ((month+l)==9||(month+l)==4||(month+l)==6||(month+l)==11){
			NumOfDaysBMonths=NumOfDaysBMonths+30;
		}
    		else if(leapyear(year)){
			NumOfDaysBMonths=NumOfDaysBMonths+29;
		} 
		else{
			NumOfDaysBMonths=NumOfDaysBMonths+28;
		}	
	}
}


int NumOfDaysInMonthBDay; //variable which is necessary to count number of days in the month of birthday

	if (d.month==1 || d.month==3 || d.month==5 || d.month==7 || d.month==8 || d.month==10 || d.month==12){
		NumOfDaysInMonthBDay=31;
	}
	else if (d.month==9 || d.month==4 || d.month==6 || d.month==11){
		NumOfDaysInMonthBDay=30;
	}
    	else if(leapyear(year)){
		NumOfDaysInMonthBDay=29;
	} 
	else{
		NumOfDaysInMonthBDay=28;
	}	

//Count the number of days in the month of current date
int NumOfDaysInMonthCDay; //variable which is necessary to count number of days in the month of current day
	if (month==1 || month==3 || month==5 || month==7 || month==8 || month==10 || month==12){
		NumOfDaysInMonthCDay=31;
	}
	else if (month==9 || month==4 || month==6 || month==11){
		NumOfDaysInMonthCDay=30;
	}
    	else if(leapyear(year)){
		NumOfDaysInMonthCDay=29;
	} 
	else{
		NumOfDaysInMonthCDay=28;
	}	

//Count the total number of days fron the birthday till the current date
int TotalNumOfDays; 

	if (month>d.month){
		TotalNumOfDays=NumberOfDaysBYears+((NumOfDaysBMonths-(NumOfDaysInMonthCDay-day))-d.day); 
	}
	else if (month<d.month){
		TotalNumOfDays=(NumberOfDaysBYears-NumOfDaysBMonths)-(NumOfDaysInMonthCDay-day)-d.day;
	}
	
	
	return TotalNumOfDays;


}


int Date::yearDifference(const Date& d) const
{
	return (year-d.year);
}


int Date::NumOfDaysInMonth(int inpMonth){
	
	if (inpMonth==1||inpMonth==3||inpMonth==5||inpMonth==7||inpMonth==8||inpMonth==10||inpMonth==12){
		return 31;
	}
	else if (inpMonth==9||inpMonth==4||inpMonth==6||inpMonth==11){
		return 30;
	}
    	else if(leapyear(year)){
		return 29;
	} 
	else{
		return 28;
	}	

}


bool Date::leapyear(int inpYear) const
{
	if((inpYear%4==0)){
	return true;
	}	
	else{
	return false;
	}
}

