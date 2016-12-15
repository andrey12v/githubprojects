package lab02;

public interface Bag {
    
    public int getCurrentSize();
    
    public boolean isEmpty();
    
    public void clear();
    
    public void add(int num);
    
    public int getFrequencyOf(int num);
    
    public boolean contains(int num);
    
    public void remove();
    
    public int get(int i);
    
    @Override
    public String toString();
    
    @Override
    public boolean equals( Object o );
}
