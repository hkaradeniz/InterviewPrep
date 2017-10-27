using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class MaximumWidth
    {
        /* Given a binary tree, how can you find the maximum width */
        /* The width is on the same level, the distance between the leftmost node and rightmost node */
        /* Solution: Perform level order traversal along with a queue to find the max width */
        /* Count the node in the queue and find the max nodes in the queue during the iteration */

        /*
        Test Data:
        MyTree.MyTree tree = new MyTree.MyTree();
            MyTree.TreeNode n1 = new MyTree.TreeNode(1);
            MyTree.TreeNode n2 = new MyTree.TreeNode(2);
            MyTree.TreeNode n3 = new MyTree.TreeNode(3);
            MyTree.TreeNode n4 = new MyTree.TreeNode(4);
            MyTree.TreeNode n5 = new MyTree.TreeNode(5);
            MyTree.TreeNode n6 = new MyTree.TreeNode(6);
            MyTree.TreeNode n7 = new MyTree.TreeNode(7);

            tree.Root = n1;
            tree.Root.LeftChild = n2;
            tree.Root.LeftChild.LeftChild = n4;
            tree.Root.LeftChild.RightChild = n5;
            tree.Root.RightChild = n3;
            tree.Root.RightChild.LeftChild = n7;
            tree.Root.RightChild.RightChild = n6;
            MyTree.MaximumWidth mx = new MyTree.MaximumWidth();
            Console.WriteLine(mx.ComputeMaximumWidth(tree.Root));
         */
        public int ComputeMaximumWidth(TreeNode root)
        {
            if (root == null) return -1;

            int maxWidth = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                if (queue.Count > maxWidth)
                    maxWidth = queue.Count;

                TreeNode temp = queue.Dequeue();

                if (temp.LeftChild != null)
                    queue.Enqueue(temp.LeftChild);

                if (temp.RightChild != null)
                    queue.Enqueue(temp.RightChild);
            }

            return maxWidth;
        }
    }
}
