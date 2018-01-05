using System;

namespace InterviewPrep.Amazon
{
    /* Convert array into Zig-Zag Array */
    /* Given an array of distinct elements, rearrange the elements of array in zig-zag fashion in O(n) time. 
     * The converted array should be in form a < b > c < d > e < f. */
    class ZigZagArray
    {
        public void OrderZigZag(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            // If flag == true then i < i + 1;
            // If flag == false then i > i + 1;
            bool flag = true;
            int pointer = 0;

            while (pointer < arr.Length - 1)
            {
                if (flag)
                {
                    if (!(arr[pointer] < arr[pointer + 1]))
                        Swap(arr, pointer, pointer + 1);
                }
                else
                {
                    if (!(arr[pointer] > arr[pointer + 1]))
                        Swap(arr, pointer, pointer + 1);
                }

                pointer++;

                // Invert flag
                flag = !flag;
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
