using InterviewPrep.MyTree;

namespace InterviewPrep.Amazon
{
    /* Check if a binary tree is subtree of another binary tree */
    /* Complexity: O(ms) */
    class BinaryTreeSubtreeOfAnotherBinaryTree
    {
        public bool IsSubtree(TreeNode mainTreeRoot, TreeNode subTreeRoot)
        {
            return IsSubtreeHelper(mainTreeRoot, subTreeRoot);
        }

        private bool AreIdentical(TreeNode mainTreeRoot, TreeNode subTreeRoot)
        {
            if (mainTreeRoot == null && subTreeRoot == null) return true;
            if (mainTreeRoot == null || subTreeRoot == null) return false;

            return ((mainTreeRoot.ValueInt == subTreeRoot.ValueInt)
                && AreIdentical(mainTreeRoot.LeftChild, subTreeRoot.LeftChild)
                && AreIdentical(mainTreeRoot.RightChild, subTreeRoot.RightChild));
        }

        private bool IsSubtreeHelper(TreeNode mainTreeRoot, TreeNode subTreeRoot)
        {
            if (subTreeRoot == null) return true;
            if (mainTreeRoot == null) return false;

            if (AreIdentical(mainTreeRoot, subTreeRoot))
                return true;

            return IsSubtreeHelper(mainTreeRoot.LeftChild, subTreeRoot)
                || IsSubtreeHelper(mainTreeRoot.RightChild, subTreeRoot);
        }
    }
}
