namespace InterviewPrep.Amazon
{
    /* Maximum Difference */
    /* Given an array C[] of integers, find out the maximum difference between any two elements such that 
     * larger element appears after the smaller number in C[].
        Examples: If array is [2, 3, 10, 6, 4, 8, 1] then returned value should be 8 (Diff between 10 and 2). 
        If array is [ 7, 9, 5, 6, 3, 2 ] then returned value should be 2 (Diff between 7 and 9). */
    /* https://practice.geeksforgeeks.org/problems/maximum-difference/0 */
    class MaximumDifference
    {
        public int GetMaxDifference(int[] arr)
        {
            if (arr == null || arr.Length == 0) return -1;

            int maxDifference = int.MinValue;
            int minValue = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                int diffence = arr[i] - minValue;

                if (diffence > maxDifference)
                    maxDifference = diffence;

                if (arr[i] < minValue)
                    minValue = arr[i];

            }

            return maxDifference;
        }
    }
}
