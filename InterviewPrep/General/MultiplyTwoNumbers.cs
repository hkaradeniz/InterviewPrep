using System;
using System.Collections.Generic;

namespace InterviewPrep.General
{
    class MultiplyTwoNumbers
    {

        /* Given an array and total find two numbers that multiply to total */
        /* 2,4,1,6,5,40,-1 : 20 */
        public void ComputePairs(int[] arr, int total)
        {
            if (arr == null || arr.Length < 2)
                return;

            HashSet<double> hash = new HashSet<double>();

            for (int i = 0; i < arr.Length; i++)
            {
                /*
                        Explanation: 
                        Dividing two ints performs an integer division, i.e. the fractional part is truncated 
                        since it can't be stored in the result type.
                        Enforce non-integer division on int arguments by explicitly casting at least one of 
                        the arguments to a floating-point type, e.g.
                        int a = 42;
                        int b = 23;
                        double result = (double)a / b;
                  */
                double number = (double) total / arr[i];

                if (hash.Contains(number))
                    Console.WriteLine($"{number}, {arr[i]}");
                else
                    hash.Add(arr[i]);
            }
        }
    }
}
