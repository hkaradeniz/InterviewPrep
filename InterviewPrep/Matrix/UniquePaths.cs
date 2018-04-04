using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep.Matrix
{
    /*
     Given a grid of size m * n, lets assume you are starting at (1,1) and your goal is to reach (m,n).
     At any instance, if you are on (x,y), you can either go to (x, y + 1) or (x + 1, y).

        Now consider if some obstacles are added to the grids. How many unique paths would there be?
        An obstacle and empty space is marked as 1 and 0 respectively in the grid.

        Example :
        There is one obstacle in the middle of a 3x3 grid as illustrated below.

        [
          [0,0,0],
          [0,1,0],
          [0,0,0]
        ]
        The total number of unique paths is 2.
         
     */
    class UniquePaths
    {
        public int uniquePathsWithObstacles(List<List<int>> A)
        {
            int m = A.Count;
            int n = A[0].Count;

            return Go(A, m - 1, n - 1);
        }

        private int Go(List<List<int>> matrix, int m, int n)
        {
            // you can either go to (x, y + 1) or (x + 1, y)
            //                           RIGHT OR DOWN
            // If we start from m-1, n-1, we can go left or up (m - 1, n) or (m, n-1)
            if (m < 0 || n < 0) return 0; // no path
            if (matrix[m].ElementAt(n) == 1) return 0; // obstacle
            if (m == 0 && n == 0) return 1;

            return Go(matrix, m - 1, n) + Go(matrix, m, n - 1);
        }
    }
}
