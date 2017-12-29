using System;

namespace InterviewPrep.Amazon
{
    /* Maximum difference between node and its ancestor */
    /* Given a Binary Tree you need to  find maximum value which you  can get by subtracting 
    value of node B from value of node A, where A and B are two nodes of the binary tree and A is an ancestor of B  */
    /* https://www.geeksforgeeks.org/maximum-difference-between-node-and-its-ancestor-in-binary-tree/ */
    /* Test Data: 
            MyTree.MyTree mt = new MyTree.MyTree();

            mt.Insert(500);
            mt.Insert(300);
            mt.Insert(200);
            mt.Insert(400);
            mt.Insert(1000);
            mt.Insert(600);
            Amazon.BSTMaximumDifference bs = new Amazon.BSTMaximumDifference();
            Console.WriteLine(bs.GetMaximumDifference(mt.Root));
     */
    class BSTMaximumDifference
    {
        private int MaxDifference { get; set; }

        public BSTMaximumDifference()
        {
            MaxDifference = int.MinValue;
        }

        public int GetMaximumDifference(MyTree.TreeNode root)
        {
            if (root == null) throw new NullReferenceException();
            CalculateDifferences(root);
            return MaxDifference;
        }

        private void CalculateDifferences(MyTree.TreeNode node)
        {
            if (node == null) return;

            int leftDifference = node.ValueInt - (node.LeftChild == null ? int.MinValue : node.LeftChild.ValueInt);
            int rightDifference = node.ValueInt - (node.RightChild == null ? int.MinValue : node.RightChild.ValueInt);

            MaxDifference = Math.Max(MaxDifference, Math.Max(leftDifference, rightDifference));

            CalculateDifferences(node.LeftChild);
            CalculateDifferences(node.RightChild);
        }
    }
}
