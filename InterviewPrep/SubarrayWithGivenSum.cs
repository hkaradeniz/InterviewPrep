using System;

namespace InterviewPrep
{
    class SubarrayWithGivenSum
    {
        public void FindSubarrayWithGivenSum()
        {
            // Sliding Window 
            /*
             Start with two pointers that represent the subarray.
             If the sum of current subarray is smaller than S, move the end pointer one step forward.
             If the sum is larger than S, move the start pointer one step forward.
             Once the current sum equals to S, we found the target.
            */

            // int[] arr = { 1, 5, 7, 9, 12, 15, 16, 18, 26 };
            //int[] arr = { 1, 16, 18, 26, 40 };
             int[] arr = { 1 };
            int sum = 60;

            int start = 0;
            int currentTotal = 0;
            int n = arr.Length;

            for (int i = 0; i <= n; i++)
            {
                while (currentTotal > sum && start < i - 1)
                {
                    currentTotal -= arr[start];
                    start++;
                }

                if (currentTotal == sum)
                {
                    Console.WriteLine($"Indexes: { start } - { i-1 }");
                    break;
                }

                if (i < n)
                    currentTotal += arr[i];

            }
          
            Console.WriteLine("No subarray!");
            
        }
    }
}
