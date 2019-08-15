using System;

namespace _2019_06_25
{
    //Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative.
    //For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
    //Follow-up: Can you do this in O(N) time and constant space?

    //[1, 2, 3, 4, 5, 6, 7]
    // 1 + 3 + 5 + 7 = 16
    // 2 + 4 + 6 = 12

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sum = 0;
            var currentIndex = -2;
            while(currentIndex < array.Length)
            {
                var x1 = currentIndex + 2 < array.Length ? array[currentIndex + 2] : 0;
                var x2 = currentIndex + 3 < array.Length ? array[currentIndex + 3] : 0;
                var x3 = currentIndex + 4 < array.Length ? array[currentIndex + 4] : 0;
                var x4 = currentIndex + 5 < array.Length ? array[currentIndex + 5] : 0;
                if (x2 + x4 > x1 + x3)
                {
                    // skip 2
                    currentIndex += 3;
                } else
                {
                    // skip 1
                    currentIndex += 2;
                }
                sum += array[currentIndex];
            }
            Console.Write(sum);
        }
    }
}
