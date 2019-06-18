using System;

namespace _2019_06_18
{

    //Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
    //For example, if our input was[1, 2, 3, 4, 5], the expected output would be[120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be[2, 3, 6].
    //Follow-up: what if you can't use division?
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            //var arr = new int[] { 3, 2, 1 };
            var result = Compute2(arr);
        }

        // OWN SOLUTION O(n**2)
        // |  1  |  2  |  3  |  4  |  5  |
        //    1    
        //    2     1
        //    6     3     2
        //    24    12    8     6
        //    120   60    40    30    24
        private static int[] Compute(int[] arr)
        {
            var length = arr.Length;
            var result = new int[length];
            var temp = 1;
            for (var i = 0; i < length; i++) result[i] = 1;

            for (var i = 0; i < length; i++)
            {
                for(var j = 0; j <= i; j++)
                {
                    result[j] *= (i == j ? temp : arr[i]);
                }

                temp *= arr[i];
            }

            return result;
        }

        /// FOUND IN THE INTERNET O(n)
        // arr       
        //           |  1  |  2  |  3  |  4  |  5  |

        // forwardScanArr
        // iteration     
        // 1         |  1  |     |     |     |     |
        // 2         |  1  |  1  |     |     |     |
        // 3         |  1  |  1  |  2  |     |     |
        // 4         |  1  |  1  |  2  |  6  |     |
        // 5         |  1  |  1  |  2  |  6  | 24  |

        // backwardScanArr
        // iteration    
        // 1         |     |     |     |     |  1  |
        // 2         |     |     |     |  5  |  1  |
        // 3         |     |     | 20  |  5  |  1  |
        // 4         |     | 60  | 20  |  5  |  1  |
        // 5         | 120 | 60  | 20  |  5  |  1  |

        // RES 
        //           | 120 | 60  | 40  | 30  |  24 |
        private static int[] Compute2(int[] arr)
        {
            int[] result = new int[arr.Length];
            int[] forwardScanArr = new int[arr.Length];
            int[] backwardScanArr = new int[arr.Length];

            forwardScanArr[0] = 1;
            backwardScanArr[arr.Length - 1] = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                forwardScanArr[i + 1] = arr[i] * forwardScanArr[i];
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                backwardScanArr[i - 1] = backwardScanArr[i] * arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = forwardScanArr[i] * backwardScanArr[i];
            }

            return result;
        }
    }
}