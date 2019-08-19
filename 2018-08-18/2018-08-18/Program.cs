using System;

namespace _2018_08_18
{
    /*
        Given a 2D matrix of characters and a target word, write a function that returns whether the word can be found in the matrix by going left-to-right, or up-to-down.
        For example, given the following matrix:
        [['F', 'A', 'C', 'I'],
         ['O', 'B', 'Q', 'P'],
         ['A', 'N', 'O', 'B'],
         ['M', 'A', 'S', 'S']]
        and the target word 'FOAM', you should return true, since it's the leftmost column. Similarly, given the target word 'MASS', you should return true, since it's the last row.   
        
        Assuming matrix is square
        and matrix edge length is equal to target word length.

    */
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new[,] { 
                { 'F', 'A', 'C', 'I' }, 
                { 'O', 'B', 'Q', 'P' }, 
                { 'A', 'N', 'O', 'B' }, 
                { 'M', 'A', 'S', 'S' }
            };

            Console.WriteLine(FindWord(matrix, "MASS"));
            Console.ReadKey();
        }

        static bool FindWord(char[,] matrix, string word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Rank != 2) throw new ArgumentException("matrix should have 2 dimentions");
            if (matrix.GetLength(0) != word.Length) throw new ArgumentException("matrix dimention 0 does not match the length of word");
            if (matrix.GetLength(1) != word.Length) throw new ArgumentException("matrix dimention 1 does not match the length of word");

            char[] wordChars = word.ToCharArray();
            for(var i = 0; i < matrix.GetLength(0); i++)
            {
                if (CheckLine(matrix, wordChars, true, i)) return true;
            }

            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                if (CheckLine(matrix, wordChars, false, i)) return true;
            }

            return false;
        }

        static bool CheckLine(char[,] matrix, char[] wordChars, bool vertical, int shift)
        {
            for(var i = 0; i < wordChars.Length; i++)
            {
                if ((vertical ? matrix[shift, i] : matrix[i, shift]) != wordChars[i]) return false;
            }

            return true;
        }
    }
}