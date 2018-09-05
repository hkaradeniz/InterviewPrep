using System.Collections.Generic;

namespace InterviewPrep
{
    /*
     Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors
     Since we have to clone the given graph, first thing to remember is each node should be cloned/copied. 
     We cannot assign old references. A simple Breadth First traversal can be performed on the graph to create a clone. 
     DFS can also achieve this goal but we have used BFS here.

     The Time complexity for cloning the graph is O(V+E) and thats because we shall be traversing each vertex 
     of the graph from the Queue and then visiting each edge E at least once.
     */
    class CloneGraph
    {
        // Definition for undirected graph.
        public class UndirectedGraphNode
        {
            public int label;
            public IList<UndirectedGraphNode> neighbors;
            public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
        }

        // Depth First Solution
        public UndirectedGraphNode CloneGraphDFS(UndirectedGraphNode node)
        {
            return CloneDFS(node, new Dictionary<int, UndirectedGraphNode>());
        }

        private UndirectedGraphNode CloneDFS(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> map)
        {
            if (node == null) return null;
            if (map.ContainsKey(node.label)) return map[node.label];

            UndirectedGraphNode cloneNode = new UndirectedGraphNode(node.label);

            map.Add(cloneNode.label, cloneNode);

            foreach (var neighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneDFS(neighbor, map));
            }

            return cloneNode;
        }


        // Breadth First Solution
        public UndirectedGraphNode CloneGraphBFS(UndirectedGraphNode node)
        {
            if (node == null) return null;

            Queue<UndirectedGraphNode> queue = new Queue<UndirectedGraphNode>();
            queue.Enqueue(node);

            Dictionary<int, UndirectedGraphNode> map = new Dictionary<int, UndirectedGraphNode>();
            UndirectedGraphNode nodeToReturn = new UndirectedGraphNode(node.label);
            map.Add(nodeToReturn.label, nodeToReturn);

            while (queue.Count > 0)
            {
                UndirectedGraphNode graphNode = queue.Dequeue();

                foreach (var neighbor in graphNode.neighbors)
                {
                    if (map.ContainsKey(neighbor.label))
                    {
                        UndirectedGraphNode cloneNode = map[graphNode.label];
                        cloneNode.neighbors.Add(map[neighbor.label]);
                    }
                    else
                    {
                        queue.Enqueue(neighbor);
                        UndirectedGraphNode neighborNodeCopy = new UndirectedGraphNode(neighbor.label);
                        map.Add(neighbor.label, neighborNodeCopy);
                        map[graphNode.label].neighbors.Add(neighborNodeCopy);
                    }
                } 
            }

            return nodeToReturn;
        }
    }

}
