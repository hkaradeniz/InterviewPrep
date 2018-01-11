namespace InterviewPrep.Adobe
{
    /* Partition Problem */
    /* https://practice.geeksforgeeks.org/problems/subset-sum-problem/0 */
    /* Given a set of numbers, check whether it can be partitioned into two subsets such that the sum of elements in both subsets is same or not. */
    class SubsetSumPartition
    {
        public bool IsPartitionAvailable(int[] arr)
        {
            if (arr == null || arr.Length == 0) return false;

            // Make sure if the sum of the array is divisible by 2
            int total = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                total += arr[i];
            }

            if (total % 2 == 1) return false;

            return Partition(arr, total / 2, 0);
        }

        private bool Partition(int[] arr, int sum, int index)
        {
            if (sum == 0)
                return true;
            if (index == arr.Length && sum != 0)
                return false;

            if (arr[index] > sum)
                return Partition(arr, sum, index + 1);

            return Partition(arr, sum, index + 1) || Partition(arr, sum - arr[index], index + 1);
        }

        // Complexity: O(2^N)
    }
}
