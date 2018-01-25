using System;

namespace InterviewPrep.Yahoo
{
    /* Max Sum without Adjacent */
    /* Given an array of positive numbers, find the maximum sum of a subsequence with the constraint that no 2 numbers in the sequence should be adjacent in the array.  */
    /* https://practice.geeksforgeeks.org/problems/max-sum-without-adjacents/0 */
    class MaxSumWithoutAdjacents
    {
        public int CalculareMaxSum(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int maxSoFar = 0;
            int includingCurrentElement = arr[0];
            int excludingPreviousElement = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                maxSoFar = Math.Max(excludingPreviousElement, includingCurrentElement);

                includingCurrentElement = excludingPreviousElement + arr[i];
                excludingPreviousElement = maxSoFar;
            }

            return Math.Max(includingCurrentElement, excludingPreviousElement);
        }
    }
}
