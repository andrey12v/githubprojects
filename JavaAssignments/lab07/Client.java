//package lab07;
import java.util.*;

public class Client 
{
    public static void main(String[] args) 
    {
        //every time when new new object of LuckyNumber class is created it is also 
        //automatically gets random number
        LuckyNumber ln1 = new LuckyNumber("Test1");
        LuckyNumber ln2 = new LuckyNumber("Test2");
        LuckyNumber ln3 = new LuckyNumber("Test3");
        LuckyNumber ln4 = new LuckyNumber("Test4");
        LuckyNumber ln5 = new LuckyNumber("Test5");
        LuckyNumber ln6 = new LuckyNumber("Test6");
        LuckyNumber ln7 = new LuckyNumber("Test7");
                
               
        LuckyNumberList lnListClient = new LuckyNumberList();
        lnListClient.addLuckyNumber(ln1);
        lnListClient.addLuckyNumber(ln2);
        lnListClient.addLuckyNumber(ln3);
        lnListClient.addLuckyNumber(ln4);
        lnListClient.addLuckyNumber(ln5);
        lnListClient.addLuckyNumber(ln6);
        lnListClient.addLuckyNumber(ln7);
        
        System.out.println("Iterate over ALL numbers  ");
        Iterable<Position<LuckyNumber>> iterable = lnListClient.positions();
        Iterator<Position<LuckyNumber>> iterator = iterable.iterator();
        
        while(iterator.hasNext()) {
            System.out.println(iterator.next().getElement());
        }
                
        System.out.println("");
        System.out.println("Iterate over PRIME numbers only");
        Iterable<Position<LuckyNumber>> iterablePrime = lnListClient.primePositions();
        Iterator<Position<LuckyNumber>> iteratorPrime = iterablePrime.iterator();
        
        while(iteratorPrime.hasNext()) {
            System.out.println(iteratorPrime.next().getElement());
        }
        
        System.out.println("");
        System.out.println("Iterate over EVEN numbers only");
        Iterable<Position<LuckyNumber>> iterableEven = lnListClient.evenPositions();
        Iterator<Position<LuckyNumber>> iteratorEven = iterableEven.iterator();
        
        while(iteratorEven.hasNext()) {
            System.out.println(iteratorEven.next().getElement());
        }
        
        
    }
    
    
}
