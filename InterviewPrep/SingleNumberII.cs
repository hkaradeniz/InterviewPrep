using System.Collections.Generic;

namespace InterviewPrep
{
    //  Given a non-empty array of integers, every element appears three times except for one, 
    // which appears exactly once. Find that single one.
    /*
   
    Note:

    Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

    Example 1:

    Input: [2,2,3,2]
    Output: 3
    Example 2:

    Input: [0,1,0,1,0,1,99]
    Output: 99
    */
    class SingleNumberII
    {
        // With extra memory
        public int SingleNumber(int[] nums)
        {
            // if(nums == null || nums.Length == 0) return -1;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict.Add(num, 0);

                dict[num]++;
            }

            foreach (var pair in dict)
            {
                if (pair.Value == 1) return pair.Key;
            }

            return -1;
        }
    }
}
