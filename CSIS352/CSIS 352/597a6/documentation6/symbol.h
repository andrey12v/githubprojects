#ifndef _SYMBOL_H_
#define _SYMBOL_H_

#include <string>
#include <iostream>
using namespace std;
const int TABLE_SIZE=13;

class Symbol
{
   public:
      string getSymbol() const;
      void setSymbol(const string&);
      int getValue() const;
      void setValue(int);
      bool operator==(const Symbol&) const;
      int Hash() const;
   private:
      string s; // the key, and what will be hashed
      int value;
};

ostream& operator<<(ostream&,const Symbol&);

#endif

