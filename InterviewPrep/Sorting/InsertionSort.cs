using System;

namespace InterviewPrep.Sorting
{
    class InsertionSort
    {
        public void Sort(int[] ar)
        {
            int arraySize = ar.Length;
            int j, element;

            for (int i = 1; i < arraySize; i++)
            {
                element = ar[i];
                j = i;
                while (j > 0 && ar[j - 1] > element)
                {
                    ar[j] = ar[j - 1];
                    ar[j - 1] = element;
                    j--;
                }
            }

            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
        }
    }
}
    // Complexity
    // Best: (n log (n))
    // Average: (n log (n))
    // Worst: (n^2)
    /*
     * Worst Case Scenarios:
       The answer depends on strategy for choosing pivot. In early versions of Quick Sort 
       where leftmost (or rightmost) element is chosen as pivot, the worst occurs 
       in following cases.

        1) Array is already sorted in same order.
        2) Array is already sorted in reverse order.
        3) All elements are same (special case of case 1 and 2)

        Since these cases are very common use cases, the problem was easily solved by 
        choosing either a random index for the pivot, choosing the middle index of the 
        partition or (especially for longer partitions) choosing the median of the first, 
        middle and last element of the partition for the pivot. With these modifications, 
        the worst case of Quick sort has less chances to occur, but worst case can still 
        occur if the input array is such that the maximum (or minimum) element is always 
        chosen as pivot. 
     */
