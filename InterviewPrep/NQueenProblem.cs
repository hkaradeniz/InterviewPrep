using System;

namespace InterviewPrep
{
    class NQueenProblem
    {
        /*
         The N-queen puzzle is the problem of placing N chess queens 
         on an N×N chessboard so that no two queens threaten each other. 
         Thus, a solution requires that no two queens share the same row, column, or diagonal.
        */
        private int N { get; set; }

        public NQueenProblem(int n)
        {
            N = n;
        }

        public void SolveNQueen()
        {
            int[,] board = new int[N, N];

            Array.Clear(board, 0, board.Length);

            if (SolveNQueenUtil(board, 0))
                PrintBoard(board);
            else
                Console.WriteLine("No Solution");
        }

        private bool SolveNQueenUtil(int[,] board, int row)
        {
            // Base case
            // Let's say N is 4. If recursive calculation reaches
            // 4 that's means Rows 0,1,2,3 is already set and
            // Queens are already placed
            // Return true 
            if (row >= N)
                return true;

            // For each row, try to place a Queen
            // by checking the columns 
            for (int i = 0; i < N; i++)
            {
                if (IsLocationSafe(board, row, i))
                {
                    // If the location is safe, place the Queen here.
                    board[row, i] = 1;

                    // Keep recursing until you place 
                    // all the queens
                    if (SolveNQueenUtil(board, row + 1))
                        return true;

                    // Backtrack...
                    // If program gets out of recursion
                    // that means there is no available square
                    // to place the queen in current row.
                    // Clear the square, and try to find 
                    // a new place for the queen in the
                    // previous square by increasing the
                    // column number
                    board[row, i] = 0;
                }
            }

            // If we get here, that means
            // there is no possible way to
            // place the queens in this board
            // without them threatening each other
            return false;
        }

        private bool IsLocationSafe(int[,] board, int row, int col)
        {
            //Check if there is another queen in the same column
            for (int i = row - 1; i >= 0; i--)
                if (board[i, col] == 1)
                    return false;

            //Check if another queen is threatening diagonally from left
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            //Check if another queen is threatening diagonally from right
            for (int i = row - 1, j = col + 1; i >= 0 && j < N; i--, j++)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        private void PrintBoard(int[,] board)
        {
            if (board.Length == 0)
            {
                Console.WriteLine("Empty Board!");
                return;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write($"{board[i, j]} ");

                Console.WriteLine();
            }
        }
    }
}
