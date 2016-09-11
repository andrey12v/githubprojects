#ifndef _SECRETARYCLASS1_
#define _SECRETARYCLASS1_
#include <string>
#include <list>
#include <iterator>
#include <iostream>
#include "Secretary.h"
#include "FullTimeEmployee.h"
#include "SalaryEmployee.h"
using namespace std;

class SecretaryClass1 : public Secretary, public FullTimeEmployee,
                        public SalaryEmployee
{
   public:
      static void addDuty(const string&);
      static void printDuties(ostream&);
      void addSpecificDuty(const string&);
      void printSpecificDuties(ostream&) const;
      virtual void Report(ostream&) const;
      static string classification;
   private:
      static list<string> duties;
      list<string> specificduties;
};

#endif

