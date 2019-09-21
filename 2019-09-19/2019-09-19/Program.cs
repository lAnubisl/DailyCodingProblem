using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_09_19
{
    /*
     Given a number represented by a list of digits, find the next greater permutation of a number, in terms of lexicographic ordering. If there is not greater permutation possible, return the permutation with the lowest value/ordering.
     For example, the list [1,2,3] should return [1,3,2]. The list [1,3,2] should return [2,1,3]. The list [3,2,1] should return [1,2,3].
    */
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 3, 2, 1 };
            var permutations = FindAllPermutations(input);
            permutations.Sort(new ArrayOfIntComparer());
            var lexicographiclyGreater = FindLexicographiclyGreater(permutations, input);
            if (lexicographiclyGreater == null) lexicographiclyGreater = permutations.First();
            Console.WriteLine("Hello World!");
        }

        static List<int[]> FindAllPermutations(int[] input)
        {
            if (input == null || input.Length == 0) return null;
            var accumulator = new List<List<int>>();
            accumulator.Add(new List<int>() { input.First() });
            for (var i = 1; i < input.Length; i++)
            {
                FindAllPermutations(input[i], ref accumulator);
            }

            return accumulator.Select(x => x.ToArray()).ToList();
        }

        static int[] FindLexicographiclyGreater(List<int[]> permutations, int[] marker)
        {
            var comparer = new ArrayOfIntComparer();
            foreach (var permutation in permutations)
            {
                if (comparer.Compare(permutation, marker) > 0) return permutation;
            }

            return null;
        }

        static void FindAllPermutations(int digit, ref List<List<int>> accumulator)
        {
            var temp = new List<List<int>>();
            foreach (var example in accumulator)
            {
                foreach (var newPermutation in FindAllPermutations(example, digit))
                {
                    temp.Add(newPermutation);
                }
            }

            accumulator = temp;
        }

        static IEnumerable<List<int>> FindAllPermutations(List<int> existingDigits, int newDigit)
        {
            for(var i = 0; i <= existingDigits.Count; i++)
            {
                var res = new List<int>(existingDigits);
                res.Insert(i, newDigit);
                yield return res;
            }
        }

        public class ArrayOfIntComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                for(var i = 0; i < x.Length; i++)
                {
                    if (x[i] > y[i]) return 1;
                    if (x[i] < y[i]) return -1;
                }

                return 0;
            }
        }
    }
}