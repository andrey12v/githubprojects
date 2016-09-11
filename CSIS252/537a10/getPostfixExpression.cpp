// File:      getPostfixExpression.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains getPostfixExpression function.
// The function returns the result of evaluation of the whole Postfix expression
// The function returns the stack with the final result of postfix evaluation on the top of the stack
// The function "getPostfixExpression" calls the function "getPostfixEvaluation"
// when two elements in the stack are operands and the top element of the stack is operator
// After evaluation the function "getPostfixExpression" pushes the result in the stack
// The function operates until the whole Postfix expression is evaluated

#include "token.h"
#include "myStack.h"
#include "queueAsArray.h"

//the function returns the result of evaluation between two operands according to operator
void getPostfixEvaluation(stackType<Token>& inpStack);

//Precondition:  The stack exists and is not empty 
//				 The queue exists and is not empty 	
//Postcondition: The function returns the result of evaluation between two operands 
//				 according to operator  
void getPostfixExpression(stackType<Token>& stack, queueType<Token>& NewQueue){
	Token t;
	while (!NewQueue.isEmptyQueue()){
		t=NewQueue.front();
		if(t.IsOperand()){
			stack.push(t);
			NewQueue.deleteQueue();
		}
		else if(t.IsOperator()){
			stack.push(t);
			NewQueue.deleteQueue();
			getPostfixEvaluation(stack);
		}

	}

}