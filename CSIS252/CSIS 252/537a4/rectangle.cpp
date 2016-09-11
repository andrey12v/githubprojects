#include<iostream>
#include"rectangle.h"
using namespace std;


Rectangle::Rectangle(double inpLength,double inpWidth){
length=inpLength;
width=inpWidth;
}

void Rectangle::setLength(double inpLength){
length=inpLength;
}

void Rectangle::setWidth(double inpWidth){
width=inpWidth;
}

double Rectangle::getLength() const
{
return length;
}

double Rectangle::getWidth() const
{
return width;
}

double Rectangle::getArea() const
{
return width*length;
}

double Rectangle::getPerimeter() const
{
return width*2+length*2;
}

void Rectangle::getArrayOfArguments(Rectangle RecArg[2]) 	 
{
	for(int i=0; i<2; i++){
     cout<<"Length of rectangle " << i+1 << ": "<<RecArg[i].getLength()<<endl;
	 cout<<"Width of rectangle " << i+1 << ": "<<RecArg[i].getWidth()<<endl;
	 cout<<"Area of rectangle " << i+1 << ": "<<RecArg[i].getArea()<<endl;
	 cout<<"Perimeter of rectangle " << i+1 << ": "<<RecArg[i].getPerimeter()<<endl;
	}
}



