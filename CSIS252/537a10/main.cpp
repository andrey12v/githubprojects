// File:      main.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains the main function.
// The programs uses stack and queues to get Postfix expression and its evaluation
// The infix expression is typed from the keyboard and saved in the queue according to precedence of oparnds and operators
// The program reads infix expression and converts it to Postfix expression by menas of the function "getPostfix(),
// The program outputs on the screen the Infix and Postfix expression,
// Then the program evaluates Postfix expression by means of the function "getPostfixExpression()".
// Finally, the program outputs on the screen the results of evaluation of Postfix Expression

#include "token.h"
#include "myStack.h"
#include "queueAsArray.h"
#include <iostream>
#include<string>
using namespace std;

//Function to converts Infix to Postfix expression
//Precondition: The stack exists and is not full.
//		logical variable is false
//Postcondition: The elements are deleted from the stack and
//		 added to the queue
//		 Outputs the Infix expression on the screen
void getPostfix(stackType<Token>& stack, queueType<Token>& queue, bool checkLeftParen);

//Function to evaluates Postfix expression
//Precondition: The stack exists and is not full.
//		The queue exists and is not full
//Postcondition: The elements are deleted from the queue and
//		 added to the stack the results of evaluation
void getPostfixExpression(stackType<Token>& stack, queueType<Token>& NewQueue);

int main()
{

//Declaraton of the objects stack and queue to get results of Infix to Postfix expression 
stackType<Token> stack;
queueType<Token> queue;

// Initialization of parametrs in stack and queue
// sets the parametrs of stack and queue which the size top element  
queue.initializeQueue();
stack.initializeStack();

//logical variable is used in the function "getPostfix()" to convert Infix to Postfix epression
bool checkLeftParen=false;

cout<<"Enter Infix expression: "<<endl;

//the function converts Infix to Postfix and outputs Infix expression on the screen
getPostfix(stack, queue, checkLeftParen);

// New queue is created to evaluate Postfix expression. 
// When Postfix expression outputs on the screen the lements are deleted from the previous queue and
// added to the new queue. The New queue passed by reference in the function "getPostfixExpression()" to
// evaluate Postfix expression.

queueType<Token> NewQueue;
NewQueue.initializeQueue();

cout<<"Postfix ";

do{
	cout<<queue.front()<<" "; 
	NewQueue.addQueue(queue.front());
	queue.deleteQueue();
}while (!queue.isEmptyQueue());
cout<<endl;

//Initialization of the stack to save the results of Postfix evaluation 
stack.initializeStack();
//call the function to evaluate the Postfix expression
getPostfixExpression(stack, NewQueue);
//Outputs the evaluation of Postfix expression on the screen
cout<<stack.top()<<endl;

   return 0;
}
