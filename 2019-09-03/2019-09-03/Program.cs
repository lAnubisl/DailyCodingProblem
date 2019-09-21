using System;

namespace _2019_09_03
{
    /*
     Given an array of integers, write a function to determine whether the array could become non-decreasing by modifying at most 1 element.
     For example, given the array [10, 5, 7], you should return true, since we can modify the 10 into a 1 to make the array non-decreasing.
     Given the array [10, 5, 1], you should return false, since we can't modify any one element to get a non-decreasing array.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Can(new[] { 10, 5, 1 }));
            Console.ReadLine();
        }

        private static bool Can(int[] arr)
        {
            var modifiedOnce = false;
            if (arr.Length < 2) return true;
            for(var i = 0; i < arr.Length; i++)
            {
                var prev = Prev(arr, i);
                var next = Next(arr, i);

                if (next != null && next.Value < arr[i])
                {
                    if (prev != null && next.Value < prev.Value)
                    {
                        return false;
                    }

                    if(modifiedOnce)
                    {
                        return false;
                    }

                    arr[i] = next.Value;
                    modifiedOnce = true;
                    continue;
                }
            }

            return true;
        }

        private static int? Prev(int[] arr, int i)
        {
            if (i - 1 >= 0)
                return arr[i - 1];
            return null;
        }

        private static int? Next(int[] arr, int i)
        {
            if (i + 1 <= arr.Length - 1)
                return arr[i + 1];
            return null;
        }
    }
}
