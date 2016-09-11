// Andrey Vasilyev
// CSIS 352
// graph.h
// 05/05/2009
// Assignment 7

#ifndef _GRAPH_
#define _GRAPH_

#include <iostream>
#include <vector> 
#include "vertex.h"  // vertex class

using namespace std;

// ******************** The description of the class Graph **************************
// The file includes declaration and implementation of the class Graph. The 
// class Graph is templated and has vector container that stores the array of 
// vertexes with their edges (pointers). The class allows creating a graph with vertexes of 
// different data types and edges between them with weights. The class graph is based on 
// class vertex because it uses the methods of class vertex to insert, delete or get new 
// vertexes and edges.
// **********************************************************************************

// enum variables are used to declare different type of graphs
// Directed or Undirected and Weighted or Unweighted
enum Weighting {WEIGHTED, UNWEIGHTED};
enum Direction {DIRECTED, UNDIRECTED};

template<class Type>
class Graph
{
public:
	
	// default constructor
    //    preconditions - no validity checking is performed
    //       - variables direction and weghting must have enumiration data type
 	//    postconditions - attributes direction, weighting, edge counter and 
	//		   vertex counter are initialized to their default values
    //    method input - none
    //    method output - none
	Graph();

	// parameter list constructor
    //    preconditions - no validity checking is performed
	//		- input parameter must have valid enumiration data type
	//    postconditions - enumiration variable weighting is assigned to
	//		input parameter 
	//	  - other variables are assigned to thier default values
	//    method input - variable of enumiuration data type
    //    method output - none
	Graph(Weighting inpWeighting);
	
	// parameter list constructor
    //    preconditions - no validity checking is performed
	//		- input parameter must have valid enumiration data type
	//    postconditions - enumiration variable direction is assigned to
	//		input parameter 
	//	  - other variables are assigned to thier default values
	//    method input - variable of enumiuration data type
    //    method output - none
	Graph(Direction inpDirection);

	// parameter list constructor
    //    preconditions - no validity checking is performed
	//		- input parameters must have valid enumiration data type
	//    postconditions - enumiration variable weighting and
	//		  direction are assigned to input parameters 
	//	  - other variables are assigned to thier default values
	//    method input - variables of enumiuration data type
    //    method output - none
	Graph(Weighting inpWeighting, Direction inpDirection);
	
	// parameter list constructor
    //    preconditions - no validity checking is performed
	//		- input parameters must have valid enumiration data type
	//    postconditions - enumiration variable weighting and
	//		  direction are assigned to input parameters 
	//	  - other variables are assigned to thier default values
	//    method input - variables of enumiuration data type
    //    method output - none
	Graph(Direction inpDirection, Weighting inpWeighting);
	
	// desctructor
	~Graph();

	// method: insertVertex - adds object of class vertex to array of vertexes 
	//    preconditions - input parameter must be valid variable of the same
	//		data type as graph
    //    postconditions - object of class vertex is declared, gets input 
	//		parameter and inserted into the array of vertexes
	//    method input - variable of the same data type as an object of 
	//		class Graph
    //    method output - none
	void insertVertex(Type inpVertex);
	
	// method: insertEdge - sets the edge between determined vertexes
	//    preconditions - input parameters must be valid variables of the same
	//		  data type as graph
	//		- weight must be an integer number
    //    postconditions - pointer to vertexes that are equal to input parameter
	//		toVertex is inserted into the vertex that is equal to input parameter
	//		fromVertex. As a result of this the edge between vertexes is set 
	//    method input - variables of the same data type as an object of 
	//		class Graph
	//		- weight as an integer number
    //    method output - none
	void insertEdge(Type fromVertex, Type toVertex, int weight=1);
	
	// method: deleteVertex - delete vertex from the array of vertexes
	//    preconditions - input parameter must be valid variable of the same
	//		  data type as graph
	//    postconditions - the vertex that is equal to input parameter Vertex is
	//		removed from the array of vertexes
	//		- associated edges in other vertexes are removed
	//    method input - variables of the same data type as an object of 
	//		class Graph
    //    method output - none
	void deleteVertex(Type Vertex); 

	// method: deleteEdge - delete edge between vertexes
	//    preconditions - input parameters must be valid variables of the same
	//		  data type as graph
	//    postconditions - pointers to vertexes with value equal to input parameter 
	//		toVertex are removed from the vertex that has value equal to input
	//		parameter fromVertex
	//		- associated edge (pointer) is removed in pair of vertexes
	//    method input - variables of the same data type as an object of 
	//		class Graph
    //    method output - none
	void deleteEdge(Type fromVertex, Type toVertex);
	
	// method: isEmpty - returns true if graph is empty and false in 
	//		opposite case
	//    preconditions - none
	//    postconditions - true is graph is empty
	//    method input - none
    //    method output - logical value
	bool isEmpty() const;
	
	// method: edgeCount - returns the number of edges in the graph
	//    preconditions - none
	//    postconditions - the number of edges in the graph
	//    method input - none
    //    method output - integer number
	int edgeCount() const;

	// method: edgeCount - returns the number of vertexes in the graph
	//    preconditions - none
	//    postconditions - the number of vertexes in the graph
	//    method input - none
    //    method output - integer number
	int vertexCount() const;
	
	// method: destroy - removes the whole graph with all edges
	//    preconditions - none
	//    postconditions - the whole graph with all edges is removed
	//    method input - none
    //    method output - none
	void destroy();

