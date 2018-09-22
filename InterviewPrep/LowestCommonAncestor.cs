using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class LowestCommonAncestor
    {
        public class TreeNode
        {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
        }

        public TreeNode GetLowestCommonAncestor(TreeNode root, TreeNode q, TreeNode p)
        {
            if (root == null || p == null || q == null) return null;

            return LCA(root, q, p); 
        }

        private TreeNode LCA(TreeNode root, TreeNode q, TreeNode p)
        {
            if (root == null) return null;
            if (root == p || root == q) return root;

            TreeNode left = LCA(root.left, q, p);
            if (root != null && left != q && left != p) return left;

            TreeNode right = LCA(root.right, q, p);
            if (root != null && right != q && right != p) return right;

            if (left != null && right != null) return root;
            else if (root == p || root == q) return root;
            else return left == null ? right : left;
        } 
    }
}
