//Andrey Vasilyev
//main.cpp
//02/15/2009
//Assignment 3

// *********The description of the function Main*****************
//
// The main function performs testing of the class Array
// Different methods of testing areapplied alloocation of arrays
// assign them different values, copies them as parametrs to other functions and
// objects of the same class Array
// All testing outputs on the screen with explanation
//
// ********The end of the function Main description***************

#include <iostream>
#include "array.h"  
#include "date.h"   //class Date from the header file date.h is used for testing purposes
using namespace std;  
using namespace ArrayNameSpace;
using namespace DateNameSpace;
const int endindex=16;
const int startindex=-3;

//function is used to test copy constructor
//the array is copied to the function and outputed to the screen
void testCopyConstructor(Array<char> inpArray);

//function to test copy constructor and return value of the array
Array<char> returnedArray(Array<char> inpArray);


int main()
{
   
   cout<<"***********Dr. Brekke's TESTING*************"<<endl;
   //allocates the array of character type with character indexes
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
   
   Array<Date> dates(startindex, endindex);
   Date date;
   int i;
   int count=startindex;
   date.setDate(11, 12, 2007);
   dates[count]=date;
   count++;
   date.setDate(10, 05, 2003);
   dates[count]=date;
   count++;
   date.setDate(05,05,2005);
   dates[count]=date;
   count++;
   date.setDate(07,03,2003);
   dates[count]=date;

   for (i=startindex; i<=count; i++)
      cout << "dates[" << i << "] = " << dates[i] << endl;

   cout << "-------------\n";
   
   Array<Date> dates2;
   dates2 = dates;
   cout<<dates2[startindex]<<endl;
 
   Date ddd(12,22,1994);
   dates2[startindex]=ddd;
   for (i=startindex; i<=count; i++)
   {
      cout << "dates2[" << i << "] = " << dates2[i] << endl;
   }
   /*cout << "correct 0" << " == " << (dates==dates2) << endl;
   cout << "correct 1" << " != " << (dates!=dates2) << endl;
   cout << "correct 1" << " <= " << (dates<=dates2) << endl;
   cout << "correct 0" << " >= " << (dates>=dates2) << endl;
   cout << "correct 1" << " < " << (dates<dates2) << endl;
   cout << "correct 0" << " > " << (dates>dates2) << endl;*/

   cout<<"!Test of comparison operator=="<<endl;
   cout<<"The first array is more than the second one. That's way there are the following results."<<endl;
   if(dates==dates2)
   {
	cout<<"dates and dates2 are equal; operator== is not correct"<<endl;
   }
   else
   {
	cout<<"dates and dates2 are not equal; operator== is correct"<<endl;
   }
   
   if(dates!=dates2)
   {
	cout<<"dates and dates2 are not equal; operator!= is correct"<<endl;
   }
   else
   {
	cout<<"dates and dates2 are equal; operator!= is not correct"<<endl;
   }

   if(dates<=dates2)
   {
	cout<<"dates is less than or equal to dates2; operator<= is not correct"<<endl;
   }
   else
   {
	cout<<"dates is not less than or equal to dates2; operator<= is correct"<<endl;
   }

   if(dates>=dates2)
   {
	cout<<"dates is more than or equal to dates2; operator>= is correct"<<endl;
   }
   else
   {
	cout<<"dates is not more than or equal to dates2; operator>= is not correct"<<endl;
   }

   if(dates<dates2)
   {
	cout<<"dates is less than dates2; operator< is not correct"<<endl;
   }
   else
   {
	cout<<"dates is not less than dates2; operator< is correct"<<endl;
   }

   if(dates>dates2)
   {
	cout<<"dates is more than dates2; operator> is correct"<<endl;
   }
   else
   {
	cout<<"dates is not more than dates2; operator> is not correct"<<endl;
   }

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
   
   cout<<"***********Andrey's TESTING*************"<<endl;
   cout<<"!Test of the integer Array!"<<endl;
   cout<<"!Test of the exception implemented for character indexes in constructor!"<<endl;
   try
   {
   	Array<int> arrayTest1('C', 'A');
   }
   catch(ArrayException e)
   {
	cout<<"constructor's exception: "<<e.what()<<endl;
   }
	cout<<endl;

   cout<<"!Test of the exception implemented for integer indexes in constructor!"<<endl;
   try
   {
   	Array<int> arrayTest2(-4, -10);
   }
   catch(ArrayException e)
   {
	cout<<"constructor's exception: "<<e.what()<<endl;
   }
	cout<<endl;

   try
   {
   	Array<int> arrayTest3('C', 'G');
   	cout<<"The size of declared array is "<<arrayTest3.Size()<<endl;
   	cout<<"Array with charater indexes will be the following:"<<endl;
   	for(i=static_cast<char>('C'); i<=static_cast<char>('G'); i++)
   	{
		arrayTest3[static_cast<char>(i)]=i+100;
   		cout<<"array ["<<static_cast<char>(i)<<"] = "<<arrayTest3[static_cast<char>(i)]<<endl;
   	}
	cout<<endl;
	cout<<"!Test of the operator="<<endl;   
	Array<int> arrayTest4('H', 'N');
	for(i=static_cast<char>('H'); i<=static_cast<char>('N'); i++)
   	{
		arrayTest4[static_cast<char>(i)]=i+232;
   	}
	arrayTest3=arrayTest4;
	cout<<"After operator= our array has got the following elements"<<endl;
	for(i=static_cast<char>('H'); i<=static_cast<char>('N'); i++)
   	{
		cout<<"array ["<<static_cast<char>(i)<<"] = "<<arrayTest3[static_cast<char>(i)]<<endl;
   	}
	cout<<endl;
	cout<<"!Test of the method Resize()!"<<endl;   	
	cout<<"The current size of array = "<<arrayTest3.Size()<<" and we convert it to size 3"<<endl;	
	arrayTest3.Resize(3);
	for(i=static_cast<char>('H'); i<=static_cast<char>('J'); i++)
   	{
		cout<<"array ["<<static_cast<char>(i)<<"] = "<<arrayTest3[static_cast<char>(i)]<<endl;
   	}
	cout<<"Now the array is resized back to the size 7"<<endl;
	arrayTest3.Resize(7);
	for(i=static_cast<char>('H'); i<=static_cast<char>('N'); i++)
   	{
		cout<<"array ["<<static_cast<char>(i)<<"] = "<<arrayTest3[static_cast<char>(i)]<<endl;
   	}
	cout<<endl;
    cout<<"!Test of the exception implemented for the method Resize()!"<<endl;
	cout<<"The array is resized to negative number -5"<<endl;
	arrayTest3.Resize(-5);
   }
   catch(ArrayException e)
   {
	cout<<"Exception for Resize(): "<<e.what()<<endl;
   }
   cout<<endl;
   cout<<"!Test of the exception implemented for character indexes in operator[]!"<<endl;
   try
   {
		Array<int> arrayTest5('C', 'G');
		cout<<arrayTest5['A']<<endl;
   }
   catch(ArrayException e)
   {
		cout<<e.what()<<endl;
   }
	cout<<endl;
   cout<<"!Test of the exception implemented for integer indexes in operator[]!"<<endl;
   try
   {
		Array<int> arrayTest6(3, 19);
		cout<<arrayTest6[-5]<<endl;
   }
   catch(ArrayException e)
   {
		cout<<e.what()<<endl;
   }
   cout<<endl;
   cout<<"!Test of the exception implemented for enum indexes in operator[]!"<<endl;
   try
   {
		Array<int> arrayTest7(Wed, Sun);
		cout<<arrayTest7[Mon]<<endl;
   }
   catch(ArrayException e)
   {
		cout<<e.what()<<endl;
   }
   cout<<endl;
   cout<<"!Test of the copy constructor!"<<endl;
   
   Array<char> arrayTest8(-5, 0);
   arrayTest8[-5]='C';
   arrayTest8[-4]='O';
   arrayTest8[-3]='P';
   arrayTest8[-2]='I';
   arrayTest8[-1]='E';
   arrayTest8[0]='D';
   cout<<"The array is passed as a parametr to the function"<<endl;
   testCopyConstructor(arrayTest8);
   cout<<"The array is passed as a parametr in the function and returned from it"<<endl;
   Array<char> arrayTest9(3, 10);
   arrayTest9=returnedArray(arrayTest8);
   for(i=-5; i<=2; i++)
   {
		cout<<arrayTest9[i]<<" ";
   }
   cout<<endl;

   cout<<"The array is passed to a new object of the class Array as a parametr"<<endl;
   cout<<"The first method by using braces (): ";
   Array<char> arrayTest10(arrayTest8);
   for(i=-5; i<=0; i++)
   {
		cout<<arrayTest10[i]<<" ";
   }
   cout<<endl;
	
   cout<<"The second method by using equal= : ";
   Array<char> arrayTest11=arrayTest9;
   for(i=-5; i<=2; i++)
   {
		cout<<arrayTest11[i]<<" ";
   }
   cout<<endl;




   return 0;
}

// the void function testCopyConstructor
      //    preconditions - no validity checking is performed
	  //    the object of the class array passed as a parameter must be valid
      //    postconditions
      //    outputs elements of the array
void testCopyConstructor(Array<char> inpArray)
{
	cout<<"The array is inside the function"<<endl;
	for(int i=-5; i<=0; i++)
	{
		cout<<inpArray[i]<<" ";	
	}
	cout<<endl;
}

// the function returnedArray returns the object of the class Array 
      //    preconditions - no validity checking is performed
	  //    the object of the class array passed as a parameter must be valid
      //    postconditions
      //    changes the value of the array elements and return changed array
Array<char> returnedArray(Array<char> inpArray)
{
	inpArray.Resize(8);
	inpArray[-5]='R';
	inpArray[-4]='E';
	inpArray[-3]='T';
	inpArray[-2]='U';
	inpArray[-1]='R';
	inpArray[0]='N';
	inpArray[1]='E';
	inpArray[2]='D';

	return inpArray;
}




