public class NameComparator implements Comparator<Employee>{
    
    public int compare(Employee e1, Employee e2){        
        
        if ( e1 == null || e2 == null )  
        {
            throw new NullPointerException("Parameter Type cannot be null");
        }
                
        String name1=e1.getName();
        String name2=e2.getName();
        return name1.compareTo(name2);
    
    } 
}
