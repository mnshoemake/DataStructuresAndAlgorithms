using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //For now, using dijkstra's algorithm. In future, type of processor 
            //used to get shortest path will depend on the type of graph used.
            
            //If Directed, Acyclic, Weighted, Use Dijkstra's
            //If Unweighted, use Breadth-First
            //Good use case for DI?


            DijkstraProcessor dijkstraProcessor = new DijkstraProcessor();

            Dictionary<string, Dictionary<string, int>> problemGraph = CreateProblemGraph();
            
            
            PrintProblemGraph(problemGraph);
            //PrintCostsGraph(costs);
            //PrintParentsGraph(parents);
            
            var solution = dijkstraProcessor.FindShortestPathToFin(problemGraph);

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

        static void PrintCostsGraph(Dictionary<string, int> costs)
        {
            Console.WriteLine("");
            Console.WriteLine("========================Printing Costs Graph========================");
            foreach (var node in costs)
            {
                Console.WriteLine("DestinationNode: " + node.Key);
                Console.WriteLine("     Cost: " + node.Value);

            }
        }

        static void PrintParentsGraph(Dictionary<string, string> parents)
        {
            Console.WriteLine("");
            Console.WriteLine("========================Printing Parents Graph========================");
            foreach (var node in parents)
            {
                Console.WriteLine("Node: " + node.Key);
                Console.WriteLine("     Parent: " + node.Value);

            }
        }
    }
}
