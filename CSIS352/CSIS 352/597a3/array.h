//Andrey Vasilyev
//array.h
//02/15/2009
//Assignment 3

// *********The description of the class Array*****************
//
// This file contains the specification and implementation for the Array class. 
// The class is designed to be as a template that provides to declare 
// objects of different types (integre, character or any other class data type)
// The class has methods that allows to resize the array, compare different
// arrays of the same type, assign one array to another so that all elements of one
// array are copied to the designated array. The array can operate with the indexes of
// different type like integres, charaters and days of week   
// Moreover the file has specification and implementation of exception class that allows 
// to define different types of errors and methods that could catch them.  
// The Array and exception classes are included in one namespace that helps the program
// to separate logically
//
// ********The end of the class Array description***************

#ifndef _ARRAYCLASS_
#define _ARRAYCLASS_

#include <string>
#include <cassert>  //library is used to process possible errors of the program execution
using namespace std;

namespace ArrayNameSpace {

//enum variable is used in arrays as an index
//the values of the enum variable are days of week: Monday, Tuesday, Wensday and etc.
enum DaysOfWeek {Mon, Tue, Wed, Thu, Fri, Sat, Sun};

//Array Exception is an exception class that catches errors occured in the methods of the class Array
class ArrayException 
{
public:	
	
//    default constructor
//    method input - none
//    method output - string with an error message
	ArrayException()
	{
		message="Input is wrong";
	}

//    parametr list constructor
//    preconditions - valid string 
//    postconditions - input string is assigned to string variable
//    method input - string with error message
//    method output - outputs the message about the error that was caught by the exception
	ArrayException(string str)	
	{
		message=str;
	}

// method to output an error message
	string what()
	{
		return message;
	}


private:
	string message;
};



template<class Type>
class Array
{
public:
	  
	  // default constructor
      //    preconditions - no validity checking is performed
      //    postconditions
      //       - dynamic array is declared with the size of 100 elements by default 
	  //       - the low index of the array is eual to 0 and the high index = 100    
	  //    method input - array size, low and high indexes
      //    method output - none
	  Array();
	  
	  // parameter list constructor
      //    preconditions - validity checking is performed
      //	   - the low and high indexes must be integer numbers or enum variables as days of week 
	  //	   - the low index must be less than or equal to the high index of array
      //    postconditions
      //       - low and high index attribute are set to the arguments.
      //       - if arguments are invalid the exception wil be thrown and catch the error
	  //	   - if the low indedx is bigger than the high index the exception will catch the invalid index
      //    method input - low and high indexes
      //    method output - none
	  Array(int, int);

	  // parameter list constructor
      //    preconditions - validity checking is performed
      //	   - the low and high indexes must be single characters
	  //	   - the low index must be less than or equal to the high index of array
      //    postconditions
      //       - low and high index attribute are set to the arguments.
      //       - if arguments are invalid the exception wil be thrown and catch the error
	  //	   - if the low indedx is bigger than the high index the exception will catch the invalid index
      //    method input - low and high indexes
      //    method output - none
	  Array(char, char);
	
	  //destructor
      //Remove all the elements from the array.
      //Postcondition: The array (list) holding the elements is deleted.
	  ~Array();
	  
	  //copy constructor
	  //copy constructor allows to copy data members of the actual object
	  //into the corresponding data members of the formal parametr
	  Array(const Array<Type>& inpArray);

	  //overloading the operator equal
	  //    preconditions - validity checking is performed
      //	   - the array must not be assigned to itself
	  //	   - the low index must be less than or equal to the high index of array
      //    postconditions
      //       - attributes (low, high indexes, size of the array) are set to the arguments.
      //       - the elements of parametr array are assigned to the current array
	  //    method input - the array to be copied
      //    method output - the array with assigned values
	  const Array<Type>& operator=(const Array<Type>& );

