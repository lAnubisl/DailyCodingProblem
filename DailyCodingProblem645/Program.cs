using System;

namespace DailyCodingProblem645
{
    /// <summary>
    /// Given a 2D matrix of characters and a target word, write a function that returns whether the word 
    /// can be found in the matrix by going left-to-right, or up-to-down. 
    /// For example, given the following matrix:
    /// 
    /// [['F', 'A', 'C', 'I'],
    ///  ['O', 'B', 'Q', 'P'],
    ///  ['A', 'N', 'O', 'B'],
    ///  ['M', 'A', 'S', 'S']]
    ///  
    /// and the target word 'FOAM', you should return true, since it's the leftmost column. 
    /// Similarly, given the target word 'MASS', you should return true, since it's the last row.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Char[,]
            {
                { 'F', 'A', 'C', 'I' },
                { 'O', 'B', 'Q', 'P' },
                { 'A', 'N', 'O', 'B' },
            };
            var targetWord = "OA";
            Console.WriteLine(Solve(input, targetWord));
            Console.ReadLine();

        }

        static bool Solve(Char[,] array, string word)
        {
            return SolveL2R(array, word) || SolveT2B(array, word);
        }

        static bool SolveL2R(Char[,] array, string word)
        {
            for (int x = 0; x <= array.GetLength(1) - word.Length; x++)
            {
                for (int y = 0; y < array.GetLength(0); y++)
                {
                    var match = true;
                    for (int i = 0; i < array.GetLength(1) - x && i < word.Length; i++)
                    {
                        if (array[y, x + i] != word[i])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match) return true;
                }
            }
            
            return false;
        }

        static bool SolveT2B(Char[,] array, string word)
        {
            for (int y = 0; y <= array.GetLength(0) - word.Length; y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    var match = true;
                    for (int i = 0; i < array.GetLength(0) - y && i < word.Length; i++)
                    {
                        if (array[y + i, x] != word[i])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match) return true;
                }
            }

            return false;
        }
    }
}
