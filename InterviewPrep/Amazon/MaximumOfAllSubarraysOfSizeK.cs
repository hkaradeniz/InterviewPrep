using System;

namespace InterviewPrep.Amazon
{
    /* Maximum of all subarrays of size k */
    /* Given an array and an integer k, find the maximum for each and every contiguous subarray of size k. */
    /* https://practice.geeksforgeeks.org/problems/maximum-of-all-subarrays-of-size-k/0 */
    /* Input:
        9 3
        1 2 3 1 4 5 2 3 6

        10 4
        8 5 10 7 9 4 15 12 90 13

        Output:
        3 3 4 5 5 5 6

        10 10 10 15 15 90 90 
     */
    class MaximumOfAllSubarraysOfSizeK
    {
        public void PrintMaximumOfAllSubarraysOfSizeK(int[] arr, int k)
        {
            if (arr == null || arr.Length == 0) return;

            int pointer = 0;
            int max = int.MinValue;

            while (pointer < k)
            {
                if (arr[pointer] > max)
                    max = arr[pointer];

                pointer++;
            }
            Console.Write($" { max } ");

            for (int i = k; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];

                Console.Write($" { max } ");
            }
        }
    }
}
