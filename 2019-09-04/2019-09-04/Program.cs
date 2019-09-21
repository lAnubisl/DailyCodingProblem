using System;
using System.Collections.Generic;

namespace _2019_09_04
{
    /*
     Given the root of a binary tree, return a deepest node. For example, in the following tree, return d.

            a
           / \
          b   c
         /
        d

    */
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node
            {
                value = "a",
                Left = new Node
                {
                    value = "b",
                    Left = new Node
                    {
                        value = "d"
                    }
                },
                Right = new Node
                {
                    value = "c"
                }
            };


            Console.WriteLine(DeepestNode(root));
            Console.ReadLine();
        }

        static string DeepestNode(Node root)
        {
            if (root == null) return null;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            Node result = null;
            while(queue.TryDequeue(out Node node))
            {
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
                result = node;
            }

            return result.value;
        }
    }

    public class Node
    {
        public Node Left;
        public Node Right;
        public string value;
    }
}