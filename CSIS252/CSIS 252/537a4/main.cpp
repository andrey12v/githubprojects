#include<iostream>
#include "rectangle.h"
using namespace std;

int main(){
double inpLength, inpWidth;
Rectangle ConstrDef;
cout<<"The test of default constructor \n";
cout<<"Width of rectangle: "<<ConstrDef.getWidth()<<" and Length "<<ConstrDef.getLength()<<endl;
cout<<"Now enter the length of rectangle \n";
cin>>inpLength;
cout<<"Enter the width of rectangle \n";
cin>>inpWidth;
Rectangle Constr(inpLength,inpWidth);
cout<<"The test of constructor. \n";
cout<<"the area of rectangle= "<<Constr.getArea()<<" the perimeter of rectangle= "<<Constr.getPerimeter()<<endl;
//The test of arrays of class object

Rectangle ArrObj[2];
cout<<"The test of array of class objects! \n";


for(int i=0; i<2; i++){
	  cout<<"enter the length for rectangle " << i+1 << ": ";
      cin>>inpLength;
	  cout<<"enter the width for rectangle " << i+1 << ": ";
	  cin>>inpWidth;
	  ArrObj[i].setLength(inpLength);
	  ArrObj[i].setWidth(inpWidth);
}

cout<<"The test on passing array of objects as argument in class Rectangle! \n";
cout<<endl;
Rectangle PassArg;
PassArg.getArrayOfArguments(ArrObj);

return 0;
}
