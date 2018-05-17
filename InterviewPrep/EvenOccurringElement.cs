using System.Collections.Generic;

namespace InterviewPrep
{
    class EvenOccurringElement
    {
        /*
         Given an integer array, one element occurs even number of times and all others have odd occurrences. 
         Find the element with even occurrences.
         */

        // Find all unique elements in the array and place them in a temp array
        // XOR all of them. Once we XOR all of them, elements occur odd number of times
        // will occur even number of times, and the element that occurs even number of times
        // will occur odd number of time 

        public int FindEvenOccuringElement(int[] arr)
        {
            if (arr == null || arr.Length == 0) return -1;

            HashSet<int> hash = new HashSet<int>();
            int result = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (!hash.Contains(arr[i])) hash.Add(arr[i]);

                result ^= arr[i];
            }

            foreach (var item in hash)
            {
                result ^= item;
            }

            return result;
        }
    }
}
