// Andrey Vasilyev 
// main.cpp
// 02/03/2009
// CSIS 352
// Assignment 2
#include <iostream>
#include <string>
#include "date.h"
#include "time.h"

using namespace std;
using namespace DateNameSpace;	//include namespace of the class Date
using namespace TimeNameSpace;  // include namespace of the class Time

int main()
{
    Date d1; 
     try
     {	
        //test of the output format for class Date
	    Date d1(1,1,2000);
		cout << "1/1/2000                      " << d1 << endl;
		Date::outputFormat(TEXT);
		cout << "January 1, 2000               " << d1 << endl;
		Date::outputFormat(FULLTEXT);
		cout << "Saturday, January 1, 2000     " << d1 << endl;
		Date::outputFormat(FULLNUMERIC);
		cout << "Saturday, 1/1/2000            " << d1 << endl;
		Date::outputFormat(NUMERIC);
		cout << "1/1/2000                      " << d1 << endl;
		Date d2(1,1,2000);
		Date d3(1,2,2000);
		Date d4(1,1,2009);
		Date d5;
		d5.now();
		//Tetst of overloaded operators comparisons
		cout << "today is: " << d5 << endl;
		if (d1 < d3 && d1 < d4 && d2 < d3 && d3 < d4 && !(d1 < d2) )
			cout << " < operator is correct\n";
		else
			cout << " < operator is **** NOT **** correct\n";
		if (d1 <= d3 && d1 <= d4 && d2 <= d3 && d3 <= d4 && d1 <= d2 )
			cout << "<= operator is correct\n";
		else
			cout << "<= operator is **** NOT **** correct\n";
		if (!(d1 > d3 && d1 > d4 && d2 > d3 && d3 > d4 && !(d1 > d2)) )
			cout << " > operator is correct\n";
		else
			cout << " > operator is **** NOT **** correct\n";
		if (!(d1 >= d3 && d1 >= d4 && d2 >= d3 && d3 >= d4 && d1 >= d2) )
			cout << ">= operator is correct\n";
		else
			cout << ">= operator is **** NOT **** correct\n";
		if (d1 == d2 && !(d1 == d3) && !(d1 == d4) && !(d3 == d4) && !(d2==d3) )
			cout << "== operator is correct\n";
		else
			cout << "== operator is **** NOT **** correct\n";
		if (!(d1 != d2) && d1 != d3 && d1 != d4 && d3 != d4 && d2!=d3 )
			cout << "!= operator is correct\n";
		else
			cout << "!= operator is **** NOT **** correct\n";
		
		//Test of overloaded operators post / pre increment / decrement
		Date d6(2,28,2008);
		Date d7;
		d7 = d6++;
		d6++;
		Date d8(4,30,2008);
		d8++;
		if (d6.getMonth() == 3 && d6.getDay() == 1 &&
			d7.getMonth() == 2 && d7.getDay() == 28 &&
			d8.getMonth() == 5 && d8.getDay() == 1)
			cout << "post ++ is correct\n";
		else
			cout << "post ++ is **** NOT **** correct\n";
		Date d9(12,31,2009);
		d7 = ++d9;
		if (d7.getMonth() == 1 && d7.getDay() == 1 && d7.getYear() == 2010 &&
			d9.getMonth() == 1 && d9.getDay() == 1 && d9.getYear() == 2010)
			cout << "pre ++ is correct\n";
		else
			cout << "pre ++ is **** NOT **** correct\n";
			d7 = d1--;
			if (d7.getMonth() == 1 && d7.getDay() == 1 && d7.getYear() == 2000 &&
			d1.getMonth() == 12 && d1.getDay() == 31 && d1.getYear() == 1999)
			cout << "post -- is correct\n";
		else
			cout << "post -- is **** NOT **** correct\n";
			d7 = --d2;
		if (d7.getMonth() == 12 && d7.getDay() == 31 && d7.getYear() == 1999 &&
			d1.getMonth() == 12 && d1.getDay() == 31 && d1.getYear() == 1999)
			cout << "pre -- is correct\n";
		else
			cout << "pre -- is **** NOT **** correct\n";
			d1.setDate(1,1,2010);

		if (d1.getDay() == 1 && d1.getMonth() == 1 && d1.getYear() == 2010)
			cout << "set attributes are correct\n";
		else
			cout << "set attributes are **** NOT **** correct\n";
   
		Date d10(1,1,2011);
		Date d11(1,1,2014);
		if (d10.dayDifference(d1) == -365 && d1.dayDifference(d10) == 365 &&
		d11.dayDifference(d1) == -1461 && d1.dayDifference(d11) == 1461)
			cout << "dayDifference is correct\n";
		else
			cout << "dayDifference is **** NOT **** correct\n";
   
		cout << "d2 = " << d2 << endl;
		cout << "d10 = " << d10 << endl;
		if (d10.yearDifference(d1) == -1 && d1.yearDifference(d10) == 1 &&
			d11.yearDifference(d1) == -4 && d1.yearDifference(d11) == 4 &&
			d2.yearDifference(d10) == 11)
			cout << "yearDifference is correct\n";
		else
			cout << "yearDifference is **** NOT **** correct\n";
      
		d10 = d1 + 365;
		d11 = d1 + 1461;
		if (d10.getMonth() == 1 && d10.getDay() == 1 && d10.getYear() == 2011 &&
			d11.getMonth() == 1 && d11.getDay() == 1 && d11.getYear() == 2014)
			cout << "operator + is correct\n";
		else
			cout << "operator + is **** NOT **** correct\n";
		d10 = d1 - 365;
		d11 = d1 - 1461;
		if (d10.getMonth() == 1 && d10.getDay() == 1 && d10.getYear() == 2009 &&
			d11.getMonth() == 1 && d11.getDay() == 1 && d11.getYear() == 2006)
			cout << "operator - (subtracting int) is correct\n";
		else
			cout << "operator - (subtracting int) is **** NOT **** correct\n";
   
		Date d12;
		d12.now();
		Date d13(12,31,2007);
		Date d14(12,31,2009);
		cout << "daysUntil Dec. 31: " << d13.daysUntil() << ' '
        << d14-d12 << endl;
		if (d13.daysUntil() == d14-d12)
			cout << "daysUntil is correct\n";
		else
			cout << "daysUntil is **** NOT **** correct\n";
   
   
		if (d14-d13 == d13-d14 && d14-d13 == 731)
			cout << "operator - (subtracting dates) is correct\n";
		else
			cout << "operator - (subtracting dates) is **** NOT **** correct\n";
		cout<<"TEST OF EXCEPTIONS"<<endl;	 
	//Test of Date Exception Class
		cout<<"Date: 0/12/2002  ";
		d13.setDate(0,12,2002);
		cout<<d13<<endl;
	 }
	 catch(DateException dateExceptionObj)
     {
		cout<<dateExceptionObj.what()<<endl;
     }
	
	 try
	 {
		cout<<"Date: 12/0/2003 : ";
		Date d1(12,0,2003);
		
	 }
	 catch(DateException dateExceptionObj)
     {
		cout<<dateExceptionObj.what()<<endl;
     }

	 try
	 {
		cout<<"Date: 12/22/-2003 : ";
		Date d1(12,22,-2003);
		
	 }
	 catch(DateException dateExceptionObj)
     {
		cout<<dateExceptionObj.what()<<endl;
     }
	
	 try
	 {
		cout<<"02/31/2008 :";
		Date d1(02,31,2008);
	 }
	 catch(DateException dateExceptionObj)
     {
		cout<<dateExceptionObj.what()<<endl;
     }


	 try
	 {
		cout<<endl;
		cout<<"TEST OF TIME"<<endl;
		cout<<"t(13)=1:00PM : ";
		Time t2(13);		// time set to 1:00PM
		cout<<t2<<endl;
		
		cout<<"t(15,30)=3:30PM : ";
		Time t3(15,30);		// time set to 3:30PM
		cout<<t3<<endl;
		
		cout<<"t(9,10,20)=9:10AM : ";
		Time t4(9,10,20);
		cout<<t4<<" or ";
		t4.outputFormat(DETAILED);
		cout<<t4<<endl;

		Time t1;
		cout<<"Test of the method outputFormat()"<<endl;
		t1.outputFormat(CIVILIAN);
		cout<<"CIVILIAN current time "<<t1<<endl;
		t1.outputFormat(MILITARY);
		cout<<"MILITARY current time "<<t1<<endl;
		t1.outputFormat(DETAILED);
		cout<<"DETAILED current time "<<t1<<endl;
		
		t1.setTime(1,1,20);
		t2.setTime(1,1,20);
		t3.setTime(1,2,20);
		t4.setTime(1,2,29);
		Time t5;
		t5.now();
		cout << "current time is: " << t5 << endl;
		cout<<endl;
		cout<<"TEST OF COMPARISON OPERATORS"<<endl;
		if (t1 < t3 && t1 < t4 && t2 < t3 && t3 < t4 && !(t1 < t2) )
			cout << " < operator is correct\n";
		else
			cout << " < operator is **** NOT **** correct\n";
		
		if (t1 <= t3 && t1 <= t4 && t2 <= t3 && t3 <= t4 && t1 <= t2 )
			cout << "<= operator is correct\n";
		else
			cout << "<= operator is **** NOT **** correct\n";
				
		if (!(t1 > t3 && t1 > t4 && t2 > t3 && t3 > t4 && !(t1 > t2)) )
			cout << " > operator is correct\n";
		else
			cout << " > operator is **** NOT **** correct\n";
		if (!(t1 >= t3 && t1 >= t4 && t2 >= t3 && t3 >= t4 && t1 >= t2) )
			cout << ">= operator is correct\n";
		else
			cout << ">= operator is **** NOT **** correct\n";
		if (t1 == t2 && !(t1 == t3) && !(t1 == t4) && !(t3 == t4) && !(t2==t3) )
			cout << "== operator is correct\n";
		else
			cout << "== operator is **** NOT **** correct\n";
		if (!(t1 != t2) && t1 != t3 && t1 != t4 && t3 != t4 && t2!=t3 )
			cout << "!= operator is correct\n";
		else
			cout << "!= operator is **** NOT **** correct\n";	 
	 	cout<<"TEST OF EXCEPTIONs"<<endl; 
		
		t1.outputFormat(CIVILIAN);
		cout<<"Time: 24:60:60 = ";
		t1.setTime(24,60,60);
		cout<<t1<<endl;
	 }
	 catch(TimeException  timeExceptionObj)
	 {
		cout<<timeExceptionObj.what()<<endl;
	 }

	 try
	 {
		cout<<"Time 24/12/23 = ";
		Time t1;
		t1.setTime(24,12,23);
		cout<<t1<<endl;
	 }
	 catch(TimeException  timeExceptionObj)
	 {
		cout<<timeExceptionObj.what()<<endl;
	 }

	 try
	 {
		cout<<"Time -11/33/23 = ";
		Time t1;
		t1.setTime(-11,33,23);
		cout<<t1<<endl;
	 }
	 catch(TimeException  timeExceptionObj)
	 {
		cout<<timeExceptionObj.what()<<endl;
	 }

	 try
	 {
		cout<<"Time 11/00/00 = ";
		Time t1;
		t1.setTime(11,00,00);
		cout<<t1<<endl;
	 }
	 catch(TimeException  timeExceptionObj)
	 {
		cout<<timeExceptionObj.what()<<endl;
	 }

	 try
	 {
		cout<<"Time 11/60/00 = ";
		Time t1;
		t1.setTime(11,60,00);
		cout<<t1<<endl;
	 }
	 catch(TimeException  timeExceptionObj)
	 {
		cout<<timeExceptionObj.what()<<endl;
	 }

	 try
	 {
		cout<<"Time 11/59/-33 = ";
		Time t1;
		t1.setTime(11,59,-33);
		cout<<t1<<endl;
	 }
	 catch(TimeException  timeExceptionObj)
	 {
		cout<<timeExceptionObj.what()<<endl;
	 }


   return 0;
}
