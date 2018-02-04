using System;

namespace InterviewPrep.Google
{
    /* Max Rectangle in Binary Matrix */
    /* Given a 2D binary matrix filled with 0’s and 1’s, find the largest rectangle containing all ones and return its area.
        Bonus if you can solve it in O(n^2) or less. */
    /*
    A : [   1 0 0 1 1 1
            1 0 1 1 0 1
            0 1 1 1 1 1
            0 0 1 1 1 1  
                ]

            Output : 8

     Solution: Create an array size of cols

      Iteration 1 - 
      + Add elements at row 0 from col 0 to col 5 to the array

        Array:
        Index   : 0   1   2   3   4   5
        Element : 1   0   0   1   1   1
        
        Create a histogram. Maximum area you can draw here is 3 (from index 3 to 5)
        MaxArea: 3    

      Iteration 2 - 
      + Add elements at row 2 from col 0 to col 5 to the array (if matrix[i,j] is 0, then the array[j] becomes 0)

        Array:
        Index   : 0   1   2   3   4   5
        Element : 2   0   1   2   0   2
        
        Create a histogram. Maximum area you can draw here is 2 (from index 2 to 3)
        MaxArea: 3 (still MaxArea is 3)   

      Iteration 3 - 
      + Add elements at row 3 from col 0 to col 5 to the array (if matrix[i,j] is 0, then the array[j] becomes 0)

        Matrix Col 2: 0 1 1 1 1 1
        Array:
        Index   : 0   1   2   3   4   5
        Element : 0   1   2   3   1   3
        
        Create a histogram. Maximum area you can draw here is 5 (from index 1 to 5)
        MaxArea: 5    

       Iteration 4 -
       + Add elements at row 4 from col 0 to col 5 to the array (if matrix[i,j] is 0, then the array[j] becomes 0)

        Matrix Col 2:  0 0 1 1 1 1  
        Array:
        Index   : 0   1   2   3   4   5
        Element : 0   0   3   4   2   4
        
        Create a histogram. Maximum area you can draw here is 8 (from index 2 to 5)
        MaxArea: 8    
    */
    /*
    Test Code:
            Google.MaximumSizeRectangle r = new Google.MaximumSizeRectangle();
            int[,] matrix = { { 1, 0, 0, 1, 1, 1, }, { 1, 0, 1, 1, 0, 1 }, { 0, 1, 1, 1, 1, 1, }, { 0, 0, 1, 1, 1, 1 } };
            Console.WriteLine(r.CalculateMaxArea(matrix));
     */
    class MaximumSizeRectangle
    {
        public int CalculateMaxArea(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return -1;

            /* Test Matrix: 
                A : [   1 0 0 1 1 1
                        1 0 1 1 0 1
                        0 1 1 1 1 1
                        0 0 1 1 1 1  
                    ]
              */
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // We create size cold+1 array, so that the last element of the array will always be 0
            // Hence we don't need to track of if we are at the last element or not!
            int[] histogram = new int[cols + 1];
            int maxArea = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                        histogram[j] = 0;
                    else
                        histogram[j] += matrix[i, j];
                }

                int currentMax = CalculateHistogramArea(histogram);
                maxArea = Math.Max(maxArea, currentMax);
            }

            return maxArea;
        }

        private int CalculateHistogramArea(int[] arr)
        {
            int maxArea = 0;
            int minHeight = int.MaxValue;
            int rows = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                // Lastly, the loop will have arr[arr.length - 1] == 0 condition since the last element is just
                // a placeholder and is always 0 
                if (arr[i] == 0)
                {
                    maxArea = Math.Max((rows * minHeight), maxArea);
                    minHeight = int.MaxValue;
                    rows = 0;
                }
                else
                {
                    minHeight = Math.Min(minHeight, arr[i]);
                    rows++;
                }
            }

            return maxArea;
        }

    }
}
