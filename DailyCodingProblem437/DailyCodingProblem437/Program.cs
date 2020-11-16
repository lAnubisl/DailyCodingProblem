using System;
using System.Linq;

namespace DailyCodingProblem437
{
    /*
    Good morning! Here's your coding interview problem for today.

    This problem was asked by Square.

    Given a string and a set of characters, return the shortest substring containing all the characters in the set.

    For example, given the string "figehaeci" and the set of characters {a, e, i}, you should return "aeci".

    If there is no substring containing all the characters in the set, return null.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DoJob("figehaeci", new char[] { 'a', 'e', 'i' }));
        }

        static string DoJob(string str, char[] chars)
        {
            int shortestStart = 0;
            int shortestEnd = 0;
            for(int i = 0; i <= str.Length - chars.Length; i++)
            {
                var set = chars.ToHashSet();
                for(int j = i; j < str.Length; j++)
                {
                    if (!set.Contains(str[j]))
                    {
                        continue;
                    }

                    set.Remove(str[j]);
                    if (set.Any() || shortestEnd - shortestStart != 0 && j - i >= shortestEnd - shortestStart)
                    {
                        continue;
                    }

                    shortestStart = i;
                    shortestEnd = j;
                    break;
                }
            }

            if (shortestEnd - shortestStart > 0)
            {
                return str.Substring(shortestStart, shortestEnd - shortestStart + 1);
            }

            return null;
        }
    }
}
