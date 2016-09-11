// File:      token.h
// Author:    Dan Brekke
// This file contains the specification for the token class.  
#ifndef TOKEN_CLASS
#define TOKEN_CLASS
#include <math.h>
#include <iostream>
using namespace std;
class Token
{
   public:
      Token();                         // no argument constructor
      Token(double);                   // double constructor
      Token(int);                      // int constructor
      Token(char);                     // char constructor
      bool Valid() const;              // true if token is valid
      bool IsOperand() const;          // true if token is an operand
      bool IsOperator() const;         // true if token is an operator
      bool IsLeftParen() const;        // true if token is a (
      bool IsRightParen() const;       // true if token is a )
      char Operator() const;           // returns '+' '-' '*' '/' '%' '^' 
      int Precedence() const;          // returns precedence of operator
      Token operator + (const Token&); // add Token to object
      Token operator - (const Token&); // subtract Token from object
      Token operator * (const Token&); // multiply object by Token
      Token operator / (const Token&); // divide object by Token
      Token operator % (const Token&); // modulus object by Token
      Token operator ^ (const Token&); // raise object to power of Token
      friend istream& operator >> (istream&,Token&); // overload input
      friend ostream& operator << (ostream&,const Token&); //overload output

   private:
      static bool unary; // to identify unary minus
      bool isnumber;     // identify whether it's a number or not
      double value;      // an operand
      char ch;           // an operator or parenthesis
      bool valid;        // true if Token is valid
};
#endif
