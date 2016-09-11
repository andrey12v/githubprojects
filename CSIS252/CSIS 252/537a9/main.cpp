// File:      main.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 9
// Date:      11/06/07

// This file contains the main function.
// This program reads the string from keyboard and inputs  
// the letters of the string into the stack and queue 
// The stack and queue are Abstract Data Types
// The letters are saved as string in stack and array
// Then each letter from the stack and queue is compared. 
// The comparison of letters begins from the first element in the queue and 
// from the top element of the stack. After comparison of letters the top element 
// in the stack and the first element in the queue are deleted to get access to the 
// next element. By means of such algorithm it can be possible to figure out a 
// palindrome. For example, the phrase "Name no one man" is the palindrome that is 
// the letters from the queue are equal to the letters from the stack. 

#include<iostream>
#include <string>
#include"myStack.h"
#include"queueAsArray.h"
using namespace std;

int main(){

//Declare the object of of stack template class  
stackType<string> stack;
//Declare the object of of queue template class  
queueType<string> queue;

//Declare the variable to input the string
char inpStr[256];
//Declare the varible to push letters into the stack and qeue
string tmpStr;
int i=0;

//inicialize the stack and queue to an empty state
queue.initializeQueue();
stack.initializeStack();

cout<<"enter a string: ";
cin.get(inpStr, 256);

//characters of the string input into the stack and queue by means of thr follwoing cycle 
while(i<strlen(inpStr) && !stack.isFullStack() && !queue.isFullQueue()){
//check if the character has upper case
	if (inpStr[i]>='A' && inpStr[i]<='Z'){
		tmpStr=inpStr[i];
		stack.push(tmpStr);
		queue.addQueue(tmpStr);
	}
//if the character has lower case the function uppercase changes to uppercase in input to stack and queue
	else if(inpStr[i]>='a' && inpStr[i]<='w'){
		tmpStr=toupper(inpStr[i]);
		stack.push(tmpStr);
		queue.addQueue(tmpStr);
	}
	
	i++;
};

//the variable checks if all elements of stack and queue were equal
bool check=false;

// there is camparison between letters of stack and array to figure out a palindrom
while (!stack.isEmptyStack() && !queue.isEmptyQueue()){
	
	if(stack.top()!=queue.front()){ 
	cout<<"\""<<inpStr<<"\" "<<" is not a palindrome."<<endl;	
	check=true;
	break;
	}
stack.pop();
queue.deleteQueue();
}

//if all letters of the queue and stack are equal it will be a palindrome 
if (!check){
cout<<"\""<<inpStr<<"\" "<<" is a palindrome."<<endl;
}


return 0;
}
