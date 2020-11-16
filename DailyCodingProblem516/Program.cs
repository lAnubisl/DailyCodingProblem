using System;
using System.Collections;
using System.Linq;

namespace DailyCodingProblem516
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Zillow.
    /// Let's define a "sevenish" number to be one which is either a power of 7, or the sum of unique powers of 7. 
    /// The first few sevenish numbers are 1, 7, 8, 49, and so on. Create an algorithm to find the nth sevenish number.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindNthPowerOfSeven(2));
        }

        static ulong FindNthPowerOfSeven(int n)
        {
            var bits = new BitArray(BitConverter.GetBytes(n)).Cast<bool>().Reverse().SkipWhile(x => !x).Reverse().ToArray();
            ulong result = 0;
            for(int i = 0; i < bits.Length; i++) result += bits[i] ? (ulong)Math.Pow(7, i) : 0;
            return result;
        }
    }
}