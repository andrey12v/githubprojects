# Andrey Vasilyev 
# COMS 352 - Asmt #4
# Makefile - prog4

# Note: the descriptions in this makefile were created by Rick Walker
 
# This file allows an administrator of another unix system to "install"
# the 'prog2' program on his/her system. 

# MACRO DEFINITIONS

# The CC macro is used to indicate which compiler to use.
# Some folks may use g++, or some other compiler ... this allows you
# to write the rules and then have the installer specify the appropriate
# compile tool.

CC = g++

# The OBJECTS macro indicates all the .o files necessary to "build
# your executable ... to simplify later lines

OBJECTS = main.o date.o person.o employee.o employees.o hourlyemployee.o salaryemployee.o getemployees.o writeemployees.o

# The LFLAGS macro is used to tell the compiler to use other libraries.

LFLAGS = 

# The CFLAGS macro is used to indicate flags for the compiler.
# Eg. you MAY want to put '-g' on this line to generate symbol table
# information so that you can use a debugger to view your
# program in execution, or you could use the '-O' option to do
# optimized compilation, etc.  Again, as with other macros, it may
# be empty.

CFLAGS =  
 
# The EXE macro is used to indicate the name of the executable to
# be produced.

EXE = prog4

# This ends the MACRO DEFINITIONS SECTION

# DEPENDENCIES AND RULES SECTION
# This next section contains groups of lines that look like:
#
# target: dependencies
#       rules(s) or action(s)
#
# Note that each group has a line that starts on the left margin
# followed by one or more lines that begin with a TAB
# This is VERY IMPORTANT ... THE RULES MUST START WITH A TAB!!!!
# 
# The dependencies list the files that the target DEPENDS on,
# the rules tell how to (re)construct the target.
#
# Where ever you see a $(macro_name), the 'make' utility makes a 
# text substitution, using the Right Hand Side of the macro
# definitions from the above section.
#
# Compiling source code to create the object files.
# This is an example only and is modified for your needs
# A backslash continues a command on the next line if needed.
# The backslash would have to be THE LAST character on the line.
# A semicolon can be used to separate multiple commands.

$(EXE):		$(OBJECTS) 
		$(CC) $(CFLAGS) -o $(EXE) $(OBJECTS) $(LFLAGS) 

date.o:		date.cpp date.h
		$(CC) $(CFLAGS) -c date.cpp 

person.o:	person.cpp person.h
		$(CC) $(CFLAGS) -c person.cpp

employee.o:	employee.cpp employee.h
		$(CC) $(CFLAGS) -c employee.cpp

employees.o:	employees.cpp employees.h
		$(CC) $(CFLAGS) -c employees.cpp

hourlyemployee.o:	hourlyemployee.cpp hourlyemployee.h
					$(CC) $(CFLAGS) -c hourlyemployee.cpp

salaryemployee.o:	salaryemployee.cpp salaryemployee.h
					$(CC) $(CFLAGS) -c salaryemployee.cpp

getemployees.o:		getemployees.cpp
					$(CC) $(CFLAGS) -c getemployees.cpp

writeemployees.o:	writeemployees.cpp
					$(CC) $(CFLAGS) -c writeemployees.cpp

main.o:		main.cpp person.h date.h person.h employee.h hourlyemployee.h salaryemployee.h
			$(CC) $(CFLAGS) -c main.cpp 

# The next lines allow you to type 'make clean' to remove unnecessary
# files following compilation and linking of your program.  Generally,
# the executable is not deleted but for purposes of this class, remove
# the executable to reduce the size of the tarred and compressed file
# you are to electronically handin.

clean:
		rm -rf $(EXE) $(OBJECTS) core.* *~ payroll employees 
