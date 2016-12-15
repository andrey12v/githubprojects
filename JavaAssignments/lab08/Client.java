import java.util.*;

public class Client 
{
    public static void main(String[] args) 
    {
        //The tree is created from teh following expression ( ((5+2)*(2-1)) / ( (2+9)+((7-2)-1) ) * 8 )
        		
        LinkedBinaryTree<String> linkedTree = new LinkedBinaryTree();
        LinkedBinaryTree<String> miniTree1 = new LinkedBinaryTree();
        LinkedBinaryTree<String> miniTree2 = new LinkedBinaryTree();
        
        // Top three layers
                           // 0*
        linkedTree.addRoot("*");
        linkedTree.addRight(linkedTree.root(), "8");
        linkedTree.addLeft(linkedTree.root(), "/");
                                 // /               // 0*  
        linkedTree.addLeft(linkedTree.left(linkedTree.root()), "*");
                                 // /               // 0*    
        linkedTree.addRight(linkedTree.left(linkedTree.root()), "+");
        
        // Left, Left minitrees
        miniTree1.addRoot("+");
        miniTree1.addLeft(miniTree1.root(), "5");
        miniTree1.addRight(miniTree1.root(), "2");
        
        miniTree2.addRoot("-");
        miniTree2.addLeft(miniTree2.root(), "2");
        miniTree2.addRight(miniTree2.root(), "1");
        
        // Attach first two minitrees
                              // 1*              // /             // 0*           // 3+      // 3-
        linkedTree.attach(linkedTree.left(linkedTree.left(linkedTree.root())), miniTree1, miniTree2);
        miniTree1 = new LinkedBinaryTree();
        miniTree2 = new LinkedBinaryTree();
        
        // Left, Right minitrees
        miniTree1.addRoot("+");
        miniTree1.addLeft(miniTree1.root(), "2");
        miniTree1.addRight(miniTree1.root(), "9");
        
        miniTree2.addRoot("-");
        miniTree2.addRight(miniTree2.root(), "1");
        miniTree2.addLeft(miniTree2.root(), "-");
        miniTree2.addLeft(miniTree2.left(miniTree2.root()), "7");
        miniTree2.addRight(miniTree2.left(miniTree2.root()), "9");
        
        // Attach second two minitrees
        linkedTree.attach(linkedTree.right(linkedTree.left(linkedTree.root())), miniTree1, miniTree2);
        
        System.out.print("Children of the root of the tree: ");
        for (Position<String> s : linkedTree.children(linkedTree.root())) {
            System.out.print(s.getElement() + " ");
        }
        System.out.println("");
        
        System.out.print("Get the first element of the tree, the left child: ");
        System.out.println(linkedTree.children(linkedTree.root()).iterator().next().getElement());
        
        //preorder traversal of tree
        System.out.print("Preorder Traversal, First method: ");
        Iterator <Position<String>> preorderIterator = linkedTree.preorder().iterator();
        while (preorderIterator.hasNext())
        {
            System.out.print(preorderIterator.next().getElement()+ " ");
        }
        System.out.println("");
        
        System.out.print("Preoder traversal, Second method: ");
        for(Position<String> content : linkedTree.preorder()){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
        
        System.out.print("Inorder traversal: ");
        for(Position<String> content : linkedTree.inorder()){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
        
        System.out.print("Postoder traversal: ");
        for(Position<String> content : linkedTree.postorder()){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
        
        System.out.println("Pre oreder indent traversal: ");
        linkedTree.printPreorderIndent(linkedTree, linkedTree.root(), 2);
        System.out.println("");
                
        System.out.print("Bredth First traversal: ");
        for(Position<String> content : linkedTree.breadthfirst()){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
        
        
        System.out.print("Paranthesized: ");
        linkedTree.parenthesize(linkedTree, linkedTree.root());
        System.out.println("\n");      
        
    }
}
