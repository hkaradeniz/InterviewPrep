using System.Collections.Generic;

namespace InterviewPrep
{
    // Binary Tree Preorder Traversal Iterative
    public class PreOrderIterative
    {
        public class TreeNode
        {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            //List<int> list = new List<int>();
            //PreOrder(root, list);
            //return list;

            return Preorder(root);
        }

        private void PreOrder(TreeNode root, List<int> list)
        {
            if (root == null) return;

            list.Add(root.val);
            PreOrder(root.left, list);
            PreOrder(root.right, list);
        }

        private List<int> Preorder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            List<int> list = new List<int>();

            if (root != null)
            {
                TreeNode current = root;
                stack.Push(root);

                while (stack.Count > 0)
                {
                    current = stack.Pop();

                    if (current != null) list.Add(current.val);

                    if (current.right != null) stack.Push(current.right);
                    if (current.left != null) stack.Push(current.left);
                }
            }

            return list;
        }
    }
}
