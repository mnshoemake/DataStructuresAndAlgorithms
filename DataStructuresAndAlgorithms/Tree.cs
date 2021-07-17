using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class Node
    {
        private Node _id;
        private Node _left;
        private Node _right;

        internal Node ID { get => _id; set => _id = value; }
        internal Node Left { get => _left; set => _left = value; }
        internal Node Right { get => _right; set => _right = value; }
    }
    class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        public static List<Node> GetPreorderList(Tree tree)
        {
            //DFS - Begin at root, dive left, stopping on way down.
            //Hit bottom, then collect right on the way up.
            //1 2 4 5 3
            List<Node> result = new List<Node>();
            GetPreorderList(tree.root, result);
            return result;
        }

        public static List<Node> GetPreorderList(Node node, List<Node> result)
        {
            result.Add(node);
            GetPreorderList(node.Left, result);
            GetPreorderList(node.Right, result);
            return result;
        }


        public static List<Node> GetInorderList(Tree tree)
        {
            //DFS - Go to deepest left point. Ascend, collecting right children after hitting
            //each left node on the way up.
            List<Node> result = new List<Node>();
            GetInorderList(tree.root, result);
            return result;
        }

        public static List<Node> GetInorderList(Node node, List<Node> result)
        {
            GetInorderList(node.Left, result);
            result.Add(node);
            GetInorderList(node.Right, result);
            return result;
        }


        public static List<Node> GetPostorderList(Tree tree)
        {
            //DFS - Go to deepest left point.
            //Collect Right at the same level.
            //Pop out to next level.
            List<Node> result = new List<Node>();
            GetPostorderList(tree.root, result);
            return result;
        }

        public static List<Node> GetPostorderList(Node node, List<Node> result)
        {
            GetPostorderList(node.Left, result);
            GetPostorderList(node.Right, result);
            result.Add(node);
            return result;
        }

    }
}
