using System;

namespace InterviewPrep.Amazon
{
    /* K largest elements from a big file or array */
    /* Given an array, print k largest elements from the array.  The output elements should be printed in decreasing order. */
    /* https://practice.geeksforgeeks.org/problems/k-largest-elements/0 */
    class KLargestElements
    {
        // Let's use minheap
        private int HeapSize;

        private void BuildMaxHeap(int[] arr)
        {
            HeapSize = arr.Length - 1;

            for (int i = HeapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);        
            }
        }

        private void Heapify(int[] arr, int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int minIndex = index;

            if (leftChildIndex <= HeapSize && arr[index] > arr[leftChildIndex])
                minIndex = leftChildIndex;

            if (rightChildIndex <= HeapSize && arr[minIndex] > arr[rightChildIndex])
                minIndex = rightChildIndex;

            // This means min value is different than the element in the index
            if (minIndex != index)
            {
                Swap(arr, index, minIndex);
                Heapify(arr, minIndex);
            }
        }

        private void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        private void SortHeap(int[] arr)
        {
            BuildMaxHeap(arr);
            for (int i = arr.Length-1; i >=0; i--)
            {
                Swap(arr, 0, i);
                HeapSize--;
                Heapify(arr, 0);
            }
        }

        public void PrintKLargestElements(int[] arr, int k)
        {
            SortHeap(arr);

            for (int i = 0; i < k; i++)
            {
                Console.Write($" { arr[i] } ");
            }
        }

        #region MinHeap
        private void BuildMinHeap(int[] arr)
        {
            HeapSize = arr.Length - 1;

            for (int i = HeapSize / 2; i >=0; i--)
            {
                MinHeapHeapify(arr, i);
            }
        }

        private void MinHeapHeapify(int[] arr, int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int maxIndex = index;

            if (HeapSize >= leftChildIndex && arr[index] < arr[leftChildIndex])
                maxIndex = leftChildIndex;

            if (HeapSize >= rightChildIndex && arr[maxIndex] < arr[rightChildIndex])
                maxIndex = rightChildIndex;

            if (maxIndex != index)
            {
                Swap(arr, index, maxIndex);
                MinHeapHeapify(arr, maxIndex);
            }
        }

        private void SortMinHeap(int[] arr)
        {
            BuildMinHeap(arr);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                HeapSize--;
                MinHeapHeapify(arr, 0);
            }
        }

        public void PrintKSmallestElements(int[] arr, int k)
        {
            SortMinHeap(arr);

            for (int i = 0; i < k; i++)
            {
                Console.Write($" { arr[i] } ");
            }
        }
        #endregion
    }
}
