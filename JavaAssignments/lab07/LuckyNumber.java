//Declare LuckyNumber class to insert its objects to the Dynamic Array ""LuckyNumberList  
import java.util.*;

public class LuckyNumber 
{
    private String name;
    private int luckyNumber;
    
    public LuckyNumber()
    {}
    
    //Lucky Number class consists of name and random number from 0 to 9
    public LuckyNumber(String name)
    {
        this.name=name;
        Random random = new Random();
        this.luckyNumber = random.nextInt(10);
    }
    
    public String getNamer()
    {
        return this.name;
    }
    
    public int getLuckyNumber()
    {
        return this.luckyNumber;
    }
    
    @Override
    public String toString()
    {
        return "Lucky Name = " + this.name + " Lucky Number = " + this.luckyNumber;
    }
    
    @Override
    public boolean equals(Object o)
    {
        if(!(o instanceof LuckyNumber))
        {
            return false;
        }
        LuckyNumber ln = (LuckyNumber) o;
        return (ln.getNamer().equals(this.name) && ln.getLuckyNumber() == this.luckyNumber);
    }
    
    
}
