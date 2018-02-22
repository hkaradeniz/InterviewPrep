using System;

namespace InterviewPrep.Amazon
{
    /*
     Complete the function nextMove which takes in 4 parameters - an integer N, integers r and c 
     indicating the row & column position of the bot and the character array grid - and outputs 
     the next move the bot makes to rescue the princess.
     */
    class BotSavesPrincess
    {
        public void Save(char[,] grid, int n, int row, int col)
        {
            Coordinates princes = Find(grid, n, row, col, 'p');
            Coordinates bot = Find(grid, n, row, col, 'q');

            if (princes == null || bot == null) return;

            double left = CalculateDistance(princes, new Coordinates(bot.Row, bot.Column - 1), row, col);
            double right = CalculateDistance(princes, new Coordinates(bot.Row, bot.Column + 1), row, col);
            double up = CalculateDistance(princes, new Coordinates(bot.Row - 1, bot.Column), row, col);
            double down = CalculateDistance(princes, new Coordinates(bot.Row + 1, bot.Column), row, col);

            double min = int.MaxValue;

            min = Math.Min(Math.Min(left, right), Math.Min(up, down));

            if (left == min) Console.WriteLine("LEFT");
            if (right == min) Console.WriteLine("RIGHT");
            if (up == min) Console.WriteLine("UP");
            if (down == min) Console.WriteLine("DOWN");
        }

        /*
         The distance formula is derived from the Pythagorean theorem. To find the distance between two points (x1,y1) and (x2,y2), all that you need to do is use the coordinates of these ordered pairs and apply the formula pictured below.

         The distance formula is 
         Distance = sqrt( (x2−x1)^2+(y2−y1)^2 )
         */
        private double CalculateDistance(Coordinates princes, Coordinates bot, int row, int col)
        {
            // Out of Map
            if (row <= bot.Row || bot.Row < 0) return int.MaxValue;
            if (col <= bot.Column || bot.Column < 0) return int.MaxValue;

            // Calculate distance
            return Math.Sqrt(((bot.Row - princes.Row) * (bot.Row - princes.Row))
                + ((bot.Column - princes.Column) * (bot.Column - princes.Column)));
        }

        private Coordinates Find(char[,] grid, int n, int row, int col, char c)
        {
            Coordinates cordinates = null;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i, j] == c)
                    {
                        cordinates = new Coordinates(i, j);
                        break;
                    }
                }
            }

            return cordinates;
        }

        internal class Coordinates
        {
            public int Row { get; }
            public int Column { get; }

            public Coordinates(int row, int col)
            {
                Row = row;
                Column = col;
            }
        }
    }
}
