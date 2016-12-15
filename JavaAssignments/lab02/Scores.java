package lab02;
import java.io.*;
import java.util.*;

public class Scores implements Bag {

    private int[] list;
    private int count;
    private int[] temp;

    public Scores()
    {
        list = new int[50];
        count = 0;
    }

    public Scores(int arrSize)
    {
        list = new int[arrSize];
        count = 0;
    }

    public int getCurrentSize()
    {
        return count;
    }

    public boolean isEmpty()
    {
        boolean emptyArray = true;
        if (list.length != 0)
        {
            emptyArray = false;
        }
        return emptyArray;
    }

    public void clear()
    {
         for(int i=0; i<list.length; i++)
         {
             list[i]=0;
         }
    }

    public void add(int num)
    {
        if(count < list.length)
        {
            list[count] = num;
            count++;
        }
        else
        {
            temp = new int[list.length*2];
            for(int i=0; i<list.length; i++)
            {
                temp[i]=list[i];
            }
            //assign reference to the memory from temporary array to list array
			list=temp;
			//set reference of temp array to null
            temp=null;
            //add element to the resized array and increment counter
            list[count]=num;
            count++;
        }
    }

    public int getFrequencyOf(int num)
    {
        int numberOfNum=0;
        for(int i=0; i<list.length; i++)
        {
            if(list[i]==num)
            {
                numberOfNum++;
            }
        }
        return numberOfNum;
    }


    public boolean contains(int num)
    {
        boolean isContain = false;
        for(int i=0; i<list.length; i++)
        {
            if(list[i]==num)
            {
                isContain = true;
                break;
            }
        }
        return isContain;
    }

    public void remove()
    {
        int random = (int)(Math.random() * list.length-1);
        list[random]=0;
        int index = random+1;
        for(int i=index; i<list.length; i++)
        {
            list[i-1]=list[i];
        }
        count--;
    }

    public int get(int i)
    {
        int arrayElement=0;
        try
        {
            arrayElement = list[i];
        }
        catch(ArrayIndexOutOfBoundsException e)
        {
            System.out.println("The index is out of the bounds of the array"  + e );
        }
        return arrayElement;
    }


    @Override
    public String toString()
    {
        String output="";
        for(int i=0; i<list.length; i++)
        {
            output += list[i] + " ";
        }
        return output;
    }

    @Override
    public boolean equals( Object o )
    {
        boolean isEqual=false;

        if ( !(o instanceof Scores) )
            isEqual=false;
        else
        {
            Scores temp = (Scores) o;
            for(int i=0; i<list.length; i++)
            {
                if (temp.get(i) == list[i])
                {
                    isEqual=true;
                }
            }
        }
        return isEqual;
    }

}
