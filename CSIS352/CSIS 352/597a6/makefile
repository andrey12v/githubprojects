# Andrey Vasilyev 
# COMS 352 - Asmt #6
# Makefile - prog6

CC = g++

OBJECTS = main.o employee.o

LFLAGS = 

CFLAGS =  
 
EXE = prog6

$(EXE):		$(OBJECTS) 
		$(CC) $(CFLAGS) -o $(EXE) $(OBJECTS) $(LFLAGS) 

symbol.o:	employee.cpp employee.h
			$(CC) $(CFLAGS) -c employee.cpp 

main.o:		main.cpp employee.h dynamichashtable.h
			$(CC) $(CFLAGS) -c main.cpp 
clean:
		rm -rf $(EXE) $(OBJECTS) core.* *~