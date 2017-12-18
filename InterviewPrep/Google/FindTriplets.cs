using System;

namespace InterviewPrep.Google
{
    class FindTriplets
    {
        /* Find triplets with zero sum */
        /* https://practice.geeksforgeeks.org/problems/find-triplets-with-zero-sum/1 */
        /* Given an array A[] of n elements. The task is to complete the function which returns true 
         *  if triplets exists in array A[] whose sum is zero else returns false. */
        public bool IsThereTriplets(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return false;

            Array.Sort(arr);

            int head, tail; 

            for (int i = 0; i < arr.Length-2; i++)
            {
                int value = arr[0];

                if (value < 1)
                {
                    head = i + 1;
                    tail = arr.Length - 1;

                    while (head < tail)
                    {
                        int sum = value + arr[head] + arr[tail];

                        if (sum == 0)
                            return true;
                        else
                        {
                            if (sum > 0)
                                tail--;
                            else
                                head++;
                        }
                    }
                }
            }

            return false;
        }
    }
}
