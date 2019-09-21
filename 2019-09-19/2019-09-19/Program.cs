using System;

namespace _2019_09_19
{
    /*
     Given a number represented by a list of digits, find the next greater permutation of a number, in terms of lexicographic ordering. If there is not greater permutation possible, return the permutation with the lowest value/ordering.
     For example, the list [1,2,3] should return [1,3,2]. The list [1,3,2] should return [2,1,3]. The list [3,2,1] should return [1,2,3].
    */
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(String.Join(", ", FindSolution(new int[] { 1, 2, 4, 3 })));
            Console.ReadKey();
        }

        static int[] FindSolution(int[] a)
        {
            var res = new int[a.Length];
            // copy original array to resulting array, 
            // so original array will not be modified
            Array.Copy(a, 0, res, 0, a.Length);

            // if we can't find next then find minimal one
            if (!FindNext(res)) Array.Sort(res);
            return res;
        }

        // start iterating array from the end to the beginning
        // the goal is to take lower rank and find lower value from upper ranks
        // [1, 2, 4, 3] -> [1, 3, 2, 4]
        //     ^     ^         ^ [sort the rest]
        static bool FindNext(int[] a)
        {
            for (int i = a.Length - 1; i > 0; i--)
                for (int j = i; j >= 0; j--) // if we have not found correct place for lower rank then take next one
                    if (a[j] < a[i])
                    {
                        Swap(a, i, j);

                        // sort the rest of array
                        Array.Sort(a, j + 1, a.Length - j - 1);
                        return true;
                    }

            return false;
        }

        static void Swap(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}