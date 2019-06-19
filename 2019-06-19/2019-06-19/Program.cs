using System;

namespace _2019_06_19
{
    class Node
    {
        public string Value;
        public Node Left;
        public Node Right;
    }

    class Serializer
    {
        public string Serialize(Node node)
        {
            if (node == null) return string.Empty;
            return $"[{node.Value},{Serialize(node.Left)},{Serialize(node.Right)}]";
        }

        public Node Deserialize(string serializedNode)
        {
            if (string.IsNullOrEmpty(serializedNode)) return null;
            return Deserialize(serializedNode.ToCharArray());
        }

        static Node Deserialize(char[] serializedNode)
        {
            var leftBound = 0;
            return Deserialize(serializedNode, ref leftBound);
        }

        static Node Deserialize(char[] serializedNode, ref int leftBound)
        {
            if (serializedNode[leftBound] != '[') return null;
            leftBound += 1;
            var value = ReadUntil(serializedNode, ref leftBound, ',');
            leftBound += 1;
            var leftNode = Deserialize(serializedNode, ref leftBound);
            leftBound += 1;
            var rightNode = Deserialize(serializedNode, ref leftBound);
            leftBound += 1;
            return new Node
            {
                Value = value,
                Left = leftNode,
                Right = rightNode
            };
        }

        static string ReadUntil(char[] serializedNode, ref int leftBound, char c)
        {
            var start = leftBound;
            var end = Array.IndexOf(serializedNode, c, leftBound, serializedNode.Length - leftBound);
            var length = end - start;
            leftBound += length;
            var res = new char[length];
            Array.Copy(serializedNode, start, res, 0, length);
            return new string(res);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var node = new Node
            {
                Value = "root",
                Left = new Node
                {
                    Value = "left",
                    Left = new Node
                    {
                        Value = "left.left"
                    }
                },
                Right = new Node
                {
                    Value = "right"
                }
            };
            var serializer = new Serializer();
            var s = serializer.Serialize(node);
            var n = serializer.Deserialize(s);
            Console.WriteLine(n.Left.Left.Value == "left.left");
            Console.ReadKey();
        }
    }
}