using System;
using System.Collections.Generic;
using System.Text;
using DataStructuresAndAlgorithms;
using Xunit;

namespace DataStructuresAndAlgorithms.Tests

{
    public class GraphProcessorTests
    {
        [Fact]
        public void FindShortestPathToFin_ShouldReturnListWithShortestPath()
        {
            //1. Arrange
            List<string> expected = new List<string>();
            expected.Add("start");
            expected.Add("b");
            expected.Add("a");
            expected.Add("fin");

            GraphProcessor testProcessor = new GraphProcessor();
            var problemGraph = CreateProblemGraph();
            //2. Act
            List<string> actual = testProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

            //3. Assert
            Assert.Equal(expected, actual);

        }

        //        DataStructuresAndAlgorithms.GraphProcessor graphProcessor = new GraphProcessor();

        //        Dictionary<string, Dictionary<string, int>> problemGraph = CreateProblemGraph();

        //        PrintProblemGraph(problemGraph);

        //        //PrintCostsGraph(costs);
        //        //PrintParentsGraph(parents);

        //        var solution = graphProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

        //        Console.WriteLine();
        //            Console.WriteLine("========================Printing Final Path========================");
        //            foreach (var node in solution)
        //            {
        //                Console.WriteLine(node);
        //            }

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
        //}
    }
}
