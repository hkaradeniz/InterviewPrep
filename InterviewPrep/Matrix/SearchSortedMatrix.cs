using System;

namespace InterviewPrep.Matrix
{
    class SearchSortedMatrix
    {
        /* Searching a 2D Sorted Matrix */
        /* Given a sorted matrix where rows and the columns are sorted.
            Write an algorithm to search an element in the matrix in O(n). */

        /* Solution: Stair Search */
        /* Below is an efficient solution that works in O(n) time.
            1) Start with top right element
            2) Loop: compare this element e with x
            ….i) if they are equal then return its position
            …ii) e < x then move it to down (if out of bound of matrix then break return false) 
            ..iii) e > x then move it to left (if out of bound of matrix then break return false)
            3) repeat the i), ii) and iii) till you find element or returned false */
        /*
         Given an n x n matrix and a number x, find position of x in the matrix if it is present in it. 
         Else print “Not Found”. In the given matrix, every row and column is sorted in increasing order.
         The designed algorithm should have linear time complexity.
            
            Input : mat[4][4] = { {10, 20, 30, 40},
                                  {15, 25, 35, 45},
                                  {27, 29, 37, 48},
                                  {32, 33, 39, 50}};
                                   x = 29
            Output : Found at (2, 1)

            Input : mat[4][4] = { {10, 20, 30, 40},
                                  {15, 25, 35, 45},
                                  {27, 29, 37, 48},
                                  {32, 33, 39, 50}};
                          x = 100
            Output : Element not found

            Test Data:
            InterviewPrep.Matrix.SearchSortedMatrix s = new InterviewPrep.Matrix.SearchSortedMatrix();
            int[,] matrix = new int[,] { { 10, 20, 30, 40 }, { 15, 25, 35, 45 }, { 27, 29, 37, 48 }, { 32, 33, 39, 50 } };
            s.Search(matrix, 100);
         */

        public void Search(int[,] matrix, int number)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int rowpointer = 0;
            int colpointer = col - 1;

            while (rowpointer < row && colpointer >= 0)
            {
                if (matrix[rowpointer, colpointer] == number)
                {
                    Console.WriteLine($"Found at ({rowpointer}, {colpointer})");
                    return;
                }
                else if (matrix[rowpointer, colpointer] > number)
                {
                    colpointer--;
                }
                else
                {
                    rowpointer++;
                }
            }

            Console.WriteLine("Element not found");
        }
    }
}
