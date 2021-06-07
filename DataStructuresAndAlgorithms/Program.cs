using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            //If Directed, Acyclic, Weighted, Use Dijkstra's
            //If Unweighted, use Breadth-First
            //Best approach: Just different overloads? DI? Polymorphism? 

            GraphProcessor graphProcessor = new GraphProcessor();

            Dictionary<string, Dictionary<string, int>> problemGraph = CreateProblemGraph();
            
            
            PrintProblemGraph(problemGraph);

            //PrintCostsGraph(costs);
            //PrintParentsGraph(parents);
            
            var solution = graphProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

            Console.WriteLine();
            Console.WriteLine("========================Printing Final Path========================");
            foreach (var node in solution)
            {
                Console.WriteLine(node);
            }
        }

       

        static Dictionary<string, Dictionary<string, int>> CreateProblemGraph()
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();

            //Create list of all nodes.
            graph["start"] = new Dictionary<string, int>();
            graph["a"] = new Dictionary<string, int>();
            graph["b"] = new Dictionary<string, int>();
            graph["fin"] = new Dictionary<string, int>();

            //Create subnodes and assign weights.
            graph["start"]["a"] = 6;
            graph["start"]["b"] = 2;

            graph["a"]["fin"] = 1;

            graph["b"]["a"] = 3;
            graph["b"]["fin"] = 5;

            return graph;
        }



        static void PrintProblemGraph(Dictionary<string, Dictionary<string, int>> problemGraph)
        {
            Console.WriteLine("");
            Console.WriteLine("========================Printing Problem Graph========================");
            foreach (var node in problemGraph)
            {
                Console.WriteLine("MainNode: " + node.Key);
                foreach (var subnode in node.Value)
                {
                    Console.WriteLine("     DestinationNode: " + subnode.Key);
                    Console.WriteLine("     Weight: " + subnode.Value);
                }
            }
        }


    }
}
