OBJECTS=	main.o getLowPrecedence.o getEqualPrecedence.o getHighPrecedence.o returnTokenAfterDegree.o getsizeOfStack.o getsizeBeforeLeftParen.o getPostfixEvaluation.o getPostfix.o getPostfixExpression.o
CC = g++

LFLAGS= 
CFLAGS= 
EXE=prog10

$(EXE):				$(OBJECTS)
				$(CC) $(CFLAGS) -o $(EXE) $(OBJECTS) token.o $(LFLAGS)
main.o:				main.cpp 
				$(CC) $(CFLAGS) -c main.cpp
getLowPrecedence.o:		getLowPrecedence.cpp 
				$(CC) $(CFLAGS) -c getLowPrecedence.cpp 
getEqualPrecedence.o:		getEqualPrecedence.cpp 
				$(CC) $(CFLAGS) -c getEqualPrecedence.cpp 
getHighPrecedence.o:		getHighPrecedence.cpp 
				$(CC) $(CFLAGS) -c getHighPrecedence.cpp 
returnTokenAfterDegree.o:	returnTokenAfterDegree.cpp 
				$(CC) $(CFLAGS) -c returnTokenAfterDegree.cpp 
getsizeOfStack.o:		getsizeOfStack.cpp 
				$(CC) $(CFLAGS) -c getsizeOfStack.cpp 
getsizeBeforeLeftParen.o:	getsizeBeforeLeftParen.cpp 
				$(CC) $(CFLAGS) -c getsizeBeforeLeftParen.cpp 
getPostfixEvaluation.o:		getPostfixEvaluation.cpp 
				$(CC) $(CFLAGS) -c getPostfixEvaluation.cpp 
getPostfix.o:			getPostfix.cpp 
				$(CC) $(CFLAGS) -c getPostfix.cpp 
getPostfixExpression.o:		getPostfixExpression.cpp 
				$(CC) $(CFLAGS) -c getPostfixExpression.cpp 

clean:
		rm -rf  $(OBJECTS) $(EXE) core.*

