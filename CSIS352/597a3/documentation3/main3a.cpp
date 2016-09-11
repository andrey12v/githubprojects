#include <iostream>
#include "array.h"
using namespace std;
using namespace ArrayNameSpace;
const int endindex=3;
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
   Array<int> numbers(startindex,endindex);

   for (int i=startindex; i<=endindex; i++)
      numbers[i] = i;
   for (int i=startindex; i<=endindex; i++)
      cout << "numbers[" << i << "] = " << numbers[i] << endl;

   cout << "-------------\n";
   Array<int> numbers2;
   numbers2 = numbers;
   numbers2[startindex]=99;
   for (int i=startindex; i<endindex; i++)
      cout << "numbers2[" << i << "] = " << numbers2[i] << endl;

   cout << "correct 0" << " == " << (numbers==numbers2) << endl;
   cout << "correct 1" << " != " << (numbers!=numbers2) << endl;
   cout << "correct 1" << " <= " << (numbers<=numbers2) << endl;
   cout << "correct 0" << " >= " << (numbers>=numbers2) << endl;
   cout << "correct 1" << " < " << (numbers<numbers2) << endl;
   cout << "correct 0" << " > " << (numbers>numbers2) << endl;

   try
   {
      cout << numbers[5] << endl;
   }
   catch (ArrayException error)
   {
      cout << error.what() << endl;
   }

   enum DaysOfWeek {Mon, Tue, Wed, Thu, Fri, Sat, Sun};

   Array<double> days(Mon,Sun);
   days[Mon] = 1;
   days[Tue] = 2;
   days[Wed] = 3;
   days[Thu] = 4;
   days[Fri] = 5;
   days[Sat] = 6;
   days[Sun] = 7;
   cout << days[Thu] << endl;
   cout << "no - ";
   if (days[Wed] < days[Tue])
      cout << "yes" << endl;
   else
      cout << "no" << endl;
   Array<double> days2(days);
   cout << "no - ";
   if (days < days2)
      cout << "yes" << endl;
   else
      cout << "no" << endl;
   days2[Wed] = 88;
   cout << "yes - ";
   if (days < days2)
      cout << "yes" << endl;
   else
      cout << "no" << endl;
   
   for (DaysOfWeek d=Mon; d<=Sun; d=static_cast<DaysOfWeek>(d+1))
      cout << days[d] << ' ';
   cout << endl;
   return 0;

}
