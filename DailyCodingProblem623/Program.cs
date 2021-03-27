using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem623
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Palantir.
    /// Write an algorithm to justify text.
    /// Given a sequence of words and an integer line length k, 
    /// return a list of strings which represents each line, fully justified.
    /// More specifically, you should have as many words as possible in each line. 
    /// There should be at least one space between each word. Pad extra spaces when necessary so that each line 
    /// has exactly length k. Spaces should be distributed as equally as possible, with the extra spaces, 
    /// if any, distributed starting from the left.
    /// If you can only fit one word on a line, then you should pad the right-hand side with spaces.
    /// Each word is guaranteed not to be longer than k.
    /// For example, given the list of words
    /// ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"] and k = 16, 
    /// you should return the following:
    /// ["the  quick brown", # 1 extra space on the left
    ///  "fox  jumps  over", # 2 extra spaces distributed evenly
    ///  "the   lazy   dog"] # 4 extra spaces distributed evenly
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var justified = Justify(new string[] { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" }, 16);
            foreach(var line in justified)
            {
                Console.WriteLine(line);
            }
        }

        static string[] Justify(string[] words, int k)
        {
            return AddSpaces(BreakToLines(words, k), k);
        }

        static string[] AddSpaces(List<List<string>> linesOfWords, int k)
        {
            foreach (var lineOfWords in linesOfWords)
            {
                var numberOfWords = lineOfWords.Count;
                var actualWordsLength = lineOfWords.Sum(w => w.Length);
                var spacesToAdd = k - actualWordsLength;
                var spacesBetweenEachWords = spacesToAdd / (numberOfWords - 1);
                var additionalSpaces = spacesToAdd - spacesBetweenEachWords * (numberOfWords - 1);
                for (var i = 0; i < numberOfWords - 1; i++)
                {
                    var numberOfSpacesToAdd = spacesBetweenEachWords + (additionalSpaces >= (i + 1) ? 1 : 0);
                    lineOfWords[i] = lineOfWords[i] + string.Join("", Enumerable.Repeat(" ", numberOfSpacesToAdd));
                }
            }

            return linesOfWords.Select(line => string.Join("", line)).ToArray();
        }

        static List<List<string>> BreakToLines(string[] words, int k)
        {
            List<List<string>> linesOfWords = new List<List<string>>();
            List<string> currentList = new List<string>();
            int currentLength = 0;
            foreach (var word in words)
            {
                if (currentLength + word.Length > k)
                {
                    linesOfWords.Add(currentList);
                    currentList = new List<string>();
                    currentLength = 0;
                }

                currentList.Add(word);
                currentLength += word.Length + 1; // +1 for space between words
            }

            linesOfWords.Add(currentList);
            return linesOfWords;
        }
    }
}
