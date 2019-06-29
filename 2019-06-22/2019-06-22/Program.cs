using System;
using System.Collections.Generic;
using System.Text;

namespace _2019_06_22
{
	// An XOR linked list is a more memory efficient doubly linked list. 
	// Instead of each node holding next and prev fields, it holds a field named both, 
	// which is an XOR of the next node and the previous node. Implement an XOR linked list; 
	// it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
    // If using a language that has no pointers (such as Python), you can assume you have access to 
	// get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
    class Program
    {
        private static readonly IDictionary<string, Node> Memory = new Dictionary<string, Node>();
        private static XorLinkedList XorLinkedList = new XorLinkedList();
        private const string BeginAddress = "00000000";
        private const string EndAddress = "00000000";
        static void Main(string[] args)
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            Add(node1);
            Add(node2);
            Add(node3);
            Add(node4);
            Add(node5);

            Console.WriteLine(node1.Equals(Get(0)));
            Console.WriteLine(node2.Equals(Get(1)));
            Console.WriteLine(node3.Equals(Get(2)));
            Console.WriteLine(node4.Equals(Get(3)));
            Console.WriteLine(node5.Equals(Get(4)));
            Console.ReadKey();
        }

        public static void Add(Node node) 
        {
            if (XorLinkedList.Address == null)
            {
                node.Both = xorIt(BeginAddress, EndAddress);
                Memory.Add(node.Address, node);
                XorLinkedList.Address = node.Address;
                return;
            }

            var lastNode = GetLast();
            var prevNodeAddress = xorIt(lastNode.Both, EndAddress);
            lastNode.Both = xorIt(prevNodeAddress, node.Address);
            node.Both = xorIt(lastNode.Address, EndAddress);
            Memory.Add(node.Address, node);
        }

        public static Node Get(int index)
        {
            return Get(BeginAddress, null, XorLinkedList.Address, 0, index);
        }

        public static Node GetLast()
        {
            return GetLast(BeginAddress, null, XorLinkedList.Address);
        }

        private static Node Get(string prevNodeAddress, Node prevNode, string currNodeAddress, int currentIndex, int findIndex)
        {
            if (!Memory.ContainsKey(currNodeAddress)) throw new Exception("Node not found");
            var node = Memory[currNodeAddress];
            if (currentIndex == findIndex) return node;
            var nextNodeAddress = xorIt(node.Both, prevNodeAddress);
            return Get(currNodeAddress, node, nextNodeAddress, currentIndex + 1, findIndex);
        }

        private static Node GetLast(string prevNodeAddress, Node prevNode, string currNodeAddress)
        {
            if (!Memory.ContainsKey(currNodeAddress)) return prevNode;
            var node = Memory[currNodeAddress];
            var nextNodeAddress = xorIt(node.Both, prevNodeAddress);
            return GetLast(currNodeAddress, node, nextNodeAddress);
        }

        private static string xorIt(string key, string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            String result = sb.ToString();

            return result;
        }
    }
}
