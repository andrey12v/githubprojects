using System;
using System.Collections.Generic;
using System.Text;


public class Decryption
{
    private int number; // original number
    private int digit1; // first digit
    private int digit2; // second digit
    private int digit3; // third digit
    private int digit4; // fourth digit
    private int decryptedNumber; 

    public Decryption()
    {
        number = 0;
    }

    public Decryption(int inpNumber)
    {
        number = inpNumber;
    }

    // Decryption a four-digit number
    public void DoDecryption()
    {
        digit1 = (number % 100)/10;
        digit2 = (number % 10);
        digit3 = (number / 1000);
        digit4 = (number % 1000)/100;
        
        digit1 = CalculateDigit(digit1);
        digit2 = CalculateDigit(digit2);
        digit3 = CalculateDigit(digit3);
        digit4 = CalculateDigit(digit4);

        decryptedNumber = digit1 * 1000 + digit2 * 100 + digit3 * 10 + digit4;
        //Console.WriteLine("d1={0}, d2={1}, d3={2}, d4={3}", digit1, digit2, digit3, digit4);
    }
    
    private int CalculateDigit(int inpDigit)
    {
        if (inpDigit > 6 && inpDigit < 10)
        {
            switch (inpDigit)
            {
                case 7:
                    return 0;
                    //break;
                case 8:
                    return 1;
                    //break;
                case 9:
                    return 2;
                    //break;
            }
        }
        else 
        {
            return inpDigit + 10 - 7;
        }

        return 0;
    }

    public int Number 
    {
        set 
        {
            number = value; 
        }
    }

    public int DecryptedNumber 
    {
        get 
        {
            return decryptedNumber;
        }
    }

}
