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
            Print(root, new List<TreeNode>());
        }

        private void Print(TreeNode node, List<TreeNode> list)
        {
            if (node == null) return;

            list.Add(node);

            if (node.LeftChild == null && node.RightChild == null)
                PrintPath(list);
            else
            {
                Print(node.LeftChild, list);
                Print(node.RightChild, list);
            }
        }

        private void PrintPath(List<TreeNode> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($" { list[i].ValueInt } ");
            }

            Console.WriteLine();
        }
    }
}
