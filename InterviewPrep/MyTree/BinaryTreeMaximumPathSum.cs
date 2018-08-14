using System;

namespace InterviewPrep.MyTree
{
    //  Kevin Naughton Jr

    // Given a binary tree, find the maximum path sum.

    // For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The path must contain at least one node and does not need to go through the root.

    // For example:
    // Given the below binary tree,

    //        1
    //       / \
    //      2   3
    // Return 6.

    /**
     * Definition for a binary tree node.
     */


    class BinaryTreeMaximumPathSum
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            TreeNode(int x) { val = x; }
        }

        int max = int.MinValue;

        public int maxPathSum(TreeNode root)
        {
            maxPathSumRecursive(root);
            return max;
        }

        private int maxPathSumRecursive(TreeNode root)
        {
            if (root == null) return 0;

            int left = Math.Max(maxPathSumRecursive(root.left), 0);
            int right = Math.Max(maxPathSumRecursive(root.right), 0);

            max = Math.Max(max, root.val + left + right);

            return root.val + Math.Max(left, right);
        }
    }
}
