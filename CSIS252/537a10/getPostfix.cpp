// File:      getPostfix.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 10
// Date:      11/17/07

// This file contains getPostfix function.
// The function converts Infix to Postfix expression
// The function uses stack and queue as parameters passed by reference from the main function
// The function also uses logical variable checkLeftParen to make two algorithms separate. 
// If checkLeftParen is false the function converts Infix to Postfix without parenthesis
// If checkLeftParen is true the function converts Infix to Postfix with parenthesis
// The main idea of the algorithm is the following. If the token is operand it is added in the queue
// If the token is operator it is pushed in stack. 
// The algorithm compares the precedence of operators in the stack. 
// If the input operator has lower precedence than the top operator in the stack 
// the top element of the stack is added in the queue and the input operator is pushed in the stack.
// If the input operator has higher precedence than the top operator in the stack 
// the top element is kept in the stack and input operator is pushed in the stack
// If the input operator and the top element of the stack have equal precedence 
// the top element of the stack is added in the queue and the input operator is pushed in the stack
// There are also some exceptions, which are degree and parenthesis. 
// If the input operator is degree and it has equal precedence with the top element of stack ('*', '/' or '%')
// the top element is kept in the stack and degree is pushed in the stack.   
// If input operator is lower than degree which is the top element of the stack 
// the degree and all elements after the degree are added in the queue from stack and 
// the input operator is pushed in the stack
// In case of parenthesis the algorithm uses the same rules and conditions to compare the precedence of operators.
// But this algorithm works within parenthesis. If the right parentheses is appeared, the rest of the elements up to
// left parentheses are added to the queue from the stack
// The algorithm finishes to work when all elements of infix expression were compared.
// The function outputs the Infix expression on the screen and returns Postfix expression saved in the queue
// The function uses the library "token.h" to work with operators and operands of the infix expression
// The library  "myStack.h" to work with stacks
// The library  "queueAsArray.h" to work with stacks
// The library  <iostream> to input from keyboard and output on screen

#include "token.h"
#include "myStack.h"
#include "queueAsArray.h"
#include <iostream>
using namespace std;

// the function checks the equation of input operator and the top element of the stack
bool getEqualPrecedence(Token& inpT, stackType<Token>& inpStack);
// the function checks the high precedence of the input operator in comparison with the top element of the stack
bool getHighPrecedence(Token& inpT, stackType<Token>& inpStack);
// the function returns token after degree in the stacks
char returnTokenAfterDegree(stackType<Token> inpStack);
// the function returns the size of stack
int getsizeOfStack(stackType<Token> inpStack);
// the function returns the quantity of tokens before left parentheses in the stack
int getsizeBeforeLeftParen(stackType<Token> inpStack);
// the fonction evaluates Postfix expression in the stack and returns the final result
void getPostfixEvaluation(stackType<Token>& inpStack);
// the function checks the low precedence of the input operator in comparison with the top element of the stack
bool getLowPrecedence(Token& inpT, stackType<Token>& inpStack);


