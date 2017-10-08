namespace InterviewPrep
{
    class SortedSearchNoSize
    {
        // Test Data
        //int[] arr = { 3, 5, 7, 9, 10, 90, 100, 130, 140, 160, 170 };
        //SortedSearchNoSize ss = new SortedSearchNoSize();
        //Console.WriteLine(ss.SolveSortedSearchNoSize(arr, 10));

        /*? 
        Sorted Search, No Size: You are given an array-like data structure Listy which lacks a size
        method. It does, however, have an elementAt ( i) method that returns the element at index i in
        0( 1) time. If i is beyond the bounds of the data structure, it returns -1. (For this reason, the data
        structure only supports positive integers.) Given a Li sty which contains sorted, positive integers,
        find the index at which an element x occurs. If x occurs multiple times, you may return any index.

        Let low be pointing to 1st element and high pointing to 2nd element of array, Now compare key with high index element,
        ->if it is greater than high index element then copy high index in low index and double the high index.
        ->if it is smaller, then apply binary search on high and low indices found.
        */
        public int SolveSortedSearchNoSize(int[] arr, int key)
        {
            int index = 1;

            while (arr[index] != -1 && arr[index] < key)
            {
                index *= 2;
            }

            return BinarySearch(arr, key, index / 2, index);
        }

        private int BinarySearch(int[] arr, int key, int left, int right)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == key)
                {
                    return mid;
                }
                else if (arr[mid] > key || arr[mid] == -1)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}
