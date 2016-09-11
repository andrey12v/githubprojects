#ifndef _LIST_H_
#define _LIST_H_

#include <iostream>
#include <fstream>
#include "phoneentry.h"
using namespace std;
const int MAX_ITEMS=100;

template <class Item>
class List
{
	public:
      // method: constructor - creates and initializes list to empty
      //    preconditions - none
      //    postconditions - the list has been created and initialized,
      //                     and the array dynamically allocated
      //    method input - the size of the list
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
      int length;     // the number of items in the list
      Item items[MAX_ITEMS];    // the array storing the list items
      int currentPos; // the position of the next item in the traversal
};
#endif


template <class Item>
ostream& operator << (ostream& outObj, List<Item>& list)
{
	Item item;
	list.ResetList();
	for(int i=0; i<list.LengthIs(); i++)
	{
		list.GetNextItem(item);
		outObj<<item<<endl;
	}
	

	return outObj;
}


template <class Item>
List<Item>::List()
{
  length = 0;
}

template <class Item>
void List<Item>::MakeEmpty()
{
  length = 0;
}

template <class Item>
bool List<Item>::IsFull() const 
{
  return (length == MAX_ITEMS);
}

template <class Item>
int List<Item>::LengthIs() const 
{
  return length;
}


// Pre: item is not already in the list
//      list is not full
// Post: item is in the list
template <class Item>
void List<Item>::InsertItem(const Item& item) 
{
	int i,j, location;
	bool check=false;

	if (length>0){
		for(location=0; location<length; location++){
			if (item<items[location]){
				
				j=length-1;
				for(i=length; i>location; i--){
					items[i]=items[j];
					j--;
				}

				items[location] = item;
				length++;
				
				check=true;		
			break;		
			}
		}
		if(!check){
			items[length] = item;
			length++; 		
			//cout<<location<<endl;
		}
	}
	else{
		items[length] = item;
		length++; 	}

}

template <class Item>
void List<Item>::DeleteItem(const Item& item) 
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

template <class Item>
void List<Item>::RetrieveItem(Item& item, bool& found)
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

template <class Item>
void List<Item>::ResetList()  
  // Post: currentPos has been initialized. 
{
  currentPos = -1;
}

template <class Item>
void List<Item>::GetNextItem(Item& item) 
  // Pre:  there is a valid item at currentPos+1
  // Post: currentPos has been updated. 
  //       item is the list item at the updated currentPos position. 
{
  currentPos++;
  item = items[currentPos];
}

template <class Item>
void List<Item>::PrintList() const
{
   for (int i=0; i<length; i++)
      cout << items[i] << endl;
}

