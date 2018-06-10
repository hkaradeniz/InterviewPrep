using System;

namespace InterviewPrep
{
    /*? 
     * Cracking the Coding Interview, 6th Edition 
     * Tic Tac Win: Design an algorithm to figure out if someone has won a game of tic-tac-toe.
     */
    class TicTacToeWinner
    {
        int totalNumberOfMoves = 0;
        string[,] board;

        public TicTacToeWinner()
        {
            board = new string[3, 3];
        }

        public void Winner(int x, int y, string player)
        {
            // Player 1:O  2:X
            // Board
            if (x > 2 || y > 2)
                throw new IndexOutOfRangeException();

            if (string.IsNullOrEmpty(board[x, y]))
                board[x, y] = player;
            else
                throw new InvalidOperationException();

            totalNumberOfMoves++;

            // Check Cols
            for (int i = 0; i < 3; i++)
            {
                if (string.IsNullOrEmpty(board[x, i]) || board[x, i] != player)
                    break;
                if (i == 2)
                { Console.WriteLine($"{player} wins!"); return; }
            }

            // Check Rows
            for (int i = 0; i < 3; i++)
            {
                if (string.IsNullOrEmpty(board[i, y]) || board[i, y] != player)
                    break;
                if (i == 2)
                { Console.WriteLine($"{player} wins!"); return; }
            }

            // Check diagonal
            if (x == y)
            {
                //we're on a diagonal
                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrEmpty(board[i, i]) || board[i, i] != player)
                        break;
                    if (i == 2)
                    { Console.WriteLine($"{player} wins!"); return; }
                }
            }

            // Check anti diagonal
            // The total is always 2
            // (0,2) (1,1) (2,0)
            if (x + y == 2)
            {
                int col = 2;
                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrEmpty(board[i, col]) || board[i, col] != player)
                        break;
                    if (i == 2)
                    { Console.WriteLine($"{player} wins!"); return; }

                    col--;
                }
            }

            if (totalNumberOfMoves == 9)
                Console.WriteLine("Draw!");

        }

        public bool Winner(int player)
        {
            int[,] board = new int[,] { {1,1,0},
                                        {1,0,1},
                                        {1,1,0}};

            bool[] rows = new bool[3];
            bool[] cols = new bool[3];
            bool diagL = true;
            bool diagR = true;

            for (int i = 0; i < 3; i++)
            {
                rows[i] = true;
                cols[i] = true;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != player)
                    {
                        rows[i] = false;
                        cols[j] = false;

                        if (i == j) diagL = false;
                        if (board.Length - i - 1 == j) diagR = false;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (rows[i] || cols[i] || diagL || diagR) return true;
            }

            return false;
        }
    }
}
