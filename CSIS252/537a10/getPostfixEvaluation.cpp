// File:      getPostfixEvaluation.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains getPostfixEvaluation function.
// The function returns the result of evaluation between two operands from the srack acccording to operator
// the stack is passed by reference as parameter in function "getPostfixEvaluation" 
// The function getPostfixEvaluation is called in the function getPostfixExpression when 
// the top element of the stack is operator and other two elements of the stack are operands
// The function uses the library "token.h" to work with operators and operands
// The library "myStack.h" to work with stacks

#include "token.h"
#include "myStack.h"

//Precondition:  The stack exists and is not empty 
//Postcondition: The function returns the result of evaluation between two operands 
//				 according to operator  
void getPostfixEvaluation(stackType<Token>& inpStack){
	Token tmpToken[3];
	int i=0;
	while(i<=2 && !inpStack.isEmptyStack()){
		tmpToken[i]=inpStack.top();
		inpStack.pop();
		i++;
	};
	switch (tmpToken[0].Operator())
   	{
			case '+' : inpStack.push(tmpToken[2]+tmpToken[1]); break;
      		case '-' : inpStack.push(tmpToken[2]-tmpToken[1]); break;
      		case '*' : inpStack.push(tmpToken[2]*tmpToken[1]); break;
      		case '/' : inpStack.push(tmpToken[2]/tmpToken[1]); break;
      		case '%' : inpStack.push(tmpToken[2]%tmpToken[1]); break;
      		case '^' : inpStack.push(tmpToken[2]^tmpToken[1]); break;
	};

}