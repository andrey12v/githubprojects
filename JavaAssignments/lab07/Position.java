public interface Position<E> {
    /**
     * Returns the element stored at this position.
     * 
     * @return the stored element
     * @thorws IllegalStateExceptoin if position no longer valid
     */
    E getElement( ) throws IllegalStateException;
}
