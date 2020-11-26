using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem525
{
    /// <summary>
    /// This problem was asked by Amazon.
    /// Given a N by M matrix of numbers, print out the matrix in a clockwise spiral.
    /// For example, given the following matrix:
    /// [[1,  2,  3,  4,  5],
    /// [6,  7,  8,  9,  10],
    /// [11, 12, 13, 14, 15],
    /// [16, 17, 18, 19, 20]]
    /// 
    /// You should print out the following: 1, 2, 3, 4, 5, 10, 15, 20, 19, 18, 17, 16, 11, 6, 7, 8, 9, 14, 13, 12
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver(new int[,]
            {
                { 01, 02, 03, 04, 05 },
                { 06, 07, 08, 09, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 }
            });
            solver.Solve();
        }
    }

    class Solver
    {
        private readonly int[,] m;
        private readonly int x, y;
        public Solver(int[,] matrix)
        {
            m = matrix;
            x = m.GetLength(1);
            y = m.GetLength(0);
        }

        public void Solve()
        {
            var list = new List<int>(x * y);
            var minDimension = Math.Min(x, y);
            var iterations = minDimension % 2 == 0 ? minDimension / 2 : (minDimension + 1) / 2;
            for (var i = 0; i <= iterations; i++) list.AddRange(L2R(i).Union(T2B(i)).Union(R2L(i)).Union(B2T(i)));
            foreach (var i in list) Console.WriteLine(i);
        }

        IEnumerable<int> L2R(int offset)
        {
            for (int i = 0 + offset; i < x - 1 - offset; i++) yield return m[offset, i];
        }

        IEnumerable<int> R2L(int offset)
        {
            for (int i = x - 1 - offset; i > offset; i--) yield return m[y - 1 - offset, i];
        }

        IEnumerable<int> B2T(int offset)
        {
            for (int i = y - 1 - offset; i > offset; i--) yield return m[i, offset];
        }

        IEnumerable<int> T2B(int offset)
        {
            for (int i = 0 + offset; i < x - 1 - offset; i++) yield return m[i, x - 1 - offset];
        }
    }
}
