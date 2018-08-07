using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class BinaryTreePaths
    {
        /* Binary Tree Paths */
        /* Given a binary tree, return all root-to-leaf paths. */

        public class TreeNode
        {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
        }

        public IList<string> GetBinaryTreePaths(TreeNode root)
        {
            List<string> list = new List<string>();

            if (root != null)
                GetPaths(root, "", list);

            return list;
        }

        private void GetPaths(TreeNode root, string s, List<string> list)
        {
            if (root.left == null && root.right == null)
            {
                s = s + root.val;
                list.Add(s);
            }

            if (root.left != null)
                GetPaths(root.left, s + root.val + "->", list);

            if (root.right != null)
                GetPaths(root.right, s + root.val + "->", list);
        }
    }
}
