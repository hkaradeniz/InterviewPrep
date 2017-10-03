using System.Collections.Generic;

namespace InterviewPrep.TreesAndGraphs
{
    /*?
     * Cracking the Coding Interview, 6th Edition
     * Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a
       route between two nodes.
     */
    class GraphNode
    {
        public int Value { get; }

        public GraphNode(int value)
        {
            Value = value;
        }
    }

    class QuickGraph
    {
        public Dictionary<GraphNode, HashSet<GraphNode>> Graph;

        public QuickGraph()
        {
            Graph = new Dictionary<GraphNode, HashSet<GraphNode>>();
        }

        public void AddVertex(GraphNode start, GraphNode end)
        {
            /* Undirected Graph*/
            // Test Data
            /*
            TreesAndGraphs.GraphNode g1 = new TreesAndGraphs.GraphNode(5);
            TreesAndGraphs.GraphNode g2 = new TreesAndGraphs.GraphNode(10);
            TreesAndGraphs.GraphNode g3 = new TreesAndGraphs.GraphNode(15);
            TreesAndGraphs.GraphNode g4 = new TreesAndGraphs.GraphNode(20);
            TreesAndGraphs.GraphNode g5 = new TreesAndGraphs.GraphNode(25);
            TreesAndGraphs.QuickGraph graph = new TreesAndGraphs.QuickGraph();
            graph.AddVertex(g1, g2);
            graph.AddVertex(g2, g4);
            graph.AddVertex(g2, g3);
            graph.AddVertex(g4, g3);
            graph.AddVertex(g3, g5);

            TreesAndGraphs.RouteBetweenNodes rn = new TreesAndGraphs.RouteBetweenNodes();

            Console.WriteLine(rn.IsConnected(graph,g1,g5)); 
             */
            /*
            if (Graph.ContainsKey(start))
            {
                Graph[start].Add(end);
            }
            else
            {
                Graph.Add(start, new HashSet<GraphNode>() { end });
            }

            if (Graph.ContainsKey(end))
            {
                Graph[end].Add(start);
            }
            else
            {
                Graph.Add(end, new HashSet<GraphNode>() { start });
            }
            */
            /* Directed Graph*/
            // Test Data
            /*
            TreesAndGraphs.GraphNode g1 = new TreesAndGraphs.GraphNode(5);
            TreesAndGraphs.GraphNode g2 = new TreesAndGraphs.GraphNode(10);
            TreesAndGraphs.GraphNode g3 = new TreesAndGraphs.GraphNode(15);
            TreesAndGraphs.GraphNode g4 = new TreesAndGraphs.GraphNode(20);
            TreesAndGraphs.GraphNode g5 = new TreesAndGraphs.GraphNode(25);
            TreesAndGraphs.QuickGraph graph = new TreesAndGraphs.QuickGraph();
            graph.AddVertex(g1, g2);
            graph.AddVertex(g4, g2);
            graph.AddVertex(g2, g3);
            graph.AddVertex(g4, g3);
            graph.AddVertex(g3, g5);
            graph.AddVertex(g5, null);

            TreesAndGraphs.RouteBetweenNodes rn = new TreesAndGraphs.RouteBetweenNodes();

            Console.WriteLine(rn.IsConnected(graph,g1,g4)); 
             */
            if (Graph.ContainsKey(start))
            {
                Graph[start].Add(end);
            }
            else
            {
                Graph.Add(start, new HashSet<GraphNode>() { end });
            }
        }
    }
    class RouteBetweenNodes
    {
        public bool IsConnected(QuickGraph graph, GraphNode start, GraphNode end)
        {
            if (start == end)
                return true;

            if (start == null || end == null)
                return false;

            Queue<GraphNode> queue = new Queue<GraphNode>();
            HashSet<GraphNode> visited = new HashSet<GraphNode>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                GraphNode current = queue.Dequeue();
                if (current != null)
                {
                    HashSet<GraphNode> vertices = graph.Graph[current];

                    foreach (var item in vertices)
                    {
                        if (!visited.Contains(item))
                        {
                            if (item == end)
                                return true;

                            visited.Add(item);
                            queue.Enqueue(item);
                        }
                    }
                } 
            }

            return false;
        }
    }
}
