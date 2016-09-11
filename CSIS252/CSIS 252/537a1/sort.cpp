// File:      sort.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 1
// Date:      09/10/07

// Function Description
// This function will  sort a integer array on decrease
// All ciphers will stored in a integer pointer array.
// The array will be used in the main program.

#include <string>
#include <iostream>
#include <fstream>
using namespace std;


void sort(int* ArrayArg, int* CountArg){
	int temp, i, j; //the variable temp is necessary to store temporary element of the array
					//the variable will be used as index in the array
					//the variable j will be used as the second index in the array to sort elements 

		//The sorting algoritm is following. 
		//if the following element is bigger than preceding 
		//it will be exchange between the following and preceding one 

	for(i=0; i<*CountArg-1; i++){
		
		for(j=i+1; j<*CountArg; j++){
			if (ArrayArg[i]>ArrayArg[j]){
			temp=ArrayArg[i];
			ArrayArg[i]=ArrayArg[j];
			ArrayArg[j]=temp;
			}
		}
	}


}

