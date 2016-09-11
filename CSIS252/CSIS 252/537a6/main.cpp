#include<iostream>
#include <fstream>
#include <iomanip>
#include "date.h"

using namespace std;

int main(){
int i;
Date d1;
d1.setDate(4,3,2005);

//////////////The test of pointers//////////////
Date *ptrDate1;  //pointer variable of the type Date
ptrDate1 = &d1;	 //d1 stores the address of d1 in ptrDate
cout<<"The test of pointers"<<endl;
cout<<"We create pointer1 to the object of class Date."<<endl;
cout<<"The value of pointer1 is the memory adress of the object: "<<ptrDate1<<endl;
cout<<"The value of the object = ";
d1.print();
cout<<endl;
cout<<"The value of pointer1 \"(*pointer1).print() =\" ";
(*ptrDate1).print();
cout<<endl;
cout<<"The value of pointer1 \"pointer1->print() =\" ";
ptrDate1->print();
cout<<endl;
cout<<"Now we create a new pointer2 to the same object and change its value"<<endl;
Date *ptrDate2;  //pointer variable of the type Date
ptrDate2 = &d1;	 //d1 stores the address of d1 in ptrDate2
(*ptrDate2).setDate(10,17,2007);
cout<<"The value of pointer2 = ";
(*ptrDate2).print();
cout<<endl;
cout<<"Now the object and pointer1 has the same value as pointer2"<<endl;
cout<<"object.print() ";
d1.print();
cout<<" (*pointer1).print() ";
(*ptrDate1).print();
cout<<endl;
if (*ptrDate1==*ptrDate2){
	cout<<"Pointer1 and pointer2 are EQUAL!"<<endl;
}
else
{
	cout<<"Pointer1 and pointer2 are NOT equal!"<<endl;
}
ptrDate1=NULL;
ptrDate2=NULL;

cout<<"Now we create dinamic array of pointers to the class Date"<<endl;
Date *ptrArray=new Date[9];  //the value stored in ptrArray is the base address of the array
cout<<"Now we initialize the array"<<endl;

for(i=0; i<9; i++){
	ptrArray[i].setMonth(i+1);
	ptrArray[i].setDay(i+1);
	ptrArray[i].setYear(2000+(i+1));
}


for(i=0; i<9; i++){
	cout<<"the "<< i+1<<"th element of array: ";  
	ptrArray->print();
	cout<<endl;
	ptrArray++;
}

//cout<<"the last memory address of the pointer array is "<<ptrArray<<endl;
cout<<"Move on 9 elements back in the array of pointers"<<endl;
for(i=0; i<9; i++){
	ptrArray--;
	cout<<(9-i)<<"th element of the array ";
	ptrArray->print(FULLNUMERIC);
	cout<<endl;

}

cout<<"Pass the value of pointer array in the function"<<endl;
FuncPointer(*ptrArray);

cout<<"Now we can dellocate the memory of pointer array which is "<<ptrArray<<endl;
delete [] ptrArray;
ptrArray=NULL;
cout<<"Now the memory of pointer array is "<<setw(31)<<ptrArray<<endl;
cout<<endl;
cout<<"The test of overloading operators"<<endl;
Date d2;
d2.setDate(9,10,1993);
cout<<"The test of operator != ";
if (d1!=d2){
	d1.print();
	cout<<" and ";
	d2.print();
	cout<<" are not equal"<<endl;
}
else{
	d1.print();
	cout<<" and ";
	d2.print();
	cout<<" are equal"<<endl;
}

cout<<"The test of operator <= ";
if (d2<=d1){
	d2.print();
	cout<<" is less or equal to ";
	d1.print();
	cout<<endl;
}
else{
	d2.print();
	cout<<" is not less or equal to ";
	d1.print();
	cout<<endl;
}

cout<<"The test of operator  > ";
if (d2>d1){
	d2.print();
	cout<<" is more than ";
	d1.print();
	cout<<endl;
}
else{
	d2.print();
	cout<<" is not more than ";
	d1.print();
	cout<<endl;
}

cout<<"The test of operator  < ";
if (d2<d1){
	d2.print();
	cout<<" is less than ";
	d1.print();
	cout<<endl;
}
else{
	d2.print();
	cout<<" is not less than ";
	d1.print();
	cout<<endl;
}


cout<<"The test of operator << ";
cout<<d1<<endl;
cout<<"The test of the method print(ostream&, DateFormat=NUMERIC)"<<endl;
ofstream ofs;
ofs.open("datefile");
if (ofs.is_open()){
	d1.print(ofs, NUMERIC);
	cout<<"Now the date "<<d1<<" appeared in the file \"datefile\""<<endl;
	ofs.close();
}
else{ cout<<"Unable to open file \"datefile\""<<endl;
}

cout<<"The test of operator >> "<<endl;
cout<<"The value of object2 is "<<d2<<endl;
cout<<"read new value in the object2 from the file \"datefile\""<<endl;
ifstream ifs("datefile");
  if (ifs.is_open())
  {
    while (! ifs.eof() )
    {
      
     ifs>>d2; 
    }
    ifs.close();
  }

cout<<"Now new value of the object2 is "<<d2<<endl;
d2++;
cout<<"The test of post increment operator \"operator++(int)\" "<<d2<<endl;
++d2;
cout<<"The test of pre increment operator  \"operator++()\"    "<<d2<<endl;
d2--;
cout<<"The test of post decrement operator \"operator++(int)\" "<<d2<<endl;
--d2;
cout<<"The test of pre decrement operator \"operator++()\"     "<<d2<<endl;

cout<<"The test of method: operator-  subtracts the number of days"<<endl; 
cout<<"represented by argument from the Date object and returns a new Date"<<endl;
cout<<d2<<" - 537 = "<<d2-537<<endl;
cout<<"The test of method: operator+  adds the number of days"<<endl; 
cout<<"represented by argument to the Date object and returns a new Date"<<endl;
cout<<d2<<" + 537 = "<<d2+537<<endl;






return 0;
}