	  //overloading the nonconstant array index (subscript) operator([])
	  //    preconditions - validity checking is performed
      //	   - the input index must be integer number or enum type as a day of week
	  //	   - the input index must be within boundary of start and end indexes
      //    postconditions
      //       - the input index passed to the array to get required element
 	  //	   - if the input index is outside of the boundary of start and end index
	  //	   - the exception will catch the invalid index
      //    method input - input index
      //    method output - the element of the array according to the input index
	  Type& operator[](int indexInt);
	  
	  //overloading the nonconstant array index (subscript) operator([])
	  //    preconditions - validity checking is performed
      //	   - the input index must be of character type
	  //	   - the input index must be within boundary of start and end indexes
      //    postconditions
      //       - the input index passed to the array to get required element
 	  //	   - if the input index is outside of the boundary of start and end index
	  //	   - the exception will catch the invalid index
      //    method input - input index
      //    method output - the element of the array according to the input index
	  Type& operator[](char indexChar);

	  //overloading the constant array index (subscript) operator([])
	  //    preconditions - validity checking is performed
      //	   - the input index must be integer number or enum type as a day of week
	  //	   - the input index must be within boundary of start and end indexes
      //    postconditions
      //       - the input index passed to the array to get required element
 	  //	   - if the input index is outside of the boundary of start and end index
	  //	   - the exception will catch the invalid index
      //    method input - input index
      //    method output - the element of the array according to the input index
	  const Type& operator[](int indexInt) const;

	  //overloading the constant array index (subscript) operator([])
	  //    preconditions - validity checking is performed
      //	   - the input index must be of character type
	  //	   - the input index must be within boundary of start and end indexes
      //    postconditions
      //       - the input index passed to the array to get required element
 	  //	   - if the input index is outside of the boundary of start and end index
	  //	   - the exception will catch the invalid index
      //    method input - input index
      //    method output - the element of the array according to the input index
	  const Type& operator[](char indexChar) const;
	
	  //The method Resize() chages the size of the array according to input data 
	  //    preconditions - validity checking is performed
      //	   - the input number, the size of the array must be more than zero
      //    postconditions
      //       - the new size is assigned to the array and the rest of the elements are removed
 	  //	   - if the new size of the array is less or equal to zero 
	  //	   - the exception will catch the invalid input parametr, the size of the array
      //    method input - input new size of the array
      //    method output - none
	  void Resize(int inpSize);

	  //The method Size() returns the size of the array 
	  //    preconditions - no validity checking is performed
      //    postconditions
      //       - the size of the array is returned
      //    method input - none
      //    method output - the size of the array
	  int Size(); 
	    
	  // method: operator==  compares the object to an argument
      	  //    preconditions - the object and argument are valid array elements
      	  //    postconditions - result of comparison is returned
      	  //    method input - an Array argument
      	  //    method output - true if object and argument are equal
      bool operator==(const Array<Type>&) const;

      	// method: operator!=  compares the object to an argument
      	//    preconditions - the object and argument are valid array elements
      	//    postconditions - result of comparison is returned
      	//    method input - an Array argument
      	//    method output - true if object and argument are not equal
      bool operator!=(const Array<Type>&) const;

      // method: operator<=  compares the object to an argument
      //    preconditions - the object and argument are valid array elements
      //    postconditions - result of comparison is returned
      //    method input - a Date argument
      //    method output - true if object is <= to argument
      bool operator<=(const Array<Type>&) const;

      // method: operator>=  compares the object to an argument
      //    preconditions - the object and argument are valid array elements
      //    postconditions - result of comparison is returned
      //    method input - an array argument
      //    method output - true if object is >= to argument
      bool operator>=(const Array<Type>&) const;

      // method: operator<  compares the object to an argument
      //    preconditions - the object and argument are valid array elements
      //    postconditions - result of comparison is returned
      //    method input - an array argument
      //    method output - true if object is < argument
      bool operator<(const Array<Type>&) const;

      // method: operator>  compares the object to an argument
      //    preconditions - the object and argument are array elements
      //    postconditions - result of comparison is returned
      //    method input - an array argument
      //    method output - true if object is > argument
      bool operator>(const Array<Type>&) const;

private:
	
