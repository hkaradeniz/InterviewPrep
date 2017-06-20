using System;

namespace InterviewPrep
{
    class _3Sum
    {
        /*
         * Determine if any 3 integers in an array sum to 0.

            For example, for array [4, 3, -1, 2, -2, 10], the function should 
            return true since 3 + (-1) + (-2) = 0. To make things simple, each 
            number can be used at most once.

            // http://blog.gainlo.co/index.php/2016/07/19/3sum/
         */

        // Brute Force Algorithm 
        // O(N^3) Cubic
        // Not acceptable
        public void Solve3SumBruteForce(int[] arr)
        {
            int size = arr.Length;
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            Console.WriteLine($"{arr[i]} {arr[j]} {arr[k]}");
                            count++;
                        }
                    }
                }
            }
        }


        // Optimal solution
        // O(N^2) Quadratic
        public void Solve3SumOptimal(int[] arr)
        {
            int start, end, size;
            size = arr.Length;

            Array.Sort(arr);

            // Fix the first element and find the other two
            // End of the loop should be size-2
            // Final Scenario: i= size-3 start=size-2 end=size-1
            for (int i = 0; i < size-2; i++)
            {
                // To find other two elements, start two index
                // variables from two corners of the array and move
                // them toward each other

                start = i + 1; // index of the first element of the remaining elements
                end = size - 1; // index of the last element

                while (start < end)
                {
                    if (arr[i] + arr[start] + arr[end] == 0)
                    {
                        Console.WriteLine($"{arr[i]} {arr[start]} {arr[end]}");
                    }
                    else if (arr[i] + arr[start] + arr[end] < 0)
                    {
                        start++;
                    }
                    else // arr[i] + arr[start] + arr[end] > 0
                    {
                        end--;
                    }
                }
            }
        }
    }
}
