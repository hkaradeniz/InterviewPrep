using System;

namespace InterviewPrep
{
    class Matrices
    {
        // Complexity of Matrix Multiplication for mxn nxp matrices => O(mnp)
        /*
         * Test Data
          int[,] a = new int[2, 3];
            int[,] b = new int[3, 2];

            a[0, 0] = 1;
            a[0, 1] = 6;
            a[0, 2] = 3;
            a[1, 0] = 4;
            a[1, 1] = 2;
            a[1, 2] = 9;

            b[0, 0] = 4;
            b[0, 1] = 8;
            b[1, 0] = 6;
            b[1, 1] = 1;
            b[2, 0] = 2;
            b[2, 1] = 5;
            

            A = 1 6 3         B= 4 8
                4 2 9            6 1
                                 2 5   
         */
        public void MatrixMultiplication(int[,] a, int[,] b)
        {
            /*Matrix 1: m*n Matrix 2= nxp*/
            int row1 = a.GetLength(0);
            int col1 = a.GetLength(1); //->Gets the first dimension size

            int row2 = b.GetLength(0); //->Gets the second dimension size
            int col2 = b.GetLength(1);

            /* The size of col1 must be equal to row2 for multiplication */
            if (col1 != row2)
                return;

            // New matrix with new size
            int[,] matrix = new int[row1, col2];

            int rowp1 = 0; int colp1 = 0;
            int rowp2 = 0; int colp2 = 0;
            int mrow = 0; int mcol = 0;

            while (rowp1 < row1)
            {
                mcol = 0;
                colp2 = 0;

                while (colp2 < col2)
                {
                    int temp = 0;
                    rowp2 = 0;
                    colp1 = 0;

                    while (colp1 < col1)
                    {
                        temp += a[rowp1, colp1] * b[rowp2, colp2];
                        colp1++;
                        rowp2++;
                    }

                    matrix[mrow, mcol] = temp;
                    mcol++;
                    colp2++;
                }

                mrow++;
                rowp1++;
            }
        }

        private void PrintMatrix(int[,] m)
        {
            int row = m.GetLength(0); // Gets row
            int col = m.GetLength(1); // Gets col

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
