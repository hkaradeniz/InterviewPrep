using System;

namespace InterviewPrep
{
    class BinarySearch
    {
        public void BinarySearchIterative(int[] array, int key, int left, int right)
        {
            while (left <= right)
            {
                // 1 2 3 4 5 6 7 8 left = 0 right = 8 mid = 4
                // 1 2 3 5 6 6 7   left = 0 right = 7 mid = 3
                int mid = (left + right) / 2; // left + (right - left) / 2

                if (key == array[mid])
                {
                    Console.WriteLine($"Position: {mid + 1}");
                    return;
                }
                else if (key < array[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
        }

        public void BinarySearchRecursive(int[] array, int key, int left, int right)
        {
            if (left > right)
                return;

            // 1 2 3 4 5 6 7 8 left = 0 right = 8 mid = 4
            // 1 2 3 5 6 6 7   left = 0 right = 7 mid = 3
            int mid = (left + right) / 2; // left + (right - left) / 2

            if (key == array[mid])
            {
                Console.WriteLine($"Position: {mid + 1}");
            }
            else if (key < array[mid])
            {
                BinarySearchRecursive(array, key, left, mid - 1);
            }
            else
            {
                BinarySearchRecursive(array, key, mid + 1, right);
            }
        }
    }
}
