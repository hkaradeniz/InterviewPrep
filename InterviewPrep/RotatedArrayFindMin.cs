namespace InterviewPrep
{
    class RotatedArrayFindMin
    {
        public int FindMin(int[] arr)
        {
            // array is empty or null
            if (arr == null || arr.Length == 0) return -1;
            // one element in the array
            if (arr.Length == 1) return arr[0];

            int left = 0;
            int right = arr.Length - 1;

            // array is not rotated.
            if (arr[left] < arr[right]) return arr[left];

            while (left <= right)
            {
                //if (right - left == 1) return arr[right];

                int middle = left + (right - left) / 2;

                if (arr[middle] < arr[middle - 1]) return arr[middle];

                if (arr[middle] < arr[right])
                    left = middle;
                else
                    right = middle;
            }

            return -1;
        }
    }
}
