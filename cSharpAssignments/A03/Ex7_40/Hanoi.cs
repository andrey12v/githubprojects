using System;
using System.Collections.Generic;
using System.Text;


public class Hanoi
{

    public static void moveDisks(int n, string inpPeg1, string inpPeg2, string inpPeg3) //ftu 
    {
        if (n <= 1)
        {
            Console.WriteLine(inpPeg1 + " --> " + inpPeg2);
        }
        else
        {
            moveDisks(n - 1, inpPeg1, inpPeg3, inpPeg2);
            System.Console.WriteLine(inpPeg1 + " --> " + inpPeg2);
            moveDisks(n - 1, inpPeg3, inpPeg2, inpPeg1);
        }
    }


}

