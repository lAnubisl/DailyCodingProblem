using System;
using System.Collections.Generic;

namespace _2019_09_20
{
    /*
     Given a number in the form of a list of digits, return all possible permutations. 
     For example, given [1,2,3], return [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    */
    class Program3
    {
        /*
         The idea is to swap 2 elements in the following way:
         iteration   data
         input        1 <> 2    3
         1            2    1 <> 3
         2            2 <> 3    1
         3            3    2 <> 1
         4            3 <> 1    2
         5            1    3 <> 2
         6            1    2    3

         The number of permutations for unique elements is always n! where n is the number of elements
       */
        static IEnumerable<int[]> Permutations(int[] a)
        {
            var count = Fuctorial(a.Length);
            var i = 0;
            while (count > 0)
            {
                Swap(a, i, i + 1);
                yield return a;
                count--;
                i = i == a.Length - 2 ? 0 : i + 1; // a.Length - 2 because the last index is a.Length - 1 and we should not go so far because we are swapping current index with next one
            }
        }

        static int Fuctorial(int n) => n == 0 ? 1 : n * Fuctorial(n - 1);

        static void Swap(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        public static void Main()
        {
            var a = new int[] { 1, 2, 3 };
            foreach (var permutation in Permutations(a))
                Console.WriteLine($"[{string.Join(", ", permutation)}]");
            Console.ReadLine();
        }
    }
}