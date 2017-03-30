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
    }
}
