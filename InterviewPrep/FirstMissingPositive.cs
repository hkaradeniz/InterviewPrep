namespace InterviewPrep
{
    // Given an unsorted integer array, find the smallest missing positive integer.
    /*
        Example 1:

        Input: [1,2,0]
        Output: 3
        Example 2:

        Input: [3,4,-1,1]
        Output: 2
        Example 3:

        Input: [7,8,9,11,12]
        Output: 1
        Note:
     */

    class FirstMissingPositive
    {
        public int FindFirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 1;
            }

            int max = -1;
            bool[] arr = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (max < nums[i])
                    max = nums[i];
            }

            if (max < 0) return 1;

            arr = new bool[max + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    arr[nums[i]] = true;
            }

            for (int i = 1; i <= max; i++)
            {
                if (arr[i] == false) return i;
            }

            return max + 1;
        }
    }
}
