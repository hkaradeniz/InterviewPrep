namespace InterviewPrep.MyTree
{
    /* Cracking the Coding Interview, 6th Edition
     Successor: Write an algorithm to find the "next" node (i.e., in-order successor) of a given node in a
     binary search tree. You may assume that each node has a link to its parent. 
    */
    class InorderSuccessor
    {
        // When we do inorder traversal in a binary search tree
        // all elements will be sorted. So, if we need the inorder successor of
        // the 5th element, we basically return the 6th element.
        // One way to solve this, traverse the whole tree inorder and 
        // return the successor of the given element
        // However, this is costly. We basically search the whole tree just because to find
        // one element

        // Better solution
        // On a given node, the inorder successor
        // if right tree exist, return the left most element
        // if no right tree, then the last left turn you take is the successor
        // For this, start from the root, and keep track of left turns

        public int GetInorderSuccessor(TreeNode root, TreeNode node)
        {
            if (node == null) return -1;

            TreeNode current = node;

            // Right tree exist...
            if (node.RightChild != null)
            {
                current = node.RightChild;
                while (current.LeftChild != null)
                {
                    current = current.LeftChild;
                }

                return current.ValueInt;
            }

            // If we get there, that means there is no right tree
            // Start from the root and keep track of left turns, return the very last left turn
            current = root;
            TreeNode lastLeft = null;

            while (current != node)
            {
                if (current.ValueInt > node.ValueInt)
                {
                    current = current.LeftChild;
                    lastLeft = current;
                }
                else
                {
                    current = current.RightChild;
                }
            }

            return lastLeft.ValueInt;

        }
    }
}
