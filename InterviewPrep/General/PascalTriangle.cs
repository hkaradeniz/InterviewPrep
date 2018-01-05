using System;

namespace InterviewPrep.General
{
    class PascalTriangle
    {
        public void CreatePascalTriangle(int n)
        {
            int[,] matrix = new int[n + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                // Setting the element col 0 to 1
                matrix[i, 0]++;

                for (int j = 1; j <= n && i > 0; j++)
                {
                    matrix[i, j] = matrix[i - 1, j - 1] + matrix[i - 1, j];
                }
            }

            PrintTriangle(matrix, n);
        }

        private void PrintTriangle(int[,] triangle, int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write($" \t { triangle[i,j] }  ");
                }

                Console.WriteLine();
            }
        }
    }
}
