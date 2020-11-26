using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem518
{
    /// <summary>
    /// This problem was asked by Microsoft.
    /// Given an array of numbers and a number k, determine if there are three entries in the array which add up to the 
    /// specified number k.For example, given[20, 303, 3, 4, 25] and k = 49, return true as 20 + 4 + 25 = 49
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 20, 202, 3, 4, 25 };
            var k = 49;

            Console.WriteLine(Solve(array, k));
        }

        static bool Solve(int[] array, int k)
        {
            return Solve(array, 0, k);
        }

        static bool Solve(int[] array, int index, int k)
        {
            if (k == 0) return true;
            if (index >= array.Length) return false;
            return array[index] <= k 
                ? Solve(array, index + 1, k) || Solve(array, index + 1, k - array[index])
                : Solve(array, index + 1, k);
        }
    }
}
