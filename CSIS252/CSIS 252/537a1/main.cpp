// File:      main.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 1
// Date:      09/10/07

// Program Description
// This program calls the functions which carry out definite tasks.
// The function read - reads the integer ciphers from file and store this ciphers in an array
// The function sort - sorts the elements of the integer array
// The function write - writes the elements into the file from the integer array
// The function findsum - finds the sum of the elements in the integer Array
// Finally, the program finds the average vale. It divides the sum of the elements on their quantity

#include <string>
#include <iostream>
#include <fstream>
using namespace std;

void read(int* ArrayArg, int* CountArg);
void sort(int* ArrayArg, int* CountArg);
void write(ofstream *outpDataArg, int* ArrayArg, int* CountArg);
void findsum(int* ArrayArg, int* CountArg, int* SumArg);

int main(){
int numbers[100];		//the integer array 
int count=0;			//the counter calculates the quantity of ciphers
int sum=0;				//the variable keeps the sum of array element
float avg;				// the variable stores the average sun of the array
read(numbers, &count);	//the function reads the ciphers from the file "data" and stores them in the integer array
ofstream outpData;		//the object of the class ofstream is used to open file and write into it integer ciphers
outpData.open ("output");	
outpData << "the unsorted numbers\n";
write(&outpData, numbers, &count);	//the function writes the elements of array in the file "output"
sort(numbers, &count);	//the function sorts the element of the integer array on decrease

outpData << "the sorted numbers\n";
write(&outpData, numbers, &count);	//the function writes the elements of array in the file "output"
outpData.close();
findsum(numbers, &count, &sum);		//the function the sum of the integer array
avg=static_cast<float>(sum)/count;	//average sum 
cout<<"the average is " << avg << endl;
	
cout << 5/0;
return 0;
}

