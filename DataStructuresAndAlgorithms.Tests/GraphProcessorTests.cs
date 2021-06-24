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
        public void FindShortestPathToFin_ShouldReturnListWithShortestPathA()
        {
            //1. Arrange
            List<string> expected = new List<string>();
            expected.Add("start");
            expected.Add("b");
            expected.Add("a");
            expected.Add("fin");

            GraphProcessor testProcessor = new GraphProcessor();
            var problemGraph = new Dictionary<string, Dictionary<string, int>>();

            //Create list of all nodes.
            problemGraph["start"] = new Dictionary<string, int>();
            problemGraph["a"] = new Dictionary<string, int>();
            problemGraph["b"] = new Dictionary<string, int>();
            problemGraph["fin"] = new Dictionary<string, int>();

            //Create subnodes and assign weights.
            problemGraph["start"]["a"] = 6;
            problemGraph["start"]["b"] = 2;

            problemGraph["a"]["fin"] = 1;

            problemGraph["b"]["a"] = 3;
            problemGraph["b"]["fin"] = 5;

            //2. Act
            List<string> actual = testProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

            //3. Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void FindShortestPathToFin_ShouldReturnListWithShortestPathB()
        {
            //1. Arrange
            List<string> expected = new List<string>();
            expected.Add("start");
            expected.Add("a");
            expected.Add("d");
            expected.Add("fin");

            GraphProcessor testProcessor = new GraphProcessor();
            var problemGraph = new Dictionary<string, Dictionary<string, int>>();

            //Create list of all nodes.
            problemGraph["start"] = new Dictionary<string, int>();
            problemGraph["a"] = new Dictionary<string, int>();
            problemGraph["b"] = new Dictionary<string, int>();
            problemGraph["c"] = new Dictionary<string, int>();
            problemGraph["d"] = new Dictionary<string, int>();
            problemGraph["fin"] = new Dictionary<string, int>();

            //Create subnodes and assign weights.
            problemGraph["start"]["a"] = 5;
            problemGraph["start"]["2"] = 2;

            problemGraph["a"]["c"] = 4;
            problemGraph["a"]["d"] = 2;
            
            problemGraph["b"]["a"] = 8;
            problemGraph["b"]["d"] = 7;

            problemGraph["c"]["d"] = 6;
            problemGraph["c"]["fin"] = 3;

            problemGraph["d"]["fin"] = 1;

            //2. Act
            List<string> actual = testProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

            //3. Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void FindShortestPathToFin_ShouldReturnListWithShortestPathC()
        {
            //1. Arrange
            List<string> expected = new List<string>();
            expected.Add("start");
            expected.Add("a");
            expected.Add("c");
            expected.Add("fin");

            GraphProcessor testProcessor = new GraphProcessor();
            var problemGraph = new Dictionary<string, Dictionary<string, int>>();

            //Create list of all nodes.
            problemGraph["start"] = new Dictionary<string, int>();
            problemGraph["a"] = new Dictionary<string, int>();
            problemGraph["b"] = new Dictionary<string, int>();
            problemGraph["c"] = new Dictionary<string, int>();
            problemGraph["fin"] = new Dictionary<string, int>();

            //Create subnodes and assign weights.
            problemGraph["start"]["a"] = 20;

            problemGraph["a"]["c"] = 20;

            problemGraph["b"]["a"] = 1;

            //this graph contains a cycle; a -> c -> b -> a...
            //yet dijkstra's still works...
            //it should fail.
            problemGraph["c"]["b"] = 1;
            problemGraph["c"]["fin"] = 30;


            //2. Act
            List<string> actual = testProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

            //3. Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void FindShortestPathToFin_ShouldReturnListWithShortestPathD()
        {
            //1. Arrange
            List<string> expected = new List<string>();
            expected.Add("start");
            expected.Add("a");
            expected.Add("fin");

            GraphProcessor testProcessor = new GraphProcessor();
            var problemGraph = new Dictionary<string, Dictionary<string, int>>();

            //Create list of all nodes.
            problemGraph["start"] = new Dictionary<string, int>();
            problemGraph["a"] = new Dictionary<string, int>();
            problemGraph["b"] = new Dictionary<string, int>();
            problemGraph["c"] = new Dictionary<string, int>();
            problemGraph["fin"] = new Dictionary<string, int>();

            //Create subnodes and assign weights.
            problemGraph["start"]["a"] = 2;
            problemGraph["start"]["b"] = 2;

            problemGraph["a"]["fin"] = 2;
            problemGraph["a"]["c"] = 2;

            problemGraph["b"]["a"] = 2;

            //This graph has a negative weight, and so should also fail 
            //as long as only Dijkstra's Algorithm is implemented.
            //Yet the test succeeds.
            problemGraph["c"]["b"] = -1;
            problemGraph["c"]["fin"] = 2;

            //2. Act
            List<string> actual = testProcessor.FindShortestPathToFin(problemGraph, "start", "fin");

            //3. Assert
            Assert.Equal(expected, actual);

        }

    }
}
