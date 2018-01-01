using System.Collections.Generic;

namespace InterviewPrep.Microsoft
{
    /* Key Pair */
    /* https://practice.geeksforgeeks.org/problems/key-pair/0 */
    /* Given an array A[] of n numbers and another number x, determine whether or not there exist 
    two elements in A whose sum is exactly x. */
    /* Test Data: new int[] {1, 4, 45, 6, 10, 8}, 16*/
    class KeyPair
    {
        public bool IsThereAKeyPair(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return false;

            HashSet<int> hash = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int difference = target - arr[i];

                if (hash.Contains(difference))
                    return true;

                hash.Add(arr[i]);
            }

            return false;
        }
    }
}
