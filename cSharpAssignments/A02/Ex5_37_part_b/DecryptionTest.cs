using System;
using System.Collections.Generic;
using System.Text;


public class DecryptionTest
{
    public static void Main(string[] args)
    {
        int inpNumber;
        Console.WriteLine("Encrypted number {0}", 7531);
        Decryption d = new Decryption(7531);
        d.DoDecryption();
        Console.WriteLine("Decrypted number {0}", d.DecryptedNumber);
        Console.Write("Enter encrypted four digit number: ");
        inpNumber = Convert.ToInt32(Console.ReadLine());
        d.Number = inpNumber;
        d.DoDecryption();
        Console.WriteLine("Decrypted number {0}", d.DecryptedNumber);


    }
}
