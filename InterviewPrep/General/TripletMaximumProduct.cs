using System;

namespace InterviewPrep.General
{
    /* Given an integer array, find a maximum product of a triplet in array. */
    class TripletMaximumProduct
    {
        // Solution 1: Brute Force solution n^3
        /*
         for int i=0 i<n-2; i++
            for int j=i+1; j<n-1; j++
                for int k=j+1; k<n; k++
         */

        // Solution 2: Sort and return max(index0 * index1 * indexn-1, indexn-1*indexn-2*indexn-3)
        // The reason we check index 0 and 1 is in case they are negative

        //  n (lg n)
        public int Max(int[] arr)
        {
            if (arr == null || arr.Length < 3) return -1;

            Array.Sort(arr);

            int n = arr.Length;

            return Math.Max(arr[0] * arr[1] * arr[n - 1], arr[n - 1] * arr[n - 2] * arr[n - 3]);
        }

        // Solution 3: Find 3 max, 2 min values linear time
        public int MaxLinear(int[] arr)
        {
            if (arr == null || arr.Length < 3) return -1;

            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int max3 = int.MinValue;

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = arr[i];
                }
                else if (arr[i] > max2)
                {
                    max3 = max2;
                    max2 = arr[i];
                }
                else if (arr[i] > max3)
                {
                    max3 = arr[i];
                }

                // Min values
                if (arr[i] < min1)
                {
                    min2 = min1;
                    min1 = arr[i];
                }
                else if (arr[i] < min2)
                {
                    min2 = arr[i];
                }
            }

            return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }
    }
}
