package proxy;



import java.net.*;
import java.io.*;

public class ProxyServer {
    
    public static void main(String[] args) throws IOException {
        ServerSocket serverSocket = null;
        boolean listening = true;

        int port = 1234;	//default
        
        try {
            // create server socket to listen on port 1234
            serverSocket = new ServerSocket(port);
            System.out.println("Started on: " + port);
        } catch (IOException e) {
            System.err.println("Could not listen on port: " + args[0]);
            System.exit(-1);
        }

        // create threads to accept client requests on server socket
        while (listening) {
            new ProxyThread(serverSocket.accept()).start();
        }
        serverSocket.close();
    }
}

