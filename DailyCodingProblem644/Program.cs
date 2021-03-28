using System;

namespace DailyCodingProblem644
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
    /// Given the root to a binary tree, count the number of unival subtrees.
    /// For example, the following tree has 5 unival subtrees:
    ///    0
    ///   / \
    ///  1   1
    ///     / \
    ///    1   1
    ///   / \
    ///  1   1
    ///  
    /// 
    ///  The plan:
    ///  1) build the tree
    ///  2) Recursivelly check 'CountUniversal' from root node
    ///  Node is universal if both children are the same value and they are universal
    ///  also the parent of current node is not universal if current value is different from child node values
    ///  
    /// </summary>
    class Program
    {
        static Node BuildGraph()
        {
            return new Node(0,
                new Node(1, null, null),
                new Node(1,
                    new Node(1,
                        new Node(1, null, null),
                        new Node(1, null, null)
                    ),
                    new Node(1, null, null)
                )
            );
        }

        static void Main(string[] args)
        {
            var graph = BuildGraph();
            Console.WriteLine(Solve(graph));
            Console.ReadLine();
        }

        static int Solve(Node graph)
        {
            var result = CountUniversal(graph);
            return result.UniversalsCount;
        }

        static CalculationResult CountUniversal(Node node)
        {
            if (node.Left == null && node.Right == null) return new CalculationResult(1, true, true);
            var leftCounted = new CalculationResult(0, true, true);
            var rightCounted = new CalculationResult(0, true, true);
            if (node.Left != null)
            {
                leftCounted = CountUniversal(node.Left);
            }
            if (node.Right != null)
            {
                rightCounted = CountUniversal(node.Right);
            }
            var isUniversal =
                   leftCounted.ParentCanBeUniversal
                && rightCounted.ParentCanBeUniversal
                && leftCounted.IsUniversal
                && rightCounted.IsUniversal
                && ChildrenHaveSameValue(node);
            return new CalculationResult(
                leftCounted.UniversalsCount + rightCounted.UniversalsCount + (isUniversal ? 1 : 0),
                leftCounted.IsUniversal && rightCounted.IsUniversal,
                leftCounted.ParentCanBeUniversal && rightCounted.ParentCanBeUniversal
                && SameValueAsChildren(node)
            );
        }

        static bool ChildrenHaveSameValue(Node node)
        {
            if (node.Left == null) return false;
            if (node.Right == null) return false;
            return node.Left.Value == node.Right.Value;
        }

        static bool SameValueAsChildren(Node node)
        {
            if (node.Left == null) return false;
            if (node.Right == null) return false;
            return node.Value == node.Left.Value && node.Value == node.Right.Value;
        }
    }

    class CalculationResult
    {
        public CalculationResult(int universalsCount, bool isUniversal, bool parentCanBeUniversal)
        {
            UniversalsCount = universalsCount;
            IsUniversal = isUniversal;
            ParentCanBeUniversal = parentCanBeUniversal;
        }
        public int UniversalsCount { get; }
        public bool IsUniversal { get; }
        public bool ParentCanBeUniversal { get; }
    }

    class Node
    {
        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
        public int Value { get; }
        public Node Left { get; }
        public Node Right { get; }
    }
}
