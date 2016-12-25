package lab04;
import javax.swing.JOptionPane;
import java.io.File;

public class RecursionClient 
{
    public static void main(String[] args) 
    {
        
        //Test of JOption Pane Dialog
        /*String firstNumber = JOptionPane.showInputDialog( "Enter first integer" );
        String secondNumber = JOptionPane.showInputDialog( "Enter second integer" );
        int number1 = Integer.parseInt( firstNumber );
        int number2 = Integer.parseInt( secondNumber );
        int sum = number1 + number2; // add numbers
        JOptionPane.showMessageDialog( null, "The sum is " + sum,
        "Sum of Two Integers", JOptionPane.PLAIN_MESSAGE );*/
        
        System.out.println("Test of recursive functions: ");
        System.out.print("Calculation of Log2(8) = ");
        System.out.println(Recursion.getLog(8));
        System.out.print("Calculation of factorial for number 8 = ");
        System.out.println(Recursion.factorial(8));
        System.out.print("The product of numbers 3 and 8 = ");
        System.out.println(Recursion.product(3, 8));
        System.out.print("Isabel calculation for the arra {1, 2, 3, 4} = ");
        int[] myList = {1, 2, 3, 4};
        System.out.println(Recursion.isabel(myList));
        System.out.println("Test of serach function for the file File.txt ");
        File name = new File("test");
        Recursion.find(name, "File.txt"); 
        
    }
}
