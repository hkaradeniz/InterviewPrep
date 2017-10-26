namespace InterviewPrep.General
{
    class MaximumAverageSubarray
    {
        /*
        Given an integer array and a number k, print the maximum average subarray of size k.

        Maximum average subarray of size k is a subarray (sequence of contiguous elements in the array) 
        for which the average is maximum among all subarrays of size k in the array.
        Average of k elements = (sum of k elements)/k
        Since k is greater than 0, the maximum sum subarray of size k will also be maximum average subarray 
        of size k. So, the problem reduces to finding maximum sum subarray of size k in the array.

            Complexity: O(N)
         */
        public int ComputeMaximumAverageSubarray(int[] arr, int k)
        {
            if (arr == null || arr.Length < k)
                return -1;

            int maxSubArray = 0;
            int window = 0;

            /* Calculate the first window */
            int pointer = 0;
            while (pointer < k)
            {
                window += arr[pointer];
                pointer++;
            }

            int head = 0;
            int tail = 0;

            /* Test Array: new int[] {11, -8, 16, -7, 24, -2, 3} k=3*/
            for (int i = k; i < arr.Length; i++)
            {
                head = arr[i];
                tail = arr[i - k];

                window = window + head - tail;

                if (window > maxSubArray)
                    maxSubArray = window;
            }

            return maxSubArray; 
        }
    }
}
