using System;

namespace InterviewPrep.Adobe
{
    /* Remove Duplicates from sorted Array */
    class RemoveDuplicatesFromSortedArray
    {
        // Extra memory
        public void RemoveDuplicatesExtraSpace(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            int n = arr.Length;
            int[] temp = new int[n];
            int tempPointer = 0;

            for (int i = 0; i < n-1; i++)
            {
                if (arr[i] != arr[i + 1])
                {
                    temp[tempPointer] = arr[i];
                    tempPointer++;
                }
            }

            temp[tempPointer] = arr[n - 1];

            PrintArray(temp);
        }

        // In Space
        public void RemoveDuplicatesInSpace(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            int n = arr.Length;
            int pointer = 0;

            for (int i = 0; i < n-1; i++)
            {
                if (arr[i] != arr[i + 1])
                {
                    arr[pointer] = arr[i];
                    pointer++;
                }
            }

            arr[pointer] = arr[n - 1];

            PrintArray(arr);
        }

        private void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($" { item } ");
            }
        }
    }
}
