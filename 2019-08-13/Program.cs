using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_08_13
{
    /* An sorted array of integers was rotated an unknown number of times.
     * Given such an array, find the index of the element in the array in faster than linear time. If the element doesn't exist in the array, return null.
     * For example, given the array[13, 18, 25, 2, 8, 10] and the element 8, return 4 (the index of 8 in the array).
     * You can assume all the integers in the array are unique.
     *
     * let's represent an array as a round
     *                   13
     *                 /    \
     *               10      18
     *                |       |
     *                8      25
     *                 \    +
     *                   2
     * then let's split it by half:
     *                   13           13
     *                 /                \
     *               10                  18
     *                |                   |
     *                8                  25
     *                 \                +
     *                   2             2
     * now we need to decide which half should we use for next iteration
     * 
     * if bounds of the half are in ascending order then there is no knot there
     * which means that values in this half are increasing monotonically
     * we should take this half if the value is in between of the bounds
     * 
     * if bounds of the half are not in ascending order then there is a knot there.
     * in this case we should take this half if the value is lower than lowest bound or greater than greatest bound
     * 
     * otherwise we need to continue with other half
     */
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                var inputArray = GenerateArray(10);
                var location = random.Next(inputArray.Length);
                var findValue = inputArray[location];
                Console.WriteLine($"Searching for value {findValue} (shound be on location {location}). Found on location {FindValue(inputArray, findValue)}");
            }
            
            Console.ReadKey();
        }

        static int[] GenerateArray(int size)
        {
            var list = new List<int>();
            for (var i = 0; i < size; i++)
            {
                list.Add(random.Next());
            }

            list.Sort();
            var array = list.ToArray();
            return Rotate(array, random.Next(size));
        }

        static int[] Rotate(int[] array, int times)
        {
            while(times > 0)
            {
                int temp = array[0];
                for (var i = 0; i < array.Length; i++)
                {
                    array[i] = i < array.Length - 1
                        ? array[i + 1] 
                        : temp;
                }

                times--;
            }

            return array;
        }

        static int? FindValue(int[] inputArray, int value)
        {
            var lowerBound = 0;
            var upperBound = inputArray.Length - 1;
            if (inputArray[lowerBound] == value) return lowerBound;
            if (inputArray[upperBound] == value) return upperBound;
            return FindValue(inputArray, value, lowerBound, upperBound);
        }

        static int? FindValue(int[] inputArray, int value, int lowerBound, int upperBound)
        {
            if (lowerBound + 1 == upperBound) return null;
            var middle = lowerBound + (upperBound - lowerBound) / 2;
            var lowerBoundValue = inputArray[lowerBound];
            var middleValue = inputArray[middle];
            if (middleValue == value) return middle;
            if (lowerBoundValue < value && value < middleValue)
            {
                return FindValue(inputArray, value, lowerBound, middle);
            }

            if (lowerBoundValue > middleValue && (value > lowerBoundValue || value < middleValue))
            {
                return FindValue(inputArray, value, lowerBound, middle);
            }

            return FindValue(inputArray, value, middle, upperBound);
        }
    }
}