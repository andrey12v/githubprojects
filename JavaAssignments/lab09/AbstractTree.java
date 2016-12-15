import java.util.*;
import java.lang.*;
//import java.lang.Iterable;

public abstract class AbstractTree<E> implements Tree<E>
{
    public boolean isInternal(Position<E> p) { return numChildren(p) > 0; }
    public boolean isExternal(Position<E> p) { return numChildren(p) == 0; }
    public boolean isRoot(Position<E> p) { return p == root(); }
    public boolean isEmpty() { return size() == 0; }

    public int depth(Position<E> p)
    { 
        if(isRoot(p))
        {
            return 0;
        }
        else
        {
            return 1+depth(parent(p));
        }
    }
       
    public int height(Position<E> p) 
    {
        int h=0;
        for(Position<E> c : children(p))
        {
            h = Math.max(h, 1 + height(c));
        }
       
        return h;
    }

    /*private class ElementIterator implements Iterator<E> {
        Iterator<Position<E>> posIterator = positions( ).iterator( );
        public boolean hasNext( ) { return posIterator.hasNext( ); }
        public E next( ) { return posIterator.next( ).getElement( ); }
        public void remove( ) { posIterator.remove( ); }
    }*/
    
    private void preorderSubtree(Position<E> p, List<Position<E>> snapshot) {
        snapshot.add(p);
        for (Position<E> c : children(p))
        {
            preorderSubtree(c, snapshot);
        }
    }
    
    public Iterable<Position<E>> preorder( ) {
        List<Position<E>> snapshot = new ArrayList<>( );
        if (!isEmpty( )) preorderSubtree(root( ), snapshot);
        return snapshot;
    }
    
    private void postorderSubtree(Position<E> p, List<Position<E>> snapshot) {
        for (Position<E> c : children(p))
        {
            postorderSubtree(c, snapshot);
        }
        snapshot.add(p);
    }
    
    public Iterable<Position<E>> postorder( ) {
        List<Position<E>> snapshot = new ArrayList<>( );
        if (!isEmpty( )) postorderSubtree(root( ), snapshot);
        return snapshot;
    }
    
    public Iterable<Position<E>> breadthfirst( ) {
        List<Position<E>> snapshot = new ArrayList<>( );
        if (!isEmpty( )) {
            Queue<Position<E>> fringe = new LinkedQueue<>( );
            fringe.enqueue(root( ));
            while (!fringe.isEmpty( )) {
                Position<E> p = fringe.dequeue( );
                snapshot.add(p);
                for (Position<E> c : children(p)) fringe.enqueue(c);
            }
        }
        return snapshot;
    }
    
    public <E> void printPreorderIndent(LinkedBinaryTree<E> T, Position<E> p, int d) {
        System.out.println(spaces(d*2) + p.getElement()); 
        for (Position<E> c : T.children(p)) {
            printPreorderIndent(T, c, d+1);
        }
    } 
    
    public static String spaces(int num)
    {
        String temp="";
        for(int i=0; i<num; i++)
        {
            temp += " ";
        }
        return temp;
    }
    
    public <E> void parenthesize(LinkedBinaryTree<E> T, Position<E> p) { 
        
        //if(T.isInternal(p)){
        //    System.out.print("(");
        //}
        if(T.left(p) != null){
            parenthesize(T, T.left(p));
        }
        System.out.print(p.getElement());
        if(T.right(p) != null){
            parenthesize(T, T.right(p));
        }
        
        //if(T.isInternal(p)){
        //    System.out.print(")");
        //}
        
        /*System.out.print(p.getElement()); 
        for (Position<E> c : T.children(p)) { 
            parenthesize(T, c);
        }*/
                
        /*System.out.print(p.getElement()); 
        if (T.isInternal(p)) { 
            boolean ﬁrstTime = true;
            for (Position<E> c : T.children(p)) { 
                System.out.print( (ﬁrstTime ? " (" : ", ") ); 
                ﬁrstTime = false;
                parenthesize(T, c);
            }
            System.out.print(")");
        }*/
    
    }
    
}
