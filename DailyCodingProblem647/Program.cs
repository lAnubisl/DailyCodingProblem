using System;
using System.Linq;

namespace DailyCodingProblem647
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Facebook.
    /// Given a multiset of integers, return whether it can be partitioned into 
    /// two subsets whose sums are the same
    /// For example, given the multiset { 15, 5, 20, 10, 35, 15, 10}, it would return true, 
    /// since we can split it up into {15, 5, 10, 15, 10} and {20, 35}, which both add up to 55.
    /// Given the multiset {15, 5, 20, 10, 35}, it would return false, since we can't split it 
    /// up into two subsets that add up to the same sum.
    /// 
    /// The plan:
    /// 1) Find the sum of all numbers and divide by 2 => the number we need to find sum of array numbers
    /// 2) Use binary recursion to find if we can get the half-sum made of values from the array. the rest 
    /// values will be in other half
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { 15, 5, 20, 10, 35, 15, 10 };
            Console.WriteLine(Solve(input));
            Console.ReadLine();
        }

        static bool Solve(int[] input)
        {
            var sum = input.Sum(x => x);
            // Now optimizations:
            // For integers:
            if (sum % 2 == 1) return false;
            return Solve(input, sum / 2, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">the input array</param>
        /// <param name="target">value we need to build from input data</param>
        /// <param name="index">input array index where we currently are</param>
        /// <returns></returns>
        static bool Solve(int[] input, int target, int index)
        {
            if (index >= input.Length) return false; // reach the end of array and did not make it
            if (target == 0) return true; // the target will be decreased in some iterations. 
            // once target is 0 then we found our combination

            // now the binary recursion.
            // it is binary because each iteration we will split solution into 2 parts:
            // 1) take the current number in sum
            // 2) do not take the current number in sum

            return Solve(input, target - input[index], index + 1) // try to use the number
                || Solve(input, target, index + 1); // try to skip the number
        }
    }
}
