using System;
using System.Collections.Generic;

namespace InterviewPrep.Google
{
    /*
        Max Distance
        Given an array A of integers, find the maximum of j - i subjected to the constraint of A[i] <= A[j].

        If there is no solution possible, return -1.

        Example :

        A : [3 5 4 2]

        Output : 2 
        for the pair (3, 4)

     */
    class MaxDistanceInArray
    {
        public int MaximumGap(List<int> A)
        {
            int n = A.Count;

            if (n == 1) return 0;

            int[] minArr = new int[n];
            int[] maxArr = new int[n];

            // Construct minArr[] such that minArr[i] 
            // stores the minimum value
            // from (arr[0], arr[1], ... arr[i]) 
            minArr[0] = A[0];
            for (int i = 1; i < n; ++i)
                minArr[i] = Math.Min(A[i], minArr[i - 1]);

            // Construct maxArr[] such that 
            // maxArr[j] stores the maximum value
            // from (arr[j], arr[j+1], ..arr[n-1]) 
            maxArr[n - 1] = A[n - 1];
            for (int j = n - 2; j >= 0; --j)
                maxArr[j] = Math.Max(A[j], maxArr[j + 1]);

            // Traverse both arrays from left 
            // to right to find optimum j - i
            // This process is similar to merge() 
            // of MergeSort 
            int pointer1 = 0; int pointer2 = 0; int maxDiff = -1;
            while (pointer1 < n && pointer2 < n)
            {
                if (minArr[pointer1] <= maxArr[pointer2])
                {
                    maxDiff = Math.Max(maxDiff, pointer2 - pointer1);
                    pointer2++;
                }
                else
                    pointer1++;
            }

            return maxDiff;
        }
    }
}
