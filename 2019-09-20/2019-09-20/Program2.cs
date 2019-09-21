using System;
using System.Collections.Generic;

namespace _2019_09_20
{    
    /*
     Given a number in the form of a list of digits, return all possible permutations.
     For example, given [1,2,3], return [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    */
    class Program2
    {
        private static IEnumerable<int[]> Permute(int[] a, int i = 0)
        {
            if (i == a.Length - 1)
            {
                yield return a;
            }

            for (int j = i; j <= a.Length - 1; j++)
            {
                Swap(a, i, j);
                foreach (var p in Permute(a, i + 1)) yield return p;
                Swap(a, i, j);
            }
        }

        public static void Swap(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        public static void Main()
        {
            var a = new int[] { 1, 2, 3 };
            foreach (var permutation in Permute(a))
            Console.WriteLine($"[{string.Join(", ", permutation)}]");
            Console.ReadLine();
        }
    }
}