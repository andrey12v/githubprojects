
public class Contact 
{
    private String name;
    private String address;
    private int phone;
    private static int contactCount;
    
    public Contact()
    {
        contactCount++;
    }
    
    public Contact( String name, String address, int phone )
    {
        this.name = name;
        this.address = address;
        this.phone = phone;
        contactCount++;
    }
    
    public String getName ()
    {
        return name;
    }
    
    public String getAddress ()
    {
        return address;
    }
    
    public int getPhone ()
    {
        return phone;
    }
    
    public void setName ( String name )
    {
        this.name = name;
    }
    
    public void setAddress ( String address )
    {
        this.address = address;
    }
    
    public void setPhone ( int phone )
    {
        this.phone = phone;
    }
    
    public static int getContactCount()
    {
        return contactCount;
    }
    
    @Override
    public String toString()
    {
        return super.toString() + ":" + getClass().getName() + ":" + getName() + ":" + getAddress() + ":" + getPhone();
    }
    
    @Override
    public boolean equals( Object o )
    {
        if ( !(o instanceof Contact ) )
            return false;
        else
        {
            Contact obj = ( Business ) o;
            return ( ( name.equals(obj.getName()) ) && ( address.equals(obj.getAddress())) && ( phone == obj.getPhone()));
            
        }
        
    }
}
