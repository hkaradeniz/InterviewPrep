using System;

namespace InterviewPrep.Facebook
{
    /* Longest Increasing Subsequence */
    /*  Find the longest increasing subsequence of a given sequence / array.
        In other words, find a subsequence of array in which the subsequence’s elements are in strictly 
        increasing order, and in which the subsequence is as long as possible. 
        This subsequence is not necessarily contiguous, or unique.
        In this case, we only care about the length of the longest increasing subsequence.*/
    /* Example :
        Input : [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15]
        Output : 6
        The sequence : [0, 2, 6, 9, 13, 15] or [0, 4, 6, 9, 11, 15] or [0, 4, 6, 9, 13, 15] 
     */
    class LongestIncreasingSubsequence
    {
        public void FindLongestIncreasingSubsequence(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int n = arr.Length;

            int[] lengthArray = new int[n];
            int[] sequenceArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                lengthArray[i] = 1;
                sequenceArray[i] = -1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] + 1)
                    {
                        if (lengthArray[i] <= lengthArray[j] + 1)
                        {
                            lengthArray[i] = lengthArray[j] + 1;
                            sequenceArray[i] = j;
                        }
                    }
                }
            }

            int maxIndex = 0;
            int max = int.MinValue; 
            // Find Max Index
            for (int i = 0; i < n; i++)
            {
                if(lengthArray[i] > max)
                {
                    max = lengthArray[i];
                    maxIndex = i;
                }   
            }

            while (maxIndex >= 0)
            {
                Console.WriteLine(arr[maxIndex]);
                maxIndex = sequenceArray[maxIndex];
            }
        }
    }
}
