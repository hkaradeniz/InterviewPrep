namespace InterviewPrep
{
    class CircularArray
    {
        // Find min in a circular array (rotated)
        public int FindMind(int[] arr)
        {
            return FindMin(arr, 0, arr.Length - 1, arr.Length);
        }

        private int FindMin(int[] arr, int left, int right, int N)
        {
            if (left > right) return -1;

            int middle = left + (right - left) / 2;

            if (arr[middle] < arr[(middle - 1) % N]
                && arr[middle] < arr[(middle + 1) % N])
                return arr[middle];
            else if (arr[left] > arr[right])
                return FindMin(arr, middle + 1, right, N);
            else
                return FindMin(arr, left, middle - 1, N);
        }
    }
}
