using System;
using System.Linq;

namespace _2019_09_20
{
    /*
     Given a number in the form of a list of digits, return all possible permutations.
     For example, given [1,2,3], return [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    */
    class Program
    {
        // First. add fuction that generates permutations for an array and an integer.
        // The goal is to place that integer before each digit in an array and in the end.
        // [1, 2, 3], 4 => [4, 1, 2, 3], [1, 4, 2, 3], [1, 2, 4, 3], [1, 2, 3, 4]
        //                  ^                ^                ^                ^
        static int[][] Permutations(int[] a, int x)
        {
            // number of the resulted permutation is the size of an array + 1
            // because we need to place digit before each digit from array + in the end
            var result = new int[a.Length + 1][];
            for (var i = 0; i < result.Length; i++) // for each such case
            {
                // each array will be 1 item longer than original one because we will insert digit into it
                result[i] = new int[a.Length + 1];
                // allocate 2 indexes, they will be incremented together but at some point
                // the 'resultedArrayIndex' will become bigger by 1 at some point.
                var resultedArrayIndex = 0;
                var sourceArrayIndex = 0;
                while (resultedArrayIndex < result[i].Length) // fill the resulted array from the beginning to the end
                {
                    if (resultedArrayIndex == i) // i is also an index to put digit
                    {
                        result[i][resultedArrayIndex] = x;
                        resultedArrayIndex++; // 'resultedArrayIndex' becomes greater than 'sourceArrayIndex'
                        continue; // check array boundary conditions and repeat if need
                    }

                    // copy value from source array to resulted one
                    result[i][resultedArrayIndex] = a[sourceArrayIndex];
                    // increment both indexes
                    resultedArrayIndex++; sourceArrayIndex++;
                }
            }

            return result;
        }

        // Now, when we have function that generated permutations for an array and digit
        // let's chin permutations. We will start with 1 digit and permutate it using second one
        // then we will permutate all results from previous iterations with next digits
        // and so one until we run out of digits.
        static int[][] Permutations(int[] a)
        {
            if (a == null || a.Length == 0) return null; // no permutations for empty array
            var res = new int[][] { new int[] { a[0] } }; // init state. This is 'permutation' for single digit
            for(var i = 1; i < a.Length; i++) // for each digit starting from second, calculate permutations
                res = res.SelectMany(r => Permutations(r, a[i])).ToArray();

            return res;
        }

        // Now. generate the input and calculate the result
        static void Main(string[] args)
        {
            var result = Permutations(new[] { 1, 2, 3 });
            foreach (var r in result)
            {
                Console.WriteLine($"[{String.Join(", ", r)}]");
            }

            Console.ReadLine();
        }
    }
}