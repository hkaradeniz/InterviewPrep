namespace InterviewPrep
{
    class RotatedArrayFindMin
    {
        public int FindMin(int[] arr)
        {
            // array is empty or null
            if (arr == null || arr.Length == 0) return -1;

            int left = 0;
            int right = arr.Length - 1;

            // array is not rotated.
            if (arr.Length == 1 || arr[left] < arr[right]) return arr[left];

            while (left <= right)
            {
                //if (right - left == 1) return arr[right];
                int middle = left + (right - left) / 2;
                //if (arr[middle] < arr[middle - 1]) return arr[middle];
                if (arr[middle] > arr[middle + 1]) return arr[middle + 1];

                // this means the right is sorted and the min cannot be on the sorted side
                if (arr[middle] < arr[right])
                    right = middle;
                else
                    left = middle;
            }

            return -1;
        }
    }
}
