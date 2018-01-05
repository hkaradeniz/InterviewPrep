using System;

namespace InterviewPrep.Amazon
{
    /* Search an element in sorted Matrix */
    /* Given an n x n matrix and a number x, find position of x in the matrix if it is present in it.  */
    /* Solution:
     * 
     *  1) Start with top right element
        2) Loop: compare this element e with x
        ….i) if they are equal then return its position
        …ii) e < x then move it to down (if out of bound of matrix then break return false) ..iii) e > x then move it to left (if out of bound of matrix then break return false)
        3) repeat the i), ii) and iii) till you find element or returned false
    */
    /*
     Test Data:
     Amazon.SortedMatrixSearch ss = new Amazon.SortedMatrixSearch();
     int[,] matrix = new int[4,4] {
                { 10, 20, 30, 40},
                { 15, 25, 35, 45},
                { 27, 29, 37, 48},
                { 32, 33, 39, 50}
     };

     ss.FindElement(matrix, 32);
     */
    class SortedMatrixSearch
    {
        public void FindElement(int[,] matrix, int element)
        {
            if (matrix == null || matrix.Length == 0) { Console.WriteLine("Empty matrix!"); return; }

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int i = 0;
            int j = col - 1;

            while (i < row && j >= 0)
            {
                if (matrix[i, j] == element)
                { Console.WriteLine($"Element is found at matrix[{i}, {j}]"); return; }
                else if (matrix[i, j] > element)
                { j--; }
                else
                { i++; }
            }


            Console.WriteLine("Element not found!");
        }
    }
}
