using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem526
{
    /// <summary>
    /// This problem was asked by Yahoo.
    /// You are given a string of length N and a parameter k.
    /// The string can be manipulated by taking one of the first k letters and moving it to the end.
    /// Write a program to determine the lexicographically smallest string that can be created after an unlimited number of moves.
    /// For example, suppose we are given the string daily and k = 1.
    /// The best we can create in this case is ailyd.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("daily", 2));
        }

        static string Solve(string word, int k)
        {
            var unsorted = word.ToCharArray();
            var sorted = unsorted.OrderBy(c => c).ToArray();
            var list = new LinkedList<char>(unsorted);
            for (int i = 0; i < k; i++)
            {
                var ith = list.ElementAt(i);
                while (sorted[i] != ith)
                {
                    list.AddLast(ith);
                    list.Remove(ith);
                }
            }

            return string.Join("", list);
        }
    }
}
