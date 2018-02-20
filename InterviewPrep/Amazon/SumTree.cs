using InterviewPrep.MyTree;

namespace InterviewPrep.Amazon
{
    /* Check if a given Binary Tree is SumTree */
    /*
           26
         /    \
        10      3
      /    \      \
     4      6      3
     */
    class SumTree
    {
        // Worst Case complexity: O(N^2)
        public bool IsSumTree(TreeNode root)
        {
            // If root is null, or root is a leaf node -> return true;
            if (root == null || (root.LeftChild == null && root.RightChild == null))
                return true;

            int leftSum = Sum(root.LeftChild);
            int rightSum = Sum(root.RightChild);

            if (root.ValueInt == leftSum + rightSum
                && (IsSumTree(root.LeftChild)
                && (IsSumTree(root.RightChild))))
                return true;

            return false;
        }

        private int Sum(TreeNode node)
        {
            if (node == null)
                return 0;

            return Sum(node.LeftChild) + Sum(node.RightChild) + node.ValueInt; 
        }
    }
}
