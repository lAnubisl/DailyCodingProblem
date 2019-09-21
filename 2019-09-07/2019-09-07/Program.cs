using System;
using System.Collections.Generic;

namespace _2019_09_07
{
    /*
        Invert a binary tree.
        For example, given the following tree:

            a
           / \
          b   c
         / \  /
        d   e f
        should become:

          a
         / \
         c  b
         \  / \
          f e  d
   */


    class Program
    {
        static void Main(string[] args)
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
                    },
                    Right = new Node
                    {
                        Value = "e"
                    }
                },
                Right = new Node
                {
                    Value = "c",
                    Left = new Node
                    {
                        Value = "f"
                    }
                }
            };

            Invert(root);
            Console.WriteLine("Hello World!");
        }

        static void Invert(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.TryDequeue(out Node node))
            {
                var t = node.Left;
                node.Left = node.Right;
                node.Right = t;

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }
    }

    public class Node
    {
        public Node Left, Right;
        public string Value;
    }
}
