using InterviewPrep.MyTree;
using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    /* Given a binary tree, print all root-to-leaf paths */
    class PrintRootToLeafPaths
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public TreeNode(int x) { val = x; }
        }


        //Get all distinct Paths
        public IList<IList<int>> GetAllPaths(TreeNode root)
        {
            var results = new List<IList<int>>();
            GetAllPaths(root, results, new List<int>());
            return results;
        }

        private void GetAllPaths(TreeNode root, IList<IList<int>> results, List<int> list)
        {
            if (root == null) return;

            list.Add(root.val);

            if (root.left == null && root.right == null)
            {
                results.Add(new List<int>(list));
            }
            else
            {
                GetAllPaths(root.left, results, list);
                GetAllPaths(root.right, results, list);
            }

            list.RemoveAt(list.Count - 1);
        }

        public TreeNode GetRoot()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(11);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.right.right.right = new TreeNode(1);
            root.right.right.left = new TreeNode(5);

            return root;
        }


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
