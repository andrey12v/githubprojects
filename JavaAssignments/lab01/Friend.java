
public class Friend extends Contact
{
    private String birthday;
    private String favoriteMovie;
    private static int friendCount;
    
    public Friend()
    {
        friendCount++;
    }
    
    public Friend( String name, String address, int phone, String birthday, String favoriteMovie )
    {
        super( name, address, phone );
        this.birthday = birthday;
        this.favoriteMovie = favoriteMovie;
        friendCount++;
    }
    
    public String getBirthday ()
    {
        return birthday;
    }
    
    public String getFavoriteMovie ()
    {
        return favoriteMovie;
    }
    
    public void setBirthday ( String birthday )
    {
        this.birthday = birthday;
    }
    
    public void setFavoriteMovie ( String favoriteMovie )
    {
        this.favoriteMovie = favoriteMovie;
    }
    
    public static int getFriendCount ()
    {
        return friendCount;
    }
    
    public String toString()
    {
        return super.toString() + ":" + getClass().getName() + ":" + getBirthday() + ":" + getFavoriteMovie();
    }
    
    public boolean equals( Object o )
    {
        if ( !(o instanceof Friend ) )
            return false;
        else
        {
            Friend obj = ( Friend ) o;
            return ( super.equals( obj ) && ( birthday.equals(obj.getBirthday()) ) && ( favoriteMovie.equals(obj.getFavoriteMovie()) ) );
        }
        
    }
}
