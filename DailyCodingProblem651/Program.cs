using System;
using System.Collections.Generic;

namespace DailyCodingProblem651
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by LinkedIn.
    /// Determine whether a tree is a valid binary search tree.
    /// A binary search tree is a tree with two children, left and right, 
    /// and satisfies the constraint that the key in the left child must be less than or equal to the root and the key in the right child must be greater than or equal to the root.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var tree = BuildTree();
            Console.WriteLine(Solve(tree));
        }

        static bool Solve(Node root)
        {
            var queue = new Queue<QueueItem>();
            queue.Enqueue(new QueueItem(root, null, null, false, false));
            while(queue.TryDequeue(out QueueItem current))
            {
                if (current.grandParent != null)
                {
                    if (current.grToPLeft && !current.pToILeft && current.item.Value > current.grandParent.Value)
                    {
                        return false;
                    }

                    if (!current.grToPLeft && current.pToILeft && current.item.Value < current.grandParent.Value)
                    {
                        return false;
                    }
                }

                if (current.parent != null)
                {
                    if (current.pToILeft && current.item.Value > current.parent.Value)
                    {
                        return false;
                    }

                    if (!current.pToILeft && current.item.Value < current.parent.Value)
                    {
                        return false;
                    }
                }

                if (current.item.Left != null)
                {
                    queue.Enqueue(new QueueItem(current.item.Left, current.item, current.parent, true, current.pToILeft));
                }

                if(current.item.Right != null)
                {
                    queue.Enqueue(new QueueItem(current.item.Right, current.item, current.parent, false, current.pToILeft));
                }
            }

            return true;
        }

        static Node BuildTree()
        {
            return new Node
                (
                    5,
                    new Node
                        (
                            3,
                            new Node
                            (
                                2,
                                new Node
                                (
                                    1,
                                    null,
                                    null
                                ),
                                null
                            ),
                            new Node
                            (
                                6,
                                null,
                                null
                            )
                        ),
                    new Node
                    (
                        10,
                        new Node
                        (
                            7,
                            null,
                            null
                        ),
                        new Node
                        (
                            11,
                            null,
                            null
                        )
                    )
                );
        }
    }

    class QueueItem
    {
        public QueueItem(Node item, Node parent, Node grandParent, bool pToILeft, bool grToPLeft)
        {
            this.item = item;
            this.parent = parent;
            this.grandParent = grandParent;
            this.grToPLeft = grToPLeft;
            this.pToILeft = pToILeft;

        }
        public Node item, parent, grandParent;
        public bool grToPLeft, pToILeft;
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
