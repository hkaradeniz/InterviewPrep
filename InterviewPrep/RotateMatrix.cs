using System;

namespace InterviewPrep
{
    class RotateMatrix
    {
        int[,] oldMatrix = new int[3, 4] {
                { 1, 2, 3, 7 },
                { 4, 5, 6, 8 },
                { 7, 8, 9, 0 }
            };

        public void RotateMatrixCounterClockwise()
        {
            int oldRow = oldMatrix.GetLength(0); //3 - Row
            int oldCol = oldMatrix.GetLength(1); //4 - Column

            // Why [oldCol, oldRow]? Because we will rotate it
            int[,] newMatrix = new int[oldCol, oldRow];

            int newRow = 0; int newCol = 0;

            for (int i = oldCol - 1; i >= 0; i--)
            {
                newCol = 0;
                for (int j = 0; j < oldRow; j++)
                {
                    newMatrix[newRow, newCol] = oldMatrix[j, i];
                    newCol++;
                }
                newRow++;
            }

            DisplayMatrix(newMatrix);
        }

        public void RotateMatrixClockwise()
        {
            int oldRow = oldMatrix.GetLength(0); //3
            int oldCol = oldMatrix.GetLength(1); //4

            int[,] newMatrix = new int[oldCol, oldRow];

            int newRow = 0; int newCol = 0;

            for (int i = 0; i < oldCol; i++)
            {
                newCol = 0;
                for (int j = oldRow - 1; j >= 0; j--)
                {
                    newMatrix[newRow, newCol] = oldMatrix[j, i];
                    newCol++;
                }
                newRow++;
            }

            DisplayMatrix(newMatrix);
        }

        public void DisplayMatrix(int[,] newMatrix)
        {
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", newMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Rotate(int[,] matrix, int n)
        {
            /*
             * Sample Matrix: 5x5
             * To Rotate in place this way, matrix must be a square matrix
             
                    0   1   2   3   4
                    |   |   |   |   |
                0-  10  11  12  13  14
                1-  15  16  17  18  19
                2-  20  21  22  23  24
                3-  25  26  27  28  29
                4-  30  31  32  33  34
                     
            **** FIRST ITERATION ****
            Layer: 0
                First: 0
                Last: 4
                    0   1   2   3   4
                    |   |   |   |   |
                0-  10  11  12  13  14
                1-  15              19
                2-  20              24
                3-  25              29
                4-  30  31  32  33  34

                First Inner Iteration:
                    i=0;
                    offset: 0; (i - first)

                    // Save Top 
                    top: matrix[0, 0]; // matrix[first, i]
                    
                    // left -> top 
                    matrix[0, 0] = matrix[4 - 0, 0]; // matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[4 - 0, 0] = matrix[4, 4 - 0]; // matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                     matrix[4, 4 - 0] = matrix[0, 4]; //matrix[last, last - offset] = matrix[i, last];

                    // top -> right
                    matrix[0, 4] = top; //matrix[i, last] = top;


                 Second Inner Iteration:
                    i=1;
                    offset: 1; (i - first)

                    // Save Top 
                    top: matrix[0, 1]; // matrix[first, i]
                    
                    // left -> top 
                    matrix[0, 1] = matrix[4 - 1, 0]; // matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[4 - 1, 0] = matrix[4, 4 - 1]; // matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                     matrix[4, 4 - 1] = matrix[1, 4]; //matrix[last, last - offset] = matrix[i, last];

                    // top -> right
                    matrix[1, 4] = top; //matrix[i, last] = top;
             */
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - layer - 1;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    // Save top
                    int top = matrix[first, i];

                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];

                    // top -> right
                    matrix[i, last] = top;
                }
            }
        }
    }
}
