using System;

namespace _2019_06_20
{
    class Program
    {
        //Given an array of integers, find the first missing positive integer in linear time and constant space.In other words, find the lowest positive integer that does not exist in the array.The array can contain duplicates and negative numbers as well.
        //For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
        //You can modify the input array in-place.
        static void Main(string[] args)
        {
            var input1 = new int[] { 1, -1, -5, -3, 3, 4, 2, 8 };
            var input2 = new int[input1.Length];

            Array.Copy(input1, input2, input1.Length);
            Solution1.Solve(input1);
            Solution2.Solve(input2);
            Console.ReadKey();
        }
    }
}