using System;

namespace InterviewPrep
{
    /*? 
    * Cracking the Coding Interview, 6th Edition 
    * Smallest Difference: Given two arrays of integers, compute the pair of values (one value in each
    array) with the smallest (non-negative) difference. Return the difference.
    EXAMPLE
    Input: {1, 3, 15, 11, 2}, {23, 127,235, 19, 8}
    Output: 3. That is, the pair (11, 8).
    */

    class SmallestDifference
    {
        public string CalculateSmallestDifference(int[] arr1, int[] arr2)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);

            int i = 0; int j = 0;
            int minDifference = Int32.MaxValue;
            string pair = string.Empty;
                
            while (arr1.Length > i && arr2.Length > j)
            {
                int temp = Math.Abs(arr1[i] - arr2[j]);
                if (temp < minDifference)
                {
                    minDifference = temp;
                    pair = $"{arr1[i]},{arr2[j]}";
                }

                if (arr1[i] > arr2[j])
                    j++;
                else
                    i++; 
            }

            return pair;
        }
    }
}
