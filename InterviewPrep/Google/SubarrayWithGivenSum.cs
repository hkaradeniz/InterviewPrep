using System;

namespace InterviewPrep.Google
{
    /*
        https://practice.geeksforgeeks.org/problems/subarray-with-given-sum/0
        Given an unsorted array of non-negative integers, find a continuous sub-array which adds to a given number.

        Input:

        The first line of input contains an integer T denoting the number of test cases. Then T test cases follow. 
        Each test case consists of two lines. The first line of each test case is N and S, where N is the size of array and S is the sum. The second line of each test case contains N space separated integers denoting the array elements.

        Output:

        Corresponding to each test case, in a new line, print the starting and ending positions of first such occuring subarray if sum equals to subarray, else print -1.

        Note: Position of 1st element of the array should be considered as 1.

        Expected Time Complexity: O(n)

        Constraints:
        1 ≤ T ≤ 100
        1 ≤ N ≤ 100
        1 ≤ an array element ≤ 200

        Example:

        Input:
        2
        5 12
        1 2 3 7 5
        10 15
        1 2 3 4 5 6 7 8 9 10

        Output:
        2 4
        1 5

        Explanation : 
        In first test case, sum of elements from 2nd position to 4th position is 12
        In second test case, sum of elements from 1st position to 5th position is 15

        Google.SubarrayWithGivenSum sub = new Google.SubarrayWithGivenSum();
        //sub.CalculateSubArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 15);
        sub.CalculateSubArray(new int[] { 1, 2, 3, 7, 5 }, 12);
     */
    class SubarrayWithGivenSum
    {
        public void CalculateSubArray(int[] arr, int sum)
        {
            if (arr == null || arr.Length == 0) return;

            int currentSum = 0;
            int head = 0;
            int tail = 0;
            int size = arr.Length;

            // 10 15
            // 1 2 3 4 5 6 7 8 9 1 0
            while (head < size)
            {
                if (currentSum == sum)
                {
                    Console.WriteLine($"{tail + 1}, {head}");
                    return;
                }
                else if (currentSum < sum)
                {
                    currentSum += arr[head];
                    head++;
                }
                else
                {
                    if (arr[head - 1] > sum)
                    {
                        tail = head;
                    }
                    else
                    {
                        tail++;
                        head = tail;
                    }

                    currentSum = 0;
                }
            }
        }
    }
}
