using System;

namespace InterviewPrep
{
    class WordSearch
    {
        /*
         Given a 2D board and a word, find if the word exists in the grid.

            The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those 
            horizontally or vertically neighboring. The same letter cell may not be used more than once.

              board =
                [
                  ['A','B','C','E'],
                  ['S','F','C','S'],
                  ['A','D','E','E']
                ]

                Given word = "ABCCED", return true.
                Given word = "SEE", return true.
                Given word = "ABCB", return false.
         */

        public bool exist(char[,] board, String word)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (search(board, i, j, row, col, word, new bool[row,col], 0))
                        return true;
                }
            }

            return false;
        }

        private bool search(char[,] board, int i, int j, int row, int col,
                               String word, bool[,] visited, int index)
        {
            if (index == word.Length) return true;
            if (i < 0 || i >= row || j < 0 || j >= col || index >= word.Length) return false;
            if (visited[i,j]) return false;

            if (board[i,j] == word[index])
            {
                visited[i,j] = true;

                if (search(board, i + 1, j, row, col, word, visited, index + 1)
                  || search(board, i - 1, j, row, col, word, visited, index + 1)
                  || search(board, i, j + 1, row, col, word, visited, index + 1)
                  || search(board, i, j - 1, row, col, word, visited, index + 1))
                    return true;

                visited[i,j] = false;
            }

            return false;
        }
    }
}
