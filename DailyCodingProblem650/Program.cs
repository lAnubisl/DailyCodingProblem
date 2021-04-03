using System;

namespace DailyCodingProblem650
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// Let A be an N by M matrix in which every row and every column is sorted.
    /// Given i1, j1, i2, and j2, compute the number of elements of A smaller than A[i1, j1] and 
    /// larger than A[i2, j2].
    /// For example, given the following matrix:
    /// [[ 1,  3,  7, 10, 15, 20],
    ///  [ 2,  6,  9, 14, 22, 25],
    ///  [ 3,  8, 10, 15, 25, 30],
    ///  [10, 11, 12, 23, 30, 35],
    ///  [20, 25, 30, 35, 40, 45]]
    ///  
    /// And i1 = 1, j1 = 1, 
    ///     i2 = 3, j2 = 3, return 15 as there are 15 numbers in the matrix smaller than 6 or greater than 23.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[,] {
                {  1,  3,  7, 10, 15, 20 },
                {  2,  6,  8, 14, 22, 25 },
                {  3,  8, 10, 15, 25, 30 },
                { 10, 11, 12, 23, 30, 35 },
                { 20, 25, 30, 35, 40, 45 }
            };
            var i1 = 4;
            var j1 = 2;
            var i2 = 2;
            var j2 = 3;

            Console.WriteLine(Solve(input, i1, j1, i2, j2));
        }

        static void Swap(ref int a, ref int b)
        {
            var c = b;
            b = a;
            a = c;
        }

        static int Solve(int[,] a, int i1, int j1, int i2, int j2)
        {
            var result = 0;
            var equalCount = 0;
            var n = a.GetLength(0);
            var m = a.GetLength(1);
            bool swapped = false;
            if (a[i1, j1] > a[i2, j2])
            {
                swapped = true;
                Swap(ref i1, ref i2);
                Swap(ref j1, ref j2);
            }

            for (var i = 0; i < i1; i++)
            for (var j = j1 + 1; j < m; j++)
            if (Iterate(a[i, j], a[i1, j1], (x, y) => x > y, ref result, ref equalCount))
            break;

            for (var j = 0; j < j1; j++)
            for (var i = i1 + 1; i < n; i++)
            if (Iterate(a[i, j], a[i1, j1], (x, y) => x > y, ref result, ref equalCount))
            break;

            for (var i = i2 + 1; i < n; i++)
            for (var j = j2 - 1; j >= 0; j--)
            if (Iterate(a[i, j], a[i2, j2], (x, y) => x < y, ref result, ref equalCount))
            break;

            for (var j = j2 + 1; j < m; j++)
            for (var i = i2 - 1; i >= 0; i--)
            if (Iterate(a[i, j], a[i2, j2], (x, y) => x < y, ref result, ref equalCount))
            break;

            result = result 
                + ((i1 + 1) * (j1 + 1) - 1) 
                + ((n - i2) * (m - j2) - 1);

            if (swapped)
            {
                result = n * m - result - equalCount - 2;
            }

            return result;
        }

        static bool Iterate(int val, int compareTo, Func<int, int, bool> func, ref int result, ref int equalsCounter)
        {
            if (func(val, compareTo))
            {
                return true;
            }

            if (val == compareTo)
            {
                equalsCounter++;
                return true;
            }

            result++;
            return false;
        }
    }
}
