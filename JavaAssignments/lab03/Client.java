package lab03;
import java.io.*;
import java.util.*;

public class Client 
{
    public static void main(String[] args) 
    {
        
        ArrayBag<Player> team = new ArrayBag<>(3);
        Player p1 = new Player("Andrey", true, 2);
        Player p2 = new Player("Bob", false, 3);
        Player p3 = new Player("John", true, 4);
        team.add(p1);
        team.add(p2);
        team.add(p3);
        System.out.println(team.getArrayCapacity());
    }
}
