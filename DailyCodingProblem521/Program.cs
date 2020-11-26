using System;
using System.Collections.Generic;

namespace DailyCodingProblem521
{
    /// <summary>
    /// This problem was asked by PayPal.
    /// Given a string and a number of lines k, print the string in zigzag form.In zigzag, 
    /// characters are printed out diagonally from top left to bottom right until reaching the kth line, 
    /// then back up to top right, and so on.
    /// For example, given the sentence "thisisazigzag" and k = 4, you should print:
    ///t     a     g
    /// h   s z   a
    ///  i i   i z
    ///   s     g

    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Solve3("thisisazigzag", 4);
        }

        static void Solve3(string str, int k)
        {
            var chars = str.ToCharArray();
            for(int y = 0; y < k; y++)
            {
                int x = -1;
                foreach(var charIndex in GetSymbolPositions(chars.Length, k, y))
                {
                    while (true)
                    {
                        x++;
                        if (x == charIndex)
                        {
                            Console.Write(chars[x]);
                            break;
                        }

                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }

        static IEnumerable<int> GetSymbolPositions(int charsLength, int k, int lineNumber)
        {
            // i -> i + 2*((k-1)-i) + 2*i + 2*((k-1)-i) + 2*1 ...
            int symbIndex = lineNumber;
            int addition = -1;
            while(true)
            {
                if (addition != 0) yield return symbIndex;
                addition = 2 * (k - 1 - lineNumber);
                symbIndex += addition;
                if (symbIndex >= charsLength) break;
                if (addition != 0) yield return symbIndex;
                addition = 2 * lineNumber;
                symbIndex += addition;
                if (symbIndex >= charsLength) break;
            }
        }

        static void Solve2(string str, int k)
        {
            var chars = str.ToCharArray();
            var down = true;
            var y = 0;
            for (int x = 0; x < chars.Length; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(chars[x]);
                if (down && y == k - 1) down = false;
                if (!down && y == 0) down = true;
                y = down ? y + 1 : y - 1;
            }
            Console.SetCursorPosition(0, k);
        }

        static void Solve1(string str, int k)
        {
            var array = new char[str.Length, k];
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = ' ';
                }
            }
            var down = true;
            var chars = str.ToCharArray();
            var y = 0;
            for(int x = 0; x < chars.Length; x++)
            {
                array[x, y] = chars[x];
                if (down && y == array.GetLength(1) - 1) down = false;
                if (!down && y == 0) down = true;
                y = down ? y + 1 : y - 1;
            }

            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
