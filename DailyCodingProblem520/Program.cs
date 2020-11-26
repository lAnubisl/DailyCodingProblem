using System;

namespace DailyCodingProblem520
{
    /// <summary>
    /// This problem was asked by LinkedIn.
    /// You are given a binary tree in a peculiar string representation.Each node is written in the form (lr), 
    /// where l corresponds to the left child and r corresponds to the right child.
    /// If either l or r is null, it will be represented as a zero. Otherwise, it will be represented by a new(lr) pair.
    /// Here are a few examples:
    ///     A root node with no children: (00)
    ///     A root node with two children: ((00)(00))
    ///     An unbalanced tree with three consecutive left children: ((((00)0)0)0)
    /// Given this representation, determine the depth of the tree.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("((((00)0)0)0)"));
        }

        static int Solve(string treeStringRepresentation)
        {
            int result = 0;
            int current = 0;
            foreach(var c in treeStringRepresentation.ToCharArray())
            {
                if (c == '(') current++;
                if (c == ')') current--;
                if (current > result) result = current;
            }
            return result;
        }
    }
}
