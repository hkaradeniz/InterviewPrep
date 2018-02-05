using System;

namespace InterviewPrep.General
{
    class MinimumJumps
    {
        /* Minimum Number of Jumps */
        /* Count the minimum number of jumps to reach the end of an array. */
        /* Google Interview Question */
        /* Example: 
         
         Array: 1,4,3,7,1,2,6,7,6,10 
         Output: 1->4->7->10
         3 Jumps (We start from arr[0])
         */

        public int ComputeMinimumJumps(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int n = arr.Length;

            int[] minJumpArr = new int[n];
            int[] jumpMap = new int[n];
            for (int i = 0; i < n; i++)
            {
                minJumpArr[i] = int.MaxValue;
            }

            minJumpArr[0] = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i <= arr[j] + j)
                    {
                        if (minJumpArr[i] > minJumpArr[j] + 1)
                        {
                            minJumpArr[i] = minJumpArr[j] + 1;
                            jumpMap[i] = j;
                        }
                    }
                }
            }

            int pointer = n-1;
            while(pointer >= 0 && jumpMap[pointer]!=0)
            {
                Console.Write($" { jumpMap[pointer] } ");
                pointer = jumpMap[pointer];
            }

            return minJumpArr[n-1];
        }
    }
}
