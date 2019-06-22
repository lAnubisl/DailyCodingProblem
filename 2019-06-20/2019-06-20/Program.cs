using System;

namespace _2019_06_20
{
    class Program
    {
        //Given an array of integers, find the first missing positive integer in linear time and constant space.In other words, find the lowest positive integer that does not exist in the array.The array can contain duplicates and negative numbers as well.
        //For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
        //You can modify the input array in-place.
        static void Main(string[] args)
        {
            var input = new int[] { 1, -1, -5, -3, 3, 4, 2, 8 };

            // Step 1: Since we need to find first POSITIVE integer missing then we need to get rid of all non-positive integers in out array
            // We will modify our array and move all positive integers in the beginning, count them and calculate 'new array end'

            var filtered = FilterPositive(input);
            input = filtered.Item1; // modified array
            var end = filtered.Item2; // new upper boundary (we should not pay attention on items that is behind 'end' index anymore)

            // Step 2: We use array indexes as additional source of information.
            // We know that all items in a new array are positive so we can use sign (+,-) as additional information too.
            // Let's change sign of values to negative of those array INDEXES that have value 'index + 1' somewhere in an array.
            // For example if we changed value at index '3' in an array from '5' to '-5' then we know that value 4 (index 3 + 1 = value 4) 
            // exists somewhere in an array.

            for(int i = 0; i < end; i++)
            {
                var value = Math.Abs(input[i]); // we use ABS here because input[i] value could be changed to negative in previous iterations
                if (value <= end)
                {
                    input[value - 1] *= -1;
                }
            }

            // Step 3: Now we need to find INDEX of first positive integer in an array
            // when we find it at the index 4 then we can say that the number '5' (4 + 1) does not exist in an array.
            // because if we had number 5 in an array then we would change the value at index 4 to negative at step 2.

            var indexOfFirstPositiveInteger = FindIndexOfFirstPositiveInteger(input);
            if (indexOfFirstPositiveInteger == -1)
            {
                Console.WriteLine($"First missing positive is: {input.Length}");
            }

            Console.WriteLine($"First missing positive is: {indexOfFirstPositiveInteger + 1}");
            Console.ReadKey();
        }

        static int FindIndexOfFirstPositiveInteger(int[] input)
        {
            for(var i = 0; i < input.Length; i++)
            {
                if (input[i] > 0) return i;
            }

            return -1;
        }

        static (int[], int) FilterPositive(int[] input)
        {
            var index = 0;
            for(int i = 0; i < input.Length; i++)
            {
                input[index] = input[i];
                if (input[i] > 0) index++;
            }

            return (input, index++);
        }
    }
}