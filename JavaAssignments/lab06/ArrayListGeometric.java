package lab06;

public class ArrayListGeometric<E> implements List<E> 
{ 
    public int capacity=16; 
    private E[ ] data; 
    private int size = 0; 
    public int counter=0;
    double increment=0.0;
    //public ArrayListGeometric() { this(capacity); }
    
    public ArrayListGeometric(double inpIncrement) { 
        
        increment=inpIncrement;
        capacity = (int) ((1+increment)*capacity);
        data = (E[ ]) new Object[capacity];
    }
    
    public int size() { return size; }
    public boolean isEmpty() { return size == 0; }
    public E get(int i) throws IndexOutOfBoundsException { 
        checkIndex(i, size); 
        return data[i]; 
    }
    
    public E set(int i, E e) throws IndexOutOfBoundsException { 
        checkIndex(i, size);
        E temp = data[i];
        data[i] = e; 
        return temp;
    }
    
    //insert element at specific location, index. The menthod contains two parameters: index number and
    //element to insert in the array
    public void add(int i, E e) throws IndexOutOfBoundsException, IllegalStateException { 
        checkIndex(i, size + 1); 
        if (size == data.length)
        {
            resize( (int)((1+increment)*data.length) ); 
        } 
        //shift all elements of the array to one index further and 
        //provide space for a new element to insert in the array
        for (int k=size-1; k>=i; k--)
        {
            data[k+1] = data[k]; 
        }
        data[i] = e;
        size++;
    }
    
    public E remove(int i) throws IndexOutOfBoundsException { 
        checkIndex(i, size); 
        E temp = data[i]; 
        for (int k=i; k < size-1; k++)
        {
             data[k] = data[k+1];
        }
        data[size-1] = null;     
        size--;     
        return temp;
    }
        
    protected void checkIndex(int i, int n) throws IndexOutOfBoundsException { 
        if (i < 0 || i >= n) 
        {
            throw new IndexOutOfBoundsException("Illegal index: " + i);
        }
    }
    
    //resize the existing array by creating temporaryy array with new array size, capacity
    protected void resize(int capacity) 
    { 
        E[ ] temp = (E[ ]) new Object[capacity];
        for (int k=0; k < size; k++)
        {
            temp[k] = data[k];
        }
        data = temp;
        temp=null;
        counter++;
    }
     
}
