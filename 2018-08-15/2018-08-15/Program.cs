using System;
using System.Linq;

namespace _2018_08_15
{
    /*
        Given a multiset of integers, return whether it can be partitioned into two subsets whose sums are the same.
        For example, given the multiset {15, 5, 20, 10, 35, 15, 10}, it would return true, since we can split it up into {15, 5, 10, 15, 10} and {20, 35}, which both add up to 55.
        Given the multiset {15, 5, 20, 10, 35}, it would return false, since we can't split it up into two subsets that add up to the same sum.
         */
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 15, 5, 20, 10, 35, 15, 10 };
            Console.WriteLine(CanDevideEqually(array));
            Console.ReadKey();
        }

        static bool CanDevideEqually(int[] array)
        {
            var total = array.Sum();
            if (total % 2 == 1) return false;
            return CanSum(array, total / 2, 0);
        }

        static bool CanSum(int[] array, int sum, int startIndex)
        {
            if (sum == 0) return true;
            if (startIndex == array.Length) return false;
            return CanSum(array, sum, startIndex + 1) || CanSum(array, sum - array[startIndex], startIndex + 1);
        }
    }
}
