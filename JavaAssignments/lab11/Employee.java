public class Employee 
{
    private int id;
    private String name = null;
    private int dept;
    private int hired;
   
    public Employee( ) {  }
    
    public Employee(int id, String name, int dept, int hired)
    {
        this.id = id;
        this.name = name;
        this.dept = dept;
        this.hired = hired;
    }
    
    public void setID(int id) {this.id = id;}
    
    public int getID( )  {return id;}
    
    public void setName(String name) {this.name = name;}
    
    public String getName() {return name;}
    
    public void setDept(int dept) {this.dept = dept;}
    
    public int getDept() {return dept;}
    
    public void setHired(int hired) {this.hired = hired;}
    
    public int getHired() {return hired;}
        
    public String toString( )
    {
        return "id: " + id + " name: " + name + " dept: " + dept + " hired: " + hired;
    }
}
