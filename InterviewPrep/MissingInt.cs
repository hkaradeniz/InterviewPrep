using System;

namespace InterviewPrep
{
    class MissingInt
    {
        //? Finding the missing integer O(N)
        /*
         *Example:
           [1, 2, 4, 6, 3, 7, 8]
            5

            1. Get the sum of numbers 
               total = n*(n+1)/2
            2  Subtract all the numbers from sum and
               you will get the missing number.
         */
        // Nonnegative Integer: An integer that is either 0 or positive 
        /* If the sum of the numbers goes beyond maximum allowed integer, then there 
         * can be integer overflow! */
        public void FindMissingInteger(int[] arr, int n)
        {
            // If the Array has 7 elements, that means max number is 8
            int expectedTotal = (n + 1) * (n + 2) / 2;
            int total = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                total += arr[i];
            }

            Console.WriteLine(expectedTotal - total);
        }

        //? Memory Concerns
        /*? 
            Missing Int: Given an input file with four billion non-negative integers, provide an algorithm to
            generate an integer that is not contained in the file. Assume you have 1 GB of memory available for
            this task.
            FOLLOW UP
            What if you have only 10 MB of memory? Assume that all the values are distinct and we now have
            no more than one billion non-negative integers.

            // Use XOR
              1) XOR all the array elements, let the result of XOR be X1.
              2) XOR all numbers from 1 to n, let XOR be X2.
              3) XOR of X1 and X2 gives the missing number.

            O(N) + O(N-1) => O(N)
         */
        // Test Data
        //int[] arr = { 1, 2, 4, 6, 3, 7, 8 };
        //MissingInt mi = new MissingInt();
        //mi.FindMissingIntegerXOR(arr, 7);

        public void FindMissingIntegerXOR(int[] arr, int n)
        {
            int max = n + 1;
            int x1 = arr[0];
            int x2 = 0;

            for (int i = 1; i < n; i++)
            {
                x1 ^= arr[i];
            }

            for (int i = 1; i <= n + 1; i++)
            {
                x2 ^= i;
            }

            Console.WriteLine(x1 ^ x2);
        }
   }
}
