package lab06;

public class Client 
{
    public static void main(String[] args) 
    {
        //Now we perform testing of new Gemoteric array and its resize method
        //We increment our for loop by 0.5 until we reach the size of the increment equal to 3.1
        //In total we perform 7 increments in rteh main for loop 
        //In the main for loop we create Gemoteric Array with capacity equal to teh size of the increment
        //After the Gemotericc Array is allocated we add 1000 numbers in the array and count how many times
        //the Gemnoteric Array resizes. The main porpuse of this ooperation is to test teh Gemoteric Array and 
        //how it is resized 
        for(float inc=0.1f; inc<=3.1f; inc=inc+0.5f)
        {
            ArrayListGeometric<Integer> arrL = new ArrayListGeometric<>(inc);
            for(int j=0; j<1000; j++)
            {
                arrL.add(j, j);
            }
            System.out.println("Increment inc = " + inc + " resize operations = " + arrL.counter);
        }
    }
}
