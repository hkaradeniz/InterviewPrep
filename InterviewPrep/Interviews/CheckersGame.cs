using System;

namespace InterviewPrep.Interviews
{
    class CheckersGame
    {
        // Board size
        private static readonly int BOARD_SIZE = 8;
        // Board. It is a 2-dimensional character array
        private char[,] board;
        // Store whose turn it is
        private char whoseturn;

        public CheckersGame()
        {
            // Initializing the board
            // W -> WHITE
            // R -> RED
            // O -> Empty
            board = new char[,] {   { 'O', 'W', 'O', 'W', 'O', 'W', 'O', 'W' },
                                    { 'W', 'O', 'W', 'O', 'W', 'O', 'W', 'O' },
                                    { 'O', 'W', 'O', 'W', 'O', 'W', 'O', 'W' },
                                    { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
                                    { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' },
                                    { 'R', 'O', 'R', 'O', 'R', 'O', 'R', 'O' },
                                    { 'O', 'R', 'O', 'R', 'O', 'R', 'O', 'R' },
                                    { 'R', 'O', 'R', 'O', 'R', 'O', 'R', 'O' } };

            // WHITE starts the game
            whoseturn = 'W';
        }

        // Read the input and parse coordinates and verify if the move is valid
        private void GetNextMove()
        {
            if (whoseturn == 'W') Console.WriteLine("WHITE moves...");
            else Console.WriteLine("RED moves...");

            // To see if the move operation performed successfully
            bool moved = false;

            while (!moved)
            {
                // Read coordinates from the user
                Console.WriteLine("Source: (enter two digits: RowDigitColumnDigit):");
                string source = Console.ReadLine();

                Console.WriteLine("Destination (enter two digits: RowDigitColumnDigit):");
                string destination = Console.ReadLine();

                // String length must be two (two digits)
                if (source.Length == 2 || destination.Length == 2)
                {
                    // Get first digit as char, get the ASCII value and subtract it from 0 to get the actual integer
                    int sourceRow = source[0] - '0';
                    int sourceColumn = source[1] - '0';

                    int destinationRow = destination[0] - '0';
                    int destinationColumn = destination[1] - '0';

                    // Check if this is a valid move
                    if (IsValidMove(sourceRow, sourceColumn, destinationRow, destinationColumn))
                    {
                        MoveChecker(sourceRow, sourceColumn, destinationRow, destinationColumn);
                        moved = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move... Try again");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move... Try again");
                }

                Console.WriteLine();
            }
        }

        // Decide if the next move is valid
        private bool IsValidMove(int sourceRow, int sourceColumn, int destinationRow, int destinationColumn)
        {
            // Check if indices are in range, if not, return false.
            if (sourceRow < 0 || sourceRow > 7 || sourceColumn < 0 || sourceColumn > 7 ||
                destinationRow < 0 || destinationRow > 7 || destinationColumn < 0 || destinationColumn > 7)
                return false;

            // Make sure the source cell is R or W (depending on whose turn) and also make sure about the
            // destination cell. It must be blank.
            if (board[sourceRow, sourceColumn] == whoseturn && board[destinationRow, destinationColumn] == 'O')
            {
                // Single step
                // Since we go diagonally, there must be always 1 difference between columns for single step
                if (Math.Abs(sourceColumn - destinationColumn) == 1)
                {
                    // If WHITE moves, since it always goes from top to bottom, destination row always increases (0 -> 7)
                    if (whoseturn == 'W' && (destinationRow - sourceRow) == 1) return true;
                    // If RED moves, since it always goes from bottom to top, destination row always decreases (7 -> 0)
                    if (whoseturn == 'R' && (destinationRow - sourceRow) == -1) return true;
                }
                // If column difference is two, this means there is a jump
                else if (Math.Abs(sourceColumn - destinationColumn) == 2)
                {
                    // If WHITE jumps two steps, make sure row difference is positive 2 
                    // since we move from top to bottom
                    // And make sure the middle cell is Red
                    if (whoseturn == 'W' && (destinationRow - sourceRow) == 2
                        && board[(sourceRow + destinationRow) / 2, (sourceColumn + destinationColumn) / 2] == 'R')
                        return true;

                    // If RED jumps two steps, make sure row difference is negative 2 
                    // since we move from bottom to top
                    // And make sure the middle cell is WHITE
                    if (whoseturn == 'R' && (destinationRow - sourceRow) == -2
                        && board[(sourceRow + destinationRow) / 2, (sourceColumn + destinationColumn) / 2] == 'W')
                        return true;
                }
            }

            return false;
        }

        // Execute the move operation
        private void MoveChecker(int sourceRow, int sourceColumn, int destinationRow, int destinationColumn)
        {
            // By default we will change players at the end unless there is another valid jump
            bool changePlayer = true;

            // Clear source cell, set destination cell
            board[sourceRow, sourceColumn] = 'O';
            board[destinationRow, destinationColumn] = whoseturn;

            // If this is a jump, make sure the remove the checker in the middle cell
            if (Math.Abs(destinationRow - sourceRow) == 2)
            {
                board[(sourceRow + destinationRow) / 2, (sourceColumn + destinationColumn) / 2] = 'O';

                // Let us see if WHITE still has valid jumps 
                if (whoseturn == 'W')
                {
                    if (IsValidMove(destinationRow, destinationColumn, destinationRow + 2, destinationColumn - 2)
                                            || IsValidMove(destinationRow, destinationColumn, destinationRow + 2, destinationColumn + 2))
                    {
                        // If we get here, that means WHITE still has valid jumps 
                        // don't change the player
                        Console.WriteLine("WHITE has valid move(s)...");
                        changePlayer = false;
                    }
                }
                // Let us see if RED still has valid jumps
                else if (whoseturn == 'R')
                {
                    if (IsValidMove(destinationRow, destinationColumn, destinationRow - 2, destinationColumn - 2)
                                           || IsValidMove(destinationRow, destinationColumn, destinationRow - 2, destinationColumn + 2))
                    {
                        // If we get here, that means RED still has valid jumps 
                        // don't change the player
                        Console.WriteLine("RED has valid move(s)...");
                        changePlayer = false;
                    }
                }
            }

            if (changePlayer) whoseturn = whoseturn == 'W' ? 'R' : 'W';
        }

        // Print the board
        private void PrintBoard()
        {
            Console.WriteLine("   0  1  2  3  4  5  6  7 ");

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write(board[i, j] + "  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        // Play the game
        public void PlayCheckersGame()
        {
            PrintBoard();

            #region Tutorials
            Console.WriteLine();
            Console.WriteLine("*****************");
            Console.WriteLine("RULES:");
            Console.WriteLine("YOU SHALL ENTER YOUR SOURCE AND DESTINATION COORDINATES AS TWO DIGITS");
            Console.WriteLine("EXAMPLE: 14");
            Console.WriteLine("INDICES START FROM 0");
            Console.WriteLine("1 -> ROW NUMBER");
            Console.WriteLine("4 -> COLUMN NUMBER");
            Console.WriteLine("*****************");
            Console.WriteLine();
            Console.WriteLine("CHOOSE WISELY... GOOD LUCK...");
            Console.WriteLine();
            #endregion

            // Execute a move and print the board out afterwards until indefinetely.
            while (true)
            {
                GetNextMove();
                PrintBoard();
            }
        }
    }
}
