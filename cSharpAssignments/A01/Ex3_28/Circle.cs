using System;
using System.Collections.Generic;
using System.Text;

public class Circle
{

    private int radius;

    public Circle(int inpRadius)
    {
        radius = inpRadius;
    }

    public int Diametr()
    {
        return 2 * radius;
    }

    public double Circumference()
    {
        return 2 * Math.PI * radius;
    }

    public double Area()
    {
        return Math.PI * Math.Pow(radius, 2);
    }

}

