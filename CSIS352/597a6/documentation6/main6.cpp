#include <iostream>
#include "hashtable.h"
#include "something.h"
using namespace std;

int main()
{
// Something must have function called Hash() returning an int
// Something must have operator== overloaded
// Something must define TABLE_SIZE
   HashTable<Something> hashtable(TABLE_SIZE);
   Something s;
   .
   .
   .
   if (!hashtable.inTable(s))
   {
      hashtable.addEntry(s);
      cout << "************ entered ***********\n";
   }
   else
   {
      cout << s << " aready in the table\n"; // overloaded << 
      cout << "************ not entered ***********\n";
   }

   cout << "--------------------------------------------------------------\n";

   Something s2;
   // assign s2 to be the key value of Something
   if (hashtable.inTable(s2))
   {
      hashtable.retrieveEntry(s2); // s2 is pass by reference and gets the matching object
      // I had mine return bool so it could have been
      // if (hashtable.retrieveEntry(s2))
      .
      .
      .
   }
   else
      // s2 is not in the hash table
      .
      .
      .
   cout << "there were " << hashtable.Collisions() << " in the hash table\n";
   return 0;
}

