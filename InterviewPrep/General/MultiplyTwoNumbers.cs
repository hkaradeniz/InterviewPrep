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
                double number = (double) total / arr[i];

                if (hash.Contains(number))
                    Console.WriteLine($"{number}, {arr[i]}");
                else
                    hash.Add(arr[i]);
            }
        }
    }
}
