using System;

namespace DailyCodingProblem624
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today. 
    /// This problem was asked by Google.
    /// Given a string of parentheses, write a function to compute the minimum number of parentheses 
    /// to be removed to make the string valid (i.e.each open parenthesis is eventually closed).
    /// For example, 
    /// given the string "()())()", you should return 1. 
    /// Given the string ")(", you should return 2, 
    /// since we must remove all of them.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("((())())"));
        }

        static int Solve(string text)
        {
            int currentLevel = 0;
            int charsToRemove = 0;
            foreach(char c in text.ToCharArray())
            {
                if (c == '(') currentLevel++;
                if (c == ')') currentLevel--;

                if (currentLevel < 0)
                {
                    charsToRemove++;
                    currentLevel = 0;
                }
            }

            charsToRemove += currentLevel;
            return charsToRemove;
        }
    }
}
