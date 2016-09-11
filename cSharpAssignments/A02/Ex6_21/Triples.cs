using System;
using System.Collections.Generic;
using System.Text;

public class Triples
{
    private int side1, side2, hyp;
    
    public void FindTriples()
    {
        Console.WriteLine("Pythagorean finds triples for seide1, side2 and hypotenuse in");
        Console.WriteLine("which all sides are no lager than 500");
        Console.WriteLine("\t\t\t    SIDE1\tSIDE2\tHYP");
    
        for(side1=1; side1<=500; side1++)
         {
          for (side2 = 1; side2 <= 500; side2++)
            {
            for (hyp = 1; hyp <= 500; hyp++)
                 {
                 if ((side1 * side1 + side2 * side2 )== hyp * hyp) 
                        {
                                
                                Console.Write("Press any key to continue . . . ");
                                Console.ReadKey(true);
                                Console.WriteLine("{0}\t{1}\t{2}", side1, side2, hyp);
                         }
                                      
                    }
                }
            }
       }
    
    
 }

