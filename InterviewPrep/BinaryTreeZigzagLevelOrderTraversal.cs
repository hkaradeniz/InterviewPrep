using System.Collections.Generic;

namespace InterviewPrep
{
    class BinaryTreeZigzagLevelOrderTraversal
    {
        /*
            Given a binary tree, return the zigzag level order traversal of its nodes' values. 
            (ie, from left to right, then right to left for the next level and alternate between).
         */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {

            if (root == null) return new List<IList<int>>();

            return ZigZag(root);
        }

        private IList<IList<int>> ZigZag(TreeNode root)
        {
            var results = new List<IList<int>>();

            Stack<TreeNode> even = new Stack<TreeNode>();
            Stack<TreeNode> odd = new Stack<TreeNode>();

            even.Push(root);

            while (even.Count > 0)
            {
                List<int> evenList = new List<int>();

                while (even.Count > 0)
                {
                    TreeNode node = even.Pop();

                    evenList.Add(node.val);

                    if (node.left != null) odd.Push(node.left);
                    if (node.right != null) odd.Push(node.right);
                }

                results.Add(evenList);

                if (odd.Count > 0)
                {
                    List<int> oddList = new List<int>();

                    while (odd.Count > 0)
                    {
                        TreeNode node = odd.Pop();

                        oddList.Add(node.val);

                        if (node.right != null) even.Push(node.right);
                        if (node.left != null) even.Push(node.left);
                    }

                    results.Add(oddList);
                }
            }

            return results;
        }
    }
}