	// method: dump - outputs the graph with all vertexes and edges
	//    preconditions - none
	//    postconditions - the graph with all vertexes and edges otputs to the screen
	//    method input - none
    //    method output - the graph with all vertexes and edges otputs to the screen
	void dump();

	// method: returnVertexes - outputs values of all vertexes saved inside of the graph
	//    preconditions - none
	//    postconditions - outputs values of all vertexes saved inside of the graph
	//    method input - none
    //    method output - outputs values of all vertexes saved inside of the graph
	void returnVertexes();

private:
	// templated vector to store objelcts of class Vertex
	vector<Vertex<Type> > graphArray;
	int weight;
	// enumiration variables to set type of graph as 
	// weighted or unweighted, directed or undirected
	Weighting weighting;	 
	Direction direction;
	int edgeCounter;
	int vertexCounter;
};

// default constructor
template<class Type>
Graph<Type>::Graph()
{
	weighting=UNWEIGHTED;
	direction=UNDIRECTED;
	edgeCounter=0;
	vertexCounter=0;
}

//destructor
template<class Type>
Graph<Type>::~Graph()
{
}

// parameter list constructor
template<class Type>
Graph<Type>::Graph(Weighting inpWeighting)
{
	weighting=inpWeighting;
	direction=UNDIRECTED;
	edgeCounter=0;
	vertexCounter=0;
}

template<class Type>
Graph<Type>::Graph(Direction inpDirection)
{
	direction=inpDirection;
	weighting=UNWEIGHTED;
	edgeCounter=0;
	vertexCounter=0;
}

template<class Type>
Graph<Type>::Graph(Weighting inpWeighting, Direction inpDirection)
{
	weighting=inpWeighting;
	direction=inpDirection;
	edgeCounter=0;
	vertexCounter=0;
}

template<class Type>
Graph<Type>::Graph(Direction inpDirection, Weighting inpWeighting)
{
	weighting=inpWeighting;
	direction=inpDirection;
	edgeCounter=0;
	vertexCounter=0;
}

template<class Type>
void Graph<Type>::insertVertex(Type inpVertex)
{
	Vertex<Type> ver(inpVertex);
	graphArray.push_back(ver);
	vertexCounter++;
}


template<class Type>
void Graph<Type>::insertEdge(Type fromVertex, Type toVertex, int weight)
{
	// find from Vertex
	edgeCounter++;
	int index=0;
	bool exist=false;
	for(int i=0; i<graphArray.size(); i++)
	{
		if (fromVertex==graphArray[i].getItem())
		{
			index=i;
			exist=true;
			break;
		}
	}

	if(exist==false)
	{
		return;
	}

	// find to Vertex
	Vertex<Type>* verPointer;
	for(int j=0; j<graphArray.size(); j++)
	{
		if(toVertex==graphArray[j].getItem())
		{
			verPointer=&graphArray[j];
			graphArray[index].setEdgeConnection(verPointer, weight);
			
			if(direction==UNDIRECTED)
			{
				verPointer=&graphArray[index];
				graphArray[j].setEdgeConnection(verPointer, weight);
			}
			break;
		}
	}
}

template<class Type>
void Graph<Type>::returnVertexes()
{
	for(int i=0; i<graphArray.size(); i++)
	{
		cout<<graphArray[i].getItem()<<endl;
	}
}

template<class Type>
void Graph<Type>::dump()
{
	for(int i=0; i<graphArray.size(); i++)
	{
		// uses the method of class Vertex to output vertexes and edges
		graphArray[i].getEdgesAndWeights();
	}
}

// remove vertexes from graph array and associated edges
template<class Type>
void Graph<Type>::deleteVertex(Type Vertex)
{	
	int i;
	// delete associacted edges of vertex that is going to be
	// removed
	for(i=0; i<graphArray.size(); i++)
	{
		graphArray[i].deleteReferenceEdges(Vertex);
	}

	// decrease the number of vertexes
	vertexCounter--;
	
	// delete the vertex, its edges and weights
	for(i=0; i<graphArray.size(); i++)
	{
		if(graphArray[i].getItem()==Vertex)
		{
			edgeCounter=edgeCounter-graphArray[i].getNumberOfEdges();
			graphArray[i].deleteEdgesAndWeights();
			graphArray.erase(graphArray.begin()+i);
			break;
		}	
	}
}

// dedlete edge between vertexes that were passed as parameters to the
// method
template<class Type>
void Graph<Type>::deleteEdge(Type fromVertex, Type toVertex)
{
	edgeCounter--;
	for(int i=0; i<graphArray.size(); i++)
	{
		if (graphArray[i].getItem()==toVertex)
		{
			graphArray[i].deleteReferenceEdges(fromVertex);
		}
		
		if (graphArray[i].getItem()==fromVertex)
		{
			graphArray[i].deleteReferenceEdges(toVertex);
		}
	}
}

template<class Type>
bool Graph<Type>::isEmpty() const
{
	if (graphArray.size()==0)
	{
		return true;
	}
	return false;
}

template<class Type> 
int Graph<Type>::edgeCount() const
{
	return edgeCounter;
}

template<class Type> 
int Graph<Type>::vertexCount() const
{
	return vertexCounter;
}

template<class Type> 
void Graph<Type>::destroy()
{
	graphArray.clear();
}

#endif
