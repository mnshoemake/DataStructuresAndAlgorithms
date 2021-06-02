using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static Dictionary<string,Dictionary<string,int>> ProblemGraph = new Dictionary<string,Dictionary<string,int>>();
        static Dictionary<string, int> Costs = new Dictionary<string, int>();
        static Dictionary<string, string> Parents = new Dictionary<string, string>();
        static List<string> Processed = new List<string>();

        static void Main(string[] args)
        {
            CreateProblemGraph();
            CreateCostsGraph();
            PrintGraph();
            PrintCostsGraph();
            CreateParentsGraph();
            PrintParentsGraph();
            FindShortestPathToFin();
        }

        static void FindShortestPathToFin()
        {
            //Dijkstra's Algorithm
            //1. Find the cheapest node
            //2. Find the total cost to get to the neighbors of the cheapest node.
            //      2a. If the total cost to get to a given neighbor, "N", is lower than the cost currently stored for "N,"
            //          update the cost and parent node for "N." Repeat for all neighbors.
            //3. Repeat steps 1 and 2 until every node in the graph has been processed.
            //4. Calculate the final path.

            //1. Find the cheapest node
            string cheapestNode = FindCheapestNode(Costs);
            
            
            while (cheapestNode != "none")
            {
                var cost = Costs[cheapestNode];

                //2. Find the total cost to get to the neighbors of the cheapest node.
                var neighbors = ProblemGraph[cheapestNode];
                foreach (string neighbor in neighbors.Keys)
                {
                    //2a. If the total cost to get to a given neighbor, "N", is lower than the cost currently stored for "N,"
                    //      update the cost and parent node for "N." Repeat for all neighbors.
                    var costToReachNeighbor = cost + neighbors[neighbor];
                    if (Costs[neighbor] > costToReachNeighbor)
                    {
                        //Update cost/parent of neighbor
                        Costs[neighbor] = costToReachNeighbor;
                        Parents[neighbor] = cheapestNode;
                    }
                }
                //3. Repeat steps 1 and 2 until every node in the graph has been processed (adding lost node to a list of processed nodes
                //until list is completed;  at this point, FindCheapestNode will return "none".
                Processed.Add(cheapestNode);
                cheapestNode = FindCheapestNode(Costs);
            }

            //4. Calculate Final path.
            //Parent table will contain the requisite links.
            //Add Nodes from fin to start, then reverse order and print.


            List<string> finalPath = new List<string>();
            finalPath.Add("fin");

            string nextNode = Parents["fin"];
            finalPath.Add(nextNode);

            while (nextNode != "start")
            {
                nextNode = Parents[nextNode]; 
                finalPath.Add(nextNode);
            }

            //finalPath.Add("start");

            //Print Final Path
            finalPath.Reverse();

            Console.WriteLine();
            Console.WriteLine("========================Printing Final Path========================");
            foreach (var node in finalPath)
            {  
                Console.WriteLine(node);
            }
        }


        static string FindCheapestNode(Dictionary<string, int> costs)
        {
            string lowestCostNode = "none"; //default value; if no cheaper nodes are found, return "start" node.
            int lowestCost = int.MaxValue; 
            
            foreach (var cost in costs)
            {
                if (cost.Value < lowestCost && !Processed.Contains(cost.Key))
                {
                    lowestCostNode = cost.Key; 
                    lowestCost = cost.Value;        
                }
            }

            return lowestCostNode;
        }


        static void CreateProblemGraph()
        {
            ProblemGraph.Clear();

            //Create list of all nodes.
            ProblemGraph["start"] = new Dictionary<string, int>();
            ProblemGraph["a"] = new Dictionary<string, int>();
            ProblemGraph["b"] = new Dictionary<string, int>();
            ProblemGraph["fin"] = new Dictionary<string, int>();

            //Create subnodes and assign weights.
            ProblemGraph["start"]["a"] = 6;
            ProblemGraph["start"]["b"] = 2;

            ProblemGraph["a"]["fin"] = 1;

            ProblemGraph["b"]["a"] = 3;
            ProblemGraph["b"]["fin"] = 5;

            
        }

        static void CreateCostsGraph()
        {
            Costs.Clear();
            foreach(string key in ProblemGraph.Keys)
            {
                //No cost to get to start node from start, so not added to table.
                if (key != "start")
                {
                    //At beginning, can only know costs of children of "start" node.
                    if (ProblemGraph["start"].ContainsKey(key))
                    {
                        Costs[key] = ProblemGraph["start"][key];
                    }
                    //Costs of all other nodes effectively infinite.
                    else
                    {
                        Costs[key] = int.MaxValue;
                    }
                }
            }            
        }

        static void CreateParentsGraph()
        {
            Parents.Clear();
            foreach (string key in ProblemGraph.Keys)
            {
                //No cost to get to start node from start, so not added to table.
                if (key != "start")
                {
                    //At beginning, can only know costs of children of "start" node.
                    if (ProblemGraph["start"].ContainsKey(key))
                    {
                        Parents[key] = "start";
                    }
                    //Costs of all other nodes effectively infinite.
                    else
                    {
                        Parents[key] = "";
                    }
                }
            }
        }

        static void PrintGraph()
        {
            Console.WriteLine("");
            Console.WriteLine("========================Printing Problem Graph========================");
            foreach (var node in ProblemGraph)
            {
                Console.WriteLine("MainNode: " + node.Key);
                foreach (var subnode in node.Value)
                {
                    Console.WriteLine("     DestinationNode: " + subnode.Key);
                    Console.WriteLine("     Weight: " + subnode.Value);
                }

            }
        }

        static void PrintCostsGraph()
        {
            Console.WriteLine("");
            Console.WriteLine("========================Printing Costs Graph========================");
            foreach (var node in Costs)
            {
                Console.WriteLine("DestinationNode: " + node.Key);
                Console.WriteLine("     Cost: " + node.Value);

            }
        }

        static void PrintParentsGraph()
        {
            Console.WriteLine("");
            Console.WriteLine("========================Printing Parents Graph========================");
            foreach (var node in Parents)
            {
                Console.WriteLine("Node: " + node.Key);
                Console.WriteLine("     Parent: " + node.Value);

            }
        }
    }
}
