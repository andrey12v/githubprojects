#include<iomanip> //this is for setprecision
#include<cctype>
#include<cstdlib>
#include<iostream>
#include<string>
#include<ctime>
#include<cmath>
#include<fstream>
using namespace std;


/////////////////////////////////////////////The test of strings
void Teststrings(){
char ch1, ch2;
string::size_type len;
int SizeStr, i;
string FistName, LastName, FullName;
one: 
cout<<"Enter the fist and the last name"<<endl;
cin>>FistName>>LastName;
FullName=FistName + " " + LastName;
//The test of the legth
len=FullName.length();
SizeStr=static_cast<int>(len);

//Thde test of functions isdigit(), ispunct() 
for(i=0; i<SizeStr; i++){
	if(isdigit(FullName[i]) || ispunct(FullName[i])){
	cout<<"You typed "<<FullName[i]<<" in you name. Try again!"<<endl;
	FullName.erase();
	goto one;};
};


//The test of the isupper() function 
if (islower(FistName[0])){
cout<<"The fist letter in your fist name has lower case."<<endl;
cout<<"Rewrite the fist letter in your fist and last name with upper case"<<endl;
FullName.erase();
goto one;
}
else if (islower(LastName[0])){
cout<<"The fist letter in your last name has lower case."<<endl;
cout<<"Rewrite the fist letter in your fist and last name with upper case"<<endl; 
FullName.erase();
goto one;
}


//the test of find() function
cout<<"The test of function \" find()\""<<endl;
two:
cout<<"Enter any two letters from your name: "<<endl;
cin>>ch1>>ch2;
if (isdigit(ch1)){
	cout<<"You entered "<<ch1<<" instead of the fist letter. Try again!"<<endl;
	goto two;
	}
else if (isdigit(ch2)) {
cout<<"You entered "<<ch2<<" instead of the second letter. Try again!"<<endl;
	goto two;
}



if (FullName.find(ch1)>10000){
	cout<<"The "<<ch1<<" letter doesn't exist in your name. Try again!"<<endl; 
	goto two;
}
else if (FullName.find(ch2)>10000){
cout<<"The "<<ch2<<" letter doesn't exist in your name. Try again!"<<endl; 
	goto two;
}
else {
	cout<<ch1<<" places "<<(FullName.find(ch1)+1)<<"th position"<<endl;
	cout<<ch2<<" places "<<(FullName.find(ch2)+1)<<"th position"<<endl;
}

int num1, num2;
num1=FullName.find(ch1);
num2=FullName.find(ch2);

//The test of substring function
if(num1>num2){
cout<<"The substring from your name: "<<FullName.substr(num2,(num1-1))<<endl;
}
else
{
cout<<"The substring from your name: "<<FullName.substr(num1,(num2-1))<<endl;
}

//the test of tab
cout<<"The test of tab: "<<FistName<<" \t"<<LastName<<endl;
//The test of setw and setfill
double d;
cout<<"The test of functions: right, setw and setfill \n";
cout<<right;
for(i=0; i<FullName.length(); i++){
modf((double)i/2,&d);	
if((modf((double)i/2,&d))>0){
	cout<<setw(2)<<setfill('-')<<FullName[i];
	}
	else{
	cout<<setw(2)<<setfill('^')<<FullName[i];
	}
}
cout<<endl;


}


/////////////////////////////////////////////The test of strings

