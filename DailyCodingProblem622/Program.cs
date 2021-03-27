using System;
using System.Collections.Generic;

namespace DailyCodingProblem622
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// Given the root of a binary tree, return a deepest node.
    /// For example, in the following tree, return f.
    ///     a
    ///    / \
    ///   b   c
    ///  /   /
    /// d   e
    ///      \
    ///       f
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var tree = BuildTree();
            var deepestNode = FindDeepestNode(tree);
            Console.WriteLine(deepestNode.Value);
        }

        static Node FindDeepestNode(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            Node deepest = null;
            while(queue.TryDequeue(out Node currentNode))
            {
                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }

                deepest = currentNode;
            }

            return deepest;
        }

        static Node BuildTree()
        {
            var root = new Node
            {
                Value = "a",
                Left = new Node
                {
                    Value = "b",
                    Left = new Node
                    {
                        Value = "d"
                    }
                },
                Right = new Node
                {
                    Value = "c",
                    Left = new Node
                    {
                        Value = "e",
                        Right = new Node
                        {
                            Value = "f"
                        }
                    }
                }
            };
            return root;
        }
    }

    internal class Node
    {
        public Node Left, Right;
        public string Value;
    }
}
