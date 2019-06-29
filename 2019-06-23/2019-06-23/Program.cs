using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace _2019_06_23
{
    internal class Result
    {
        internal string Word;
        internal int CodeLength = 0;
    }
    class Program
    {
        //Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
        //For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
        //You can assume that the messages are decodable.For example, '001' is not allowed.
        static void Main(string[] args)
        {
            Decode("11111");
            Console.ReadKey();
        }

        private static Collection<string> Decode(string code)
        {
            var results = new Collection<string>();
            var queue = new Queue<Result>();
            Decode(code, queue, new Result { CodeLength = 0, Word = string.Empty }, 1, results);
            while (queue.Count > 0)
            {
                Decode(code, queue, queue.Dequeue(), 1, results);
            }

            return results;
        }

        private static void Decode(string code, Queue<Result> queue, Result currentResult, int decodeLength, Collection<string> resultingWords)
        {
            if (currentResult.CodeLength + decodeLength > code.Length) return;
            var part = code.Substring(currentResult.CodeLength, decodeLength);
            var key = Convert.ToInt32(part);
            if (!Mapping.ContainsKey(key)) return;
            var newResult = new Result()
            {
                Word = currentResult.Word + Mapping[key],
                CodeLength = currentResult.CodeLength + decodeLength
            };

            if (newResult.CodeLength == code.Length)
            {
                resultingWords.Add(newResult.Word);
                return;
            }

            queue.Enqueue(newResult);
            Decode(code, queue, currentResult, decodeLength + 1, resultingWords);
        }

        private static readonly Dictionary<int, char> Mapping = "abcdefghijklmnopqrstuvwxyz".ToCharArray().Select((c, i) => new { C=c, I=i }) new Dictionary<int, char>()
        {
            { 1, 'a' }, { 2, 'b' }, { 3, 'c' }, { 4, 'd' },{ 5, 'e' },
            { 6, 'f' }, { 7, 'g' }, { 8, 'h' }, { 9, 'i' },{10, 'j' },
            {11, 'k' }, {12, 'l' }, {13, 'm' }, {14, 'n' },{15, 'o' },
            {16, 'p' }, {17, 'q' }, {18, 'r' }, {19, 's' },{20, 't' },
            {21, 'u' }, {22, 'v' }, {23, 'w' }, {24, 'x' },{25, 'y' },
            {26, 'z' },
        };
    }
}
