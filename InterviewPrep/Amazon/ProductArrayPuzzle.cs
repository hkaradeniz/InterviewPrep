using System;

namespace InterviewPrep.Amazon
{
    // A Product Array Puzzle
    /*
    Given an array arr[] of n integers, construct a Product Array prod[] (of same size) such that prod[i] is 
    equal to multiplication of all the elements of arr[] except arr[i]. Solve it without division operator and in O(n).
    */
    class ProductArrayPuzzle
    {
        // With division
        public void SolvePuzzleWithDivision(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int result = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                result *= arr[i];
            }

            int[] productionArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                productionArr[i] = result / arr[i];
            }

            PrintArray(productionArr);
        }

        // Without division
        /*
            1) Construct a temporary array left[] such that left[i] contains product of all elements on left 
            of arr[i] excluding arr[i].
            2) Construct another temporary array right[] such that right[i] contains product of all elements 
            on on right of arr[i] excluding arr[i].
            3) To get prod[], multiply left[] and right[].
         */
        public void SolvePuzzleWithoutDivision(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int n = arr.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            int[] prod = new int[n];

            // Construct left arr
            /*
                    Ex:
                    Index: 0  1  2  3
                    Arr  : 1, 2, 3, 4
                    left : 1, 1, 2, 6  
              */
            int total = 1;
            for (int i = 0; i < n; i++)
            {
                left[i] = total;
                total *= arr[i];
            }

            // Construct right arr
            /*
                    Ex:
                    Index : 0  1  2  3
                    Arr   : 1, 2, 3, 4
                    right :24, 12, 4, 1  
              */
            total = 1;
            for (int i = n-1; i >= 0; i--)
            {
                right[i] = total;
                total *= arr[i];
            }

            // Construct Prod array
            for (int i = 0; i < n; i++)
            {
                prod[i] = left[i] * right[i];
            }

            PrintArray(prod);
        }

        private void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($" {arr[i]} ");
            }
        }
    }
}
