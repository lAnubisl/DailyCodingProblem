using System;

namespace _2019_06_19
{
    //Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
    //For example, given the following Node class
    //class Node :
    //    def __init__(self, val, left=None, right=None):
    //        self.val = val
    //        self.left = left
    //        self.right = right
    //The following test should pass:
    //node = Node('root', Node('left', Node('left.left')), Node('right'))
    //assert deserialize(serialize(node)).left.left.val == 'left.left'
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