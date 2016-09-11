Name:    Andrey Vasilyev
Class:   CSIS 252
Program: Assignment 10
Date:    11/17/07

The program carries out the following operations:
1) inputs the infix expression from the keyboard
2) converts infix expression to postfix expression and 
3) stores the result of Postfix expression in the queue
4) outputs the Infix expression on the screen
5) outputs Postfix expression on the screen
6) evaluates Postfix expression and stores the result in the stack
7) outputs the result of Postfix evaluation on the screen

The input of the program:
1) the input is from the keyboard.
The input is the infix expression. The infix expression includes operands and operators. 
If there are spaces or another characters between operands and operators the program skips them
   
The output of the program:
1) The program outputs Infix, Postfix expressions and the results of
Postfix evaluation

The program has the following algorithms: 
1) compares the operators according to precedence. The program pushes operands in the queue and pushes 
operators in the stack or queue according to their precedence.
2) evaluates the Postfix expression. The program evaluates two operands from the stack according to
operator from the top of the stack.

Program design
1) The program includes Abstract Data Types. Stack and queue are objects of classes StackType and QeueType. They are 
Abstract Data Types. 
2) The objects stack and queue stores the tokens from the Infix expression. The objects can manipulate the
tokens by means of predefined methods.  
3) The class StackType and QeueType are template classes and can work with different data types; 
These classes allocate the memory dynamically
4) The class StackType and QeueType have constructor, destructor, copy constructor, 
overloading the assignment operator. 
6) The program uses two main algorithms. 
The first algorithm converts Infix to Postfix expression and the second evaluates	Postfix expression.
When the program converts Infix to Postfix Expression it uses different user-defined function such 
getLowPrecedence, getsizeOfStack and etc. The program uses different conditions to compare the input operator 
with the operator from the top of the stack. According to conditions and precedence of operators the program 
stores the operator in the queue or in the stack. The final result of such algorithm is Postfix expression in
the queue
When the program evaluates the postfix expression it considers the queue. The program takes the front token from 
the queue. If it is operand the program pushes operand in the stack. If the token from the queue is operator 
takes two operands from the stack, evaluates the result between them according to operator. The program pushes
the final result in the stack . Finally, the stack will keep only the result of Postfix evaluation.

The program has the following files:

File						function	 				description
Main.cpp 					main()						main function	
myStack.h					Declaration and 			Declare and implement the template class Stack 
							implementation	
queueAsArray.h				Declaration and 			Declare and implement the template class Qeueu 
							implementation
getEqualPrecedence.cpp		getEqualPrecedence()		check the equation precedence of operators
getHighPrecedence.cpp		getHighPrecedence()			check the high precedence of operators
getLowPrecedence.cpp		getLowPrecedence()			check the low precedence of operators
getPostfix.cpp				getPostfix()				output the Infix expression and returns Postfix expression
getPostfixEvaluation.cpp	getPostfixEvaluation()		return the evaluation between two operands according to operator
getPostfixExpression.cpp	getPostfixExpression()		return the result of Postfix evaluation
getsizeBeforeLeftParen.cpp	getsizeBeforeLeftParen()	return the quantity of tokens before left parentheses
getsizeOfStack.cpp			getsizeOfStack()			return the size of stack
returnTokenAfterDegree.cpp	returnTokenAfterDegree()	return the token after degree in the stack

The test of the program.
1) When different Infix expressions were entered, the program outputted the final result
2) When Infix expression with blank spaces were entered the program skipped blank spaces and
outputted the final result.
