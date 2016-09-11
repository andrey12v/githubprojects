// Andrey Vasilyev
// CSIS 352
// vertex.h
// 05/05/2009
// Assignment 7

#ifndef _VERTEX_
#define _VERTEX_

#include <iostream>
#include <vector> // vector from Standard Template Library
using namespace std;

// ******************** The description of the class Vertex *************************
// The file includes declaration and implementation of the class Vertex. The class 
// vertex is templated and can store the main element of any data type. The class 
// Vertex also has templated vector container that stores pointers to other vertexes. 
// The array of pointers to Vertexes is used to set the edges between the current 
// vertex and other vertexes that were declared in a graph. The vertex might have 
// directed and undirected edges. If the graph is declared as undirected the vertexes 
// stores pointers pointing to each other so that edge is represented as two way 
// connection between vertexes. 
// **********************************************************************************

template<class Type>
class Vertex
{
public:
	// default constructor
    //    preconditions - no validity checking is performed
    //    postconditions - none
    //    method input - none
    //    method output - none
	Vertex();
	
	// parameter list constructor
    //    preconditions - no validity checking is performed
    //    postconditions
    //       - the value is assigned to the local templated variable  
    //    method input - value of any data type
    //    method output - none 
	Vertex(const Type& inputElement);
	
	// method: setEdgeConnection - adds pointer pointing to another vertex and 
	//			set weight for the edge (pointer) 
    //    preconditions - input parameter must be valid pointer to the vertex of 
	//          the same data type as the main vertex 
	//		 	- weight must be an integer number 
    //    postconditions - pointer pointing to another vertex is added in the 
	//			  vector container
	//			- weight attribute is set to the argument if the graph is 
	//			  declared as weighted
	//    method input - pointer to an object of class Vertex, 
	//				   - integer number as a weight if graph is weighted 
    //    method output - none
	void setEdgeConnection(Vertex<Type>* toVertex, int weight=1);
	
	// method: getEdgeConnection - outputs the value of the current vertex 
	//			- weights of edges and valueus of other vertexes which the 
	//			current vertex has edges (connections) with
	//    preconditions - none 
    //    postconditions - outputs value of current vertex, weights of edges, 
	//			value of other vertexes that current vertex points to
	//    method input - pointer to an object of class Vertex, 
	//				   - integer number as a weight if graph is declared as weighted 
    //    method output - none
	void getEdgesAndWeights();
	
	// method: deleteEdgesAndWeights - delete all edges and weights of current vertex 
	//    preconditions - none 
    //    postconditions - all edges and weights of current vertex are removed
	//    method input - none 
    //    method output - none
	void deleteEdgesAndWeights();

	// method: deleteReferenceEdges - deletes weights of edges and pointers to 
	//      other vertexes that has values equal to input parameter  
	//    preconditions - input parameter must be valid and must have has the same 
	//      data type as vertex
    //    postconditions - all weights of edges and vertex pointers equal to
	//		input parameter are removed
	//    method input - parameter of the same data type as current vertex  
    //    method output - none
	void deleteReferenceEdges(Type Vertex);
	
	// method: getNumberOfEdges - returns the number of edges (pointers to other
	//	    vertexes) inside of the current vertex 
	//    preconditions - none
    //    postconditions - number of edges is returned
	//    method input - none  
    //    method output - integer number
	int getNumberOfEdges();
	
	// method: getItem - returns current value of vertex 
	//    preconditions - none 
    //    postconditions - the value of the vertex that has the same data
	//		type is returned
	//    method input - none  
    //    method output - the value that has the same data type as vertex is
	//		returned
	Type getItem();

private:
	// templated vector to store pointers to vertexes
	vector<Vertex<Type>* > vertexPointers;
	// vector of type int to store weights of edges
	vector<int> weightArray;
	// the value of vertex has the same data type as object of vertex class
	Type item;
	int weight;
};

// default constructor
template<class Type>
Vertex<Type>::Vertex()
{
}

// parameter list constructor
template<class Type>
Vertex<Type>::Vertex(const Type& inputElement)
{
	item=inputElement;
}

// the value of vertex is returned
template<class Type>
Type Vertex<Type>::getItem()
{
	return item;
}


template<class Type>
int Vertex<Type>::getNumberOfEdges()
{
	return vertexPointers.size();
}

template<class Type>
void Vertex<Type>::setEdgeConnection(Vertex<Type>* toVertex, int weight)
{
	bool exist=false;
	for(int i=0; i<vertexPointers.size(); i++)
	{
		if(vertexPointers[i]->getItem()==toVertex->getItem())
		{ 
			exist=true; 
			break;
		}
	}
	
	if(exist==false)
	{
		vertexPointers.push_back(toVertex);
		weightArray.push_back(weight);
	}
}

// outputs edges and weights that are stored in vertex
template<class Type>
void Vertex<Type>::getEdgesAndWeights()
{
	cout<<"******* Vertex: "<<item<<" *******"<<endl;
	for(int i=0; i<vertexPointers.size(); i++)
	{
		cout<<"Edge:__"<<vertexPointers[i]->getItem()<<"   Weight:__"<<weightArray[i]<<endl;
	}
}

template<class Type>
void Vertex<Type>::deleteEdgesAndWeights()
{
	vertexPointers.clear();
	weightArray.clear();
}

// deletes edges and weights of different vertexes from current vertex
template<class Type>
void Vertex<Type>::deleteReferenceEdges(Type Vertex)
{
	for(int i=0; i<vertexPointers.size(); i++)
	{
		if(Vertex==vertexPointers[i]->getItem())
		{
			vertexPointers.erase(vertexPointers.begin()+i);
			weightArray.erase(weightArray.begin()+i);
		}
	}
}


#endif


