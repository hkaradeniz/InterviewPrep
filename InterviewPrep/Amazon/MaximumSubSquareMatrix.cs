using System;

namespace InterviewPrep.Amazon
{
    /* Maximum size SQUARE sub-matrix with all 1s */
    /*
        1) Construct a sum matrix S[R][C] for the given M[R][C].
         a)    Copy first row and first columns as it is from M[][] to S[][]
         b)    For other entries, use following expressions to construct S[][]
             If M[i][j] is 1 then
                S[i][j] = min(S[i][j-1], S[i-1][j], S[i-1][j-1]) + 1
             Else //If M[i][j] is 0
                S[i][j] = 0
        2) Find the maximum entry in S[R][C]
        3) Using the value and coordinates of maximum entry in S[i], print
           sub-matrix of M[][]
    */
    class MaximumSubSquareMatrix
    {
        public void FindMaximumSubSquareMatrix(int[,] matrix)
        {
            if (matrix == null) return;

            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);

            int[,] newMatrix = new int[row + 1, column + 1];

            // Set the new matrix
            // If matrix[i,j]==0 then place 0 in the new matrix
            // If matrix[i,j]==1 then check for the previous col, previos row and the one across. Get min value, increase 1  
            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= column; j++)
                {
                    if (matrix[i - 1, j - 1] == 0)
                        newMatrix[i, j] = 0;
                    else
                    {
                        newMatrix[i,j] = Math.Min(Math.Min(newMatrix[i, j-1], newMatrix[i-1,j]), newMatrix[i-1,j-1]) + 1;
                    }
                }
            }

            // Find the max value in the new matrix
            int max = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 1; i <=row ; i++)
            {
                for (int j = 1; j <= column; j++)
                {
                    if (newMatrix[i, j] > max)
                    {
                        max = newMatrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"Max Area: {max * max}");
        }
    }

    /*
    Test:
     Amazon.MaximumSubSquareMatrix ms = new Amazon.MaximumSubSquareMatrix();
            int[,] matrix = new int[4, 5];
            matrix[0, 0] =0;
            matrix[0, 1] =0;
            matrix[0, 2] =1;
            matrix[0, 3] =1;
            matrix[0, 4] =1;

            matrix[1, 0] = 1;
            matrix[1, 1] = 0;
            matrix[1, 2] = 1;
            matrix[1, 3] = 1;
            matrix[1, 4] = 1;

            matrix[2, 0] = 0;
            matrix[2, 1] = 1;
            matrix[2, 2] = 1;
            matrix[2, 3] = 1;
            matrix[2, 4] = 1;

            matrix[3, 0] = 1;
            matrix[3, 1] = 0;
            matrix[3, 2] = 1;
            matrix[3, 3] = 1;
            matrix[3, 4] = 1;
            ms.FindMaximumSubSquareMatrix(matrix);
    */
}
