using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    /*
      Given a n-ary tree, find its maximum depth.

      The maximum depth is the number of nodes along the longest path 
      from the root node down to the farthest leaf node.
     */
    class MaximumDepthNaryTree
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public int MaxDepth(Node root)
        {
            return MaxDepthHelper(root);
        }

        private int MaxDepthHelper(Node root)
        {
            if (root == null) return 0;

            int max = 1;
            foreach (var child in root.children)
            {
                max = Math.Max(max, MaxDepthHelper(child) + 1);
            }

            return max;
        }
    }
}
