# Andrey Vasilyev 
# COMS 352 - Asmt #7
# Makefile - prog7

CC = g++

OBJECTS = main.o employee.o

LFLAGS = 

CFLAGS =  
 
EXE = prog7

$(EXE):		$(OBJECTS) 
		$(CC) $(CFLAGS) -o $(EXE) $(OBJECTS) $(LFLAGS) 

employee.o:	employee.cpp employee.h
			$(CC) $(CFLAGS) -c employee.cpp 

main.o:		main.cpp vertex.h graph.h
			$(CC) $(CFLAGS) -c main.cpp 
clean:
		rm -rf $(EXE) $(OBJECTS) core.* *~