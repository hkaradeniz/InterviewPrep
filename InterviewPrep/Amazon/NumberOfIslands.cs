using System;

namespace InterviewPrep.Amazon
{
    /* Find the number of islands */
    /* A group of connected 1s forms an island. Write a function to return the number of islands present. */
    /* Island is connected only vertically and horizontally NOT Diagonally */
    /* https://practice.geeksforgeeks.org/problems/find-the-number-of-islands/1 */
    /* We will use Depth First Traversal for a Graph */
    class NumberOfIslands
    {
        public int GetNumberOfIslands(int[,] map)
        {
            if (map == null || map.Length == 0) { Console.WriteLine("Empty Map"); return 0; }

            int row = map.GetLength(0);
            int col = map.GetLength(1);

            bool[,] land = new bool[row, col];
            int numberOfIslands = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (map[i, j] == 1 && !land[i, j])
                    {
                        numberOfIslands++;
                        SetLandBoundaries(i, j, row, col, map, land);
                    }
                }
            }

            return numberOfIslands; 

        }

        private void SetLandBoundaries(int i, int j, int row, int col, int[,] map, bool[,] land)
        {
            if (i >= row || j >= col)
                return;

            if (i < 0 || j < 0)
                return;

            if (map[i, j] == 1)
            {
                land[i, j] = true;
                SetLandBoundaries(i + 1, j, row, col, map, land);
                SetLandBoundaries(i, j + 1, row, col, map, land);
            }
        }
    }
}
