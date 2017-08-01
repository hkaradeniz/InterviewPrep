using System;
using System.Collections.Generic;

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

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
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
    }
}
