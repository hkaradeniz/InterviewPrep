using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class VerticalSum
    {
        /* Given a binary tree, how you find the vertical sum of Binary tree */
        /*
                   1    2    3  4   5 
                             1
                          /    \
                        2       3
                      /  \     / \
                    4     5  /    6
                            /
                           7
        
        There will be total 5 vertical sums. For Line 3: 1+5+7=13
        
        Solution: We need to check the horizontal distances from Root to all nodes
        Horizontal Distance for the Root is 0
        For right child, we add 1 to HD
        For left child, we substract 1 from HD
        
        */
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
            MyTree.VerticalSum vs = new MyTree.VerticalSum();
            vs.ComputeVerticalSum(tree);
            */
        public Dictionary<int, int> ComputeVerticalSum(MyTree tree)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            HorizontalDistance(tree.Root, dict, 0);
            return dict;
        }

        private void HorizontalDistance(TreeNode node, Dictionary<int, int> dict, int HDValue)
        {
            if (node == null)
                return;

            if (!dict.ContainsKey(HDValue))
                dict.Add(HDValue, 0);

            dict[HDValue] += node.ValueInt;

            HorizontalDistance(node.LeftChild, dict, HDValue - 1);
            HorizontalDistance(node.RightChild, dict, HDValue + 1);
        }
    }
}
