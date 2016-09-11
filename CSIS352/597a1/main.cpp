#include<iostream>
#include <fstream>
#include <iomanip>
#include "date.h"

using namespace std;

int main(){

cout<<"Hello a user! We will test different methods of the class \"Date\""<<endl;
cout<<endl;
Date d1;
d1.now();
cout<<"Test of the method now()  "<<d1<<endl; 
d1.setDate(12, 11, 2004);
Date d2(05, 10, 2009);
cout<<"Test of the method dayDifference() between 05/10/2009 and 12/11/2004 = "<<d2.dayDifference(d1)<<endl;
d2.setDate(07, 8, 2009);
d1.setDate(07, 30, 2009);
cout<<"Test of the method dayDifference() between 07/08/2009 and 07/30/2009 = "<<d2.dayDifference(d1)<<endl;
d2.setDate(12, 31, 2008);
d1.setDate(11, 30, 2009);
cout<<"Test of the method dayDifference() between 12/31/2008 and 11/30/2009 = "<<d2.dayDifference(d1)<<endl;
d2.setDate(10, 15, 2009);
d1.setDate(10, 15, 2009);
cout<<"Test of the method dayDifference() between 10/15/2009 and 10/15/2009 = "<<d2.dayDifference(d1)<<endl;
d2.setDate(10, 31, 2008);
d1.setDate(11, 1, 2008);
cout<<"Test of the method dayDifference() between 10/31/2008 and 11/1/2009 = "<<d2.dayDifference(d1)<<endl;
d2.setDate(10, 20, 2009);
d1.setDate(02, 05, 2009);
cout<<"Test of the method dayDifference() between 10/20/2009 and 02/05/2009 = "<<d2.dayDifference(d1)<<endl;
d2.setDate(01, 05, 2010);
d1.setDate(02, 05, 2009);
cout<<"Test of the method dayDifference() between 01/05/2010 and 02/05/2009 = "<<d2.dayDifference(d1)<<endl;

cout<<endl;
d2.setDate(10, 20, 2001);
d1.setDate(11, 05, 2111);
cout<<"Test of the method yearDifference() between 10/20/2001 and 11/05/2111 = "<<d2.yearDifference(d1)<<endl; 
cout<<endl;
cout<<"Test of the method daysUntil() where date argument = 10/20/2001 = "<<d2.daysUntil()<<endl;
cout<<"Test of the method daysUntil() where date argument = 11/05/2111 = "<<d1.daysUntil()<<endl;
d1.setDate(01, 05, 2008);
cout<<"Test of the method daysUntil() where date argument = 01/05/2008 = "<<d1.daysUntil()<<endl;
cout<<"Here we get the same number of days because the year attribute is not considered";
d1.setDate(01, 05, 2111);
cout<<"Test of the method daysUntil() where date argument = 01/05/2111 = "<<d1.daysUntil()<<endl;
cout<<endl;

d1.setDate(01, 05, 2008);
d2.setDate(01, 05, 2008);
cout<<"Test of the operator == between dates 01, 05, 2008 and 01.05.2008"<<endl;
if (d1==d2)
{ cout<<"dates are equl!"<<endl; }
else { cout<<"dates are not equal"<<endl; }

cout<<"Test of the operator == between dates 01, 05, 2008 and 02.05.2008"<<endl;
d1.setDate(01, 05, 2008);
d2.setDate(02, 05, 2008);
if (d1==d2)
{ cout<<"dates are equl!"<<endl; }
else { cout<<"dates are not equal"<<endl; }

cout<<"Test of the operator < ";
if (d1<d2)
{ cout<<"date 01/05/2008 is less then 02/05/2008"<<endl; }
else { cout<<"date 01/05/2008 is not less then 02/05/2008"<<endl; }
cout<<"Test of the operator > ";
if (d1>d2)
{ cout<<"date 01/05/2008 is more then 02/05/2008"<<endl; }
else { cout<<"date 01/05/2008 is not more then 02/05/2008"<<endl; }
cout<<"Test of operator != ";
if (d1!=d2)
{ cout<<"RIGHT date 01/05/2008 is not equal to 02/05/2008"<<endl; }
else { cout<<"date 01/05/2008 is equal to 02/05/2008"<<endl; }
cout<<endl;

cout<<"Test of operator++(int) post increment for date 01/05/2008 = "<<d1++<<endl;
cout<<"NOW the date increased to one day because of post increment = "<<d1<<endl;
cout<<"Test of operator++() pre increment for date 01/05/2008 = "<<++d1<<endl;
cout<<"Test of operator--() pre decrement for date 01/05/2008 = "<<--d1<<endl;
cout<<"Test of operator--(int) post decrement for date 01/05/2008 = "<<d1--<<endl;
cout<<"NOW the date decreased to one day because of post decrement = "<<d1<<endl;
cout<<endl;
d1.now();
cout<<"Test of operator- \"current date - 567\" = "<<d1-567<<endl;
d1.now();
cout<<"Test of operator- \"current date - 156\" = "<<d1-156<<endl;
d1.now();
cout<<"Test of operator+ \"current date + 387\" = "<<d1+387<<endl;
d1.now();
cout<<"Test of operator+ \"current date + 3\" = "<<d1+3<<endl;
d1.now();
cout<<"Test of operator+ \"current date + 12\" = "<<d1+12<<endl;
cout<<endl;
d1.now();
d1.outputFormat(TEXT);
cout<<"Test of the method outputFormat(TEXT) "<<d1<<endl;
d1.outputFormat(NUMERIC);
cout<<"Test of the method outputFormat(NUMERIC) "<<d1<<endl;
d1.outputFormat(FULLNUMERIC);
cout<<"Test of the method outputFormat(FULLNUMERIC) "<<d1<<endl;
d1.outputFormat(FULLTEXT);
cout<<"Test of the method outputFormat(FULLTEXT) "<<d1<<endl;


return 0;
}







