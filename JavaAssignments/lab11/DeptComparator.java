public class DeptComparator implements Comparator<Employee>{
    
    public int compare(Employee e1, Employee e2){        
        
        if ( e1 == null || e2 == null )  
        {
            //throw null pointer exception
        }
        int rv=0;        
        int dept1=e1.getDept();
        int dept2=e2.getDept();
        if(dept1<dept2)
        {
            rv=-1;
        }
        else if(dept1>dept2)
        {
            rv=1;
        }
        
        return rv;
    
    } 
}
