package lab02;
import java.io.*;
import java.util.*;

public class Client{
     
    public static void main(String[] args) 
    {
        int randNum=0;
        Random rand = new Random();
        // max = 30; min = -10;
        //int random = (int)(rand.nextInt(30 + 1 + 10) - 10);
        
        Scores scArr = new Scores(100);
        for(int i=0; i<100; i++)
        {
            randNum = (int)(rand.nextInt(100 + 1 + 100) - 100);
            scArr.add(randNum);
        }
        
        System.out.print(scArr.toString());
        scArr.remove();
        System.out.println("");
        System.out.println(scArr.get(75));
        System.out.println(scArr.getFrequencyOf(86));
        System.out.println(scArr.contains(86));
        
    }
    
}
