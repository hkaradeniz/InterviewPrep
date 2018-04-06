using System;

namespace InterviewPrep.Facebook
{
    /*
        Print matrix in spiral form. Print the 2-D array in spiral form.
        
        a  b  c  d  e
        f  g  h  i  j
        u  v  m  n  o
        p  q  r  s  t
        
        a, b, c, d, j, o, t, s, r, q, p, u, f, g, h, i, n, m, v                    
            
        You will traverse
        First Row -> Last Column -> Last Row -> First Column
        

    */
    class SprialPrint
    {
        public void PrintMatrix(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int pointer = 0;
            int firstRow = 0;
            int firstCol = 0;
            int lastRow = row - 1;
            int lastCol = col - 1;

            while (firstRow < lastRow && firstCol < lastCol)
            {
                // Print the first row from the remaining rows
                for (pointer = firstCol; pointer <= lastCol; pointer++)
                {
                    Console.Write($"{matrix[firstRow, pointer]} ");
                }
                firstRow++;

                // Print the last column from the remaining columns 
                for (pointer = firstRow; pointer <= lastRow; pointer++)
                {
                    Console.Write($"{matrix[pointer, lastCol]} ");
                }
                lastCol--;

                // Print the last row from the remaining rows */
                for (pointer = lastCol; pointer >= firstRow; pointer--)
                {
                    Console.Write($"{matrix[lastRow, pointer]} ");
                }
                lastRow--;

                // Print the first column from the remaining columns */
                for (pointer = lastRow; pointer >= firstRow; pointer--)
                {
                    Console.Write($"{matrix[pointer, firstCol]} ");
                }
                firstCol++;
            }

        }
        
    }
}
