using System;
using System.Collections.Generic;

namespace DailyCodingProblem522
{
    /// <summary>
    /// This problem was asked by Microsoft.
    /// Given a string and a pattern, find the starting indices of all occurrences of the pattern in the string. 
    /// For example, given the string "abracadabra" and the pattern "abr", you should return [0, 7].
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var str = "abracadabra";
            var pattern = "abra";

            Console.WriteLine(string.Join(", ", Solve2(str, pattern)));
        }

        static int[] Solve2(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern)) return new int[0];
            var result = new List<int>();
            var possibility = new List<Solve2Possible>();
            var patternChars = pattern.ToCharArray();
            var firstChar = patternChars[0];
            var chars = str.ToCharArray();
            for(int i = 0; i < chars.Length; i++)
            {
                var toRemove = new List<Solve2Possible>();
                foreach (var possible in possibility)
                {
                    if (!possible.Feed(chars[i]))
                    {
                        toRemove.Add(possible);
                        continue;
                    }

                    if (possible.Finished)
                    {
                        result.Add(possible.start);
                        toRemove.Add(possible);
                    }
                }

                foreach(var tr in toRemove)
                {
                    possibility.Remove(tr);
                }

                if (chars[i] == firstChar)
                {
                    possibility.Add(new Solve2Possible { chars = patternChars, start = i, nextChar = 1 });
                }
            }
            return result.ToArray();
        }

        class Solve2Possible
        {
            public int start;
            public char[] chars;
            public int nextChar;

            public bool Finished => nextChar == chars.Length;

            public bool Feed(char ch)
            {
                if (chars[nextChar] == ch)
                {
                    nextChar++;
                    return true;
                }

                return false;
            }
        }

        static int[] Solve1(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern)) return new int[0];
            var result = new List<int>();
            var start = 0;
            var current = 0;
            do
            {
                current = str.IndexOf(pattern, start);
                if (current > -1)
                {
                    start = current + 1;
                    result.Add(current);
                }

            } while (current > -1);

            return result.ToArray();
        }
    }
}
