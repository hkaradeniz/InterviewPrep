namespace InterviewPrep.Cisco
{
    class KthLargestElement
    {
        private int HeapSize;

        private void BuildMaxHeap(int[] arr)
        {
            HeapSize = arr.Length - 1;

            for (int i = HeapSize / 2; i >=0 ; i--)
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

            if (leftChildIndex <= HeapSize && arr[minIndex] > arr[rightChildIndex])
                minIndex = rightChildIndex;

            if (minIndex != index)
            {
                Swap(arr, minIndex, index);
                Heapify(arr, minIndex);
            }
        }

        private void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        public void SortHeap(int[] arr)
        {
            BuildMaxHeap(arr);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                HeapSize--;
                Heapify(arr, 0);
            }
        } 
    }
}
