using System;

namespace _2019_07_06
{
    //This problem was asked by Google.
    //Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.
    //For example, given A = 3-> 7 -> 8 -> 10 and B = 99-> 1 -> 8 -> 10, return the node with value 8.
    //In this example, assume nodes with the same value are the exact same node objects.
    //Do this in O(M + N) time(where M and N are the lengths of the lists) and constant space.
    class Program
    {
        static void Main(string[] args)
        {
            var input = Build2Lists();
            var output = FindIntersection(input.Item1, input.Item2);
            Console.WriteLine($"Solution: {output?.Value}");
        }

        private static Node FindIntersection(Node list1, Node list2)
        {
            RebindListToStartNode(list1);
            return FindFirstNodeBindToStartNode(list2, list1);
        }

        private static Node FindFirstNodeBindToStartNode(Node listStart, Node startNode)
        {
            while (listStart.Next != null)
            {
                if (listStart.Next.Equals(startNode)) return listStart;
                listStart = listStart.Next;
            }

            return null;
        }

        private static void RebindListToStartNode(Node listStart)
        {
            var start = listStart;
            while (start.Next != null)
            {
                var next = start.Next;
                start.Next = listStart;
                start = next;
            }
        }

        private static (Node, Node) Build2Lists()
        {
            //A = 3 -> 7 -\
            //              8-> 10
            //B = 99 -> 1 -/
            var n3 = new Node(3);
            var n7 = new Node(7);
            var n8 = new Node(8);
            var n10 = new Node(10);

            var n99 = new Node(99);
            var n1 = new Node(1);

            n3.Next = n7;
            n7.Next = n8;
            n8.Next = n10;
            n99.Next = n1;
            n1.Next = n8;

            return (n3, n99);
        }
    }

    class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value;
        public Node Next;
    }
}