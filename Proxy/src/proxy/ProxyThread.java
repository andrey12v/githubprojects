
package proxy;

import java.net.*;
import java.io.*;
import java.util.*;
import java.text.*;

public class ProxyThread extends Thread {
    private Socket socket = null;
    private static final int BUFFER_SIZE = 32768000;
    public ProxyThread(Socket socket) {
        super("ProxyThread");
        this.socket = socket;
    }

    public void run() {
        
        //get input from user
        //send request to server
        //get response from server
        //send response to user
        try {
            
            // create input and output streams attached to socket
            DataOutputStream out =
		new DataOutputStream(socket.getOutputStream());
            BufferedReader in = new BufferedReader(
		new InputStreamReader(socket.getInputStream()));
            
            
            String inputLine, outputLine;
            int cnt = 0;
            String urlToCall = "";
            String urlLog = "";
            String requestType = "";
            ///////////////////////////////////
            //begin get request from client
            while ((inputLine = in.readLine()) != null) {
                try {
                    StringTokenizer tok = new StringTokenizer(inputLine);
                    tok.nextToken();
                } catch (Exception e) {
                    break;
                }
                //parse the first line of the request to find the url
                if (cnt == 0) {
                    String[] tokens = inputLine.split(" ");
                    requestType = tokens[0];
                    requestType.trim();
                    urlToCall = tokens[1];
                }
                cnt++;
            }
            //end get request from client
            ///////////////////////////////////
            BufferedReader rd = null;
            try {
                
                //begin send request to server, get response from server
                int contentLength;
                URL url = new URL(urlToCall);
                URLConnection conn = url.openConnection();
                conn.setDoInput(true);
                //not doing HTTP posts
                conn.setDoOutput(false);
            
                // Get the response
                InputStream is = null;
                HttpURLConnection huc = (HttpURLConnection)conn;
                if (conn.getContentLength() > 0) {
                    try {
                        is = conn.getInputStream();
                        rd = new BufferedReader(new InputStreamReader(is));
                    } catch (IOException ioe) {
                        System.out.println(
				"********* IO EXCEPTION **********: " + ioe);
                    }
                }
                //end send request to server, get response from server
                ///////////////////////////////////

                ///////////////////////////////////
                //begin send response to client
                byte by[] = new byte[ BUFFER_SIZE ];
                int index = is.read( by, 0, BUFFER_SIZE );
                while ( index != -1 )
                {
                  out.write( by, 0, index );
                  index = is.read( by, 0, BUFFER_SIZE );
                }
                out.flush();
                
                // We filter our requests based on GET request method in order to save 
                // only appropriate urls to log file.
                if (requestType.equalsIgnoreCase("get"))
                {
                    //Save url to urlLog variable based on GET request method only
                    urlLog = urlToCall;
                    // get current date to save it into the log file
                    Date curDate = new Date();
                    SimpleDateFormat fDate = new SimpleDateFormat("MMM dd yyyy hh:mm:ss");
                    //get browser IP address
                    InetAddress addr = InetAddress.getLocalHost();
                    // pass url to URL class to get url size
                    URL urlTemp = new URL(urlLog);
                    URLConnection connLog = urlTemp.openConnection();
                    connLog.setDoInput(true);
                    //pass false to setDoOutput for not doing HTTP posts
                    connLog.setDoOutput(false); 
                    // print out to console screen records that go to log file
                    System.out.println(fDate.format(curDate) + " " + addr.getHostAddress() + 
                        " " + urlLog + " " + connLog.getContentLength());

                    // open file stream to record url to log file
                    FileWriter fstream = new FileWriter("proxy.log", true);
                    BufferedWriter fbw = new BufferedWriter(fstream);
                    fbw.write(fDate.format(curDate) + " " + addr.getHostAddress() + 
                        " " + urlToCall + " " + connLog.getContentLength());
                    fbw.newLine();
                    fbw.close();
                }
                

                //end send response to client
                ///////////////////////////////////
            } catch (Exception e) {
            }
            if (out != null) {
                out.close();
            }
            if (in != null) {
                in.close();
            }
            if (socket != null) {
                socket.close();
            }
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }
}

