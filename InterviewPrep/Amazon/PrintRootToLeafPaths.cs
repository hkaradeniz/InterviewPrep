using InterviewPrep.MyTree;
using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    /* Given a binary tree, print all root-to-leaf paths */
    class PrintRootToLeafPaths
    {
        public void Print(TreeNode root)
        {
            Print(root, string.Empty);
        }

        private void Print(TreeNode node, string path)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                Console.WriteLine(path + node.ValueInt);
                return;
            }

            if (node.LeftChild != null)
                Print(node.LeftChild, path + node.ValueInt + " * ");

            if (node.RightChild != null)
                Print(node.RightChild, path + node.ValueInt + " * ");
        }
    }
}
