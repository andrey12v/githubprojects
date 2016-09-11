// File:      read.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 1
// Date:      09/10/07

// Function Description
// This function will output a integer ciphers from the file.
// All ciphers will stored in a integer pointer array.
// The array will be used in the main program.


#include <string>
#include <iostream>
#include <fstream>
using namespace std;

void read(int* ArrayArg, int* CountArg){
	int limit=100;				//the variable checks the size of array

	ifstream inpData;			//the object of the class ifstream which is necessary to input data from file into array 
	inpData.open ("data");	
		
		//Ciphers output from the file and stored in the pointer array 
		if (inpData.is_open())
		{
			inpData>>*ArrayArg;
  	  		while (!inpData.eof() && *CountArg<limit)
			{
			*ArrayArg++;
			++*CountArg;
			inpData>>*ArrayArg;
			};
	  	inpData.close();
		}
		else
		{
			cout << "Error opening file";
		}	
}

