using System;
using System.Collections.Generic;

namespace _2019_06_17
{
    //Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
    //For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
    //Bonus: Can you do this in one pass?
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 15, 3, 7 };
            var k = 17;
            Console.WriteLine(Check(arr, k));
            Console.ReadKey();
        }

        private static bool Check(int[] arr, int k)
        {
            var set = new HashSet<int>();
            foreach(var i in arr)
            {
                if (set.Contains(i)) return true;
                set.Add(k - i);
            }

            return false;
        }
    }
}