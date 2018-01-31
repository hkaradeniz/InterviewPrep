using System;

namespace InterviewPrep.Sorting
{
    class SelectionSort
    {
        public void Sort(int[] arr)
        {
            if (arr == null || arr.Length == 0) Console.WriteLine();

            PrintArray(arr);

            for (int i = 0; i < arr.Length-1; i++)
            {
                int min = arr[i];
                int pointer = i + 1;
                int minIndex = i;

                while (pointer < arr.Length)
                {
                    if (min > arr[pointer])
                    {
                        minIndex = pointer;
                        min = arr[pointer];
                    }

                    pointer++;
                }

                if (minIndex != i)
                    Swap(arr, i, minIndex);
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
            foreach (var item in arr)
            {
                Console.Write($" { item } ");
            }

            Console.WriteLine();
        }
    }
}
