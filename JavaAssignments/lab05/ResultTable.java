package lab05;

public class ResultTable 
{
    private int N;
    private String staticValue;
    private String dynamicValue;
    
    public ResultTable(){}
    
    public ResultTable(int N, String staticValue, String dynamicValue)
    {
        this.N = N;
        this.staticValue = staticValue;
        this.dynamicValue = dynamicValue;
    }
    
    public int getN()
    {
        return N;
    }
    
    public void setN (int N)
    {
        this.N = N;
    }
    
    public String getStaticValue()
    {
        return staticValue;
    }
    
    public void setStaticValue (String staticValue)
    {
        this.staticValue = staticValue;
    }
    
    public String getDynamicValue()
    {
        return dynamicValue;
    }
    
    public void setDynamicValue (String dynamicValue)
    {
        this.dynamicValue = dynamicValue;
    }
}
