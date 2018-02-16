using System;

namespace InterviewPrep.Amazon
{
    // Maximum sum rectangle in a 2D matrix
    class MaxSumOf2DArray
    {
        /*
         Test:
         Amazon.MaxSumOf2DArray sm = new Amazon.MaxSumOf2DArray();
         sm.FindMaxSumMatrix(new int[,] {
                        { 1,   2,  -1, -4, -20},
                        {-8,  -3,   4,  2,   1},
                        { 3,   8,  10,  1,   3},
                        {-4,  -1,   1,  7,  -6}
                        });

            (Top, Left) (1, 1)
            (Bottom, Right) (3, 3)
            Max sum is: 29
         */
        /*
         * STEP 1
         Matrix:
            left = 0; right=0              Array (matrix[i,right]) RIGHT=0
           { 2,   6,  -2,  7,   1},         2
           { 5,   3,   4,  1,  -6},         5
           { 0,   2,  -1,  1,  -1},         0
           { 8,  -3,  -1,  1,  -1}          8
                                            Calculate the maximum subarray in the array above.


          * STEP 2
         Matrix:
            left = 0; right=1              Array (matrix[i,right]) RIGHT=1 (Add existing array)
           { 2,   6,  -2,  7,   1},         2+6
           { 5,   3,   4,  1,  -6},         5+3
           { 0,   2,  -1,  1,  -1},         0+2
           { 8,  -3,  -1,  1,  -1}          8-3
                                            Calculate the maximum subarray in the array above.
            ...
           Once right reaches the last col, increase left and do all this over again...

         */
        // asymptotic runtime complexity o(n^3)
        public void FindMaxSumMatrix(int[,] matrix)
        {
            if (matrix == null) return;

            int maxSum = int.MinValue;
            int maxLeft = 0;
            int maxRight = 0;
            int maxUp = 0;
            int maxDown = 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int left = 0; left < cols; left++)
            {
                int[] temp = new int[rows];

                for (int right = left; right < cols; right++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        temp[i] += matrix[i, right];
                    }

                    MaxAtLocation result = CalculateMax(temp);

                    if (result.Max > maxSum)
                    {
                        maxSum = result.Max;
                        maxLeft = left;
                        maxRight = right;
                        maxUp = result.StartIndex;
                        maxDown = result.EndIndex;
                    }
                    
                }
            }

            Console.WriteLine($"Max Sum: { maxSum }");
            Console.WriteLine($"Coordinates: { maxLeft }, { maxUp } : { maxRight }, { maxDown }");
        }


        // Using Kadane's Largest Sum Contiguous Subarray
        private MaxAtLocation CalculateMax(int[] arr)
        {
            MaxAtLocation result = new MaxAtLocation();

            int currentMax = 0;
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentMax += arr[i];

                if (currentMax < 0)
                {
                    currentMax = 0;
                    index++;
                    continue;
                }

                if (currentMax > result.Max)
                {
                    result.Max = currentMax;
                    result.StartIndex = index;
                    result.EndIndex = i; 
                }
            }

            return result;
        }
    }

    class MaxAtLocation
    {
        public int Max { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public MaxAtLocation()
        {
            Max = int.MinValue;
        }
    }
}
