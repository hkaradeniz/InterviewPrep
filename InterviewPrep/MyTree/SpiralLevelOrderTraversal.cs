using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class SpiralLevelOrderTraversal
    {
        /* Spiral level order traversal of a binary tree */

        /* Test Data:
            MyTree.SpiralLevelOrderTraversal sp = new MyTree.SpiralLevelOrderTraversal();
            MyTree.MyTree mt = new MyTree.MyTree();
            mt.InsertNumber(500);
            mt.InsertNumber(300);
            mt.InsertNumber(700);
            mt.InsertNumber(250);
            mt.InsertNumber(350);
            mt.InsertNumber(650);
            mt.InsertNumber(750);
            mt.InsertNumber(325);
            mt.InsertNumber(375);
            mt.InsertNumber(675);
            sp.PrintSpiralLevelOrder(mt.Root);
                             500
                         /         \   
                       300         700
                     /   \         /  \
                    250  350     650   750
                        /  \           /
                      325  375       675 
         */

        /* Given a binary tree, write a program to print nodes of the tree in a spiral order. */
        /* Time Complexity: O(N) Space Complexity: O(N) */
        public void PrintSpiralLevelOrder(TreeNode root)
        {
            if (root == null)
                return;

            Stack<TreeNode> stackEven = new Stack<TreeNode>();
            stackEven.Push(root);
            PrintSpiralLevelOrder(stackEven, new Stack<TreeNode>());
        }

        private void PrintSpiralLevelOrder(Stack<TreeNode> stackEven, Stack<TreeNode> stackOdd)
        {

            while (stackEven.Count > 0)
            {
                TreeNode temp = stackEven.Pop();
                Console.WriteLine(temp.ValueInt);

                if (temp.LeftChild != null)
                    stackOdd.Push(temp.LeftChild);

                if (temp.RightChild != null)
                    stackOdd.Push(temp.RightChild);
            }

            while (stackOdd.Count > 0)
            {
                TreeNode temp = stackOdd.Pop();
                Console.WriteLine(temp.ValueInt);

                if(temp.RightChild != null)
                    stackEven.Push(temp.RightChild);

                if (temp.LeftChild != null)
                    stackEven.Push(temp.LeftChild);
            }

            if (stackEven.Count > 0)
                PrintSpiralLevelOrder(stackEven, stackOdd);
        }
    }
}
