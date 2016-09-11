#include <iostream>
#include <fstream>
#include "array.h"
using namespace std;
using namespace ArrayNameSpace;

void func(Array<int> a)
{
   a.Resize(1000);
   for (int i=1; i<20; i++)
      a[i] = 999;
}

Array<int> func2()
{
   Array<int> x('C','F');
   for (char c='C'; c<='F'; c++)
      x[c] = static_cast<int>(c);
   return x;
}

int main()
{
   Array<int> a1(1,15);
   for (int i=1; i<10; i++)
      a1[i] = i;
   func(a1);
   func(a1);
   func(a1);
   func(a1);
   func(a1);
   func(a1);
   func(a1);
   func(a1);
   for (int i=1; i<10; i++)
      cout << a1[i] << ' ';
   cout << endl;
   Array<int> a2;
   a2 = func2();
   try
   {
      for (char c='C'; c<='F'; c++)
         cout << a2[c] << ' ';
   }
   catch (ArrayException e)
   {
      cout << e.what() << endl;
   }
   cout << endl;
   cout << a2.Size() << endl;
   return 0;
}
