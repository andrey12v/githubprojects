// File:      findsum.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 1
// Date:      09/10/07

// Function Description
// This function will sum up the elements of a integer array. 
// Finally, the function will return the sum of a integer array 


#include <string>
#include <iostream>
#include <fstream>
using namespace std;


void findsum(int* ArrayArg, int* CountArg, int* SumArg){

	//The algoritm sums up the elements of the integer array	
	for(int i=0; i<*CountArg; i++){
	*SumArg=*SumArg+ArrayArg[i];
	}
}

