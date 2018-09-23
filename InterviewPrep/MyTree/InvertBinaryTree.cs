using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    // Invert a binary tree.

    //      4
    //    /   \
    //   2     7
    //  / \   / \
    // 1   3 6   9

    // to

    //      4
    //    /   \
    //   7     2
    //  / \   / \
    // 9   6 3   1

    class InvertBinaryTree
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public TreeNode(int x) { val = x; }
        }

        public void Invert()
        {
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(9);
            PrintTree(root);
            Console.WriteLine("***********");
            Invert(root.left, root.right);
            PrintTree(root);
        }

        private TreeNode Invert(TreeNode root)
        {
            if (root == null) return null;

            TreeNode temp = Invert(root.left);
            root.left = Invert(root.right);
            root.right = temp;

            return root;
        }

        private void Invert(TreeNode left, TreeNode right)
        {
            if (left == null || right == null) return;

            int temp = left.val;
            left.val = right.val;
            right.val = temp;

            Invert(left.left, right.right);
            Invert(left.right, right.left);
        }

        private void PrintTree(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;

                while (size > 0)
                {
                    TreeNode node = queue.Dequeue();

                    Console.Write(node.val + " ");

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    size--;
                }

                Console.WriteLine();
            }
        }
    }
}
