Iimport java.util.*; 
import java.io.IOException; 
import java.lang.*;
import org.apache.hadoop.conf.*; 
import org.apache.hadoop.io.*; 
import org.apache.hadoop.fs.*; 
import org.apache.hadoop.mapred.*; 
import org.apache.hadoop.util.*; 
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.Mapper;
import org.apache.hadoop.mapreduce.Reducer;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;
import org.apache.hadoop.mapreduce.lib.output.MultipleOutputs;
import org.apache.hadoop.mapreduce.lib.input.TextInputFormat;
import org.apache.hadoop.mapreduce.lib.output.TextOutputFormat;

public class WeightedSum 
{
    //Declare and implement the Mapper class 
    public static class WSMapper extends Mapper<LongWritable, Text, Text, DoubleWritable>{
        
        //Declare the variable weightedSum as double writable data type to store weighted sum  
        private final static DoubleWritable weightedSum = new DoubleWritable();
        //Declare keyValue variable as Text data type to store the key values. 
        //In our case we store class number in the variable keyValue
        private Text keyValue = new Text();
        
        //Declare and implement the map method that maps keyValue (Class Number) and weighted sum pairs. 
        //key - input parameter, LongWritable data type
        //value - input parameter, Text data type
        //context - output parameter, Context data type 
        public void map(LongWritable key, Text value, Context context) throws IOException, InterruptedException {
            
            //Convert input value parameter from Text data type to String for further processing 
            String line = value.toString(); 
            //Use StringTokenizer class from Java Library to parse every line of the input file
            //The values are pulled from the file based on tab separator 
            StringTokenizer s = new StringTokenizer(line,"\t");
            //declare and initialize variables to calculate weighted sum 
            double sum=0.0; 
            int counter=1;
            double multiplier=0.0;
            
            //Class (Category) number is saved to the string variable lineNum by means of StringTokenizer function
            //the menthod s.nextToken() allows to move cursor line by line
            String lineNum = s.nextToken(); 
            
            //The while loop pulls numbers seperated by a tab symbol   
            while(s.hasMoreTokens())
            {
                //Counter is used to determine the column number and, based on the coumn number, apply appropriate multiplier 
                if (counter==1)
                {
                    //the multiplier is assigned the value 0.1 if column 1 is parsed 
                    multiplier=0.1;
                }
                if ((counter==2) || (counter==3) || (counter==5))
                {
                    //the multiplier is assigned the value 0.2 if column is 1, 3 or 5 are parsed
                    multiplier=0.2;
                }
                if (counter==4)
                {
                    //the multiplier is assigned the value 0.3 if column is 4 is parsed
                    multiplier=0.3;
                }
                //calculate the weighted sum by multipling the value of multiplier to every single value and add all values together
                sum += multiplier*Double.parseDouble(s.nextToken());
                counter++;
            }
            //assign class number to the KeyValue variable for the mapper to match key value pairs
            keyValue.set(lineNum);
            //assign value of the weighted sum to the weightedSum variable
            weightedSum.set(sum);
            //Write key - value pairs to mapper and use the context variable to save this data
            context.write(keyValue, weightedSum);
        }
    }
   
    //Declare and implement the Reducer class that reduces all values by class number (line number)
    public static class WSReducer extends Reducer<Text, DoubleWritable, Text, DoubleWritable> {
        
        //Declare result variable as DoubleWritable data type to save the results of the reduce procedure
        DoubleWritable result = new DoubleWritable();
        //Declare variable mos as MultipleOutputs Abstract Data Type to output calcualted results into seperate files
        //MultipleOutputs abstract data type is used to store Key - Values pairs as Text and DoubleWritable data types
        //MultipleOutputs ADT outputs data into seperate files for average, minimum and maximum values 
        //MultipleOutputs improves readbility and processing time by storing output data in seperate files
        private MultipleOutputs<Text, DoubleWritable> mos;
        
        //Declare setup method to initialize MoltipuleOutputs mos variable   
        @Override
        public void setup(Context context) throws IOException, InterruptedException {
                mos = new MultipleOutputs<Text, DoubleWritable>(context);
        }
        
