#include<iostream>
using namespace std;
void ArrayStrings();
void Enumiration();
void Teststrings();

int main(){
int var;
cout<<"What do you want to test. \n";
cout<<"Press the number of variant. \n";
one:
cout<<"1 - Strings \n";
cout<<"2 - Enumiration \n";
cout<<"3 - Array strings \n";
cin>>var;
switch(var){
case 1:
Teststrings();

break;

case 2:
Enumiration();
break;

case 3:
ArrayStrings();
break;

default:
cout<<"Choose 1, 2 or 3 \n";
goto one;
}







return 0;
}