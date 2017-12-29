namespace InterviewPrep.Amazon
{
    /* Check if Binary Tree is a Binary Search Tree */
    /* Given a binary tree, return true if it is BST, else false */
    /* https://practice.geeksforgeeks.org/problems/check-for-bst/1 */
    class CheckForBST
    {
        public bool IsBST(MyTree.TreeNode root)
        {
            if (root == null) return false;
            return IsValidBST(root, int.MinValue, int.MaxValue);
        }

        private bool IsValidBST(MyTree.TreeNode node, int min, int max)
        {
            if (node == null) return true;

            if (node.ValueInt > min && node.ValueInt < max
                && IsValidBST(node.LeftChild, min, node.ValueInt)
                && IsValidBST(node.RightChild, node.ValueInt, max))
                return true;
            else
                return false;
        }
    }
}
