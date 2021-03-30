using System;

namespace DailyCodingProblem649
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// Given a string, return the first recurring character in it, or null if there is no recurring character.
    /// For example, given the string "acbbac", return "b". Given the string "abcdef", return null.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var result = Solve("abcdef");
            Console.WriteLine("Hello World!");
        }


        /// <summary>
        /// Speed: O(n)
        /// Memory: O(1)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static char? Solve(string text)
        {
            var markers = new bool['z'];
            foreach(var c in text.ToCharArray())
            {
                if (markers[c])
                {
                    return c;
                }

                markers[c] = true;
            }

            return null;
        }
    }
}
