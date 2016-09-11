////////////////////////////////////////////////////The test of enumiration and typedef
#include<iostream>
#include<string>
#include<cmath>
#include<ctime>
using namespace std;

void Enumiration(){
typedef int integer; 
integer number;
integer choice;
string inp;
enum GameChoice {well, scissors, paper};
GameChoice PlayerChoice, ComputerChoice;
cout<<"The test of enumiration and typdef \n";
cout<<"Hello! This is gambling game! The rules of the game are the following.\n"; 
cout<<"Two players choose one choice: paper, scissors or a well. \n"; 
cout<<"Scissors can cut paper but sink in a well. Paper can cover a well\n"; 
cout<<"but can be cut by scissors. If two players choose the same choice \n"; 
cout<<"like paper or scissors nobody win. You will play with computer, \n"; 
cout<<"which chooses its variant randomly. \n"; 
one:
cout<<"1-Well, 2-scissors or 3-paper. Choose one cipher of three varionts! \n";
cin>>choice;

srand(time(NULL)); //sprand is a good option for randoming needs
number = rand() % 3 + 1; //random from 3 to 1

switch (choice){
case 1:PlayerChoice=well;
cout<<"player choice: well \n";
	break;
case 2:PlayerChoice=scissors;
cout<<"player choice: scissors \n";
	break;
case 3:PlayerChoice=paper;
cout<<"player choice: paper \n";
	break;
}

switch (number){
case 1:ComputerChoice=well;
	cout<<"computer choice: well \n";
break;
case 2:ComputerChoice=scissors;
cout<<"computer choice: scissors \n";
	break;
case 3:ComputerChoice=paper;
	cout<<"computer choice: paper \n";
break;
}


if ((PlayerChoice==well && ComputerChoice==well) || (PlayerChoice==paper && ComputerChoice==paper) || (PlayerChoice==scissors && ComputerChoice==scissors))
cout<<"You have the same choice. Nobody won. Play again!  \n";
else if(PlayerChoice==well && ComputerChoice==scissors)
cout<<"You won! Your choice is well. The choice of computer is scissors \n";
else if(PlayerChoice==well && ComputerChoice==paper)
cout<<"You lost! Your choice is well. The choice of computer is paper \n";
else if(PlayerChoice==paper && ComputerChoice==scissors)
cout<<"You lost! Your choice is paper. The choice of computer is scissors \n";
else if(PlayerChoice==paper && ComputerChoice==well)
cout<<"You won! Your choice is paper. The choice of computer is well \n";
else if(PlayerChoice==scissors && ComputerChoice==well)
cout<<"You lost! Your choice is scissors. The choice of computer is well \n";
else if(PlayerChoice==scissors && ComputerChoice==paper)
cout<<"You won! Your choice is scissors. The choice of computer is paper \n";
cout<<"Do you want play again? Yes No \n";
cin>>inp;
if (inp=="Yes" || inp=="yes" || inp=="y") {
goto one;
}
}

////////////////////////////////////////////////////The test of enumiration and typedef
