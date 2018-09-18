using System;
using InterviewPrep.MyTree;

namespace InterviewPrep.Amazon
{
    /* Diameter of a Binary Tree */
    /* Given a Binary Tree, find diameter of it.  The diameter of a tree is the number of nodes on the 
     * longest path between two leaves in the tree. */
    /* https://practice.geeksforgeeks.org/problems/diameter-of-binary-tree/1 */
    class BinaryTreeDiameter
    {
        private int diameter;

        public BinaryTreeDiameter()
        {
            diameter = int.MinValue;
        }

        public int GetDiameter(TreeNode root)
        {
            Height(root);

            return diameter;
        }

        private int Height(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = Height(node.LeftChild);
            int rightHeight = Height(node.RightChild);

            diameter = Math.Max(diameter, leftHeight + rightHeight);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
