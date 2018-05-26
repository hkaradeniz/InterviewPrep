using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class PostOrderIterative
    {
        public class TreeNode
        {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public int val { get; set; }
        }

        public void PostOrder(TreeNode root)
        {
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            stack1.Push(root);

            while (stack1.Count > 0)
            {
                TreeNode current = stack1.Pop();

                stack2.Push(current);

                if (current.left != null)
                    stack1.Push(current.left);
                if (current.right != null)
                    stack1.Push(current.right);
            }

            while (stack2.Count > 0)
                Console.WriteLine(stack2.Pop());
        }
    }
}
