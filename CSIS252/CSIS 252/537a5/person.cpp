// File:      person.cpp
// Name:      Andrey Vasilyev
// Class:     CSIS 252
// Program:   assignment 5
// Date:      10/04/07

//This file contains the implementation for the Person class. 
//The implementation includes the default constructor, and 
//methods of class Person. Some methods of class Person include methods of the class Data.  
//The methods are necessary to get the name of Person, 
//his/her birthday in the format mm/dd/yyyy. Other methods are necessary to get 
//the name of person, his/her birthday, age and day of week when he or she was born.

#include<string>
#include<iostream>
#include <fstream>	
#include<iomanip>
#include<string>

#include "person.h"
#include "date.h"
using namespace std;

//the default constructor
Person::Person(){
	name="";
	birthday=0;
}

//The method setBirthday sets birthday, the object of the class Data
void Person::setBirthday(Date &d){
	birthday=d;
}

//The method getBirthday returns birthday, the object of the class Data
Date Person::getBirthday(){
	return birthday;
} 

//The method setName sets the name of person
void Person::setName(string namePerson){
name=namePerson;
}

//The method setName returns the name of person
string Person::getName() const
{
return name;
}

//The method setName returns the age of person
int Person::getAge() const
{
Date Now;
Now.now();
int age;
age=birthday.yearDifference(Now);
return age;
}