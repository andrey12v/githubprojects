#include <iostream>
#include <fstream>
#include "array.h"
#include "date.h"
using namespace std;
using namespace ArrayNameSpace;
using namespace DateNameSpace;
const int endindex=16;
const int startindex=-3;

int main()
{
   Array<char> array('J','N');
   array['J'] = 'H';
   array['K'] = 'E';
   array['L'] = 'L';
   array['M'] = 'L';
   array['N'] = 'O';
   cout << array['J'] << array['K'] << array['L'] << array['M'] 
        << array['N'] << endl;
   try
   {
      array['F'] = '.';
   }
   catch (ArrayException e)
   {
      cout << e.what() << endl;
   }
   Array<Date> dates(startindex,endindex);
   Date date;
   int m,d,y;
   char temp;
   ifstream f;
   f.open("dates");
   int count=startindex;
   f >> m;
   while (!f.eof())
   {
      f >> temp >> d >> temp >> y;
      date.setDate(m,d,y);
      dates[count] = date;
      count++;
      f >> m;
   }
   f.close();

   for (int i=startindex; i<count; i++)
      cout << "dates[" << i << "] = " << dates[i] << endl;

   cout << "-------------\n";
   Array<Date> dates2;
   dates2 = dates;
   Date ddd(12,22,1994);
   dates2[startindex]=ddd;
   for (int i=startindex; i<count; i++)
      cout << "dates2[" << i << "] = " << dates2[i] << endl;

   cout << "correct 0" << " == " << (dates==dates2) << endl;
   cout << "correct 1" << " != " << (dates!=dates2) << endl;
   cout << "correct 1" << " <= " << (dates<=dates2) << endl;
   cout << "correct 0" << " >= " << (dates>=dates2) << endl;
   cout << "correct 1" << " < " << (dates<dates2) << endl;
   cout << "correct 0" << " > " << (dates>dates2) << endl;

   try
   {
      cout << dates2[19] << endl;
   }
   catch (ArrayException error)
   {
      cout << error.what() << endl;
   }

   enum DaysOfWeek {Mon, Tue, Wed, Thu, Fri, Sat, Sun};

   Date d1(1,28,2008);
   Date d2(1,29,2008);
   Date d3(1,30,2008);
   Date d4(1,31,2008);
   Date d5(2,1,2008);
   Date d6(2,2,2008);
   Date d7(2,3,2008);
   Array<Date> days(Mon,Sun);
   days[Mon] = d1;
   days[Tue] = d2;
   days[Wed] = d3;
   days[Thu] = d4;
   days[Fri] = d5;
   days[Sat] = d6;
   days[Sun] = d7;
   cout << days[Thu].getMonth() << '/'
        << days[Thu].getDay() << '/'
        << days[Thu].getYear() << endl;
   cout << days[Thu] << endl;
   cout << "no - ";
   if (days[Wed] < days[Tue])
      cout << "yes" << endl;
   else
      cout << "no" << endl;
   Array<Date> days2(days);
   cout << "no - ";
   if (days < days2)
      cout << "yes" << endl;
   else
      cout << "no" << endl;
   days2[Wed] = d4;
   cout << "yes - ";
   if (days < days2)
      cout << "yes" << endl;
   else
      cout << "no" << endl;
   
   for (DaysOfWeek d=Mon; d<=Sun; d=static_cast<DaysOfWeek>(d+1))
      cout << days[d] << endl;
   return 0;

}
