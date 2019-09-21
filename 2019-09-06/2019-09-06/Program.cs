using System;
using System.Text;

namespace _2019_09_06
{
    /*
     Using a read7() method that returns 7 characters from a file, implement readN(n) which reads n characters.
     For example, given a file with the content “Hello world”, three read7() returns “Hello w”, “orld” and then “”.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(readN(3));
            Console.ReadKey();
        }

        private static string readN(int n)
        {
            var sb = new StringBuilder();
            var part = string.Empty;
            do
            {
                part = read7();
                sb.Append(part);
            }
            while (part.Length == 7 && sb.Length < n);
            return sb.Length > n ? sb.ToString(0, n) : sb.ToString();
        }

        static string FileContent = "Hello world";
        static int position = 0;
        private static string read7()
        {
            var readLength = FileContent.Length >= position + 7 ? 7 : FileContent.Length - position;
            var part = FileContent.Substring(position, readLength);
            position += readLength;
            return part;
        }
    }
}