        //Declare Reduce method to reduce ke-value pairs by class number and average, minimum, maximum values 
        //key - input parameter, Text data type
        //values - input parameter, Iterable values of DoubleWritable data type
        //context - output parameter, Context data type 
        public void reduce(Text key, Iterable<DoubleWritable> values, Context context) throws IOException, InterruptedException {
            
            //declare and initialize variables to store weighted sum, average, minimum and maximum values 
            double sum=0.0;
            double avg=0.0;
            double min=100000000.0;
            double max=0.0;
            double tempVal=0.0;
            int counter=0;
            
            //iterate through weighted sum values and get minimum, maximum, average values
            for (DoubleWritable val : values) {
                tempVal = val.get();
                if (min > tempVal)
                {
                    min = tempVal;
                }
                if(max < tempVal)
                {
                    max = tempVal;
                }
                sum +=tempVal;
                counter++;
            }
            
            //save minimum value into the result variable
            result.set(min);
            //produce output key and result values in the file "min"
            mos.write("min", key, result);
            result.set(max);
            mos.write("max", key, result);
            avg=sum/counter;
            result.set(avg);
            mos.write("avg", key, result);
            //result.set(sum);
            //mos.write("sum", key, result);
        }
    }
        
    //Main function 
   public static void main(String args[])throws Exception 
   { 
        //Declare startTime long variable to start timer and measure how many milliseconds it takes to run Map Reduce procedure 
        long startTime = System.currentTimeMillis();
        //Instantiate object of Jobconf class to initialize the class Weightedsum for Map Reduce procedure
        JobConf conf = new JobConf(WeightedSum.class);
        //Instantiate object of the Job class and initialize it
        Job job = new Job(conf, "WeightedSumJob");
        //Add input file path to get input data from DataSet.txt file for map reduce procedure   
        FileInputFormat.addInputPath(job, new Path("/user/vasilyev/weightedsum/input"));
        //Add output file path to store files with output data - average, minimum and maximum values 
        FileOutputFormat.setOutputPath(job, new Path("/user/vasilyev/weightedsum/output"));
        job.setJarByClass(WeightedSum.class);
        //initiate Mapper and Reduce methods in order to execute Map and Redudce procedure 
        job.setMapperClass(WSMapper.class);
        job.setReducerClass(WSReducer.class);
        //Specify input and output format
        job.setInputFormatClass(TextInputFormat.class);
        job.setOutputFormatClass(TextOutputFormat.class);
        //Specify data types for the key and for the value 
        job.setOutputKeyClass(Text.class);
        job.setOutputValueClass(DoubleWritable.class);
        //Specify output files "min", "max" and "avg" for output values minimum, maximum and average respectively
        MultipleOutputs.addNamedOutput(job, "min", TextOutputFormat.class, Text.class, DoubleWritable.class);
        MultipleOutputs.addNamedOutput(job, "max", TextOutputFormat.class, Text.class, DoubleWritable.class);
        MultipleOutputs.addNamedOutput(job, "avg", TextOutputFormat.class, Text.class, DoubleWritable.class);
        //MultipleOutputs.addNamedOutput(job, "sum", TextOutputFormat.class, Text.class, DoubleWritable.class);
        
        //declare object of the FileSystem class to execute Map Reduce procedure on multiple nodes
        FileSystem fs = FileSystem.get(conf);
        long dataLength = fs.getContentSummary(new Path("/user/vasilyev/weightedsum/input")).getLength();
        //initialize numNodes variable to how many nodes will be used by map reduce procedure
        int numNodes = 2;
        FileInputFormat.setMaxInputSplitSize(job, (long) (dataLength / numNodes));
        job.setNumReduceTasks(numNodes/2);
        job.waitForCompletion(true);
        //determine the end tme of map reduce procedure and save it to the endTime variable
        long endTime = System.currentTimeMillis();
        //output the difference between the beginning and the end time of map reduce procedure in milleseconds
        System.out.println("Time taken to run the program is " + (endTime - startTime) + " milliseconds");
        
   }
   
}
    

