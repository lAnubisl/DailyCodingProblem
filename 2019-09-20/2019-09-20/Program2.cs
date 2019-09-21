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
            if (i >= a.Length) yield break;
            if (i == a.Length - 1) yield return a;
            for (int j = i; j <= a.Length - 1; j++)
            {
                if (!ShouldSwap(a, i, j)) continue;
                Swap(a, i, j); // permutation
                foreach (var p in Permute(a, i + 1)) yield return p;
                Swap(a, i, j); // restore
            }
        }

        static bool ShouldSwap(int[] a, int l, int r)
        {
            // This cpndition looks Ok when a[l] == a[r]
            // But it is a bit cinfusing when a[l] != a[r] but some item between them a[l+] == a[r]
            // The trick is that a[l+] should be handled by nested recursion call!
            for (int i = l; i < r; i++)
            {
                if (a[i] == a[r])
                {
                    return false;
                }
            }
            return true;
        }

        public static void Swap(int[] a, int i, int j)
        {
            if (i == j) return;
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        public static void Main()
        {
            foreach (var permutation in Permute(new int[] { 3, 1, 3, 2 }))
                Console.WriteLine($"[{string.Join(", ", permutation)}]");
            Console.ReadLine();
        }

        /*  (L1)   (L2)   (L3)   (L4)
            3132
                   3132
                          3132
                                 3132 -> Solution 1
                          3132
                            || permutation
                          3123
                                 3123 -> Solution 2
                          3123
                            || restore
                          3132
                   3132
                    || permutation
                   3312
                          3312
                                 3312 -> Solution 3
                          3312
                            || permutation
                          3321
                                 3321 -> Solution 4
                          3321
                            || restore
                          3312
                   3312
                    || restore
                   3132
                    | | permutation
                   3231
                          3231
                                 3231 -> Solution 5
                          3231
                            || permutation
                          3213
                                 3213 -> Solution 6
                          3213
                            || restore
                          3231
                   3231
                    | | restore
                   3132
            3132
            || permutation
            1332
                   1332
                          1332
                                 1332 -> Solution 7
                          1332
                            || permutation
                          1323
                                 1323 -> Solution 8
                          1323
                            || restore
                          1332
                   1332
                    || permutation
                  (1332) <- DUPLICATE DETECTED
                   1332
                    | | permutation
                   1233
                          1233
                                 1233 -> Solution 9
                          1233
                            || permutation
                         (1233) <- DUPLICATE DETECTED
                          1233
                   1233
                    | | restore
                   1332
            1332
            3132
            | | permutation
           (3132) <- DUPLICATE DETECTED
            3132
            |  | permutation
            2133
                   2133
                          2133
                                 2133 -> Solution 10
                          2133
                            || permutation
                         (2133) <- DUPLICATE DETECTED
                          2133
                   2133
                    ||  permutation
                   2313
                          2313
                                 2313 -> Solution 11
                          2313
                            || permutation
                          2331
                                 2331 -> Solution 12
                          2331
                            || restore
                          2313
                   2313
                    ||  restore
                   2133
                    | | permutation
                  (2331) <- DUPLICATE DETECTED
                   2133
            2133
            |  | restore
            3132
         */
    }
}