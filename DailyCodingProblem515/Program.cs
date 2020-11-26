using System;
using System.Collections.Generic;

namespace DailyCodingProblem515
{
    /// <summary>
    /// This problem was asked by LinkedIn.
    /// Given a linked list of numbers and a pivot k, partition the linked list so that all nodes less than k come before nodes greater than or equal to k.
    /// For example, given the linked list 5 -> 1 -> 8 -> 0 -> 3 and k = 3, the solution could be 1 -> 0 -> 5 -> 8 -> 3
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Node(5, new Node(1, new Node(8, new Node(0, new Node(3, null)))));
            var pivot = 3;

        }

        static Node NextGreaterThan(int pivot, Node node)
        {

        }

        static void ReLink(Node to, Node from, Node beforeFrom)
        {
            beforeFrom.Next = from.Next;
            from.Next = to.Next;
            to.Next = from;
        }
    }

    class Node
    {
        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }

        public int Value { get; }

        public Node Next { get; set; }
    }
}
