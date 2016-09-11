// File:      returnTokenAfterDegree.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains returnTokenAfterDegree function.
// If the top element of the stack is degree the function returns the token after the top element in the stack
// The function "returnTokenAfterDegree" is used in the function "getPostfix"
// This function is used in the following case. If the input operator has the similar
// precedence as degree which is the top of the stack and the element after degree in the stack has
// lower precedence such as "+" or "-", the top element of the stack which is degree is added to the 
// queue and the input operator is pushed in the stack
// If the stack is empty the function returns the character 'n'
// If there is operator after degree the function returns the following operator
// If there is left parentheses after degree the function returns the character '('
// The function "returnTokenAfterDegree" uses stack as parameter passed by value.
// The function "returnTokenAfterDegree" doesn't have any influence on the stack in the function "getPostfix"
// The function uses the library "token.h" to work with operators and operands of the infix expression
// The library "myStack.h" to work with stacks

#include "token.h"
#include "myStack.h"

//Precondition: The stack exists and is not empty 
//Postcondition: The function returns the operator after degree in the stack
char returnTokenAfterDegree(stackType<Token> inpStack){

	Token tmpToken1;
	inpStack.pop();
	if(!inpStack.isEmptyStack()){
		tmpToken1=inpStack.top();
	}
	else if(inpStack.isEmptyStack()){
		return 'n';
	}

	if(!inpStack.isEmptyStack() && !tmpToken1.IsLeftParen()){
		return tmpToken1.Operator();
	}
	else if(!inpStack.isEmptyStack() && tmpToken1.IsLeftParen()){
		return '(';
	}
}