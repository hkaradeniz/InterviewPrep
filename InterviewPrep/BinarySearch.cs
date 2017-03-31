using System;

namespace InterviewPrep
{
    class BinarySearch
    {
        public void BinarySearchIterative(int[] array, int key, int min, int max)
        {
            while (min <= max)
            {
                // 1 2 3 4 5 6 7 8 min = 0 max = 8 mid = 4
                // 1 2 3 5 6 6 7   min = 0 max = 7 mid = 3
                int mid = (min + max) / 2;

                if (key == array[mid])
                {
                    Console.WriteLine($"Position: {mid + 1}");
                    return;
                }
                else if (key < array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
        }

        public void BinarySearchRecursive(int[] array, int key, int min, int max)
        {
            if (min > max)
                return;

            // 1 2 3 4 5 6 7 8 min = 0 max = 8 mid = 4
            // 1 2 3 5 6 6 7   min = 0 max = 7 mid = 3
            int mid = (min + max) / 2;

            if (key == array[mid])
            {
                Console.WriteLine($"Position: {mid + 1}");
            }
            else if (key < array[mid])
            {
                BinarySearchRecursive(array, key, min, mid - 1);
            }
            else
            {
                BinarySearchRecursive(array, key, mid + 1, max);
            }
        }
    }
}
