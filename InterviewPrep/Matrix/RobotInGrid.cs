using System.Collections.Generic;

namespace InterviewPrep.Matrix
{
    class RobotInGrid
    {
        /* Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
            The robot can only move in two directions, right and down, but certain cells are "off limits" such that
            the robot cannot step on them. Design an algorithm to find a path for the robot from the top left to
            the bottom right. 
         */
        /*
           Matrix.RobotInGrid rg = new Matrix.RobotInGrid();
           int[,] matrix = new int[4, 4];
           matrix[0, 0] = 1;
           matrix[0, 1] = 1;
           matrix[0, 2] = 0;
           matrix[0, 3] = 0;

           matrix[1, 0] = 1;
           matrix[1, 1] = 0;
           matrix[1, 2] = 0;
           matrix[1, 3] = 0;

           matrix[2, 0] = 1;
           matrix[2, 1] = 1;
           matrix[2, 2] = 1;
           matrix[2, 3] = 0;

           matrix[3, 0] = 0;
           matrix[3, 1] = 0;
           matrix[3, 2] = 1;
           matrix[3, 3] = 1;
           rg.FindPath(matrix);
         */
        public void FindPath(int[,] matrix)
        {
            // Robot is at 0,0
            // If the cell is 0, it is a block
            if (matrix == null || matrix.Length == 0) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            List<string> path = new List<string>();
            // Robot must get to rows-1, cols-1
            if (Go(matrix, rows, cols, 0, 0, path))
                PrintPath(path);

            System.Console.WriteLine("No Path!");
        }

        private bool Go(int[,] matrix, int rows, int cols, int i, int j, List<string> path)
        {
            if (i >= rows || j >= cols || matrix[i, j] == 0)
                return false;

            if ((i == rows - 1 && j == cols - 1)
                || Go(matrix, rows, cols, i + 1, j, path)
                || Go(matrix, rows, cols, i, j + 1, path))
            {
                path.Add($"{i}, {j}");
                return true;
            }

            return false;
        }

        private void PrintPath(List<string> list)
        {
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
