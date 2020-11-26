using System;
using System.Linq;

namespace DailyCodingProblem523
{
    /// <summary>
    /// This problem was asked by Jane Street.
    /// Given integers M and N, write a program that counts how many positive integer pairs(a, b) satisfy the following conditions:
    /// a + b = M
    /// a XOR b = N
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // CPU: O(m), Mem: O(1)
            Console.WriteLine(Solve(100, 100));
        }

        static int Solve(int m, int n)
        {
            return Enumerable.Range(1, (m / 2) - 1).Where(i => (i ^ (m - i)) == n).Count() * 2;
        }
    }
}
