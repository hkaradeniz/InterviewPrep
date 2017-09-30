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

        /* Either the left or right half must be normally ordered. Find out which side
            * is normally ordered, and then use the normally ordered half to figure out
             * which side to search to find x. 

            This code will run in O(log n) if all the elements are unique. However, with many duplicates, the algorithm
            is actually O( n). This is because with many duplicates, we will often have to search both the left and
            right sides of the array (or subarrays).
         */

        // Elements must be distinct
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
                else if (arr[mid] <= arr[high]) // //Left is normally ordered.
                {
                    if (arr[mid] < target && arr[high] >= target)
                        low = mid + 1; // Search RIGHT
                    else
                        high = mid - 1; // Search LEFT 
                }
                // if right is not sorted somehow, this means left is totaly sorted
                else
                {
                    if (arr[low] <= target && arr[mid] > target) //Right is normally ordered.
                        high = mid - 1; // Search LEFT
                    else
                        low = mid - 1; // // Search RIGHT
                }
            }

            return -1;
        }

        // Find Rotation Count
        /*
        2 Test Arrays:
        
                                 X
        15 | 22 | 23 | 28 | 31 | 38 | 5 | 6 | 8 | 10 | 12 


                                X
        15 | 22 | 23 | 28 | 3 | 4 | 5 | 6 | 8 | 10 | 12


            Arrayl: {10, 15, 20, 0, 5}
            Array2: {50, 5, 20, 30, 40}
        */
        public int FindRotationCount(int[] arr)
        {
            int low = 0;
            int n = arr.Length;
            int high = n-1;
            
            // Rotation count will be equal to the index of the minium element
            // Minimum element is located at the index of where the value of 
            // previous index or the value of next index are greater.
            while (low <= high)
            {
                // Case 1
                if (arr[low] <= arr[high])
                    return low;

                int mid = low + (high - low) / 2;
                int previous = (mid + n - 1) % n;
                int next = (mid + 1) % n; 

                // Case 2
                if (arr[mid] <= arr[next] && arr[mid] <= arr[previous])
                    return mid;
                // Case 3
                else if (arr[mid] >= arr[high])
                    low = mid + 1; // Go right. The smallest element must be on the rotated side
                // Case 4
                else if (arr[mid] <= arr[low])
                    high = mid - 1; // Go left...
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
