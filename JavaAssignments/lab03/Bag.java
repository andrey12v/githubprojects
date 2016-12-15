package lab03;

public interface Bag<T> {
    
    public int getCurrentSize();
    
    public boolean isEmpty();
    
    public boolean isFull();
    
    public boolean add(T elem);
    
    public T remove();
    
    public boolean remove(T elem);
    
    public void clear();
    
    public int getFrequencyOf(T elem);
    
    public boolean contains(T elem);
    
    public T[] returnArray();
    
    @Override
    public boolean equals(Object o );
}
