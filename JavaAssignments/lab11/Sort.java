import java.lang.*;
import java.util.*;

public class Sort {

    public static <K> void bubbleSort( K[] data, Comparator<K> comp )
    {
        for ( int i = 0; i < data.length; i++ )
        {
            for ( int j = 0; j < data.length - 1; j++ )
            {
                if ( comp.compare( data[j], data[j+1] ) <= 0 )
                {
                    K temp = data[j];
                    data[j] = data[j+1];
                    data[j+1] = temp;
                }
            }
        }
    }
    
    public static <K> void merge(K[ ] S1, K[ ] S2, K[ ] S, Comparator<K> comp) { 
        int i = 0, j = 0;
        while (i + j < S.length) { 
            if (j == S2.length || (i < S1.length && comp.compare(S1[i], S2[j]) < 0))
                S[i+j] = S1[i++]; // copy ith element of S1 and increment i
            else
                S[i+j] = S2[j++]; // copy jth element of S2 and increment j
            } 
    }
    
    public static <K> void mergeSort(K[ ] S, Comparator<K> comp) { 
        int n = S.length;
        if (n < 2) return; // array is trivially sorted
        int mid = n/2;
        K[ ] S1 = Arrays.copyOfRange(S, 0, mid); // copy of first half
        K[ ] S2 = Arrays.copyOfRange(S, mid, n); // copy of second half
        // conquer (with recursion)
        mergeSort(S1, comp); // sort copy of first half
        mergeSort(S2, comp); // sort copy of second half
        // merge results
        merge(S1, S2, S, comp); // merge sorted halves back into original
    }
    
    
    /*private static <K> void merge(K[ ] in, K[ ] out, Comparator<K> comp, int start, int inc) {  
        int end1 = Math.min(start + inc, in.length); // boundary for run 1
        int end2 = Math.min(start + 2 * inc, in.length); // boundary for run 2
        int x=start; // index into run 1
        int y=start+inc; // index into run 2
        int z=start; // index into output
        while (x < end1 && y < end2)
        {
            if (comp.compare(in[x], in[y]) < 0)
                out[z++] = in[x++]; // take next from run 1
            else
                out[z++] = in[y++]; // take next from run 2
        }
        if (x < end1) System.arraycopy(in, x, out, z, end1 - x); // copy rest of run 1
        else if (y < end2) System.arraycopy(in, y, out, z, end2 - y); // copy rest of run 2
    }  

    public static <K> void mergeSort(K[ ] orig, Comparator<K> comp) { 
       int n = orig.length;
       K[ ] src = orig; // alias for the original
       K[ ] dest = (K[ ]) new Object[n]; // make a new temporary array
       K[ ] temp; // reference used only for swapping
       for (int i=1; i < n; i *= 2) 
           { // each iteration sorts all runs of length i
               for (int j=0; j < n; j += 2*i) // each pass merges two runs of length i
                   merge(src, dest, comp, j, i);
                   temp = src; src = dest; dest = temp; // reverse roles of the arrays
           } 
       if (orig != src)
       System.arraycopy(src, 0, orig, 0, n); // additional copy to get result to original
    }*/
    
    
    public static <K> void quickSort(Queue<K> S, Comparator<K> comp) { 
        int n = S.size( );
        if (n < 2) return; // queue is trivially sorted
        K pivot = S.first( ); // using first as arbitrary pivot
        Queue<K> L = new LinkedQueue<>( );
        Queue<K> E = new LinkedQueue<>( );
        Queue<K> G = new LinkedQueue<>( );
        while (!S.isEmpty( )) { // divide original into L, E, and G
            K element = S.dequeue( );
            int c = comp.compare(element, pivot);
            if (c < 0) // element is less than pivot
                L.enqueue(element);
            else if (c == 0) // element is equal to pivot
                E.enqueue(element);
            else // element is greater than pivot
            G.enqueue(element);
        }  // conquer
        quickSort(L, comp); // sort elements less than pivot
        quickSort(G, comp); // sort elements greater than pivot
        // concatenate results
        while (!L.isEmpty( )){
            S.enqueue(L.dequeue( ));
        }
        while (!E.isEmpty( )){
            S.enqueue(E.dequeue( ));
        }
        while (!G.isEmpty( )){
            S.enqueue(G.dequeue( ));
        }
    }
    
    public static <K> void radixSort(K[ ] data) 
    { 
        Comparator comp1 = new DeptComparator();
        Sort.mergeSort( data, comp1);
        Comparator comp2 = new NameComparator();
        Sort.mergeSort(data, comp2);
    }
    
    //********************* These methods are not used in the assignment ************************
    //******* These methods are implemented for references and educational purposes *************
    //The method converts Array to Queue. The method is based on Generic Data Types 
    //(we can use any data type as an input parameter)
    public static <K> LinkedQueue<K> convertFromArrToQueue(K[] arrEmp)
    {
        LinkedQueue<K> lq = new LinkedQueue<>();
        for(K e : arrEmp)
        {
            lq.enqueue(e);
        }
        return lq;
    }
    
    //The method converts Queue to Array. The method is based on Generic Data Types
    //(we can use any data type as an input parameter)
    public static <K> K[] convertFromQueueToArr(LinkedQueue<K> queueEmp)
    {
        K[] arrEmp = (K[])new Object[queueEmp.size()];  
        int i=0;
        while(!queueEmp.isEmpty())
        {
            arrEmp[i]=queueEmp.dequeue();
            i++;
        }
        return arrEmp;
    }
   
    
    
}
