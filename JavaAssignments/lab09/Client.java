import java.util.*;
import java.io.*;

public class Client 
{
    public static void main(String[] args) 
    {
        int i=0;
        String temp="";
        String stackTemp="";
        String matchingOpenParanthesis="";
        
        ArrayList<String> elements = new ArrayList<>();
        LinkedQueue<String> linkedQ = new LinkedQueue<>();
        LinkedStack<String> linkedS = new LinkedStack<>();
        
        Scanner scan = new Scanner (System.in);
        System.out.print("The expression from the file is: ");
        //String filePath = scan.nextLine();
                
        BufferedReader br = null;
        try {
                String currentLine;
                String delims = "[ ]+";
                String[] tokens;
                //br = new BufferedReader(new FileReader(filePath));
                br = new BufferedReader(new FileReader("data.txt"));
                while ((currentLine = br.readLine()) != null) {
                        
                        System.out.println(currentLine);
                        tokens = currentLine.split(delims);
                        
                        for (String s : tokens) {
                            elements.add(s);
                        }
                }
                br.close();
        } 
        catch (IOException e) {
                e.printStackTrace();
        } 
        
        System.out.println("");
        
        for(i=0; i<elements.size(); i++)
        {
            if(isNumeric(elements.get(i)))
            {
                //System.out.println("Number: " + elements.get(i));
                linkedQ.enqueue(elements.get(i));
            }
            if( isOperation(elements.get(i)) )
            {
                //System.out.println("Operation: " + elements.get(i));
                while ( (linkedS.top()!=null) && isOperation(linkedS.top()) && isEqualPrecedence(linkedS.top(), elements.get(i)) )
                {
                    linkedQ.enqueue(linkedS.pop());
                }
                linkedS.push(elements.get(i));
            }
            if( isOpenParanthesis(elements.get(i)) )
            {
                //System.out.println("Open Paranthesis: " + elements.get(i));
                linkedS.push(elements.get(i));
            }
            if( isClosingParanthesis(elements.get(i)) )
            {
                //System.out.println("Closing Paranthesis: " + elements.get(i));
                temp=linkedS.pop();
                while(!isOpenParanthesis(temp))
                {
                    linkedQ.enqueue(temp);
                    temp=linkedS.pop();
                }
            }
        }
        
        while(linkedS.top()!=null)
        {
            linkedQ.enqueue(linkedS.pop());
        }
        LinkedBinaryTree<String> linkedTree = buildTree(linkedQ);
        
        System.out.print("Preoder traversal:  ");
        for(Position<String> content : linkedTree.preorder()){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
    
        System.out.print("Inoder traversal:   ");
        for(Position<String> content : linkedTree.inorder()){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
        
        System.out.print("Postoder traversal: ");
        for(Position<String> content : linkedTree.postorder() ){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
        
        System.out.print("Breadth First Search traversal: ");
        for(Position<String> content : linkedTree.breadthfirst() ){                                    
            System.out.print(content.getElement() + " ");
        }
        System.out.println("");
    }
    
      
    
    public static LinkedBinaryTree<String> buildTree(LinkedQueue<String> inpQ)
    {
        String token = "";
        LinkedStack<LinkedBinaryTree<String>> linkedS = new LinkedStack<>();
        while(!inpQ.isEmpty())
        {
            token = inpQ.dequeue();
            if(isNumeric(token))
            {
                LinkedBinaryTree<String> numberBT = new LinkedBinaryTree<>();
                numberBT.addRoot(token);
                linkedS.push(numberBT);
            }
            else
            {
                LinkedBinaryTree<String> operationBT = new LinkedBinaryTree<>();
                operationBT.addRoot(token);
                LinkedBinaryTree<String> rt = new LinkedBinaryTree<>(); 
                rt=linkedS.pop();
                LinkedBinaryTree<String> lt = new LinkedBinaryTree<>();  
                lt=linkedS.pop();
                operationBT.attach(operationBT.root(), lt, rt);
                linkedS.push(operationBT);
                
            }
        }
        
        return linkedS.pop();
    }
    
    
    public static boolean isNumeric(String str)
    {
        return Character.isDigit(str.charAt(0));
    }
        
    public static boolean isOperation(String s)
    {
        boolean rv = false;
        if ( (s.equals("+")) || (s.equals("-")) || (s.equals("*")) || (s.equals("/")) )
        {
            rv=true;
        } 
        return rv;
    }
    
    public static boolean isOpenParanthesis(String s)
    {
        boolean rv = false;
        if (s.equals("("))
        {
            rv=true;
        } 
        return rv;
    }
    
    public static boolean isClosingParanthesis(String s)
    {
        boolean rv = false;
        if (s.equals(")"))
        {
            rv=true;
        } 
        return rv;
    }
   
    public static boolean isEqualPrecedence(String str1, String str2)
    {
        boolean rv=false;
        if ( ((str1.equals("+")) || (str1.equals("-"))) && ((str2.equals("+")) || (str2.equals("-"))) )
        {
            rv=true;
        }
        if ( ((str1.equals("*")) || (str1.equals("/"))) && ((str2.equals("*")) || (str2.equals("/"))) )
        {
            rv=true;
        }
        return rv;
    }

}
