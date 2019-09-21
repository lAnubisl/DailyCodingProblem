using System;
using System.Collections.Generic;

namespace _2019_09_17
{
    /*
     Given a tree, find the largest tree/subtree that is a BST.
     Given a tree, return the size of the largest tree/subtree that is a BST.

     Question: What is the latgest?
               Is it the tree of the greatest length
               or is it the tree with the biggest number of nodes?
     
     Consideration: The largest tree is the tree of the greatest length.

                           15
                         /   \
                        13   18
                       /    /  \
                     12    16  20






    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = FindGreatestBSTNode(
                new Node
                {
                    Value = 30,
                    Left = new Node
                    {
                        Value = 50,
                        Left = new Node
                        {
                            Value = 25
                        },
                        Right = new Node
                        {
                            Value = 75
                        }
                    },
                    Right = new Node
                    {
                        Value = 150,
                        Left = new Node
                        {
                            Value = 125
                        },
                        Right = new Node
                        {
                            Value = 175,
                            Left = new Node
                            {
                                Value = 163
                            }
                        }
                    }
                }
            );
            Console.WriteLine($"Greatest BST node is '{result.Item1?.Value}' and it's length is '{result.Item2}'");
            Console.ReadLine();
        }

        static (Node, int) FindGreatestBSTNode(Node node)
        {
            Node greatestNode = null;
            int greatestNodeLength = 0;
            FindGreatestBSTNode(node, ref greatestNode, ref greatestNodeLength);
            return (greatestNode, greatestNodeLength);
        }

        static void FindGreatestBSTNode(Node node, ref Node accumNode, ref int accumNodeLength)
        {
            if (node == null) return;
            var nodeLength = BSTLength(node);
            if (nodeLength > accumNodeLength)
            {
                accumNodeLength = nodeLength;
                accumNode = node;
                return;
            }

            if (node.Left != null) FindGreatestBSTNode(node.Left, ref accumNode, ref accumNodeLength);
            if (node.Right != null) FindGreatestBSTNode(node.Right, ref accumNode, ref accumNodeLength);
        }

        static int BSTLength(Node node, int accumulator = 1)
        {
            var leftBSTLength = node.Left == null ? accumulator : node.Left.Value < node.Value ? BSTLength(node.Left, accumulator++) : 0;
            if (leftBSTLength == 0) return 0;
            var rightBSTLength = node.Right == null ? accumulator : node.Right.Value > node.Value ? BSTLength(node.Right, accumulator++) : 0;
            if (rightBSTLength == 0) return 0;
            return Math.Max(leftBSTLength, rightBSTLength);
        }
    }

    public class Node
    {
        public int Value;
        public Node Left, Right;
    }
}