//Precondition:  The stack exists and is not full
//				 The queue exists and is not full
//Postcondition: Infix expression outputs on the sreen
//				 Postfix expression is returned in the queue	
void getPostfix(stackType<Token>& stack, queueType<Token>& queue, bool checkLeftParen)
{

// the objects of the class Token are used to store operands and operators of the Infix expression
Token t, tmpToken;
// the array of objects of the class Token is used to store the infix expression and output on the screen
Token outToken[100];

int j=0;
int i=0;
cin>>t;
outToken[0]=t;
//the cycle operates until all element of Infix expression were red
while (t.Valid()) 
{
outToken[j]=t;
j++;	
// if the token is operand it is added in the queue
if (t.IsOperand()){
		queue.addQueue(t);
		}
	//if the token is operator the function checks the precedence 
    //According to conditions the operator is added in the queue or pushed in stack 
	else if(t.IsOperator() && checkLeftParen==false){
		if(!stack.isEmptyStack()){
			tmpToken=stack.top();			

			if(getLowPrecedence(t, stack) && getsizeOfStack(stack)==1){
				queue.addQueue(stack.top());
				stack.pop();
				stack.push(t);
				goto out;
			}
			else if(getHighPrecedence(t, stack)){
				stack.push(t);
				goto out;	
			}
			else if(getEqualPrecedence(t, stack)){
				queue.addQueue(stack.top());
				stack.pop();
				stack.push(t);
				goto out;			
			}
			else if(getLowPrecedence(t, stack) && getsizeOfStack(stack)>=2){
				queue.addQueue(stack.top());
				stack.pop();
				queue.addQueue(stack.top());
				stack.pop();
				stack.push(t);
				goto out;		
			}
			else if(t.Operator()=='^'){
				stack.push(t);
				goto out;
			}
			else if(tmpToken.Operator()=='^' && (t.Operator()=='+' || t.Operator()=='-') ){
				
				while(!stack.isEmptyStack()){
					queue.addQueue(stack.top());
					stack.pop();
				}
				stack.push(t);	
				goto out;
			}
			else if(tmpToken.Operator()=='^' && (t.Operator()=='*' || t.Operator()=='/' || t.Operator()=='%') &&
			(returnTokenAfterDegree(stack)=='-' || returnTokenAfterDegree(stack)=='+' || 
			returnTokenAfterDegree(stack)=='n') ){
				queue.addQueue(stack.top());
				stack.pop();
				stack.push(t);
				goto out;
			}
			else if(tmpToken.Operator()=='^' && (t.Operator()=='*' || t.Operator()=='/' || t.Operator()=='%') &&
			(returnTokenAfterDegree(stack)=='*' || returnTokenAfterDegree(stack)=='/')){
				
				queue.addQueue(stack.top());
				stack.pop();
				queue.addQueue(stack.top());
				stack.pop();
				stack.push(t);
				goto out;
			
			}
			else if(tmpToken.Operator()=='^' && (t.Operator()=='*' || t.Operator()=='/' || t.Operator()=='%') &&
			(returnTokenAfterDegree(stack)=='^')){

				while(!stack.isEmptyStack()){
					if(tmpToken.Operator()=='^'){
						queue.addQueue(stack.top());
						stack.pop();					
						tmpToken=stack.top();
					}else{break;}
				}

				if(tmpToken.Operator()=='*' || tmpToken.Operator()=='/' || tmpToken.Operator()=='%'){
					queue.addQueue(stack.top());
					stack.pop();
				}
				if(!stack.isEmptyStack()){
					tmpToken=stack.top();
				}
				if(stack.isEmptyStack() || tmpToken.Operator()=='+' || tmpToken.Operator()=='-'){
					stack.push(t);
					goto out;
				}	
			}
		};		
		if(stack.isEmptyStack()){
			stack.push(t);
			goto out;
		};
	}
	


	//if the token is operator and between parenthesis the function checks the precedence of operators
	//According to conditions the operator is added in the queue or pushed in stacks
	else if(t.IsLeftParen() || (checkLeftParen==true && t.IsOperator()) ){
		if(!stack.isEmptyStack()){
			tmpToken=stack.top();
		}
		if(stack.isEmptyStack() || t.IsLeftParen()){
			stack.push(t);
			checkLeftParen=true;
			goto out;
		}
		else if(tmpToken.IsLeftParen()){
			stack.push(t);
			goto out;
		}
		else if(getHighPrecedence(t, stack)){
			stack.push(t);
			goto out;	
		}
		else if(getEqualPrecedence(t, stack)){
			queue.addQueue(stack.top());
			stack.pop();
			stack.push(t);
			goto out;			
		}
		else if(getLowPrecedence(t, stack)){
			if(getsizeBeforeLeftParen(stack)==1){
				queue.addQueue(stack.top());
				stack.pop();
			}
			else if(getsizeBeforeLeftParen(stack)==2){
				queue.addQueue(stack.top());
				stack.pop();
				queue.addQueue(stack.top());
				stack.pop();
			}
			stack.push(t);
			goto out;
		}
		else if(t.Operator()=='^'){
			stack.push(t);
			goto out;
		}
		else if(tmpToken.Operator()=='^' && (t.Operator()=='+' || t.Operator()=='-') ){
				
			while(!tmpToken.IsLeftParen()){
				tmpToken=stack.top();		
				if(!tmpToken.IsLeftParen()){
					queue.addQueue(stack.top());
					stack.pop();
				}
			}

			stack.push(t);	
			goto out;
		}
		else if(tmpToken.Operator()=='^' && (t.Operator()=='*' || t.Operator()=='/' || t.Operator()=='%') &&
		(returnTokenAfterDegree(stack)=='-' || returnTokenAfterDegree(stack)=='+' || 
		returnTokenAfterDegree(stack)=='(') ){
			queue.addQueue(stack.top());
			stack.pop();
			stack.push(t);
			goto out;
		}
		else if(tmpToken.Operator()=='^' && (t.Operator()=='*' || t.Operator()=='/' || t.Operator()=='%') &&
		(returnTokenAfterDegree(stack)=='*' || returnTokenAfterDegree(stack)=='/')){
				
			queue.addQueue(stack.top());
			stack.pop();
			queue.addQueue(stack.top());
			stack.pop();
			stack.push(t);
			goto out;
			
		}
		else if(tmpToken.Operator()=='^' && (t.Operator()=='*' || t.Operator()=='/' || t.Operator()=='%') &&
		(returnTokenAfterDegree(stack)=='^')){

			while(!tmpToken.IsLeftParen()){
				if(tmpToken.Operator()=='^'){
					queue.addQueue(stack.top());
					stack.pop();					
					tmpToken=stack.top();
				}else{break;}
			}

			if(tmpToken.Operator()=='*' || tmpToken.Operator()=='/' || tmpToken.Operator()=='%'){
				queue.addQueue(stack.top());
				stack.pop();
				tmpToken=stack.top();
			}if(tmpToken.IsLeftParen() || tmpToken.Operator()=='+' || tmpToken.Operator()=='-'){
				stack.push(t);
				goto out;
			}	
		}
	}
	
	//if right parentheses is reached all elements are added in the queue from the stack 
	//until the left parentheses is reached
	else if(t.IsRightParen()){
		tmpToken=stack.top();
	
		while(!tmpToken.IsLeftParen()){
			tmpToken=stack.top();		
			if(!tmpToken.IsLeftParen()){
				queue.addQueue(stack.top());
				stack.pop();
			}
		}	

		if(tmpToken.IsLeftParen()){
			stack.pop();
		}

		checkLeftParen=false;
	};

out: cin >> t;
}

//The rest of elements are added in the queue from the stack
while(!stack.isEmptyStack()){
queue.addQueue(stack.top());
stack.pop();
}
//Output of infix expression
cout<<"Infix ";
for(i=0; i<j; i++){
cout<<outToken[i]<<" ";
};
cout<<endl;


};