using System;

namespace DailyCodingProblem519
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// Given three 32-bit integers x, y, and b, return x if b is 1 and y if b is 0, using only mathematical or bit 
    /// operations. You can assume b can only be 1 or 0.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int x = 7;
            int y = 9;
            int b = 1;
            Console.WriteLine(x * b + y * (b ^ 1));
        }
    }
}
