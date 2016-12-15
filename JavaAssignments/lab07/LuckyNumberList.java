
import java.util.NoSuchElementException;

public class LuckyNumberList {
    
    //Declare Linked Positional List to insert objects of LuckyNumber class
    //This list is strongly typed for LuckyNumber Class
    private LinkedPositionalList<LuckyNumber> lnList = null;

    public LuckyNumberList() {
        lnList = new LinkedPositionalList<>();
    }

    public void addLuckyNumber(LuckyNumber inpLN) {
        lnList.addLast(inpLN);
    }

    //******************** BEGIN REGULAR ITERATOR ********************
    //----- nested PositionIterator class -----
    private class PositionIterator implements Iterator<Position<LuckyNumber>> {
        private Position<LuckyNumber> cursor = lnList.first();   // position of the next element to report
        private Position<LuckyNumber> recent = null;               // position of last reported element
        /**
         * Tests whether the iterator has a next object.
         */
        @Override
        public boolean hasNext() {
            return (cursor != null);
        }
        /**
         * Returns the next position in the iterator.
         */
        @Override
        public Position<LuckyNumber> next() throws NoSuchElementException {
            if (cursor == null) {
                throw new NoSuchElementException("nothing left ");
            }
            recent = cursor;
            cursor = lnList.after(cursor);
            return recent;
        }
        /**
         * Removes the element returned by most recent call to next.
         */
        @Override
        public void remove() throws IllegalStateException {
            if (recent == null) {
                throw new IllegalStateException("nothing to remove");
            }
            lnList.remove(recent);         // remove from outer list
            recent = null;              // do not allow remove again until next is called
        }
    } //----- end of nested PositionIterator class -----

    private class PositionIterable implements Iterable<Position<LuckyNumber>> {
        @Override
        public Iterator<Position<LuckyNumber>> iterator() {
            return new PositionIterator();
        }
    } //----- end of nested PositionIterable class -----
    public Iterable<Position<LuckyNumber>> positions( ) {
        return new PositionIterable( );  // create a new instace of the inner class
    }
    //******************** END REGULAR ITERATOR ********************
    
    //******************** BEGIN PRIME ITERATOR ********************
    //----- nested PositionIterator class -----
    private class PrimePositionIterator implements Iterator<Position<LuckyNumber>>{
        private Position<LuckyNumber> cursor = lnList.first();   // position of the next element to report
        private Position<LuckyNumber> recent = null;               // position of last reported element
        
        /** Tests whether the iterator has a next object. */
        //The method hasNext() checks if the next element in the array is prime and if it does then
        //method return true value. If the next element is not prime it iterates over the elements
        //until it gets the prime number
        @Override
        public boolean hasNext( ) { 
            boolean rv=false;
            //iterate while cursor is not null
            while (cursor != null) 
            {
                //if element is prime then return true valuee and gets out of the loop
                //otherwise move to the next element with the help of after method of LinkedPositionalList
                if(isPrime(cursor.getElement().getLuckyNumber()))
                {
                    rv=true;
                    return rv;
                }
                cursor = lnList.after( cursor );
            }
            
            return rv; 
        }
        /** Returns the next position in the iterator. */
        @Override
        public Position<LuckyNumber> next( ) throws NoSuchElementException {
            
            if ( cursor == null ) throw new NoSuchElementException( "nothing left " );
            recent = cursor;
            cursor = lnList.after( cursor );
            
            return recent;
        }
        /** Removes the element returned by most recent call to next. */
        @Override
        public void remove( ) throws IllegalStateException {
            if ( recent == null ) throw new IllegalStateException( "nothing to remove" );
            lnList.remove( recent );         // remove from outer list
            recent = null;              // do not allow remove again until next is called
        }
    } //----- end of nested PositionIterator class -----
    
    //----- nested PositionIterable class -----
    private class PrimePositionIterable implements Iterable<Position<LuckyNumber>>{
        @Override
        public Iterator<Position<LuckyNumber>> iterator( ) { return new PrimePositionIterator( ); }        
    } //----- end of nested PositionIterable class -----
    
    /** Returns an iterable representation of the list's positions.
     * @return  */
    public Iterable<Position<LuckyNumber>> primePositions( ) {
        return new PrimePositionIterable( );  // create a new instace of the inner class
    }
    
    //Declare method to check if number is prime or not for Prime Iterator
    public boolean isPrime(int n) {
        boolean primeNum=true;
        for(int i=2; i<n; i++) {
            if(n%i==0){
                primeNum=false;
            }
        }
        return primeNum;
    }
    //********************** END PRIME ITERATOR ************************  
    
    
    //********************* BEGIN EVEN ITERATOR *************************  
    
     //----- nested PositionIterator class -----
    private class EvenPositionIterator implements Iterator<Position<LuckyNumber>>{
        private Position<LuckyNumber> cursor = lnList.first();   // position of the next element to report
        private Position<LuckyNumber> recent = null;               // position of last reported element
        
        /** Tests whether the iterator has a next object. */
        //The method hasNext() checks if the next element in the array is EVEN and if it does then
        //method return true value
        @Override
        public boolean hasNext( ) { 
             boolean rv=false;
            //iterate while cursor is not null
            while (cursor != null) 
            {
                //if element is even then return true valuee and gets out of the loop
                //otherwise move to the next element with the help of after method of LinkedPositionalList
                if(isEven(cursor.getElement().getLuckyNumber()))
                {
                    rv=true;
                    return rv;
                }
                cursor = lnList.after( cursor );
            }
            return rv;
        }

        /** Returns the next position in the iterator. */
        @Override
        public Position<LuckyNumber> next( ) throws NoSuchElementException {
            
            if ( cursor == null ) throw new NoSuchElementException( "nothing left " );
            recent = cursor;
            cursor = lnList.after( cursor );
            
            return recent;
        }
        /** Removes the element returned by most recent call to next. */
        @Override
        public void remove( ) throws IllegalStateException {
            if ( recent == null ) throw new IllegalStateException( "nothing to remove" );
            lnList.remove( recent );         // remove from outer list
            recent = null;              // do not allow remove again until next is called
        }
    } //----- end of nested PositionIterator class -----
    
    //----- nested PositionIterable class -----
    private class EvenPositionIterable implements Iterable<Position<LuckyNumber>>{
        @Override
        public Iterator<Position<LuckyNumber>> iterator( ) { return new EvenPositionIterator( ); }        
    } //----- end of nested PositionIterable class -----
    
    /** Returns an iterable representation of the list's positions.
     * @return  */
    public Iterable<Position<LuckyNumber>> evenPositions( ) {
        return new EvenPositionIterable( );  // create a new instace of the inner class
    }
    
    //Declare method to check if number is even or not for Prime Iterator
    public boolean isEven(int n) {
        boolean evenNum=false;
        if ((n%2)==0){ evenNum = true; }
        return evenNum;
    }
    
    //**************************** END EVEN ITERATOR ******************************  
    
    
}
