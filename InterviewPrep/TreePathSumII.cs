using System.Collections.Generic;

namespace InterviewPrep
{
    /*
        Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

        Note: A leaf is a node with no children.

        Example:

        Given the below binary tree and sum = 22,

              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1
        Return:

        [
           [5,4,11,2],
           [5,8,4,5]
        ]
     */
    class TreePathSumII
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public TreeNode(int x) { val = x; }
        }

        public IList<IList<int>> GetPaths(TreeNode root, int sum)
        {
            var results = new List<IList<int>>();
            GetPaths(root, sum, results, new List<int>());
            return results;
        }

        private void GetPaths(TreeNode root, int sum, IList<IList<int>> results, List<int> list)
        {
            if (root == null) return;

            list.Add(root.val);
            if (root.left == null && root.right == null && sum == root.val)
            {
                results.Add(new List<int>(list));
            }
            else
            {
                GetPaths(root.left, sum - root.val, results, list);
                GetPaths(root.right, sum - root.val, results, list);
            }

            list.RemoveAt(list.Count - 1);
        }

        public void TestPaths(int sum)
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(11);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.right.right.right = new TreeNode(1);
            root.right.right.left = new TreeNode(5);

            GetPaths(root, sum);
        }
    }
}
