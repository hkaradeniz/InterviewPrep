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

                        longestHead = currentHead - 1;
                        longestTail = currentTail;
                        currentTail = currentHead;
                    }

                    numberOfElements = 1;
                }
            }



            //while (currentHead < arr.Length)
            //{
            //    while (arr[currentHead] > arr[currentHead - 1])
            //    {
            //        currentHead++;
            //        numberOfElements++;
            //    }

            //    if (arr[currentHead] < arr[currentHead - 1] || currentHead == arr.Length - 1)
            //    {
            //        if (numberOfElements > longest)
            //        {
            //            longest = numberOfElements;

            //            longestHead = currentHead-1;
            //            longestTail = currentTail;
            //            currentTail = currentHead;
            //        }

            //        numberOfElements = 1;
            //    }
            //}

            //for (int i = 1; i < arr.Length; i++)
            //{
            //    if (arr[i] > arr[i - 1])
            //    {
            //        currentHead = i;
            //        numberOfElements++;
            //    }

            //    if (arr[i - 1] > arr[i] || i == arr.Length-1)
            //    {
            //        if (numberOfElements > longest)
            //        {
            //            longest = numberOfElements;
            //            longestHead = currentHead;
            //            longestTail = currentTail;

            //            currentTail = currentHead = i;
            //        }

            //        numberOfElements = 1;
            //    }
            //}
            
            Console.WriteLine($"Longest: {longest} \n Head: {longestHead} \n Tail: {longestTail}");
        }
    }
}
