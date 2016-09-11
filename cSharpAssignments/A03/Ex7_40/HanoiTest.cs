using System;
using System.Collections.Generic;
using System.Text;

public class HanoiTest
{
    public static void Main(string[] args)
    {

        string peg1, peg2, peg3;
        int numberOfDisks;
        Console.WriteLine("Hello, this is program Hanoi");
        one:
        Console.Write("Enter the number of disks to be moved from 1 to 9: ");
        numberOfDisks = Convert.ToInt32(Console.ReadLine());
        if (numberOfDisks < 1 || numberOfDisks > 9)
        {
            goto one;
        }
        else
        {
            Console.Write("The peg on which the disks are initially threaded: ");
            peg1 = Convert.ToString(Console.ReadLine());
            Console.Write("The peg to which the stack of disks is to be moved: ");
            peg2 = Convert.ToString(Console.ReadLine());
            Console.Write("The peg to be used as a temporary holding area: ");
            peg3 = Convert.ToString(Console.ReadLine());
            Hanoi.moveDisks(numberOfDisks, peg1, peg2, peg3);
        }


    }
}

