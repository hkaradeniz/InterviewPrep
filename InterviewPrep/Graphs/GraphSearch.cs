using System.Collections.Generic;

namespace InterviewPrep.Graphs
{
    class GraphSearch
    {
        private Dictionary<int, Node> nodeLookup;

        public GraphSearch()
        {
            nodeLookup = new Dictionary<int, Node>();
        }

        internal class Node
        {
            public int Id { get; }

            LinkedList<Node> Adjacents; 

            public Node(int id)
            {
                Id = id;
                Adjacents = new LinkedList<Node>();
            }

            public void AddConnection(Node destination)
            {
                Adjacents.AddLast(destination);
            }

            public LinkedList<Node> GetConnections()
            {
                return Adjacents;
            }
        }
        private Node GetNode(int id)
        {
            return nodeLookup[id];
        }

        public void AddVertex(int source, int destination)
        {
            Node s = GetNode(source);
            Node d = GetNode(destination);
            s.AddConnection(d);
        }

        #region Depth First Search (DFS) 
        public bool HasPathDFS(int source, int destination)
        {
            Node s = GetNode(source);
            Node d = GetNode(destination);
            HashSet<int> visited = new HashSet<int>();
            return HasPathDFS(s, d, visited);
        }

        private bool HasPathDFS(Node source, Node destination, HashSet<int> visited)
        {
            if (visited.Contains(source.Id)) return false;

            visited.Add(source.Id);

            if (source.Id == destination.Id) return true;

            foreach (var item in source.GetConnections())
            {
                if (HasPathDFS(item, destination, visited))
                    return true;
            }

            return false;
        }
        #endregion

        #region Breadth First Search (BFS)
        public bool HasPathBFS(int source, int destination)
        {
            
            Node s = GetNode(source);
            Node d = GetNode(destination);
            HashSet<int> visited = new HashSet<int>();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(s);

            while (queue.Count > 0)
            {
                Node temp = queue.Dequeue();

                if (!visited.Contains(temp.Id))
                {
                    if (temp == d)
                        return true;

                    foreach (var item in temp.GetConnections())
                    {
                        queue.Enqueue(item);
                    }

                    visited.Add(temp.Id);
                }
            }

            return false;
        }
        #endregion
     }
}
