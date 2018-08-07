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
    class SpiralPrint
    {
        public void PrintMatrix(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int top = 0;
            int bottom = row - 1;
            int left = 0;
            int right = col - 1;

            while (true)
            {
                // from left to right
                for (int i = left; i <= right; i++)
                    Console.Write(matrix[top, i] + " ");
                top++;
                if (left > right || top > bottom) return;

                // from top to bottom
                for (int i = top; i <= bottom; i++)
                    Console.Write(matrix[i, right] + " ");
                right--;
                if (left > right || top > bottom) return;

                // from right to left
                for (int i = right; i >= left; i--)
                    Console.Write(matrix[bottom, i] + " ");
                bottom--;
                if (left > right || top > bottom) return;

                // from bottom to top
                for (int i = bottom; i >= top; i--)
                    Console.Write(matrix[left, i] + " ");
                left++;
                if (left > right || top > bottom) return;
            }
        }
    }
}
