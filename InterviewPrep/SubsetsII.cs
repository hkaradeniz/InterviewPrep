using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    class SubsetsII
    {
        // Given a collection of integers that might contain duplicates, nums, return all possible subsets (the power set).
        // Note: The solution set must not contain duplicate subsets.

        /*
            Example:

            Input: [1,2,2]
            Output:
            [
              [2],
              [1],
              [1,2,2],
              [2,2],
              [1,2],
              []
            ]
         */
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            var results = new List<IList<int>>();
            List<int> list = new List<int>();
            GetSubArrays(results, list, 0, nums);
            return results;
        }

        private void GetSubArrays(IList<IList<int>> results, List<int> list, int position, int[] nums)
        {
            results.Add(new List<int>(list));

            for (int i = position; i < nums.Length; i++)
            {
                if (i == position || nums[i] != nums[i - 1])
                {
                    list.Add(nums[i]);
                    GetSubArrays(results, list, i + 1, nums);
                    list.RemoveAt(list.Count - 1);
                }
            }

            return;
        }
    }
}
