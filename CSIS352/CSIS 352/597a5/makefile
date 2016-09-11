# Andrey Vasilyev 
# COMS 352 - Asmt #5
# Makefile - prog5

CC = g++

OBJECTS = main.o date.o person.o employee.o salaryemployee.o hourlyemployee.o fulltimeemployee.o benefits.o parttimeemployee.o secretary.o secretaryclass3.o secretaryclass2.o secretaryclass1.o

LFLAGS = 

CFLAGS =  
 
EXE = prog5

$(EXE):		$(OBJECTS) 
		$(CC) $(CFLAGS) -o $(EXE) $(OBJECTS) $(LFLAGS) 

date.o:			date.cpp date.h
			$(CC) $(CFLAGS) -c date.cpp 

person.o:		person.cpp person.h
			$(CC) $(CFLAGS) -c person.cpp

employee.o:		employee.cpp employee.h
			$(CC) $(CFLAGS) -c employee.cpp

salaryemployee.o:	salaryemployee.cpp salaryemployee.h
			$(CC) $(CFLAGS) -c salaryemployee.cpp

hourlyemployee.o:	hourlyemployee.cpp hourlyemployee.h
			$(CC) $(CFLAGS) -c hourlyemployee.cpp

fulltimeemployee.o:	fulltimeemployee.cpp fulltimeemployee.h
			$(CC) $(CFLAGS) -c fulltimeemployee.cpp

benefits.o:		benefits.cpp benefits.h
			$(CC) $(CFLAGS) -c benefits.cpp

parttimeemployee.o:	parttimeemployee.cpp parttimeemployee.h
			$(CC) $(CFLAGS) -c parttimeemployee.cpp

secretary.o:		secretary.cpp secretary.h
			$(CC) $(CFLAGS) -c secretary.cpp

secretaryclass3.o:		secretaryclass3.cpp secretaryclass3.h
			$(CC) $(CFLAGS) -c secretaryclass3.cpp

secretaryclass2.o:		secretaryclass2.cpp secretaryclass2.h
						$(CC) $(CFLAGS) -c secretaryclass2.cpp

secretaryclass1.o:		secretaryclass1.cpp secretaryclass1.h
						$(CC) $(CFLAGS) -c secretaryclass1.cpp

main.o:		main.cpp person.h date.h employee.h salaryemployee.h hourlyemployee.h fulltimeemployee.h benefits.h parttimeemployee.h secretary.h secretaryclass3.h
			$(CC) $(CFLAGS) -c main.cpp 
clean:
		rm -rf $(EXE) $(OBJECTS) core.* *~