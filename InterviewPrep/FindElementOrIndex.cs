namespace InterviewPrep
{
    class FindElementOrIndex
    {
        // array = [1,3,5,7] target = 1 return: 0
        // array = [1,3,5,7] target = 7 return: 3
        // array = [1,3,5,7] target = 0 return: 0
        // array = [1,3,5,7] target = 9 return: 4

        public int GetIndex(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return -1;

            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (arr[middle] == target) return middle;
                else if (arr[middle] < target) left = middle + 1;
                else right = middle - 1;
            }

            return left;
        }
    }
}
