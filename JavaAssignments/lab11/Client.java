import java.util.*;

public class Client 
{
    public static void main(String[] args) {
        
                
        /*String s1="Sachin";  
        String s2="Sachin";  
        String s3="Ratan";  
        System.out.println(s1.compareTo(s2));//0  
        System.out.println(s1.compareTo(s3));//1(because s1>s3)  
        System.out.println(s3.compareTo(s1));//-1(because s3 < s1 )*/  
        
        Employee[] empArr = new Employee[ 6 ];        
        empArr[ 0 ] = new Employee(8, "Joe", 50, 1998);
        empArr[ 1 ] = new Employee(90, "Tom", 48, 2001);
        empArr[ 2 ] = new Employee(7, "Anderson", 12, 1999);
        empArr[ 3 ] = new Employee(10, "Penny", 12, 2005);     
        empArr[ 4 ] = new Employee(34, "Sue", 88, 2011); 
        empArr[ 5 ] = new Employee(5, "Fred", 12, 2002);
        
        System.out.println("Unsorted array: ");
        printArray(empArr);
        System.out.println();
       
        //Use Strongly Typed Comparator in order to compare values by Name
        //For this purpose we implemented the class NameComparator that makes standard string comparison in java
        //if trhe strings are equal then it returns 0; if the first string is greater than the second one then it retrurns 1
        //and if the first string is less than the second one then it returns -1 
        Comparator comp1 = new NameComparator();
        Sort.mergeSort( empArr, comp1);
        System.out.println("Sorted array by name: ");
        printArray( empArr );
        System.out.println();
        
        //Use Strongly Typed Comparator in order to compare departments
        //the results are return in the same way. 0 - equual;
        //1 - first is greater than the second one
        //-1 - first is less then the second one
        Comparator comp2 = new DeptComparator();
        //in order to use advantage of quick sort we convert our input parameter from array to queue
        //and then we pass our aray to quicksort method to sort the array
        LinkedQueue<Employee> lq = convertFromArrToQueue(empArr);
        Sort.quickSort(lq, comp2);
        System.out.println("Sorted array by department: ");
        while(!lq.isEmpty())
        {
            System.out.println(lq.dequeue().toString());
        }
        System.out.println("");
        
        
        System.out.println("Sorted array with radix sort: ");
        Sort.radixSort(empArr);
        printArray(empArr);
        
    }
   
    public static void printArray(Employee[] data )
    {
        for ( int i = 0; i < data.length; i++ )
            System.out.println( data[i] );
    }
    
    //The method converts Array to Queue for sorting algorithms
    //The method uses Employee as a Strongly Typed Data Type 
    public static LinkedQueue<Employee> convertFromArrToQueue(Employee[] arrEmp)
    {
        LinkedQueue<Employee> lq = new LinkedQueue<>();
        for(Employee e : arrEmp)
        {
            lq.enqueue(e);
        }
        
        return lq;
    }
    
    //The method converts Queue to Regular Array
    //The method uses Employee as a Strongly Typed Data Type
    public static Employee[] convertFromQueueToArr(LinkedQueue<Employee> queueEmp)
    {
        Employee[] arrEmp = new Employee[queueEmp.size()];
        int i=0;
        while(!queueEmp.isEmpty())
        {
            arrEmp[i]=queueEmp.dequeue();
            i++;
        }
        
        return arrEmp;
    }
    
    
}
