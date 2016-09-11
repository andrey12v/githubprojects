// Andrey Vasilyev
// CSIS 352
// main.cpp
// 05/05/2009
// Assignment 7

#include "graph.h"
#include "employee.h"
#include <string>
#include <iostream>

using namespace std;

// ********************* The description of the function main ***********************
// The file contains implementation of the function main that tests class Graph. The 
// function tests all methods of class Graph using different data types. First time 
// the class Graph was declared as string data type, then as data type of class 
// Employee and, at the end, the class Graph used integer numbers to test all methods.   
// ***********************************************************************************

int main()
{
	// array of string is allocated
	string city[12] = {"Seattle", "Los Angeles", "Phoenix", 
	"Denver", "Fargo", "Minneapolis", "Houston", "St. Louis",
	"Chicago", "Detroit", "Miami", "New York"};

	Graph<string> gr(WEIGHTED, DIRECTED);
	for(int i=0; i<12; i++)
	{
		gr.insertVertex(city[i]);
	}
	// Seattle
	gr.insertEdge(city[0], city[3], 1332);
	gr.insertEdge(city[0], city[8], 2072);
	// Los Angeles
	gr.insertEdge(city[1], city[0], 1151);
	gr.insertEdge(city[1], city[3], 1023);
	gr.insertEdge(city[1], city[2], 381);
	gr.insertEdge(city[1], city[11], 2824);
	// Phoenix
	gr.insertEdge(city[2], city[1], 381);
	gr.insertEdge(city[2], city[6], 1186);
	// Denver
	gr.insertEdge(city[3], city[1], 1023);
	gr.insertEdge(city[3], city[5], 920);
	// Fargo
	gr.insertEdge(city[4], city[3], 909);
	gr.insertEdge(city[4], city[5], 240);
	// Minneapolis
	gr.insertEdge(city[5], city[3], 920);
	gr.insertEdge(city[5], city[4], 240);
	gr.insertEdge(city[5], city[8], 409);
	// Houston
	gr.insertEdge(city[6], city[2], 1186);
	gr.insertEdge(city[6], city[7], 780);
	gr.insertEdge(city[6], city[10], 1190);
	// St. Louis
	gr.insertEdge(city[7], city[3], 861);
	gr.insertEdge(city[7], city[9], 547);
	// Chicago
	gr.insertEdge(city[8], city[5], 409);
	gr.insertEdge(city[8], city[9], 286);
	gr.insertEdge(city[8], city[11], 821);
	// Detroit
	gr.insertEdge(city[9], city[8], 286);
	gr.insertEdge(city[9], city[11], 640);
	gr.insertEdge(city[9], city[7], 547);
	// Miami
	gr.insertEdge(city[10], city[6], 1190);
	gr.insertEdge(city[10], city[11], 1281);
	// New York
	gr.insertEdge(city[11], city[8], 821);
	gr.insertEdge(city[11], city[10], 1281);
	gr.insertEdge(city[11], city[1], 2824);
	gr.dump();
	cout<<endl;
	cout<<"TEST OF GRAPH METHODS"<<endl;
	cout<<"------- Test of the method vertexCount() -------"<<endl;
	cout<<"The number of vertexes: "<<gr.vertexCount()<<endl;
	cout<<"------- Test of the method edgeCount() -------"<<endl;
	cout<<"The number of edges:    "<<gr.edgeCount()<<endl;
	cout<<"------- Test of the method isEmpty() -------"<<endl;
	if(gr.isEmpty()==false){cout<<"The graph is not empty"<<endl;}
	cout<<endl;
	cout<<"------- Test of the method deleteEdge() -------"<<endl;
	cout<<"The edge between Houston and Miami will be deleted with weight 1190."<<endl;
	cout<<"SEE the updated graph with cities and edges"<<endl;
	gr.deleteEdge(city[6], city[10]);
	gr.dump();
	cout<<endl;
	cout<<"------- Test of the method deleteVertex() -------"<<endl;
	cout<<"The vertex St. Louis will be deleted with corresponding edges"<<endl;
	cout<<"SEE the updated graph with cities and edges"<<endl;
	gr.deleteVertex(city[7]);
	gr.dump();
	cout<<endl;
	cout<<"------- Test of the method destroy() -------"<<endl;
	gr.destroy();
	cout<<"All graph was destroyed"<<endl;
	gr.dump();
    gr.destroy();
	cout<<endl;
	cout<<"------- Test of the graph constructors() -------"<<endl;
	cout<<"New graph was created with the following Vertexes and Edges"<<endl;
	cout<<"THE CONSTRUCTOR is WEIGHTED and DIRECTED"<<endl;
	Graph<string> graph1(WEIGHTED, DIRECTED);
	string localCity[3] = {"Fargo", "Minneapolis", "Denver"};
	for(int i=0; i<3; i++)
	{
		graph1.insertVertex(localCity[i]);
	}
	// Fargo
	graph1.insertEdge(localCity[0], localCity[1], 240);
	graph1.insertEdge(localCity[0], localCity[2], 909);
	// Minneapolis
	graph1.insertEdge(localCity[1], localCity[0], 240);
	graph1.insertEdge(localCity[1], localCity[2], 920);
	// Denver
	graph1.insertEdge(localCity[2], localCity[1], 920);
	graph1.dump();

	cout<<endl;
	cout<<"THE CONSTRUCTOR is DIRECTED and WEIGHTED"<<endl;
	Graph<string> graph2(WEIGHTED, DIRECTED);
	for(int i=0; i<3; i++)
	{
		graph2.insertVertex(localCity[i]);
	}
	// Fargo
	graph2.insertEdge(localCity[0], localCity[1], 240);
	graph2.insertEdge(localCity[0], localCity[2], 909);
	// Minneapolis
	graph2.insertEdge(localCity[1], localCity[0], 240);
	graph2.insertEdge(localCity[1], localCity[2], 920);
	// Denver
	graph2.insertEdge(localCity[2], localCity[1], 920);
	graph2.dump();

	cout<<endl;
	cout<<"THE CONSTRUCTOR is WEIGHTED and UNDIRECTED by default"<<endl;
	Graph<string> graph3(WEIGHTED);
	for(int i=0; i<3; i++)
	{
		graph3.insertVertex(localCity[i]);
	}
	// Fargo
	graph3.insertEdge(localCity[0], localCity[1], 240);
	graph3.insertEdge(localCity[0], localCity[2], 909);
	// Minneapolis
	graph3.insertEdge(localCity[1], localCity[0], 240);
	graph3.insertEdge(localCity[1], localCity[2], 920);
	// Denver
	graph3.insertEdge(localCity[2], localCity[1], 920);
	graph3.dump();

	cout<<endl;
	cout<<"THE CONSTRUCTOR is DIRECTED and UNWEIGHTED by default"<<endl;
	Graph<string> graph4(WEIGHTED);
	for(int i=0; i<3; i++)
	{
		graph4.insertVertex(localCity[i]);
	}
	// Fargo
	graph4.insertEdge(localCity[0], localCity[1]);
	graph4.insertEdge(localCity[0], localCity[2]);
	// Minneapolis
	graph4.insertEdge(localCity[1], localCity[0]);
	graph4.insertEdge(localCity[1], localCity[2]);
	// Denver
	graph4.insertEdge(localCity[2], localCity[1]);
	graph4.dump();

	cout<<endl;
	cout<<"THE CONSTRUCTOR is UNDIRECTED and UNWEIGHTED by default"<<endl;
	Graph<string> graph5;
	for(int i=0; i<3; i++)
	{
		graph5.insertVertex(localCity[i]);
	}
	// Fargo
	graph5.insertEdge(localCity[0], localCity[1]);
	graph5.insertEdge(localCity[0], localCity[2]);
	// Minneapolis
	graph5.insertEdge(localCity[1], localCity[0]);
	graph5.insertEdge(localCity[1], localCity[2]);
	// Denver
	graph5.insertEdge(localCity[2], localCity[1]);
	graph5.dump();

	cout<<endl;
	cout<<"TEST OF THE GRAPH with OBJECTS OF EMPLOYEE CLASS"<<endl;
	cout<<"The main idea of this type of test is that objects of class"<<endl;
	cout<<"Employee are stored as vertexes in the graph and edges"<<endl;
	cout<<"between employees represent simple employees' relationships"<<endl;
	cout<<"1 - low priority; 2 - middle priority; 3 - high priority"<<endl;
	cout<<"The graph is declared as directed and weighted."<<endl;
	Employee emp1;
	emp1.setSSN("123-12-1234");
	emp1.setName("Andrey Vasilyev");

	Employee emp2;
	emp2.setSSN("222-22-2222");
	emp2.setName("John Tassova");
	
	Employee emp3;
	emp3.setSSN("333-33-3333");
	emp3.setName("Jeff Zent");

	Graph<Employee> grEmp(DIRECTED, WEIGHTED);
	grEmp.insertVertex(emp1);
	grEmp.insertVertex(emp2);
	grEmp.insertVertex(emp3);
	
	// The first employee - Andrey Vasilyev
	grEmp.insertEdge(emp1, emp2, 1);
	grEmp.insertEdge(emp1, emp3, 2);
	// The second employee - John Tassova
	grEmp.insertEdge(emp2, emp1, 1);
	grEmp.insertEdge(emp2, emp3, 3);
	// The third employee - Jeff Zent
	grEmp.insertEdge(emp3, emp2, 3);
	cout<<endl;
	grEmp.dump();
	cout<<endl;
	cout<<"The edge between Andrey and Jeff is removed "<<endl;
	grEmp.deleteEdge(emp1, emp3);
	grEmp.dump();
	cout<<endl;
	cout<<"The vertex John Tassova is removed "<<endl;
	grEmp.deleteVertex(emp2);
	grEmp.dump();
	cout<<endl;
	
	cout<<"TEST OF THE GRAPH with integer numbers"<<endl;
	cout<<"The graph is declared as directed and weighted."<<endl;

	int a=3;
	int b=5;
	int c=8;
	Graph<int> grT(DIRECTED, WEIGHTED);
	grT.insertVertex(a);
	grT.insertVertex(b);
	grT.insertVertex(c);
	
	grT.insertEdge(a, b, 1);
	grT.insertEdge(a, c, 2);
	grT.insertEdge(b, a, 1);
	grT.insertEdge(b, c, 3);
	grT.insertEdge(c, b, 3);
	cout<<endl;
	grT.dump();
	cout<<endl;
	cout<<"The vertex 5 is removed "<<endl;
	grT.deleteVertex(b);
	grT.dump();
	cout<<endl;
	

	return 0;
}

