using System.Linq;

namespace InterviewPrep
{
    class SearchRotatedArray
    {
        /*
         Uber Interview Questions – Search an Element in a Sorted and Rotated Array
         the algorithm as follows:
         http://blog.gainlo.co/index.php/2017/01/12/rotated-array-binary-search/
         */
        public int SolveSearchRotatedArray(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // If target is at the middle point then we found it. Return the middle index
                if (arr[mid] == target)
                    return mid;
                // Else let's find out which side of the array is sorted...
                else if (arr[mid] <= arr[high]) // this means the right half is sorted
                {
                    if (arr[mid] < target && arr[high] >= target)
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
                // if right is not sorted somehow, this means left is totaly sorted
                else
                {
                    if (arr[low] <= target && arr[mid] > target)
                        high = mid - 1;
                    else
                        low = mid - 1;
                }
            }

            return -1;
        }


         /*
         // Recursive
         1-   If the middle element is the target number, just return.
         2-   If the pivot point is at the left of the middle element:
                A- If the target is in the range of [mid, rightmost element], then it’s in the right half of the array.
                B- Otherwise, it’s in the left half of the array.
         3-   If the pivot point is at the right of the middle element:
                A- If the target is in the range of [leftmost element, mid], then it’s in the left half of the array.
                B- Otherwise, it’s in the right half of the array.

            For this question, you should come up with the following corner cases:

            * Empty array
            * Array with 2 elements
            * Middle element is the pivot number
            * Target is not present

             O(N) time complexity and O(1) space complexity.
         */
         // { 10, 20, 1, 3, 6, 7, 8 }
        public int SolveSearchRotatedArray(int[] arr, int left, int right, int target)
        {
            // Stop recursion if these are the cases
            if (arr.Count() == 0)
                return -1;
            if (left == right)
                if (arr[left] == target)
                    return left;
                else
                    return -1;

            // Check if the middle element is the same as the target
            int mid = (left + right) / 2;
            if (arr[mid] == target)
                return mid;

            // Pivot point is at the right of the middle element
            if (arr[left] <= arr[mid])
            {
                if (target >= arr[left] && target <= arr[mid])
                    return SolveSearchRotatedArray(arr, left, mid - 1, target);
                return SolveSearchRotatedArray(arr, mid + 1, right, target);
            }

            // Pivot point is at the left of the middle element
            if (target >= arr[left] && target <= arr[mid])
                return SolveSearchRotatedArray(arr, mid + 1, right, target);
            return SolveSearchRotatedArray(arr, left, mid - 1, target);
        }
    }
}
