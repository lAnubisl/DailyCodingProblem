using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_09_05
{
    /*
     Given a mapping of digits to letters (as in a phone number), and a digit string, return all possible letters the number could represent. You can assume each valid number in the mapping is a single digit.
     For example if {“2”: [“a”, “b”, “c”], 3: [“d”, “e”, “f”], …} then “23” should return [“ad”, “ae”, “af”, “bd”, “be”, “bf”, “cd”, “ce”, “cf"].
    */
    class Program
    {
        private static readonly IDictionary<int, char[]> mapping = new Dictionary<int, char[]>
        {
            {2,  new [] { 'a', 'b', 'c' } },
            {3,  new [] { 'd', 'e', 'f' } },
            {4,  new [] { 'g', 'h', 'i' } },
            {5,  new [] { 'j', 'k', 'l' } },
            {6,  new [] { 'm', 'n', 'o' } },
            {7,  new [] { 'p', 'q', 'r', 's' } },
            {8,  new [] { 't', 'u', 'v' } },
            {9,  new [] { 'w', 'x', 'y', 'z' } },
        };

        static void Main(string[] args)
        {
            // O((4*n)**2)
            var result = Combinations(2345);
            foreach(var res in result)
            {
                Console.WriteLine(res);
            }
            
            Console.ReadKey();
        }

        private static string[] Combinations(int number)
        {
            var digits = GetDigits(number);
            var result = new List<string>() { string.Empty };
            foreach(var digit in digits)
            {
                if (!mapping.ContainsKey(digit)) return null;
                result = Combine(result, mapping[digit]).ToList();
            }

            return result.ToArray();
        }

        private static IEnumerable<string> Combine(List<string> strings, char[] chars)
        {
            foreach(var str in strings)
            {
                foreach(var c in chars)
                {
                    yield return str + c;
                }
            }
        }

        private static int[] GetDigits(int number)
        {
            var digits = new Stack<int>();
            do
            {
                digits.Push(number % 10);
                number = number / 10;              
            } while (number > 0);

            return digits.ToArray();
        }
    }
}
