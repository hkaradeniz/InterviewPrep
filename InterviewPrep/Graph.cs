using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep
{
    class Graph
    {
        // Number of vertices
        private int V;

        // Dictionary for Adjacency List Representation
        Dictionary<int, LinkedList<int>> graph;

        public Graph(int v)
        {
            this.V = v;
            graph = new Dictionary<int, LinkedList<int>>();
        }

        public void AddEdge(int v, int w)
        {
            if (graph.ContainsKey(v))
                graph[v].AddLast(w);
            else
            { graph.Add(v, new LinkedList<int>()); graph[v].AddLast(w); }
        }

        /*
        * Depth First Search
        * Test Data
            Graph g = new Graph(4);
 
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);
 
            Console.WriteLine("Following is Depth First Traversal - starting from vertex 2");
 
            g.DepthFirstSearch(2);   
        */
        public void DepthFirstSearch(int v)
       {
           // Boolean array to mark if the vertex is visited
           bool[] visited = new bool[V];

           // Call the recursive helper function to print DFS traversal
           DepthFirstSearchUtil(v, visited);
       }

        private void DepthFirstSearchUtil(int v, bool[] visited)
        {
           // Mark the node as visited and display it
           visited[v] = true;
           Console.Write($"{v} -");

           // Recur for all the vertices adjacent to this vertex
           foreach (var item in graph)
           {
               int vertex = item.Key;
               LinkedList<int> edges = item.Value;

               foreach (var edge in edges)
               {
                   if (!visited[edge])
                       DepthFirstSearchUtil(edge, visited);
               }
           }
        }

       /*
        * Breadth First Search
        * Test Data
           // Create a graph given in the above diagram 
           Graph g = new Graph(4);

           g.AddEdge(0, 1);
           g.AddEdge(0, 2);
           g.AddEdge(1, 2);
           g.AddEdge(2, 0);
           g.AddEdge(2, 3);
           g.AddEdge(3, 3);

           Console.WriteLine("Following is Breadth First Traversal - starting from vertex 2");

           g.BreadthFirstSearch(2);
        */
        // prints BFS traversal from a given source v
        public void BreadthFirstSearch(int v)
        {
            bool[] visited = new bool[V];

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            visited[v] = true;

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                LinkedList<int> edgeList = graph[vertex];
                Console.Write($"{vertex} - ");

                // Get all adjacent vertices of the dequeued vertex v
                // If an adjacent has not been visited yet, then mark it
                // visited and put it in the queue.
                foreach (var item in edgeList)
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
        }


        /*
         * Topological Sorting
         * Test Data
         // Create a graph given in the above diagram
            Graph g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            Console.WriteLine("Following is a Topological sort of the given graph");
            g.TopologicalSort();
         */
        public void TopologicalSort()
        {
            // To mark visited vertices
            bool[] visited = new bool[V];

            // To store visited nodes
            Stack<int> stack = new Stack<int>();

            int[] vertexList = graph.Keys.ToArray();

            foreach (var vertex in vertexList)
            {
                if (!visited[vertex])
                { TopologicalSortUtil(vertex, visited, stack); }
            }

            while (stack.Count > 0)
            { Console.Write($"{stack.Pop()} - "); }
        }

        // A recursive function used by topologicalSort
        private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {

            // Mark the current node as visited.
            visited[v] = true;
            LinkedList<int> edgesList = new LinkedList<int>();

            if (graph.ContainsKey(v))
                edgesList = graph[v];

            foreach (var edge in edgesList)
            {
                if (!visited[edge])
                    TopologicalSortUtil(edge, visited, stack);
            }

            // Push current vertex to stack
            stack.Push(v);
        }
    }
}
