// File:      getsizeBeforeLeftParen.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains getsizeBeforeLeftParen function.
// The function returns the quantity of tokens before left parentheses. 
// This function is used in the function "getPostfix()"
// The function "getsizeBeforeLeftParen()" is very beneficial for the algorithm 
// to convert from infix to postfix expression between parenthesis.
// If there is one token before left parentheses this token is added in the queue 
// If there are two or more tokens the rest of tokens are added to the queue
// The function uses the library "token.h" to work with operators and operands of the infix expression
// The function uses the library "myStack.h" to work with stacks

#include "token.h"
#include "myStack.h"

//Precondition: The stack exists and is not empty 
//Postcondition: The function returns the quantity of tokens before left parentheses in the stack

int getsizeBeforeLeftParen(stackType<Token> inpStack){
	int count=0;
	Token tmpToken;
	do{
		inpStack.pop();
		count=count+1;
		tmpToken=inpStack.top();	
	}while(!tmpToken.IsLeftParen());
return count;
}