	Type *list;		// declaration of dynamic array of an unsigned type
	int count;		// variable to count a size of an array
	int maxSize;	// variable to store a maximum size of an array 
	int lowIndex;	// variable to store a start index of an array
	int highIndex;	// variable to store an end index of an array
};


//default constructor
template <class Type>
Array<Type>::Array()
{
	maxSize=100;
	list=new Type[maxSize];
	lowIndex=0;
	highIndex=100;
}

//parametr list constructor with integer indexes as input parametrs 
template <class Type>
Array<Type>::Array(int inpLowIndex, int inpHighIndex)
{
	if (inpLowIndex>inpHighIndex)
	{
		throw ArrayException("Low index must be less or equal to upper index");
	}
	else
	{
		count=0;
		for(int i=inpLowIndex; i<=inpHighIndex; i++)
		{
			count++;
		}
	
		maxSize=count;
		list=new Type[maxSize];
		lowIndex=inpLowIndex;
		highIndex=inpHighIndex;
	}
}

//parametr list constructor with character indexes as input parametrs 
template <class Type>
Array<Type>::Array(char inpLowIndex, char inpHighIndex)
{
	if (static_cast<int>(inpLowIndex)>static_cast<int>(inpHighIndex))
	{
		throw ArrayException("Low index must be less or equal to upper index");
	}
	else
	{
		count=0;
		for(int i=static_cast<int>(inpLowIndex); i<=static_cast<int>(inpHighIndex); i++)
		{
			count++;
		}
	
		maxSize=count;
		list=new Type[maxSize];
		lowIndex=static_cast<int>(inpLowIndex);
		highIndex=static_cast<int>(inpHighIndex);
	}
}

//copy constructor
template <class Type>
Array<Type>::Array(const Array<Type>& inpArray)
{
	maxSize=inpArray.maxSize;
	lowIndex=inpArray.lowIndex;
	highIndex=inpArray.highIndex;

	list=new Type[maxSize];
	//for(int j=lowIndex; j<=highIndex; j++)
	for(int j=0; j<maxSize; j++)
	{
		list[j]=inpArray.list[j];
	}

}

//overloading of the operator equal
template <class Type>
const Array<Type>& Array<Type>::operator=(const Array<Type>& inpArray)
{
	if(this!=&inpArray)
	{	
		delete [] list;
		maxSize=inpArray.maxSize;
		lowIndex=inpArray.lowIndex;		
		highIndex=inpArray.highIndex;

		list=new Type[maxSize];
		for(int j=0; j<maxSize; j++)
		{
			list[j]=inpArray.list[j];
		} 
	}
	return *this;
}

//overloading the nonconstant array index (subscript) operator([]) of integer index type
template <class Type>
Type& Array<Type>::operator[](int indexInt)
{
	if (indexInt<lowIndex)
	{
		throw ArrayException("The minimum index must be equal to or more than the lowest index of the array");
	}
	else if (indexInt>highIndex)
	{
		throw ArrayException("The maximum index must be equal to or less than the highest index of the array");
	}
	{
		return list[indexInt-lowIndex];
	}
}

//overloading the nonconstant array index (subscript) operator([]) of character index type
template <class Type>
Type& Array<Type>::operator[](char indexChar)
{
	if (static_cast<int>(indexChar)<lowIndex)
	{
		throw ArrayException("The minimum index must be equal to or more than the lowest index of the array");
	}
	else if (static_cast<int>(indexChar)>highIndex)
	{
		throw ArrayException("The maximum index must be equal to or less than the highest index of the array");
	}
	else
	{
		int tmp=static_cast<int>(indexChar);
		return list[tmp-lowIndex];
	}
}

//overloading the constant array index (subscript) operator([]) of integer index type
template <class Type>
const Type& Array<Type>::operator[](int indexInt) const
{
	if (indexInt<lowIndex)
	{
		throw ArrayException("The minimum index must be equal to or more than the low index of the array");
	}
	else if (indexInt>highIndex)
	{
		throw ArrayException("The maximum index must be equal to or less than the highest index of the array");
	}
	{
		return list[indexInt-lowIndex];
	}
}

//overloading the constant array index (subscript) operator([]) of character index type
template <class Type>
const Type& Array<Type>::operator[](char indexChar) const
{
	if (static_cast<int>(indexChar)<lowIndex)
	{
		throw ArrayException("The minimum index must be equal to or more than the lowest index of the array");
	}
	else if (static_cast<int>(indexChar)>highIndex)
	{
		throw ArrayException("The maximum index must be equal to or less than the highest index of the array");
	}
	else
	{
		int tmp=static_cast<int>(indexChar);
		return list[tmp-lowIndex];
	}
}

//method Resize() to change the size of the method
template <class Type>
void Array<Type>::Resize(int inpSize)
{
	if (inpSize<=0)
	{
		throw ArrayException("The size of the array must be more than zero");
	}
	else
	{
		//creates temporary array to keep elements the current array
		int i;
		Type *tmpList;
		tmpList=new Type[inpSize];
		for(i=0; i<inpSize; i++)
		{
			if(i>=maxSize)
			{
				tmpList[i]=0;	
			}
			else
			{
				tmpList[i]=list[i];
			}
		}
		//delete current array and allocates the new array with new size
		delete [] list;
		maxSize=inpSize;
		highIndex=lowIndex+(inpSize-1);
	
		//assign elements to the array
		list=new Type[maxSize];
		for(i=0; i<maxSize; i++)
		{
			list[i]=tmpList[i];	
		}
		delete [] tmpList;
	}
}

//meth=od to return a size of an array 
template <class Type>
int Array<Type>::Size()
{
	return maxSize;
}

//overloading comparison operator equal
template <class Type>
bool Array<Type>::operator==(const Array<Type>& inpArray) const
{
	bool logicTmp=true;
	if (maxSize!=inpArray.maxSize)
	{
		return false;
	}
	else if (maxSize==inpArray.maxSize)
	{
		//for(int i=lowIndex; i<=highIndex; i++)
		for(int i=0; i<maxSize; i++)
		{
			if (list[i]!=inpArray.list[i])
			{
				logicTmp=false;
			}
		}
	}
	
	return logicTmp;
	
}

//overloading comparison operator not equal
template <class Type>
bool Array<Type>::operator!=(const Array<Type>& inpArray) const
{
	return (!this->operator ==(inpArray));
}


template <class Type>
bool Array<Type>::operator<(const Array<Type>& inpArray) const
{
	bool logicTmp=true;
	int minSize=0;
	
	//chose the minimum size of array
	if(maxSize<inpArray.maxSize)
	{
		minSize=maxSize;
	}
	else
	{
		minSize=inpArray.maxSize;
	}
	
	//check each element of the array so that even if one element of the array is
	//more than the element from another array the result will be false
	//otherwise true
	//for(int i=lowIndex; i<=lowIndex+(minSize-1); i++)
	for(int i=0; i<minSize; i++)
	{
		if (list[i]>inpArray.list[i])
		{
			logicTmp=false; 
		}
	}

	//if all elements of two arrays are equal the result will be false
	if (this->operator==(inpArray)) 
	{
		logicTmp=false;
	}


	return logicTmp;
}

template <class Type>
bool Array<Type>::operator<=(const Array<Type>& inpArray) const
{
	return (this->operator<(inpArray) || this->operator==(inpArray));
}

template <class Type>
bool Array<Type>::operator>(const Array<Type>& inpArray) const
{
	return ((!this->operator<(inpArray)) && (!this->operator==(inpArray)));
}

template <class Type>
bool Array<Type>::operator>=(const Array<Type>& inpArray) const
{
	return (this->operator>(inpArray) || this->operator==(inpArray));
}

//destructor
template <class Type>
Array<Type>::~Array() //destructor
{
    delete [] list; //deallocate the memory occupied 
                //by the array
}

}


#endif


