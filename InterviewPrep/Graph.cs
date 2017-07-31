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

        public void DFS(int v)
        {
            // Boolean array to mark if the vertex is visited
            bool[] visited = new bool[V];

            // Call the recursive helper function to print DFS traversal
            DFSUtil(v, visited);
        }

        private void DFSUtil(int v, bool[] visited)
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
                        DFSUtil(edge, visited);
                }
            }
        }
    }
}
