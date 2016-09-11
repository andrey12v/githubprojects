// Andrey Vasilyev 
// time.cpp
// 02/03/2009
// CSIS 352
// Assignment 2
#include<iostream>
#include "time.h"

using namespace std;
namespace TimeNameSpace {

//Default Constructor to set the current date 
Time::Time()
{
	time ( &rawtime );	
	timeinfo = localtime ( &rawtime );
	hour=timeinfo->tm_hour;
	minute=timeinfo->tm_min;
	second=timeinfo->tm_sec;
}

// Parameter list constructor with one parameter 
Time::Time(int inpHour)
{
	if (inpHour<=0)
	{
		throw TimeException("Hours must be more than zero");
	}
	else if(inpHour>24)
	{
		throw TimeException("Hours must not be more than 24");
	}

	else
	{ 
		hour=inpHour;
		minute=0;
		second=0;
	}
}

// Parameter list constructor with two parameters 
Time::Time(int inpHour, int inpMinute)
{
	if ((inpHour<=0) || (inpHour>24))
	{
		throw TimeException("Hours entered must be more than 0 and less than or equal to 24");
	}
	else if ((inpMinute<0) || (inpMinute>59))
	{ 
		throw TimeException("Minutes entered must not be negative and more than 59");
	}
	else{
		hour=inpHour;
		minute=inpMinute;
		second=0;
	}
}

// Parameter list constructor with three parameters 
Time::Time(int inpHour, int inpMinute, int inpSecond)
{
	this->setTime(inpHour, inpMinute, inpSecond);
}

// the static variable to store the output format for objects of the class Time
// the CIVILIAN format was assigned to static variable by default 
TimeFormat Time::TimePrintFormat=CIVILIAN;

//method to set the time: hour, minute, second 
//if the date is invalid the exception will catch the error
void Time::setTime(int inpHour,int inpMinute,int inpSecond)
{
	if ((inpHour<=0) || (inpHour>24))
	{
		throw TimeException("Hours entered must be more than 0 and less than or equl to 24");
	}
	else if ((inpMinute<0) || (inpMinute>59))
	{ 
		throw TimeException("Minutes entered must not be negative and more than 59");
	}
	else if((inpSecond<0) || (inpSecond>59))
	{
		throw TimeException("Seconds entered must not be negative and more than 59");
	}
	else
	{
		hour=inpHour;
		minute=inpMinute;
		second=inpSecond;
	}
}


int Time::getHour() const 
{
	return hour;
}

//method to set the hour
// if the hour is invalid the exception will catch the error
void Time::setHour(int inpHour)
{
	if ((inpHour<=0) || (inpHour>24))
	{
		throw TimeException("Hours entered must be more than 0 and less than or equal to 24");
	}
	else
	{
		hour=inpHour;
	}
}

int Time::getMinute() const
{
	return minute;
}

//method to set the minute
// if the minute is invalid the exception will catch the error
void Time::setMinute(int inpMinute)
{
	if ((inpMinute<0) || (inpMinute>59))
	{ 
		throw TimeException("Minutes entered must not be negative and more than 59");
	}
	else 
	{
		minute=inpMinute;
	}
}

int Time::getSecond() const
{
	return second;
}

//method to set the second
// if the second is invalid the exception will catch the error
void Time::setSecond(int inpSecond)
{
	if ((inpSecond<0) || (inpSecond>59))
	{ 
		throw TimeException("Seconds entered must not be negative and more than 59");
	}
	else 
	{
		second=inpSecond;
	}
}

//method to set time arguments to current time
void Time::now()
{
	time ( &rawtime );	
	timeinfo = localtime ( &rawtime );
	hour=timeinfo->tm_hour;
	minute=timeinfo->tm_min;
	second=timeinfo->tm_sec;
}

//method to output time according to set format
void Time::outputFormat(TimeFormat outTFormat)
{
	switch (outTFormat)
	{
			case CIVILIAN : Time::TimePrintFormat=CIVILIAN; break; 
			case MILITARY : Time::TimePrintFormat=MILITARY; break;
			case DETAILED : Time::TimePrintFormat=DETAILED; break;	
	}
}

//method to overload operator output
ostream& operator<<(ostream& ofs, const Time& timeObj)
{

	switch (Time::TimePrintFormat)
	{
		case CIVILIAN : 
			if ((timeObj.getHour()>0) && (timeObj.getHour()<=11))
			{
				ofs<<timeObj.getHour()<<":"<<timeObj.getMinute()<<"AM"; break;	
			}
			else if ((timeObj.getHour()==0) || (timeObj.getHour()==24))
			{
				ofs<<"12"<<":"<<timeObj.getMinute()<<"AM"; break;
			}
			else if ((timeObj.getHour()>12) && (timeObj.getHour()<=23))
			{
				ofs<<timeObj.getHour()-12<<":"<<timeObj.getMinute()<<"PM"; break;	
			}
			else if(timeObj.getHour()==12)
			{
				ofs<<timeObj.getHour()<<":"<<timeObj.getMinute()<<"PM"; break;
			}
		case MILITARY : 
			if ((timeObj.getHour()==0) || (timeObj.getHour()==24))
			{
				ofs<<"24"<<":"<<timeObj.getMinute(); break;
			}
			else
			{
				ofs<<timeObj.getHour()<<":"<<timeObj.getMinute(); break;
			}
		case DETAILED : 
			if ((timeObj.getHour()==0) || (timeObj.getHour()==24))
			{
				ofs<<"24"<<":"<<timeObj.getMinute()<<":"<<timeObj.getSecond(); break;	
			}
			else
			{
				ofs<<timeObj.getHour()<<":"<<timeObj.getMinute()<<":"<<timeObj.getSecond(); break;
			}
	}
	
	return ofs;
}


bool Time::operator==(const Time& argTime) const
 {
	return (minute==argTime.minute && second==argTime.second 
			 && hour==argTime.hour);
 }


bool Time::operator<(const Time& argTime) const
{
	return (hour<argTime.hour || 
		(hour==argTime.hour && minute<argTime.minute) ||
		(hour==argTime.hour && minute==argTime.minute && second<argTime.second));
}


bool Time::operator!=(const Time& argTime) const
{
	return (!this->operator ==(argTime));
}


bool Time::operator<=(const Time& argTime) const
{
	return (this->operator<(argTime) || this->operator==(argTime));
}


bool Time::operator>(const Time& argTime) const
{
	return ((!this->operator<(argTime)) && (!this->operator==(argTime)));
}

bool Time::operator>=(const Time& argTime) const
{
	return (this->operator>(argTime) || this->operator==(argTime));
}

}
