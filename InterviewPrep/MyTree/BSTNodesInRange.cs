namespace InterviewPrep.MyTree
{
    class BSTNodesInRange
    {
        /* Count BST nodes that lie in a given range  */
        /* Given a Binary Search Tree (BST) and a range, count the number of nodes in the BST that lie in the given range. */
        private int numberOfNodes = 0;

        public int GetCountOfNode(TreeNode root, int min, int max)
        {
            if (root != null)
            {
                GetCountOfNodeRecursive(root, min, max);
                return numberOfNodes;
            }

            return 0;
        }

        private void GetCountOfNodeRecursive(TreeNode node, int min, int max)
        {
            if (node == null) return;

            if (node.ValueInt < min) GetCountOfNodeRecursive(node.RightChild, min, max);
            else if (node.ValueInt > max) GetCountOfNodeRecursive(node.LeftChild, min, max);
            else
            {
                numberOfNodes++;
                GetCountOfNodeRecursive(node.LeftChild, min, max);
                GetCountOfNodeRecursive(node.RightChild, min, max);
            }
        }

    }
}
