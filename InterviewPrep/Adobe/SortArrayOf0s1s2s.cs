using System;

namespace InterviewPrep.Adobe
{
    /* Sort an array of 0s, 1s and 2s */
    /* Write a program to sort an array of 0's,1's and 2's in descending order. */
    /* https://practice.geeksforgeeks.org/problems/sort-an-array-of-0s-1s-and-2s/0 */
    class SortArrayOf0s1s2s
    {
        public void Sort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int left = 0;
            int right = arr.Length - 1;
            int pointer = 0;

            while(pointer <= right)
            {
                int num = arr[pointer];

                if (num == 2)
                {
                    Swap(arr, left, pointer);
                    left++;
                    pointer++;
                }
                else if (num == 1)
                {
                    pointer++;
                }
                else if (num == 0)
                {
                    Swap(arr, pointer, right);
                    right--;
                }
            }

            PrintArray(arr);
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($" { arr[i] } ");
            }
        }
    }
}
