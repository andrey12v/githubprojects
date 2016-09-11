// Filename:     list.cpp
// Author:       Dan Brekke
#include "list.h"

// Description
// This file contains the implementation for the List class

List::List()
{
  length = 0;
}

void List::MakeEmpty()
{
  length = 0;
}

bool List::IsFull() const 
{
  return (length == MAX_ITEMS);
}

int List::LengthIs() const 
{
  return length;
}


// Pre: item is not already in the list
//      list is not full
// Post: item is in the list
void List::InsertItem(const Item& item) 
{
  items[length] = item;
  length++; 
}

void List::DeleteItem(const Item& item) 
  // Pre:  item's key has been initialized. 
  //       An element in the list has a key that matches item's. 
  // Post: No element in the list has a key that matches item's. 
{
  int location = 0;
  
  while (items[location] != item)
    location++;

  items[location] = items[length - 1];
  length--;
}

void List::RetrieveItem(Item& item, bool& found)
{
  int location = 0;
  found = false;


  while (!found && location<length)
  {
     if (item == items[location])
        found = true;
     else
        location++;
  }
  if (found)
    item = items[location];
}

void List::ResetList()  
  // Post: currentPos has been initialized. 
{
  currentPos = -1;
}

void List::GetNextItem(Item& item) 
  // Pre:  there is a valid item at currentPos+1
  // Post: currentPos has been updated. 
  //       item is the list item at the updated currentPos position. 
{
  currentPos++;
  item = items[currentPos];
}

void List::PrintList() const
{
   for (int i=0; i<length; i++)
      cout << items[i] << endl;
}
