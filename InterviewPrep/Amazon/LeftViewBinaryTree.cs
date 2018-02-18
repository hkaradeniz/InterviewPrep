using System;

namespace InterviewPrep.Amazon
{
    /* Print Left View of a Binary Tree */
    /* Given a Binary Tree, print left view of it. Left view of a Binary Tree is 
    set of nodes visible when tree is visited from left side. */
    class LeftViewBinaryTree
    {
        int level = -1;

        public void PrintView(MyTree.TreeNode root)
        {
            Print(root, 0);
        }

        private void Print(MyTree.TreeNode node, int currentLevel)
        {
            if (node == null) return;

            if (currentLevel > level)
            {
                level = currentLevel;
                Console.WriteLine(node.ValueInt);
            }

            Print(node.LeftChild, currentLevel + 1);
            Print(node.RightChild, currentLevel + 1);
        }
    }
}
