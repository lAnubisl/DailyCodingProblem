using System;

namespace DailyCodingProblem517
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.
    /// For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.
    /// In this example, assume nodes with the same value are the exact same node objects.
    /// Do this in O(M + N) time(where M and N are the lengths of the lists) and constant space.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new Node<int>(3, new Node<int>(7, new Node<int>(8, new Node<int>(10, null))));
            var list2 = new Node<int>(99, new Node<int>(1, new Node<int>(8, new Node<int>(10, null))));
            Console.WriteLine(Solve(list1, list2));
        }

        static T Solve<T>(Node<T> list1, Node<T> list2)
        {
            var current1 = list1;
            var current2 = list2;
            while (true)
            {
                if (Equals(current1.Value, current2.Value)) return current1.Value;
                current1 = current1.Next ?? list2;
                current2 = current2.Next ?? list1;
            }
        }
    }

    class Node<T>
    {
        public Node(T value, Node<T> next)
        {
            Next = next;
            Value = value;
        }

        public Node<T> Next { get; }
        public T Value { get; }
    }
}
