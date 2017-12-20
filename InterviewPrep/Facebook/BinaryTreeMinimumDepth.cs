using System;

namespace InterviewPrep.Facebook
{
    class BinaryTreeMinimumDepth
    {
        public int GetMinimumHeight(MyTree.TreeNode root)
        {
            return GetMinimumHeightHelper(root);
        }

        private int GetMinimumHeightHelper(MyTree.TreeNode node)
        {
            if (node == null)
                return 0;

            int left = GetMinimumHeightHelper(node.LeftChild);
            int right = GetMinimumHeightHelper(node.RightChild);

            return 1 + Math.Min(left, right);
        }
    }
}
