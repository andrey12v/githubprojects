
public class Business extends Contact
{
    private String title;
    private String businessName;
    private static int businessCount;
    
    public Business()
    {
        businessCount++;
    }
    
    public Business( String name, String title, String businessName, String address, int phone )
    {
        super(name, address, phone);
        this.title = title;
        this.businessName = businessName;
        businessCount++;
    }
    
    public String getTitle()
    {
        return title;
    }
    
    public String getBusinessName()
    {
        return businessName;
    }
    
    public void setTitle ( String title )
    {
        this.title = title;
    }
    
    public void setBusinessName ( String businessName )
    {
        this.businessName = businessName;
    }
    
    public static int getBusinessCount ( )
    {
        return businessCount;
    }
    
    @Override
    public String toString()
    {
        return super.toString() + ":" + getClass().getName() + ":" + getTitle() + ":" + getBusinessName();
    }
    
    @Override
    public boolean equals( Object o )
    {
        if ( !(o instanceof Business ) )
            return false;
        else
        {
            Business obj = ( Business ) o;
            return ( super.equals( obj ) && ( title.equals(obj.getTitle()) ) && ( businessName.equals(obj.getBusinessName()) ) );
        }
    }
}
