using System;

namespace InterviewPrep.ArraysStrings
{
    class CountFrequencies
    {
        /* Given an array of length n having integers 1 to n with some elements being repeated. 
         * Count frequencies of all elements from 1 to n.

            Example:
            Input Array: {2, 3, 3, 2, 5}
            Output:
            1 0
            2 2
            3 2
            4 0
            5 1 

            Time Complexity: O(n)
            Space Complexity: O(n)
         */

        public void PrintFrequencies(int[] arr, int n)
        {
            if (arr == null || arr.Length == 0)
                return;

            int[] frequencies = new int[n+1];

            for (int i = 0; i < arr.Length; i++)
            {
                frequencies[arr[i]]++;
            }

            for (int i = 1; i < n+1; i++)
            {
                Console.WriteLine($"{i}: { frequencies[i] }");
            }
        }
    }
}
