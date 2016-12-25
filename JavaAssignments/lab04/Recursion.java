package lab04;
import java.io.File;

public class Recursion 
{

    //recursive algorithm to compute the integer part of the base-two logarithm of 
    //n using only addition and integer division
    //The trace of recursive calls for log(8)=3 looks like this:
    // 1) 8; 2) 4; 3) 2; 4) return 0;
    // After the recursion fuction is executed to the base case
    // all recursive functions are called from the heap in the following order with return values
    // 1) return 0
    // 2) retrun 1 + 0 = 1
    // 3) return 1 + 1 = 2
    // 4) return 1 + 2 = 3
    // All functions are called from the heap
    public static int getLog(int n)
    {
        if(n < 2)
        {
            return 0;
        }
        else
        {
            return 1 + getLog(n/2);
        }
    }    
   
    //recursion function 'to calculate factorial
    //The execution of factorial function factorial(3) looks like this:
    // 1) 3; 
    // 2) 2; 
    // 3) 1; 
    // 4) 0;
    //Now we cal recursive function from the heap:
    // 1) 0, return 1; 
    // 2) 1 * 1 = 1
    // 3) 1 * 2 = 2
    // 4) 2 * 3 = 6
    public static int factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        } 
        else
        {
            return n * factorial(n-1);
        }
    } 

    //recursive algorithm to compute the product of two positive integers, m and n, 
    //using only addition and subtraction
    //The execution of product function product(2, 4) looks like this:
    // 1) product(2, 4) 
    // 2) product(2, 3) 
    // 3) product(2, 2)
    //Now we call recursive functions from the heap:
    // 1) 2 + 2 = 4
    // 2) 4 + 2 = 6
    // 3) 6 + 2 = 8
    public static int product(int n1, int n2) 
    { 
        if (n2 > 1) 
        { 
            n1 += product(n1, n2-1); 
            //System.out.println("n1= " + n1 + " n2 " + n2);
        } 
        return n1; 
    }
    
    //recursive function that adds elements of an array and returns the total sum
    public static int isabel( int[] A )
    {
        int n = A.length;
        int[] B = new int[(A.length)/2];
        
        //adds all elements of the second half of the array and store them 
        //in every element of the array B
        for ( int i = 0; i < (n/2); i++)
        {
            B[i] = A[2*i] + A[2*i + 1];
        }
        //reduce the size of the initial array A in a half
        A = new int[(n/2)];
        //reassigns all elements of the array B to the initial array A
        for ( int i = 0; i < (n/2); i++)
        {
            A[i] = B[i];
        }
        if(B.length == 1)
        {
            return A[0];
        }
        else
        {
            return isabel( A );
        }
    }

    //Recursive function that searches file name from the selectred folder
    //The function has two input parameters - folder name and file name
    //if the function finds teh file name it prints the whole folder path
    //otherwise function continues recursive calls to subfolders 
    public static void find(File filePath, String fileName)
    {
        if (filePath.isDirectory( )) 
        {
            //get the list of files and subfolders of selected folder 
            for (String childname : filePath.list( )) 
            {
                File child = new File(filePath, childname); 
                //call the function to go into subfolder and get the list of files and sub-sub folders 
                find(child, fileName);
                //if child element is a file and it is equal to the name of the file that we search then print it   
                if ((child.isFile()) && (child.getName().equals(fileName)))
                {
                    System.out.println(child.getPath());
                }
            }
        }
    }
    
    //The function displays the list of folders and files that belong to the selected 
    //folder path sent as a parameter
    public static void getFoldersAndFiles(File name)
    {
        //check if the selected object is folder or file
        //if it is folder then list all subfolders and files
        if(name.isDirectory())
        {
            //get the list of folders and files
            String[] foldersAndFiles = name.list();
            System.out.println("Directory content:\n");
            for(String outputValues: foldersAndFiles)
            {
                System.out.println(outputValues);
            }
        }
    }
    
}


// URL Resources for File and Folder Java Libraries: 
//https://www.tutorialspoint.com/java/java_file_class.htm
//https://www.tutorialspoint.com/java/java_files_io.htm