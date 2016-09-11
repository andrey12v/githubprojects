// Andrey Vasilyev
// CSIS 352
// benefits.cpp
// 03/14/2009
// Assignment 5

#include<iostream>
#include "benefits.h"

using namespace std;

Benefits::Benefits()
{
	health=0.0;
	dental=0.0;
	life=0.0;
}

void Benefits::setBenefits(double inpHealth, double inpDental, double inpLife)
{
	health=inpHealth;
	dental=inpDental;
	life=inpLife;
}

double Benefits::getHealth() const
{
	return health;
}

double Benefits::getDental() const
{
	return dental;
}	

double Benefits::getLife() const
{
	return life;
}
