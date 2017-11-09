using System;

namespace InterviewPrep.Graphs
{
    class NumberOfClusters
    {
        /* Given a 2D matrix of 0s and 1s, find total number of clusters formed by elements with value 1. The algorithm 
        to find total number of clusters of elements with value 1 in a given 2D matrix treats the given matrix as a 
        graph and then it finds out total number of connected components in that graph. */
        /*
        Test Data:
         Graphs.NumberOfClusters nc = new Graphs.NumberOfClusters();
            int[,] matrix = new int[3, 5];
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 1;
            matrix[0, 3] = 0;
            matrix[0, 4] = 1;

            matrix[1, 0] = 1;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;
            matrix[1, 3] = 0;
            matrix[1, 4] = 0;

            matrix[2, 0] = 0;
            matrix[2, 1] = 1;
            matrix[2, 2] = 0;
            matrix[2, 3] = 1;
            matrix[2, 4] = 1;
            nc.ComputeNumberOfClusters(matrix);

            Complexity(O(mn))
         */
        public void ComputeNumberOfClusters(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            bool[,] lands = new bool[row, col];
            int counter = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j]==1 && !lands[i,j])
                    {
                        counter++;
                        PinpointLands(i, j, row, col, matrix, lands);
                    }
                }
            }

            Console.WriteLine($"Number of Islands: {counter}");
        }


        /*
                1  0  1  0  1
                1  1  0  0  0
                0  1  0  1  1
         */
        private void PinpointLands(int i, int j, int row, int col, int[,] matrix, bool[,] lands)
        {
            if (i >= row || j >= col)
                return;

            if (i < 0 || j < 0)
                return;

            if (matrix[i, j]==1)
            {
                lands[i, j] = true;
   
                PinpointLands(i, j + 1, row, col, matrix, lands);
                PinpointLands(i + 1, j, row, col, matrix, lands);
                PinpointLands(i + 1, j + 1, row, col, matrix, lands);
                PinpointLands(i - 1, j + 1, row, col, matrix, lands);    
            }
        }
    }
}
