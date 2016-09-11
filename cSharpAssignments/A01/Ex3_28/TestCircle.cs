using System;
using System.Collections.Generic;
using System.Text;

public class TestCircle
{
   public static void Main( string[] args )
   {
       int inpRadius;
       Console.Write("Enter a radius of a circle: ");
       inpRadius = Convert.ToInt32(Console.ReadLine());

       Circle objCircle = new Circle(inpRadius);
       Console.WriteLine("The diametr is {0}", objCircle.Diametr());
       Console.WriteLine("The circumference is {0:f3}", objCircle.Circumference());
       Console.WriteLine("The are is {0:f3}", objCircle.Area());
 
   }
}
