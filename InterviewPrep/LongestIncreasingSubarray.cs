using System;

namespace InterviewPrep
{
    //http://blog.gainlo.co/index.php/2017/02/02/uber-interview-questions-longest-increasing-subarray/

    class LongestIncreasingSubarray
    {
        public void SolveLongestIncreasingSubarray()
        {
            //int[] arr = { 1, 3, 2, 3, 4, 8, 10, 11, 10, 14, 7, 9 };
            //int[] arr = { 1, 3, 2, 3, 4, 8, 7, 9 };
            int[] arr = { 1, 3, 2, 3, 4, 8, 10, 11, 12, 14, 16, 19 };
            //int[] arr = { 1, 2 };

            int longestHead = 0;
            int longestTail = 0;
            int currentHead = 1;
            int currentTail = 0;
            int n = arr.Length;

            int longest = 0;
            int numberOfElements = 1;

            for (int i = 1; i < n; i++)
            {
                currentHead = i;

                if (arr[i] > arr[i - 1])
                {
                    numberOfElements++;
                }

                if (arr[i] < arr[i - 1] || i == n - 1)
                {
                    if (numberOfElements > longest)
                    {
                        longest = numberOfElements;

                        // (currentHead / (n - 1) - 1) : if this is 0
                        // that means we are at the end of the list
                        // if it is -1, that means the ,
                        longestHead = currentHead + (currentHead / (n - 1) - 1);
                        longestTail = currentTail;
                        currentTail = currentHead;
                    }

                    numberOfElements = 1;
                }
            }

            Console.WriteLine($"Longest: {longest} \n Head: {longestHead} \n Tail: {longestTail}");
        }
    }
}
