package lab05;
import java.util.*;
import java.lang.*;
import java.text.*;

public class Client 
{
    public static void main(String[] args) {
        
        int staticTimerDiff, dynamicTimerDiff;
        int i, counter=0;
        int N=1024;
        int randomNumber;
        long startTime, endTime;
        
        System.out.println("Time taken to run static and dynamic queues and stacks");
        try
        {
            while(N>1000)
            {
                //********************* Begin Testing of Static Queues and Stacks *****************************
                // Declare Static Queue
                Queue<Integer> arrayQ = new ArrayQueue<>(N);
                Random random = new Random();
                for (i = 0; i < N; i++){
                    randomNumber = random.nextInt(200)-100;
                    arrayQ.enqueue(randomNumber);
                }
                startTime = System.currentTimeMillis();
                
                // Declare Static Stack
                Stack<Integer> arrayS = new ArrayStack<>(N);
                //Dequeue array of queue and push elements from the queue to the stack
                //repeat this process until array queue is empty
                while (!arrayQ.isEmpty())
                {
                    arrayS.push(arrayQ.dequeue());
                }
                //Pop elements from the stack and add them back to the queue
                //Repeat this process until the stack gets empty
                while (!arrayS.isEmpty())
                {
                    arrayQ.enqueue(arrayS.pop());
                }
                //calculate how much time it takes to complete all these operqations for static queue and stack
                endTime = System.currentTimeMillis();
                staticTimerDiff = (int)(endTime-startTime);
                //********************* End Testing of Static Queues and Stacks **********************
                
                //********************* Begin Testing of Dynamic Queues and Stacks *****************************
                //Declare Dynamic Queue 
                Queue<Integer> linkedQueue = new LinkedQueue<>();
                for (i = 0; i < N; i++){
                    randomNumber = random.nextInt(200)-100;
                    linkedQueue.enqueue(randomNumber);
                }
                startTime = System.currentTimeMillis();
                
                //Declare Dynamic Stack 
                Stack<Integer> linkedStack = new LinkedStack<>();
                while (!arrayQ.isEmpty())
                {
                    arrayS.push(arrayQ.dequeue());
                }
                while (!arrayS.isEmpty())
                {
                    arrayQ.enqueue(arrayS.pop());
                }
                endTime = System.currentTimeMillis();
                dynamicTimerDiff = (int)(endTime-startTime);
                
                //***** End conversion of N, Static and Dynamic Values into Comma Delimited Strings ********
                System.out.println("N: " + N + getFirstSpace(N) + " Static Time (msec): " + staticTimerDiff + getSecondSpace(staticTimerDiff) + " Dynamic Time (msec): " + dynamicTimerDiff);
                counter++;
                N=N*2;
            }
        }
        catch(OutOfMemoryError e)
        {
            System.out.println("Out of memory!");
        }
    
    }
    
    public static String getFirstSpace(int number)
    {
        int numOfDigits = String.valueOf(number).length();
        String spaces=""; 
        int numOfSpaces = 10 - numOfDigits;
        for(int i=0; i<numOfSpaces; i++)
        {
            spaces += " ";
        }
        return spaces;
    }
    
    public static String getSecondSpace(int number)
    {
        int numOfDigits = String.valueOf(number).length();
        String spaces=""; 
        int numOfSpaces = 4 - numOfDigits;
        for(int i=0; i<numOfSpaces; i++)
        {
            spaces += " ";
        }
        return spaces;
    }
    
}
