using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class DijkstraProcessor
    {
        static List<string> processed = new List<string>();

        public List<string> FindShortestPathToFin(Dictionary<string, Dictionary<string, int>> problemGraph)
        {
            Dictionary<string, int> costs = CreateCostsGraph(problemGraph);
            Dictionary<string, string> parents = CreateParentsGraph(problemGraph); 
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


           
            solution.Add("fin");

            string nextNode = parents["fin"];
            solution.Add(nextNode);

            while (nextNode != "start")
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
            string lowestCostNode = "none"; //default value; if no cheaper nodes are found, return "start" node.
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

        static Dictionary<string, int> CreateCostsGraph(Dictionary<string, Dictionary<string, int>> problemGraph)
        {
            Dictionary<string, int> costs = new Dictionary<string, int>();

            foreach (string key in problemGraph.Keys)
            {
                //No cost to get to start node from start, so not added to table.
                if (key != "start")
                {
                    //At beginning, can only know costs of children of "start" node.
                    if (problemGraph["start"].ContainsKey(key))
                    {
                        costs[key] = problemGraph["start"][key];
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

        static Dictionary<string, string> CreateParentsGraph(Dictionary<string, Dictionary<string, int>> problemGraph)
        {
            Dictionary<string, string> parents = new Dictionary<string, string>();
            foreach (string key in problemGraph.Keys)
            {
                //No cost to get to start node from start, so not added to table.
                if (key != "start")
                {
                    //At beginning, can only know costs of children of "start" node.
                    if (problemGraph["start"].ContainsKey(key))
                    {
                        parents[key] = "start";
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


    }
}
