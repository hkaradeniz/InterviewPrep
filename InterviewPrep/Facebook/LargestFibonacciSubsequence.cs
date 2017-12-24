using System;

namespace InterviewPrep.Facebook
{
    /* Largest Fibonacci Subsequence */
    /* Given an array with positive number the task to find the largest subsequence from 
    array that contain elements which are Fibonacci numbers. */
    /* https://practice.geeksforgeeks.org/problems/largest-fibonacci-subsequence/0 */
    /*
    Example:
        Input:
        7
        1 4 3 9 10 13 7

        9
        0 2 8 5 2 1 4 13 23

        Output:
        1 3 13

        0 2 8 5 2 1 13 
    */
    class LargestFibonacciSubsequence
    {
        /*
             We will use Binet's Formula.
             The standard way to check if a number is a Fibonacci Number is if (5N^2+4) or (5N^2−4) is a perfect square.
             Greek letter phi ( φι fi [fi]) ) represents the golden ratio. It is an irrational number with a value of:
             φ = (1 + sqrt(5)) / 2 = 1.6180339887498948482
         */

        private bool IsPerfectSquare(int number)
        {
            int result = (int)Math.Sqrt(number);

            return number == GetSquare(result);
        }

        private int GetSquare(int number)
        {
            return number * number;
        }

        public void LongestSubsequence(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isFibonacci = IsPerfectSquare(5 * GetSquare(arr[i]) + 4) || IsPerfectSquare(5 * GetSquare(arr[i]) - 4);

                if(isFibonacci)
                    Console.Write($"{arr[i]} ");
            }
        }
    }
}
