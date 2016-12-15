public class Client 
{
    public static void main(String[] args) 
    {    
        System.out.println("Hash code for POTS is                " + toBinary(hashCode("POTS")) );
        //System.out.println(toBinary(122));
    }
    
    public static int hashCode(String s) { 
        int h=0;
        int counter=0;
        System.out.println("Creating hash code for " + s);
        
        
        for (int i=0; i<s.length( ); i++) { 
            
            System.out.println("Entering hashCode, pass " + i);
            //h = (h << 5);
            System.out.println("hashCode << 5                        " + toBinary( (h << 5) ));
            //h = (h >>> 27);
            System.out.println("hashCode >>> 27                      " + toBinary( (h >>> 27) ));
            h = (h << 5) | (h >>> 27); // 5-bit cyclic shift of the running sum
            System.out.println("hashCode << 5 | hashCode >>> 27      " + toBinary(h));
            h += (int) s.charAt(i); // add in next character
            System.out.println("");
            System.out.println("Adding character " + s.charAt(i) + "                   " + toBinary(h));
            
            //System.out.println(h);
        }
        System.out.println("Exiting hashCode");
        return h;
    }
    
    public static String toBinary(int n) {
       if (n == 0) {
           return "0";
       }
       String binary = "";
       while (n > 0) {
           int rem = n % 2;
           binary = rem + binary;
           n = n / 2;
       }
       return binary;
   }
    
}
