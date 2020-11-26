using System;
using System.Linq;

namespace DailyCodingProblem524
{
    /// <summary>
    /// This problem was asked by Amazon.
    /// Given an array of numbers, find the maximum sum of any contiguous subarray of the array.
    /// For example, given the array[34, -50, 42, 14, -5, 86], the maximum sum would be 137, since we would take elements 42, 14, -5, and 86.
    /// Given the array[-5, -1, -8, -9], the maximum sum would be 0, since we would not take any elements.
    /// Do this in O(N) time.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 34, -50, 42, 14, -5, 86 };
            Console.WriteLine(Solve(array));
        }

        static int Solve(int[] input)
        {
            // CPU: O(n), Mem: O(1)
            if (input == null || input.Length == 0) return 0;
            var right = FindRightSpikeLocation(input);
            if (right == -1) return 0;
            var left = FindLeftSpikeLocation(input);
            return Enumerable.Range(left, right - left + 1).Sum(i => input[i]);
        }

        static int FindLeftSpikeLocation(int[] input)
        {
            var spike = input[input.Length - 1];
            var spikeLocation = input.Length - 1;
            var current = input[input.Length - 1];
            for (var i = input.Length - 1; i >= 0; i--)
            {
                current += input[i];
                if (current > spike)
                {
                    spike = current;
                    spikeLocation = i;
                }
            }

            if (spike < 0) return -1;
            return spikeLocation;
        }

        static int FindRightSpikeLocation(int[] input)
        {
            var spike = input[0];
            var spikeLocation = 0;
            var current = input[0];
            for(var i = 1; i < input.Length; i++)
            {
                current += input[i];
                if (current > spike)
                {
                    spike = current;
                    spikeLocation = i;
                }
            }

            if (spike < 0) return -1;
            return spikeLocation;
        }
    }
}
