using System;

namespace InterviewPrep.Google
{
    /*
     You are given an array A containing 2*N+2 positive numbers, out of which N numbers are repeated exactly once and the other two numbers occur exactly once and are distinct. You need to find the other two numbers and print them in ascending order.
 https://practice.geeksforgeeks.org/problems/finding-the-numbers/0

        Input :
        The first line contains a value T, which denotes the number of test cases. Then T test cases follow .The first line of each test case contains a value N. The next line contains 2*N+2 space separated integers.

        Output :
        Print in a new line the two numbers in ascending order.

        Constraints :
        1<=T<=100
        1<=N<=10^6
        1<=A[i]<=5*10^8

        Example:
        Input :
        2
        2
        1 2 3 2 1 4
        1
        2 1 3 2

        Output :
        3 4
1 3
     */
    class FindingTheNumbers
    {
        /* 1- Naive Solution: scan the array for each element then then sort the distinct ones O(N^2) */

        /* 2- Sort the array, remove duplicates, return the result O(N LOG(N))*/

        public void PrintNumbers(int[] arr, int n)
        {
            if (arr == null || arr.Length == 0) return;

            Array.Sort(arr);
            int size = 2 * n + 2;

            int previous = arr[0];
            //int counter = 0;
            int scanner = 1;

            while (scanner < size)
            {
                if (arr[scanner - 1] == arr[scanner])
                {
                    scanner = scanner + 2;
                }
                else
                {
                    Console.WriteLine(arr[scanner-1]);
                    scanner++;
                }
            }
        }
    }
}
