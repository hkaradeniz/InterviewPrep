using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class InOrderIterative
    {
        public class TreeNode
        {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public int val { get; set; }
        }

        public void InOrder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (true)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                    Console.WriteLine(root.val);
                    root = root.left;
                }
            }
        }
    }
}
