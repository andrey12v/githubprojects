
import java.util.TreeSet;
import java.util.*;
/**
 * This class provides a utility to build a graph from a list of edges.
 *
 * It also contains specific factory methods to generate graph instances used
 * as examples within Data Structures and Algorithms in Java, 6th edition.
 */
public class Client {

  /**
   * Constructs a graph from an array of array strings.
   *
   * An edge can be specified as { "SFO", "LAX" }, in which case edge is created
   * with default edge value of 1, or as { "SFO", "LAX", "337" }, in which case
   * the third entry should be a string that will be converted to an integral value.
   */
  public static Graph<String,Integer> graphFromEdgelist(String[][] edges, boolean directed) {
    Graph<String,Integer> g = new AdjacencyMapGraph<>(directed);
       
    // first pass to get sorted set of vertex labels
    TreeSet<String> labels = new TreeSet<>();
    for (String[] edge : edges) {
      labels.add(edge[0]);
      labels.add(edge[1]);
    }
    
    // now create vertices (in alphabetical order)
    HashMap<String, Vertex<String> > verts = new HashMap<>();
    for (String label : labels){
      verts.put(label, g.insertVertex(label));
      //System.out.println(label);
    }
  
    // now add edges to the graph
    for (String[] edge : edges) {
      Integer cost = (edge.length == 2 ? 1 : Integer.parseInt(edge[2]));
      g.insertEdge(verts.get(edge[0]), verts.get(edge[1]), cost);
      //System.out.println(verts.get(edge[0]).getElement() + " " + verts.get(edge[1]).getElement() + " " + cost);
    }
    
    return g;
 }
 
  
  /** Returns the unweighted, directed graph from Figure 14.3 of DSAJ6. */
  public static Graph<String,Integer> figure14_3() {
    String[][] edges = {
      {"BOS","SFO"}, {"BOS","JFK"}, {"BOS","MIA"}, {"JFK","BOS"},
      {"JFK","DFW"}, {"JFK","MIA"}, {"JFK","SFO"}, {"ORD","DFW"},
      {"ORD","MIA"}, {"LAX","ORD"}, {"DFW","SFO"}, {"DFW","ORD"},
      {"DFW","LAX"}, {"MIA","DFW"}, {"MIA","LAX"},
    };
    return graphFromEdgelist(edges, true);
  }

  /** Returns the unweighted, directed graph from Figure 14.8 of DSAJ6. */
  public static Graph<String,Integer> figure14_8() {
    String[][] edges = {
      {"BOS","SFO"}, {"BOS","JFK"}, {"BOS","MIA"}, {"JFK","BOS"},
      {"JFK","DFW"}, {"JFK","MIA"}, {"JFK","SFO"}, {"ORD","DFW"},
      {"ORD","MIA"}, {"LAX","ORD"}, {"DFW","SFO"}, {"DFW","ORD"},
      {"DFW","LAX"}, {"MIA","DFW"}, {"MIA","LAX"}, {"SFO","LAX"},
    };
    return graphFromEdgelist(edges, true);
  }
  
  /** Returns the unweighted, directed graph from Figure 14.11 of DSAJ6. */
  public static Graph<String,Integer> figure14_11() {
    String[][] edges = {
      {"BOS","JFK"}, {"BOS","MIA"}, {"JFK","BOS"}, {"JFK","DFW"},
      {"JFK","MIA"}, {"JFK","SFO"}, {"ORD","DFW"},
      {"LAX","ORD"}, {"DFW","SFO"}, {"DFW","ORD"},
      {"DFW","LAX"}, {"MIA","DFW"}, {"MIA","LAX"},
    };
    return graphFromEdgelist(edges, true);
  }
  
 
  public static void main(String[] args) {
    
    System.out.println("Figure 14.3");
    System.out.println(figure14_3());
    Graph<String, Integer> g1 = figure14_3();
    getGraph(g1);
    
    System.out.println("Figure 14.8");
    System.out.println(figure14_8());
    Graph<String, Integer> g2 = figure14_8();
    getGraph(g2);
    
    System.out.println("Figure 14.11");
    System.out.println(figure14_11());
    Graph<String, Integer> g3 = figure14_11();
    getGraph(g3);
  }

  public static void getGraph(Graph<String, Integer> g)
  {
      //Declare Vertex with capacity equal to the size of the input parameter - the graph g
      Vertex[] verts = new Vertex[g.numVertices()];
      //Declare iterable of the vertexes of the input graph
      Iterable<Vertex<String>> iterable = g.vertices();
      //Declare iterator to iterate over the vertexes
      Iterator<Vertex<String>> iterator = iterable.iterator();
      int i=0;
      int rows=0;
      int columns=0;
      
      //declare two dimensional array to display matrix consisting of edge values
      //the capacity of two dimensional array is equal to number of vertexes in vertex array
      int[][] arrCost = new int[verts.length][verts.length];
      //Declare string array to store vertexes of the graph
      String[] arrVerts = new String[g.numVertices()];
            
      //Iterate over vertexes of the input graph g 
      while(iterator.hasNext())
      {
            //store vertexes in the vertex array 
            verts[i]=iterator.next();
            arrVerts[i]=verts[i].getElement().toString();
            //System.out.println(arrVerts[i]);
            i++;
      }
            
      //Iterate over vertexes to get edges and their cost
      for(i=0; i<verts.length; i++)
      {
          for(int j=0; j<verts.length; j++)
          {
              //use method getEdge to get the edge from the input graph g
              Edge<Integer> edge = g.getEdge(verts[i], verts[j]);
              if(edge!=null)
              {
                    //get the cost of the edge 
                    Integer cost = edge.getElement();
                    //get indexes for rows and clomuns based on the name of Vertexes
                    rows=getIndex(verts[i].getElement().toString(), arrVerts);
                    columns=getIndex(verts[j].getElement().toString(), arrVerts);
                    arrCost[rows][columns]=cost;
                    //System.out.println(verts[i].getElement() + " " + verts[j].getElement() + " " + cost);
              }
          }
      }
      
      
        System.out.println("+-----+-----+-----+-----+-----+-----+-----+-----+");
        System.out.format( "|%-5s|","");

        for(i=0; i<verts.length; i++)
        {
            System.out.print(" " + arrVerts[i] + " |");
        }
        System.out.println("");
        System.out.println("+-----+-----+-----+-----+-----+-----+-----+-----+");

        for(i=0; i<arrCost.length; i++)
        {
            System.out.print("| " + arrVerts[i] + " |");
            for(int j=0; j<arrCost.length; j++)
            {
                System.out.print("  " + arrCost[i][j] + "  |");
            }
            System.out.println("");
            System.out.println("+-----+-----+-----+-----+-----+-----+-----+-----+");
        }
      
  }
  
  private static int getIndex(String inpVertex, String[] inpArr)
  {
      for(int i=0; i<inpArr.length; i++)
      {
          if(inpVertex.equals(inpArr[i]))
          {
              return i; 
          }
      }
      return 0;
  }
  
  
  
}
