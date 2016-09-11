#include<iostream>
#include<string>
#include<fstream>
#include <iomanip>
using namespace std;

void ArrayStrings(){
char seats[8][3];	

ifstream inpData;			//the object of the class ifstream which is necessary to input data from file into array 
inpData.open ("data.txt");	
		
		//Ciphers output from the file and stored in the pointer array 
		if (inpData.is_open())
		{
  	  		while (!inpData.eof())
			{
				for(int i=0; i<8; i++){
					for(int j=0; j<3; j++){
					inpData>>seats[i][j];
					}
				}
			};
	  	inpData.close();
		}
		else
		{
			cout << "Error opening file";
		}	

int TClass, row, SeatNum, i, j;  
char seat;
 
cout<<"What kind of ticket do you prefere: fist class or economy class? \n";
one: 
cout<<"Press 1 for fist class or 2 for economy class \n";
cin>>TClass; 
if (TClass<1 || TClass>2){
goto one;
}

cout<<"Choose desired seat \n";
cout<<"* indicates that the seat is available \n";
cout<<"X indicates that the seat is occupied \n";
if (TClass==1){
for(i=0; i<3; i++){
	if (i==0){
	cout<<setw(7);}
	else{
	cout<<"Row "<<i<<" ";}
	for(j=0; j<3; j++){
	cout<<" "<<seats[i][j];
	}
	cout<<endl;
	}
}
else{
	
	cout<<setw(7);
	for(j=0; j<3; j++){
	cout<<" "<<seats[0][j];
	}
	cout<<endl;	
	for(i=3; i<8; i++){
	cout<<"Row "<<i<<" ";
		for(j=0; j<3; j++){
		cout<<" "<<seats[i][j];
		}
	cout<<endl;
	}
}

two:
cout<<"Choose the number of row. \n"; 
cin>>row;

if (TClass<2)
{
if (row<1 || row>2){
goto two;}
}
else{
if (row<3 || row>7){
goto two;}
}

three:
cout<<"Choose the number of place: A, B, C \n"; 
cin>>seat;
switch(seat){
case 'a':
SeatNum=0;
break;
case 'b': 
SeatNum=1;
break;
case 'c': 
SeatNum=2;
break;
case 'd': 
SeatNum=3;
break;
case 'e': 
SeatNum=4;
break;
case 'f':
SeatNum=5;
break;
default: 
cout<<"The place is invalid. \n";
goto three;
break;
}


if (seats[row][SeatNum]=='X'){
cout<<"The place is occupied or you typed a wrong letter.\n";
}
else if (seats[row][SeatNum]=='*'){
seats[row][SeatNum]='X';
cout<<"Thank you for registration. \n";
}

ofstream outData;			//the object of the class ifstream which is necessary to input data from file into array 
outData.open ("data.txt");	
		
		//Ciphers output from the file and stored in the pointer array 
		if (outData.is_open())
		{
				for(int i=0; i<8; i++){
					for(int j=0; j<3; j++){
					outData<<" "<<seats[i][j];
					}
				outData<<endl;
				}
	  	outData.close();
		}
		else
		{
			cout << "Error opening file";
		}	


			
for(i=0; i<8; i++){
	if (i==0){
	cout<<setw(7);}
	else{
	cout<<"Row "<<i<<" ";}
	for(j=0; j<3; j++){
	cout<<" "<<seats[i][j];
	}
	cout<<endl;
	}
}