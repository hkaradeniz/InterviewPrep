using InterviewPrep.MyTree;

namespace InterviewPrep.ArraysStrings
{
    class SymmetricBinaryTree
    {
        /* Check if Binary Tree is Symmetric or Not */
        /* Write a program to check if the given binary tree is symmetric tree or not.
        A symmetric tree is defined as a tree which is mirror image of itself about the root node. */
        /*
                                     3
                                /        \           
                               1          1
                             /  \       /  \   
                            0   2      2    0
            
          */

        public bool IsBinaryTreeSymmetric(TreeNode node1, TreeNode node2)
        {
            /* Both node1 and node2 hit null. They arrived the end */
            if (node1 == null && node2 == null)
                return true;

            /* This means, one of the branches is null. It cannot be a symmetric tree */
            if (node1 == null || node2 == null)
                return false;

            if (node1.ValueInt == node2.ValueInt
                && IsBinaryTreeSymmetric(node1.LeftChild, node2.RightChild)
                && IsBinaryTreeSymmetric(node1.RightChild, node2.LeftChild))
                return true;

            return false;
        }
    }
}
