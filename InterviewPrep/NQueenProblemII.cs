using System;

namespace InterviewPrep
{
    class NQueenProblemII
    {
        // Given a chess board queens placed on it, check if queens are safe from each other
        // BUG.
        public bool AreQueensSafe(int[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            bool[] rowKeeper = new bool[rows];
            bool[] colKeeper = new bool[rows];
            //bool[] diagTopKeeper = new bool[rows * 2]; // from top to right 14 squares
            //bool[] diagBottomKeeper = new bool[rows * 2];   // from left to bottom 14 squares

            /*
                                T
                    0   1   2   3   4   5   6   7
                 0  X   X   X   X   X   X   X   X   
                 1  X   X   X   X   X   X   X   X   8
                 2  X   X   X   X   X   X   X   X   9
              l  3  X   X   X   X   X   X   X   X   10
                 4  X   X   X   X   X   X   X   X   11  R
                 5  X   X   X   X   X   X   X   X   12
                 6  X   X   X   X   X   X   X   X   13
                 7  X   X   X   X   X   X   X   X   14
                        8   9   10  11  12  13  14
                                B
             */

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == 1)
                    {
                        //Console.WriteLine($"Row: {i} ** Col: {j}");

                        if (rowKeeper[i]) return false;
                        if (colKeeper[j]) return false;

                        //int sum = i + j;
                        //int diff = Math.Abs(i - j);

                        //if (diagTopKeeper[sum] || diagBottomKeeper[diff + sum]) return false;
                        //Check if another queen is threatening diagonally from left
                        for (int m = i - 1, n = j - 1; m >= 0 && n >= 0; m--, n--)
                            if (board[m, n] == 1)
                                return false;

                        //Check if another queen is threatening diagonally from right
                        for (int x = i - 1, y = j + 1; x >= 0 && y < rows; x--, y++)
                            if (board[x, y] == 1)
                                return false;

                        rowKeeper[i] = true;
                        colKeeper[j] = true;
                        //diagTopKeeper[sum] = true;
                        //diagBottomKeeper[diff + sum] = true;
                    }
                }
            }

            return true;
        }

        public void TestQueens()
        {
            int[,] board1 = new int[8, 8]
            {   {1,0,0,0,0,0,0,0 },
                {0,0,0,0,1,0,0,0 },
                {0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,1,0,0 },
                {0,0,1,0,0,0,0,0 },
                {0,0,0,0,0,0,1,0 },
                {0,1,0,0,0,0,0,0 },
                {0,0,0,1,0,0,0,0 }};

            int[,] board2 = new int[4, 4]
            {   {0,1,0,0 },
                {0,0,0,1 },
                {1,0,0,0 },
                {0,0,1,0 }};

            Console.WriteLine(AreQueensSafe(board1));
            Console.WriteLine(AreQueensSafe(board2));
        }
    }
}
