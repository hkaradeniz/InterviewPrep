namespace InterviewPrep.ArraysStrings
{
    class KadanesLargestSumContiguousSubarray
    {
        /* Largest Sum Contiguous Subarray  */
        /* Array: -2, -3, 4, -1, 1, 5, -3 */
        /* Complexity: O(N) */
        /* 
         Explanation:
            Simple idea of the Kadane's algorithm is to look for all positive contiguous segments of the array (max_ending_here is used 
            for this). And keep track of maximum sum contiguous segment among all positive segments (max_so_far is used for this). 
            Each time we get a positive sum compare it with max_so_far and update max_so_far if it is greater than max_so_far
         */

        public int GetLargestSumContiguousSubarray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int max = 0;
            int maxCurrentEnding = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                maxCurrentEnding += arr[i];

                if (max < maxCurrentEnding)
                    max = maxCurrentEnding;

                if (maxCurrentEnding < 0)
                    maxCurrentEnding = 0;
            }

            return max;
        }
    }
}
