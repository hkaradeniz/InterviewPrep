using System;

namespace InterviewPrep.ArraysStrings
{
    class LargestSubsetWithConsecutiveNumbers
    {
        /* Given a set of numbers, find the longest subset of consecutive numbers. */

        /* Solution -1 : Brute Force. Use 2 loops O(N^2)*/

        /* Solution -2: In place. Sort the array and find the longest consecutive subarray. O(NlogN) + O(N) => O(NlogN)*/
        public void FindLargestSubsetWithConsecutiveNumbers(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            /*
              *  If the partition size is fewer than 16 elements, it uses an insertion sort algorithm.
              *  If the number of partitions exceeds 2 * LogN, where N is the range of the input array, it uses a Heapsort algorithm.
              *  Otherwise, it uses a Quicksort algorithm.
             */
            Array.Sort(arr);

            int maxHead = 0;
            int maxTail = 0;
            int maxLength = int.MinValue;
            int pointerHead = 0;
            int pointerTail = 0;
            int pointerLength = 1;
         
            while (pointerHead < arr.Length)
            {
                pointerLength = 1;

                while (pointerHead < arr.Length - 1)
                {
                    int temp = arr[pointerHead];

                    if (temp + 1 == arr[pointerHead + 1])
                    {
                        pointerLength++;
                        pointerHead++;
                    }
                    else
                        break;
                }

                if (pointerLength > maxLength)
                {
                    maxHead = pointerHead;
                    maxTail = pointerTail;
                    maxLength = pointerLength;
                }

                pointerHead++;
                pointerTail = pointerHead;
            }

            Console.WriteLine($"Tail: {maxTail} * Head: {maxHead} * Length: {maxLength}");
        }
    }
}
