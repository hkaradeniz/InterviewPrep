using System;

namespace InterviewPrep.General
{
    class UnsortedSubarray
    {
        /* Minimum length subarray of an unsorted array sorting which results in complete sorted array */
        /*  */

        /* 1, 4, 7, 3, 10, 48, 17, 26, 30, 45, 50, 62  */

        /* Solution:
         1- From the start find where the sort order breaks; min (3)
         2- From the end, find where the sort order breaks; max (48)
         3- Find the index of the first number where min>x x:minIndex
         4- Find the index of the first number where max<x x:maxIndex
         5- Sort the subarray
         */
        /* Test Data:
           General.UnsortedSubarray us = new General.UnsortedSubarray();
           us.FixArray(new int[] { 1, 4, 7, 3, 10, 48, 17, 26, 30, 45, 50, 62 }); */
        public void FixArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            int min = 0;
            int max = arr.Length - 1;

            int minIndex = 0;
            int maxIndex = 0;

            //  (minI) (min)  (max)          (maxI)
            /* 1, 4, 7, 3, 10, 48, 17, 26, 30, 45, 50, 62  */
            /* minIndex: 1, 
                min: 3,
                max: 5,
                maxIndex: 9    
            */
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[min] < arr[i])
                    min++;
                else
                { min = i; break; }                    
            }

            for (int i = arr.Length-2; i >= 0; i--)
            {
                if (arr[max] > arr[i])
                    max--;
                else
                { max = i; break; }
            }

            int pointer = min-1;
            while (pointer >= 0)
            {
                if (arr[min] < arr[pointer])
                    pointer--;
                else
                { minIndex = pointer + 1; break; }
            }

            pointer = max + 1;
            while (pointer < arr.Length)
            {
                if (arr[max] > arr[pointer])
                    pointer++;
                else
                { maxIndex = pointer-1; break; }
            }

            Array.Sort(arr, minIndex, maxIndex);
            PrintArray(arr);
        }

        private void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine($"{item} * ");
            }
        }
    }
}
