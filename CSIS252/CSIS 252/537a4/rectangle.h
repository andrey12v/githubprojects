#include<iostream>
using namespace std;

#ifndef _CIRCLE_H_
#define _CIRCLE_H_

class Rectangle
{
   public:
      Rectangle(double=0, double=0);  // constructor with default radius
      void setLength(double);
      void setWidth(double);
	  double getLength() const;
      double getWidth() const;
      double getArea() const;
      double getPerimeter() const;
	  void getArrayOfArguments(Rectangle RecArg[2]); 	 
   private:
      double length;
	  double width;
};

#endif