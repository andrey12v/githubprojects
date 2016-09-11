// The following methods overload the [] operator
// They work only for indices 0 through n-1.  You must change these
// to work with other ranges

// theArray is a pointer to a dynamically allocated array of int
int& Array::operator[](int index)
{
   // throw an exception if outside the array boundaries
   return theArray[index];
}

// the following method allows a const pass by reference argument
// For example: void func(const Array& array)
const int& Array::operator[](int index) const
{
   // throw an exception if outside the array boundaries
   return theArray[index];
}

