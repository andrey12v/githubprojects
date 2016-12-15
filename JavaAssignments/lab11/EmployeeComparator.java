public class EmployeeComparator implements Comparator<String>{
    
    public int compare(String a, String b){        
        
        return a.compareTo(b);
    
    } 
    
    public int compare(int a, int b){        
        
        int rv=0;
        if(a<b){ rv=-1;}
        if(a==b){ rv=0;}
        if(a>b){ rv=1;}
        
        return rv;
    }
    
    
}
