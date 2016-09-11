// Filename:     itemtype.cpp
// Author:       Dan Brekke

// Description
// This file contains the implementation for the PhoneEntry class

#include "itemtype.h"

PhoneEntry::PhoneEntry(const string& n, const string& p)
{
   name = n;
   phone = p;
}

string PhoneEntry::GetName() const
{
   return name;
}

void PhoneEntry::SetName(const string& n)
{
   name=n;
}

string PhoneEntry::GetPhone() const
{
   return phone;
}

void PhoneEntry::SetPhone(const string& p)
{
   phone=p;
}

bool PhoneEntry::operator== (const PhoneEntry& entry) const
{
   return GetName() == entry.GetName();
}

bool PhoneEntry::operator!= (const PhoneEntry& entry) const
{
   return GetName() != entry.GetName();
}

bool PhoneEntry::operator<= (const PhoneEntry& entry) const
{
   return GetName() <= entry.GetName();
}

bool PhoneEntry::operator>= (const PhoneEntry& entry) const
{
   return GetName() >= entry.GetName();
}

bool PhoneEntry::operator< (const PhoneEntry& entry) const
{
   return GetName() < entry.GetName();
}

bool PhoneEntry::operator> (const PhoneEntry& entry) const
{
   return GetName() > entry.GetName();
}

ostream& operator << (ostream& o, const PhoneEntry& entry)
{
   o << setw(40) << left << entry.GetName();
   o << left << entry.GetPhone();
   return o;
}

