// File:      getsizeOfStack.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains getsizeOfStack function.
// The function returns the whole quantity of tokens in the stack. 
// This function is used in the function "getPostfix()"
// The function "getsizeOfStack()" is used because it is impossible to find the size of the stack.
// It is impossible to get access to the next element in the stack without delete of the top element.
// The function uses stack passed by value to count the number of elements and delete top elements of the stack
// The function doesn't have influence on the original stack in the function getPostfix() and returns the size of the original stack.
// The function uses the library "token.h" to work with operators and operands of the infix expression
// The function uses the library "myStack.h" to work with stacks

#include "token.h"
#include "myStack.h"

//Precondition:  The stack exists and is not empty 
//Postcondition: The function returns the size of the stack
int getsizeOfStack(stackType<Token> inpStack){
	int count=0;
	while(!inpStack.isEmptyStack()){
		inpStack.pop();
		count=count+1;
	}
	return count;
}