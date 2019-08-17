using System;

namespace _2019_08_17
{
    /*
        There is an N by M matrix of zeroes. Given N and M, write a function to count the number of ways of starting at the top-left corner and getting to the bottom-right corner. You can only move right or down.

        For example, given a 2 by 2 matrix, you should return 2, since there are two ways to get to the bottom-right:

        Right, then down
        Down, then right
        Given a 5 by 5 matrix, there are 70 ways to get to the bottom-right.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateNumberOfWays(1, 1, 5, 5));
            Console.ReadKey();
        }

        static int CalculateNumberOfWays(int fromX, int fromY, int toX, int toY)
        {
            if (fromX == toX && fromY == toY) return 1;
            if (fromX == toX) return CalculateNumberOfWays(fromX, fromY + 1, toX, toY);
            if (fromY == toY) return CalculateNumberOfWays(fromX + 1, fromY, toX, toY);
            return CalculateNumberOfWays(fromX, fromY + 1, toX, toY) + CalculateNumberOfWays(fromX + 1, fromY, toX, toY);
        }
    }
}