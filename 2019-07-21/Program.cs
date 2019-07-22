using System;

namespace _2019_07_21
{
    //Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.
    //Do this in linear time and in-place.
    //For example, given the array['G', 'B', 'R', 'R', 'B', 'R', 'G'], it should become['R', 'R', 'R', 'G', 'G', 'B', 'B'].
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new char[] {'G', 'B', 'R', 'R', 'B', 'R', 'G'};

            var r = 0;
            var g = 0;
            var b = 0;

            foreach(char c in arr)
            {
                if (c == 'R') r++;
                if (c == 'G') g++;
                if (c == 'B') b++;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if (r > 0)
                {
                    arr[i] = 'R';
                    r--;
                    continue;
                }
                if (g > 0)
                {
                    arr[i] = 'G';
                    g--;
                    continue;
                }
                if (b > 0)
                {
                    arr[i] = 'B';
                    b--;
                    continue;
                }
            }

            Console.WriteLine(string.Join(',', arr));
            Console.ReadKey();
        }
    }
}