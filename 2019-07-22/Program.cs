using System;

namespace _2019_07_22
{
    //Given the root to a binary search tree, find the second largest node in the tree.
    class Program
    {
        static void Main(string[] args)
        {
            var tree = GenerateBinarySearchTree();
            var solution = FindSecondLargest(tree);
            Console.WriteLine("Second largest node value is:" + solution);
            Console.ReadKey();
        }

        static int FindSecondLargest(Node root)
        {
            var largestNode = root;
            var secondLargestNode = root;

            while(largestNode.Right != null)
            {
                secondLargestNode = largestNode;
                largestNode = largestNode.Right;
            }

            if (largestNode.Left != null)
            {
                secondLargestNode = largestNode.Left;
                while(secondLargestNode.Right != null)
                {
                    secondLargestNode = secondLargestNode.Right;
                }
            }

            return secondLargestNode.Value;
        }

        static Node GenerateBinarySearchTree()
        {
            return
                new Node(10,
                    new Node(5,
                        new Node(2),
                        new Node(7)),
                    new Node(20,
                        new Node(15),
                        new Node(30, new Node(25)))
            );
        }
    }

    class Node
    {
        public Node(int value, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public readonly int Value;
        public readonly Node Left;
        public readonly Node Right;
    }
}
