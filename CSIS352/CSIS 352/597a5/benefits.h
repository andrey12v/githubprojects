// Andrey Vasilyev
// CSIS 352
// benefits.h
// 03/14/2009
// Assignment 5

#ifndef _BENEFITS_
#define _BENEFITS_

//****************** The description of the class Benefits ****************************** 
// The class benefits is used by the following inherited employee and secretary 
// classes: full time employee, salary employee, secretary, secretary classes 1, 2 and 3. 
// The class keeps information about expenses that employee spends on health, life and 
// dental insurance. The class has output methods that displays required information about 
// employee’s benefits.
//**************************************************************************************** 

class Benefits
{
	public:
		// default constructor
        //    preconditions - no validity checking is performed
        //       - arguments health, dental, life must be double variable 
	    //         if no arguments are given, the arguments are set to zero
        //    method input - none
        //    method output - arguments are set zero
		Benefits();

		// parametr list constructor
        //    preconditions - no validity checking is performed
        //       - arguments health, dental, life must be double variable 
	    //    method input - double variable health, dental, life
        //    method output - sets parametrs health, dental and life to the arguments
		void setBenefits(double inpHealth, double inpDental, double inpLife);
		
		//method: getHealth - gets the employee's health expense as a double value
	   	//    preconditions - none
      	//    postconditions - gets the employee's health expense as a double value
      	//    method input - none
      	//    method output - double
		double getHealth() const;
		
		//method: getDental - gets the employee's dental expense as a double value
	   	//    preconditions - none
      	//    postconditions - gets the employee's dental expense as a double value
      	//    method input - none
      	//    method output - double
		double getDental() const;	
				
		//method: getLife - gets the employee's life expense as a double value
	   	//    preconditions - none
      	//    postconditions - gets the employee's life expense as a double value
      	//    method input - none
      	//    method output - double
		double getLife() const;
	private:
		double health;
		double dental;
		double life;	
};
#endif
