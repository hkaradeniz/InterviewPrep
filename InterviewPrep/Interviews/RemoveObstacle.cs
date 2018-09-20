using System;

namespace InterviewPrep.Interviews
{
    class RemoveObstacle
    {
        /*
            1   1   1   1 
            0   1   1   1
            0   9   1   1
            1   1   0   1
            
            9: Obstacle
            1: Flat Area
            0: Trench 
         */
        int minDistance = int.MaxValue;

        public int MinDistance(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            MinDistance(matrix, rows, cols, 0, 0, new bool[rows, cols], 0);

            return minDistance;
        }

        private void MinDistance(int[,] matrix, int rows, int cols, int i, int j, bool[,] visited, int distance)
        {
            if (i >= rows || i < 0) return;
            if (j >= cols || j < 0) return;
            if (visited[i, j] || matrix[i,j] == 0) return;

            if (matrix[i, j] == 9)
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    return;
                }
            }

            visited[i, j] = true;

            MinDistance(matrix, rows, cols, i + 1, j, visited, distance + 1);
            MinDistance(matrix, rows, cols, i - 1, j, visited, distance + 1);
            MinDistance(matrix, rows, cols, i, j - 1, visited, distance + 1);
            MinDistance(matrix, rows, cols, i, j + 1, visited, distance + 1);
            /*
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    MinDistance(matrix, rows, cols, i + x, j + y, visited, distance + 1);
                }
            }
            */

            visited[i, j] = false;
        }

        public void RunTest()
        {
            int[,] matrix = new int[,] { { 1, 1, 1, 1 },
                                         { 0, 0, 1, 1 },
                                         { 0, 9, 1, 1 },
                                         { 1, 1, 0, 1 } };
           
            Console.WriteLine(MinDistance(matrix));
        }
    }
}
