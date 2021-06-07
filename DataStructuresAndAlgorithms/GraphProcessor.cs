using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class GraphProcessor
    {
        static List<string> processed = new List<string>();

        public List<string> FindShortestPathToFin(Dictionary<string, Dictionary<string, int>> problemGraph, string startNodeKey, string endNodeKey)
        {
            //Dijsktra Overload
            
            //If Graph Values are Dictionaries, meaning there are at least 3 layers of data,
            //the Graph is assumed to be Weighted. Thus, we apply Dijkstra's Algorithm in this
            //overload.

            //If the Graph Values are strings or collections of strings, then the Graph is
            //assumed to be unweighted, and thus a different overload, applying a Breadth First
            //Search is used.


            Dictionary<string, int> costs = CreateCostsGraph(problemGraph, startNodeKey);
            Dictionary<string, string> parents = CreateParentsGraph(problemGraph, startNodeKey);

            PrintCostsGraph(costs);
            PrintParentsGraph(parents);

            List<string> solution = new List<string>();


            processed.Clear();

            //Dijkstra's Algorithm
            //1. Find the cheapest node
            //2. Find the total cost to get to the neighbors of the cheapest node.
            //      2a. If the total cost to get to a given neighbor, "N", is lower than the cost currently stored for "N,"
            //          update the cost and parent node for "N." Repeat for all neighbors.
            //3. Repeat steps 1 and 2 until every node in the graph has been processed.
            //4. Calculate the final path.

            //1. Find the cheapest node
            string cheapestNode = FindCheapestNode(costs);


            while (cheapestNode != "none")
            {
                var cost = costs[cheapestNode];

                //2. Find the total cost to get to the neighbors of the cheapest node.
                var neighbors = problemGraph[cheapestNode];
                foreach (string neighbor in neighbors.Keys)
                {
                    //2a. If the total cost to get to a given neighbor, "N", is lower than the cost currently stored for "N,"
                    //      update the cost and parent node for "N." Repeat for all neighbors.
                    var costToReachNeighbor = cost + neighbors[neighbor];
                    if (costs[neighbor] > costToReachNeighbor)
                    {
                        //Update cost/parent of neighbor
                        costs[neighbor] = costToReachNeighbor;
                        parents[neighbor] = cheapestNode;
                    }
                }
                //3. Repeat steps 1 and 2 until every node in the graph has been processed (adding lost node to a list of processed nodes
                //until list is completed;  at this point, FindCheapestNode will return "none".
                processed.Add(cheapestNode);
                cheapestNode = FindCheapestNode(costs);
            }

            //4. Calculate Final path.
            //Parent table will contain the requisite links.
            //Add Nodes from fin to start, then reverse order and print.

           
            solution.Add(endNodeKey);

            string nextNode = parents[endNodeKey];
            solution.Add(nextNode);

            while (nextNode != startNodeKey)
            {
                nextNode = parents[nextNode];
                solution.Add(nextNode);
            }

            //Solution is calculated backward from fin.
            solution.Reverse();

            return solution;
        }

        static string FindCheapestNode(Dictionary<string, int> costs)
        {
            string lowestCostNode = "none";
            int lowestCost = int.MaxValue;

            foreach (var cost in costs)
            {
                if (cost.Value < lowestCost && !processed.Contains(cost.Key))
                {
                    lowestCostNode = cost.Key;
                    lowestCost = cost.Value;
                }
            }

            return lowestCostNode;
        }

        static Dictionary<string, int> CreateCostsGraph(Dictionary<string, Dictionary<string, int>> problemGraph, string startNodeKey)
        {
            Dictionary<string, int> costs = new Dictionary<string, int>();

            foreach (string key in problemGraph.Keys)
            {
                //No cost to get to start node from start, so not added to table.
                if (key != startNodeKey)
                {
                    //At beginning, can only know costs of children of "start" node.
                    if (problemGraph[startNodeKey].ContainsKey(key))
                    {
                        costs[key] = problemGraph[startNodeKey][key];
                    }
                    //Costs of all other nodes effectively infinite.
                    else
                    {
                        costs[key] = int.MaxValue;
                    }
                }
            }

            return costs;
        }

        static Dictionary<string, string> CreateParentsGraph(Dictionary<string, Dictionary<string, int>> problemGraph, string startNodeKey)
        {
            Dictionary<string, string> parents = new Dictionary<string, string>();
            foreach (string key in problemGraph.Keys)
            {
                //No cost to get to start node from start, so not added to table.
                if (key != startNodeKey)
                {
                    //At beginning, can only know costs of children of "start" node.
                    if (problemGraph[startNodeKey].ContainsKey(key))
                    {
                        parents[key] = startNodeKey;
                    }
                    //Costs of all other nodes effectively infinite.
                    else
                    {
                        parents[key] = "";
                    }
                }
            }
            return parents;
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
