// Filename:     list.h
// Author:       Dan Brekke

/*
 Description
     This file contains the specification for the ADT List class.  The
     list is unordered (the order of items in the list is determined 
     by the order of insertions and deletions
 Requirements
   - the class specification for the item to be stored in the list
     is contained in the file itemtype.h
   - itemtype.h must contain a typedef to define Item.  For example,
     if the file itemtype.h contains the specification for a DVD class:
        typedef DVD Item;
     This is required because this ADT stores the type Item
   - the relational operators == and != must be defined for the item to
     be stored in the list.
*/

#ifndef _LIST_H_
#define _LIST_H_
#include "itemtype.h"
#include <iostream>
using namespace std;

const int MAX_ITEMS=100;   // max number of items in the list

class List
{
   public:
      // method: constructor - creates and initializes list to empty
      //    preconditions - none
      //    postconditions - the list has been created and initialized
      //    method input - none
      //    method output - none
      List();

      // method: MakeEmpty - clears out the list and makes it empty
      //    preconditions - none
      //    postconditions - list is empty
      //    method input - none
      //    method output - none
      void MakeEmpty();

      // method: IsFull - returns whether the list is full or not
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - none
      bool IsFull() const;

      // method: LengthIs - returns the number of items in the list
      //    preconditions - none
      //    postconditions - none
      //    method input - none
      //    method output - none
      int LengthIs() const;

      // method: InsertItem - adds an item to the end of the list
      //    preconditions - item is a valid item of the class being
      //                    stored in the list
      //                  - the list is not full
      //    postconditions - item has been added to the end of the list
      //    method input - none
      //    method output - item
      void InsertItem(const Item& item);

      // method: DeleteItem - deletes an item from the list.  The last
      //                      item in the list replaces the deleted item
      //    preconditions - item must exist in the list
      //    postconditions - item has been deleted 
      //    method input - item to be deleted
      //    method output - none
      void DeleteItem(const Item& item);

      // method: RetrieveItem - retrives an item from the list
      //    preconditions - none
      //    postconditions - if found, the item is returned
      //    method input - the item
      //    method output - the item (if found)
      //                  - a bool flag indicating whether found or not
      void RetrieveItem(Item& item, bool& found);

      // method: ResetList - initializes the list to be traversed
      //                     from the beginning of the list
      //    preconditions - none
      //    postconditions - list is ready to be traversed from beginning
      //    method input - none
      //    method output - none
      void ResetList(); // reset the list for GetNextItem

      // method: GetNextItem - used in traversing the list, it returns
      //                       the next item in the list
      //    preconditions - the next item in the list exists (i.e. the
      //                    list has been reset and there is still at
      //                    one item left in the traversal
      //    postconditions - the next item has been returned
      //                   - the position of the next item is updated
      //    method input - none
      //    method output - the next item in the list traversal
      void GetNextItem(Item& item); // get one item at a time

      // method: PrintList - outputs all the items in the list to the screen
      //    preconditions - operator << overloaded for the Item class
      //    postconditions - list has been output to the screen
      //    method input - none
      //    method output - none
      void PrintList() const;

   private:
      int length;   // the number of items in the list
      Item items[MAX_ITEMS];  // the array storing the list items
      int currentPos; // the position of the next item in the traversal
};
#endif

