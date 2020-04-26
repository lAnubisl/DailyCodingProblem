using System;

namespace _2020_04_26
{
    /* Good morning! Here's your coding interview problem for today.
     * This problem was asked by Google.
     * In linear algebra, a Toeplitz matrix is one in which the elements on any given diagonal from top left to bottom right are identical.
     * Here is an example:
     * 1 2 3 4 8
     * 5 1 2 3 4
     * 4 5 2 2 3
     * 7 4 5 1 2
     * Write a program to determine whether a given input is a Toeplitz matrix.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(new int[,] { 
                { 1, 2, 3, 4, 8 }, 
                { 5, 1, 2, 3, 4 }, 
                { 4, 5, 1, 2, 3 }, 
                { 7, 4, 5, 1, 2 } 
            }));
        }

        static bool Solve(int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Rank != 2) throw new ArgumentException("matrix should have 2 dimensions");
            if (matrix.GetLength(0) == 1 || matrix.GetLength(1) == 1) return true;

            for(var j = matrix.GetLength(1) - 1; j >= 0 ; j--)
            {
                if (!Scan(0, j, matrix)) return false;
            }

            for(var i = 1; i < matrix.GetLength(0); i++)
            {
                if (!Scan(i, 0, matrix)) return false;
            }

            return true;
        }

        private static bool Scan(int x, int y, int[,] matrix)
        {
            var value = matrix[x, y];
            x++;
            y++;
            while (x < matrix.GetLength(0) && y < matrix.GetLength(1))
            {
                if (matrix[x, y] != value)
                {
                    return false;
                }

                x++;
                y++;
            }

            return true;
        }
    }
}