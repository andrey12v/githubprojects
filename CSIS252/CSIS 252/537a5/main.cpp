// File:      main.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 5
// Date:      10/04/07


// This file contains the main function.
// This program will create the list of people which with include their names, 
// birthday, age and day of week when he or she was born.  The information will 
// be given from the file "peoplefile". The file will provide people's names and 
// their date of birthday. During execution of the program it will created 
// the array of people and the program will calculate people's age. 
// Finally, the program will output people's name, the day of week when person was born, 
// his or her the date of birth and age.


#include<string>
#include<iostream>
#include <fstream>	
#include<iomanip>	//the library which is necessary to work with string functions
#include"date.h"	//the declaration of class Date
#include"person.h"	//the declaration of class Person

using namespace std;

int main(int argc,char *argv[]){		

// check the number of arguments which were input from the command line
if (argc != 2)
   {
      cout << "usage: " << argv[0] << " <inputfile>\n";
      return 0;
  }


char namePerson[25];  //local character variable to keep person's name
char ch;  		  //local character variable to keep the sign "/" 	

int monthBD;		//stores the month of birthday
int dayBD;		//stores the month of day
int yearBD;		//stores the month of year

//count which is necessary to order th list of people descendly according to his/her age 
int count=0;		

Date d;	
Person People[100];	//array of objects of class Person


ifstream inpFile;			//the object of the class ifstream which is necessary to input data from file into array 
inpFile.open (argv[1]);		//argv[1] - is the second argument from the command line that is the name of file
	  	int i=0;		
		//Ciphers output from the file and stored in the pointer array 
		if (inpFile.is_open())
		{
  
			while (!inpFile.eof())
			{
				//the algoritm stores people's names,their birthday 
				inpFile.getline(namePerson,25);
				People[i].setName(namePerson);
				inpFile>>monthBD;
				d.setMonth(monthBD);
				inpFile>>ch;
				inpFile>>dayBD;
				d.setDay(dayBD);
				inpFile>>ch;
				inpFile>>yearBD;
				d.setYear(yearBD);
				People[i].setBirthday(d);
				inpFile.clear();
				inpFile.ignore(200, '\n');
				i++;
				count++;
	
			};
	  	
		inpFile.close();
		}
		else
		{
			cout << "Error opening file";
		};	


Person tmp;  //the temporary object of class Person

//the algoritm sorts the peiople's data descendly according their age
for(i=0; i<count-1; i++){
 for(int j=i+1; j<count; j++){
	if (People[i].getAge()<People[j].getAge()){
		tmp=People[i];
		People[i]=People[j];
		People[j]=tmp;
	}
 }
}

//The output of the header of the list
cout<<left;
cout<<setw(25)<<"Name"<<setw(15)<<"Day"<<setw(15)<<"Birthday"<<setw(11)<<"Age"<<endl;
cout<<setfill('-');
cout<<setw(24)<<""<<setw(14)<<" "<<setw(16)<<" "<<setw(12)<<" "<<endl;

//The output people's list in the definite format with the definite length between columns 
//For this purpose it was used the function - setw()
cout<<setfill(' ');
for(i=0; i<count; i++){

	cout<<setw(25)<<People[i].getName()<<setw(15)<<People[i].getBirthday().getDayOfWeek()
	<<People[i].getBirthday().getMonth()<<"/"<<People[i].getBirthday().getDay()<<"/"<<setw(10)<<People[i].getBirthday().getYear()
	<<setw(10)<<People[i].getAge()<<endl;
}

return 0;
}