// File:      getLowPrecedence.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains getLowPrecedence function.
// The function checks the precedence of operators. 
// If the input operator is '+' or '-' and the top element of the stack has higher precedence operator '*' or '/' or '%' 
// the input operator has lower precedence and the result of the function is true. Otherwise, false
// The function is used in another function "getPostfix()" to convert Infix to Postfix expression
// The function uses the library "token.h" to work with operators and operands of the infix expression
// The function uses the library "myStack.h" to work with stacks

#include "token.h"
#include "myStack.h"

//Precondition: The token of the infix expression exists 
//				The stack exists and is not empty.
//Postcondition: The function returns true if input operator has lower precedence than the top element of the stack
// 				 Otherwise, false
bool getLowPrecedence(Token& inpT, stackType<Token>& inpStack){
	Token tmpToken;
	tmpToken=inpStack.top();
	if( (inpT.Operator()=='+' || inpT.Operator()=='-') && 
		(tmpToken.Operator()=='*' || tmpToken.Operator()=='/' || tmpToken.Operator()=='%')){
		return true;}
	else{
		return false;}
}