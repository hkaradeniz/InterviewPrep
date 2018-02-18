using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    /* Breadth-first search in a matrix  */
    /*
    Test:
     Amazon.MatrixBreadthFirstSearch ms = new Amazon.MatrixBreadthFirstSearch();
     int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
     Console.WriteLine(ms.Search(matrix, 7));
    */
    class MatrixBreadthFirstSearch
    {
        public bool Search(int[,] matrix, int number)
        {
            if (matrix == null) return false;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[,] visited = new bool[rows, cols];

            Queue<Index> queue = new Queue<Index>();
            Index index = new Index(0,0);
            queue.Enqueue(index);

            while (queue.Count > 0)
            {
                Index temp = queue.Dequeue();
                
                if (temp.Row < rows && temp.Col < cols && !visited[temp.Row, temp.Col])
                {
                    Console.WriteLine($"Coordinates: { temp.Row }, { temp.Col }");
                    visited[temp.Row, temp.Col] = true;

                    if (matrix[temp.Row, temp.Col] == number)
                        return true;

                    Index newIndex1 = new Index(temp.Row + 1, temp.Col);
                    Index newIndex2 = new Index(temp.Row, temp.Col + 1);
                    queue.Enqueue(newIndex1);
                    queue.Enqueue(newIndex2);
                }
            }

            return false;
        }

        
    }

    class Index
    {
        public Index(int i, int j)
        {
            Row = i;
            Col = j;
        }

        public int Row { get; }
        public int Col { get; }
    }
}
