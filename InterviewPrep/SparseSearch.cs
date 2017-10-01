using System;

namespace InterviewPrep
{
    /*?
    Cracking the Coding Interview, 6th Edition
    Sparse Search: Given a sorted array of strings that is interspersed with empty strings, write a
        method to find the location of a given string.
        EXAMPLE
        Input: ball, {"at","", "", "","ball","", "","car","", "","dad","", ""}
        Output: 4

        If it weren't for the empty strings, we could simply use binary search. We would compare the string to be
        found, s tr, with the midpoint of the array, and go from there.
        With empty strings interspersed, we can implement a simple modification of binary search. All we need to
        do is fix the comparison against mid, in case mid is an empty string. We simply move mid to the closest
        non-empty string.
        The recursive code below to solve this problem can easily be modified to be iterative. We provide such an
        implementation in the code attachment.
    */

    /*?
    The worst-case runtime for this algorithm is O ( n).
    */

    class SparseSearch
    {
        public int SparseBinarySearch(string[] arr, string str)
        {
            if (String.IsNullOrEmpty(str) || arr == null)
                return -1;

            return SparseSearchRecursive(arr, str, 0, arr.Length - 1);
        }

        private int SparseSearchRecursive(string[] arr, string str, int first, int last)
        {
            if (first > last)
                return -1;

            // Get middle
            int mid = first + (last - first) / 2;

            // If mid is empty, find closest non-empty string. 
            if (String.IsNullOrEmpty(arr[mid]))
            {
                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {
                    if (left < first && right > last)
                        return -1;
                    else if (right <= last && !String.IsNullOrEmpty(arr[right]))
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && !String.IsNullOrEmpty(arr[left]))
                    {
                        mid = left;
                        break;
                    }

                    left--;
                    right++;
                }
            }

            // Check for string, and recurse if necessary
            if (str == arr[mid])
                return mid;
            else if (arr[mid].CompareTo(str) < 0) // Go right
                return SparseSearchRecursive(arr, str, mid + 1, last);
            else // Go left
                return SparseSearchRecursive(arr, str, first, mid-1);
        }
    }
}
