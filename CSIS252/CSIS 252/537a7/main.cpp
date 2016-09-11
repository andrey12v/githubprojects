#include<iostream>
#include <fstream>
#include "list.h"
#include "itemtype.h"
using namespace std;

int main(int argc,char *argv[]){

// check the number of arguments which were input from the command line
if (argc != 2)
   {
      cout << "type the " << argv[0] << " <inputfile>\n";
      return 0;
  }


List listitem;
PhoneEntry item;
string name;
string number;
int count=0;
ifstream ifs(argv[1]);

 if (ifs.is_open())
  {
    	do{
			getline(ifs, name);
			getline(ifs, number);
			item.SetName(name);
			item.SetPhone(number);
			listitem.InsertItem(item);
			count=count+1;		
			if(count>=100){
			break;}
		}while(!ifs.eof());
		
    ifs.close();
  }
  else{ cout<<"Unable to open file"<<endl;};

cout<< setw(40) << left << "Name";
cout<< left << "Phone"<<endl;

listitem.PrintList();


return 0;

}