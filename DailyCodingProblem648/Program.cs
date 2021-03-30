using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DailyCodingProblem648
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This question was asked by Snapchat.
    /// Given the head to a singly linked list, where each node also has a “random” pointer 
    /// that points to anywhere in the linked list, deep clone the list.
    /// </summary>
    class Program
    {
        static ObjectIDGenerator objectIdGenerator = new ObjectIDGenerator();
        static void Main(string[] args)
        {
            var input = GenerateInput();
            var output = DeepCopy(input);

            Print(input, "Input:");
            Print(output, "Output:");

            var arr = output.ToArray();
            Console.WriteLine(ReferenceEquals(arr[0], arr[0].OtherNode));
            Console.WriteLine(ReferenceEquals(arr[4], arr[4].OtherNode));

        }

        static void Print(LinkedList<Node> list, string title)
        {
            Console.WriteLine(title);
            foreach (var node in list)
            {
                Console.Write($"{node.Name} -> ");
            }
            Console.WriteLine();
            foreach (var node in list)
            {
                Console.Write($"{node.OtherNode.Name}    ");
            }
            Console.WriteLine();
        }

        static LinkedList<Node> DeepCopy(LinkedList<Node> list)
        {
            var length = GetLength(list);
            var dict = GetAddressDict(list);
            var result = new Node[length];

            int index = 0;
            foreach(var node in list)
            {
                result[index] = Clone(node);
                index++;
            }

            index = 0;
            foreach (var node in list)
            {
                result[index].OtherNode = result[dict[GetAddress(node.OtherNode)]];
                index++;
            }

            return new LinkedList<Node>(result);
        }

        static Node Clone(Node node)
        {
            return new Node { Name = node.Name };
        }

        static Dictionary<long, int> GetAddressDict(LinkedList<Node> input)
        {
            var length = GetLength(input);
            var dict = new Dictionary<long, int>(length);
            int index = 0;
            foreach (var node in input)
            {
                dict.Add(GetAddress(node), index);
                index++;
            }

            return dict;
        }

        /// <summary>
        /// Speed: O(n)
        /// Memory: O(1)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static int GetLength(LinkedList<Node> input)
        {
            int length = 0;
            foreach(var node in input)
            {
                length++;
            }

            return length;
        }

        static long GetAddress(Node node)
        {
            return objectIdGenerator.GetId(node, out bool firstTime);
        }

        static LinkedList<Node> GenerateInput()
        {
            var list = new LinkedList<Node>();

            var n1 = new Node { Name = "A" };
            var n2 = new Node { Name = "B" };
            var n3 = new Node { Name = "C" };
            var n4 = new Node { Name = "D" };
            var n5 = new Node { Name = "A" };
            var n6 = new Node { Name = "F" };
            var n7 = new Node { Name = "G" };

            n5.OtherNode = n1;
            n1.OtherNode = n1;
            n2.OtherNode = n3;
            n3.OtherNode = n7;
            n4.OtherNode = n5;
            n6.OtherNode = n5;
            n7.OtherNode = n2;

            list.AddLast(n1);
            list.AddLast(n2);
            list.AddLast(n3);
            list.AddLast(n4);
            list.AddLast(n5);
            list.AddLast(n6);
            list.AddLast(n7);

            return list;
        }
    }

    class Node
    {
        public string Name;

        public Node OtherNode { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }

        private bool Equals(Node other)
        {
            if (other == null) return false;
            return Equals(this.Name, other.Name);
        }

        public override int GetHashCode()
        {
            return Name == null ? 0 : Name.GetHashCode();
        }
    }
}
