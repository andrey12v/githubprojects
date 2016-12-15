//Implementation of Array of Generic Type from Bag integrafce
package lab03;

public class ArrayBag<T> implements Bag<T>
{
    T[] bagList;
    private int count;
        
    public ArrayBag()
    {
        bagList = (T[]) new Object[1];
        count = 0;
    }
    
    public ArrayBag(int capacity)
    {
        bagList = (T[]) new Object[capacity];
        count = 0;
    }
    
    public int getCurrentSize()
    {
        return count;
    }
    
    public boolean isEmpty()
    {
        boolean emptyArray = true;
        if (bagList.length != 0)
        {
            emptyArray = false;
        }
        return emptyArray;
    }
    
    public boolean isFull()
    {
        return count==bagList.length;
    }
    
    public boolean add(T element)
    {
        boolean rv=false;
        if(count < bagList.length)
        {
            bagList[count] = element;
            count++;
            rv=true;
        }
        else 
        {
            //in order to resize the array we create a new array 
            //copy all elements from old array to a new one
            //create a shallow copy of the array by seting pointer from  
            //old array to a new one. newArray = oldArray 
            
            T[] tempBagList = (T[]) new Object[bagList.length*2];
            tempBagList = bagList;
            
            for(int i=0; i<bagList.length; i++)
            {
                tempBagList[i]=bagList[i];
            }
            bagList=tempBagList;
            tempBagList=null;
            count++;
        }
        return rv;
    }
    
    
    
    
    public int getArrayCapacity()
    {
        return bagList.length;
    }
    
    public boolean remove(T item)
    {
        boolean itemExists = false;
        int i=0;
        for(i=0; i<bagList.length; i++)
        {
            if (item.equals(bagList[i]))
            {
                bagList[i]=null;
                for(int j=i; j<bagList.length; j++)
                {
                    i++;
                    bagList[j]=bagList[i];
                }
            }
        }
        return itemExists;
    }
    
    public T remove()
    {
        int random = (int)(Math.random() * bagList.length-1);
        int index = random+1;
        T elem = bagList[random];
        for(int i=index; i<bagList.length; i++)
        {
            bagList[i-1]=bagList[i];
        }
        count--;
        
        return elem;
    }
    
    public void clear()
    {
        for(int i=0; i<bagList.length; i++)
        {
            bagList[i]=null;
        }
        bagList=null;
    }
    
    
    public T get(int i)
    {
        return bagList[i];
    }
    
    @Override
    public boolean equals( Object o )
    {
        boolean isEqual=false;
        
        if ( !(o instanceof ArrayBag) )
            isEqual=false;
        else
        {
            ArrayBag temp = (ArrayBag) o;
            for(int i=0; i<bagList.length; i++)
            {
                if (temp.get(i).equals(bagList[i]))
                {
                    isEqual=true;
                }
            }
        }
        return isEqual;
    }
    
    public int getFrequencyOf(T elem)
    {
        int freq=0;
        for(int i=0; i<bagList.length; i++)
        {
            if(elem==bagList[i])
            {
                freq++;
            }
        }
        return freq;
    }
    
    public boolean contains(T elem)
    {
        boolean rv=false;
        for(int i=0; i<bagList.length; i++)
        {
            if(elem==bagList[i])
            {
                rv=true;
            }
        }
        return rv;
    }
    
    //A method that returns the copy of the bag array, instance variable
    public T[] returnArray()
    {
        T[] newBagList = (T[]) new Object[bagList.length];
        //we make shallow copy here, create pointer to the values of 
        //the original array 
        System.arraycopy(bagList, 0, newBagList, 0, bagList.length);
        return newBagList;
    }
    
    
}
