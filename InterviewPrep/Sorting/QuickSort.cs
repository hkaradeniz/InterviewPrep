using System;

namespace InterviewPrep.Sorting
{
    // QuickSort - pivot is the last element
    // https://www.hackerrank.com/challenges/quicksort4/problem
    class QuickSort
    {
        public void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
            PrintArray(arr);
        }

        private void Sort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int partition = Partition(arr, left, right);
            Sort(arr, left, partition - 1);
            Sort(arr, partition + 1, right);
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
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
