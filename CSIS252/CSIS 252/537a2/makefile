
# MACRO DEFINITIONS

CC = g++

OBJECTS = main.o ArrayStrings.o enumiration.o teststrings.o

# The LFLAGS macro is used to tell the compiler to use other libraries.
LFLAGS = 

# The CFLAGS macro is used to indicate flags for the compiler.
CFLAGS =  

EXE = prog1


$(EXE):		$(OBJECTS) 
		$(CC) $(CFLAGS) -o $(EXE) $(OBJECTS) $(LFLAGS) 

main.o:		main.cpp
		$(CC) $(CFLAGS) -c main.cpp 

ArrayStrings.o:		ArrayStrings.cpp
			$(CC) $(CFLAGS) -c ArrayStrings.cpp 		

enumiration.o:	enumiration.cpp
		$(CC) $(CFLAGS) -c enumiration.cpp 

teststrings.o:	teststrings.cpp
		$(CC) $(CFLAGS) -c teststrings.cpp 		
		
				   
# The next lines allow you to type 'make clean' to remove unnecessary
# files following compilation and linking of your program.  Generally,
# the executable is not deleted but for purposes of this class, remove
# the executable to reduce the size of the tarred and compressed file
# you are to electronically handin.

clean:
		rm -rf $(EXE) $(OBJECTS) core.* 

