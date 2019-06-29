using System;

namespace _2019_06_24
{
    internal sealed class Node
    {
        internal int Value;
        internal Node Left;
        internal Node Right;
    }
    class Program
    {
        // A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
        // Given the root to a binary tree, count the number of unival subtrees.
        // For example, the following tree has 5 unival subtrees:
        //   0
        //  / \
        // 1   0
        //    / \
        //   1   0
        //  / \
        // 1   1
        static void Main(string[] args)
        {
            var root = new Node
            {
                Value = 0,
                Left = new Node
                {
                    Value = 1
                },
                Right = new Node
                {
                    Value = 0,
                    Left = new Node
                    {
                        Value = 1,
                        Left = new Node
                        {
                            Value = 1
                        },
                        Right = new Node
                        {
                            Value = 1
                        }
                    },
                    Right = new Node
                    {
                        Value = 0
                    }
                }
            };
            Console.WriteLine(CountUnivalSubtrees(root));
            Console.ReadKey();
        }

        private static int CountUnivalSubtrees(Node root)
        {
            var counter = 0;
            IsUnivalNode(root, ref counter);
            return counter;
        }

        private static bool IsUnivalNode(Node node, ref int counter)
        {
            var result = true;
            if (node.Left != null) result &= IsUnivalNode(node.Left, ref counter) && node.Left.Value == node.Value;
            if (node.Right != null) result &= IsUnivalNode(node.Right, ref counter) && node.Right.Value == node.Value;
            if (result) counter++;
            return result;
        }
    }
}