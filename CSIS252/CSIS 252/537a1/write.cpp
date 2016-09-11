// File:      write.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 1
// Date:      09/10/07

// Function Description
// This function will  write a integer array in the file
// The object of class fsteram was passed by reference.


#include <string>
#include <iostream>
#include <fstream>
using namespace std;

void write(ofstream *outpDataArg, int* ArrayArg, int* CountArg){
  
	//Writting a integer array in the file
	for(int i=0; i<*CountArg; i++){  
	*outpDataArg<<ArrayArg[i] << endl;
	};

}

