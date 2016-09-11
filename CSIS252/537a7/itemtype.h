// Filename:     itemtype.h
// Author:       Dan Brekke

// Description
// This file contains the specification for the PhoneEntry class

#ifndef _PhoneEntry_H_
#define _PhoneEntry_H_
#include <string>
#include <iostream>
#include <iomanip>
using namespace std;
class PhoneEntry
{
   public:
      PhoneEntry(const string& name = "",const string& phone = "");
      string GetName() const;
      void SetName(const string&);
      string GetPhone() const;
      void SetPhone(const string&);
      bool operator==(const PhoneEntry&) const;
      bool operator!=(const PhoneEntry&) const;
      bool operator<=(const PhoneEntry&) const;
      bool operator>=(const PhoneEntry&) const;
      bool operator<(const PhoneEntry&) const;
      bool operator>(const PhoneEntry&) const;
   private:
      string name;
      string phone;
};

typedef PhoneEntry Item;
ostream& operator << (ostream&,const PhoneEntry&);
#endif

