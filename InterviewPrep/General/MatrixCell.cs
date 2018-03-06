namespace InterviewPrep.General
{
    // Find number of paths to reach to a cell in matrix.
    // You can only go right and down
    // matrix[,]
    class MatrixCell
    {
        public int TotalNumberOfWays(int i, int j)
        {
            if (i < 1 || j < 1) return 1;

            return TotalNumberOfWays(i, j - 1) + TotalNumberOfWays(i - 1, j);
        }
    }
}
