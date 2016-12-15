package lab03;

public class Player {
   
    private String name;
    private boolean played = false;
    private int jerseyNum;
    
    public Player()
    {
        name="";
        jerseyNum=0;
    }

    public Player(String name, boolean played, int jerseyNum)
    {
        this.name = name;
        this.played = played;
        this.jerseyNum = jerseyNum;
    }
    
    //Set and Get, accessor and mutator methods 
    public void setName (String name)
    {
        this.name = name;
    }
    public String getName()
    {
        return name;
    }
    
    public void setPlayed (boolean played)
    {
        this.played = played;
    }
    public boolean getPlayed()
    {
        return this.played;
    }
    
    public void setJerseyNum (int jerseyNum)
    {
        this.jerseyNum = jerseyNum;
    }
    public int getJerseyNum()
    {
        return this.jerseyNum;
    }
    
    @Override
    public boolean equals( Object o )
    {
        if ( !(o instanceof Player ) )
            return false;
        else
        {
            Player objPlayer = ( Player ) o;   
            return ( (objPlayer.getName().equals(this.name)) && (objPlayer.played == this.played) && (objPlayer.jerseyNum==objPlayer.jerseyNum) );
        }
    }
    

}
