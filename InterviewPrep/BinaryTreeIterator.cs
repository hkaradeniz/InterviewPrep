using System.Collections.Generic;

namespace InterviewPrep
{
    class BinaryTreeNode
    {
        public int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;

        public BinaryTreeNode(int v)
        {
            val = v;
        }
    }
    class BinaryTreeIterator
    {
        Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
        BinaryTreeNode current;

        public BinaryTreeIterator(BinaryTreeNode root)
        {
            current = root;
        }

        public bool hasNext()
        {
            if (current != null || stack.Count > 0)
                return true;

            return false;
        }

        public int next()
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            BinaryTreeNode next = stack.Pop();
            current = next.right;
            return next.val;
        }
    }
}
