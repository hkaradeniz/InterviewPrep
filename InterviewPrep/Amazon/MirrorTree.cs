using InterviewPrep.MyTree;

namespace InterviewPrep.Amazon
{
    /* Convert a Binary Tree into its Mirror Tree */
    class MirrorTree
    {
        public TreeNode Mirror(TreeNode root)
        {
           root = MirrorBinaryTree(root);

           return root;
        }

        private TreeNode MirrorBinaryTree(TreeNode node)
        {
            if (node == null) return null;

            TreeNode left = MirrorBinaryTree(node.LeftChild);
            TreeNode right = MirrorBinaryTree(node.RightChild);

            // Swap Nodes:
            node.LeftChild = right;
            node.RightChild = left;

            return node;
        }
    }
}
