using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class MyTree
    {
        public TreeNode Root;
        int numberOfVisitedNodes = 0;

        public MyTree()
        {
            Root = null;
        }

        public TreeNode First
        {
            get { return Root; }
        }

        public void InsertNumber(int value)
        {
            TreeNode newNode = new TreeNode(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                TreeNode pointer = Root;

                while (true)
                {
                    if (newNode.ValueInt > pointer.ValueInt)
                    {
                        if (pointer.RightChild == null)
                        {
                            pointer.RightChild = newNode;
                            return;
                        }

                        pointer = pointer.RightChild;
                    }
                    else if (newNode.ValueInt < pointer.ValueInt)
                    {
                        if (pointer.LeftChild == null)
                        {
                            pointer.LeftChild = newNode;
                            return;
                        }

                        pointer = pointer.LeftChild;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void InsertString(string str)
        {
            TreeNode newNode = new TreeNode(str);

            if (Root == null)
                Root = newNode;
            else
            {
                TreeNode pointer = Root;

                while (true)
                {
                    if (pointer.ValueStr.CompareTo(newNode.ValueStr) < 0)
                    {
                        if (pointer.RightChild == null)
                        {
                            pointer.RightChild = newNode;
                            return;
                        }
                        else
                        {
                            pointer = pointer.RightChild;
                        }
                    }
                    else if (pointer.ValueStr.CompareTo(newNode.ValueStr) > 0)
                    {
                        if (pointer.LeftChild == null)
                        {
                            pointer.LeftChild = newNode;
                            return;
                        }
                        else
                        {
                            pointer = pointer.LeftChild;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        public void FindKthLargestElement(int k)
        {
            numberOfVisitedNodes = 0;
            FindKthLargestElement(Root, k);
        }

        public void FindKthLargestElement(TreeNode node, int k)
        {
            if (node == null || numberOfVisitedNodes >= k)
                return;

            FindKthLargestElement(node.RightChild, k);

            numberOfVisitedNodes++;

            if (numberOfVisitedNodes == k)
            {
                Console.Write(node.ValueInt);
                return;
            }

            FindKthLargestElement(node.LeftChild, k);
        }

        #region Traveling
        /* 
         * Preorder traversal sequence: F, B, A, D, C, E, G, I, H (root, left, right)
         * Inorder traversal sequence: A, B, C, D, E, F, G, H, I (left, root, right)
         * Postorder traversal sequence: A, C, E, D, B, H, I, G, F (left, right, root)
         */

        // Travel preOrder
        public void PreOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.DisplayStr();
                PreOrder(localRoot.LeftChild);
                PreOrder(localRoot.RightChild);
            }
        }

        // Travel InOrder
        public void InOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                InOrder(localRoot.LeftChild);
                localRoot.DisplayStr();
                InOrder(localRoot.RightChild);
            }
        }

        // Travel PostOrder
        public void PostOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                PostOrder(localRoot.LeftChild);
                PostOrder(localRoot.RightChild);
                localRoot.DisplayStr();
            }
        }

        // Travel LevelOrder
        public void LevelOrder(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root != null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                Console.WriteLine(node.ValueInt);
                Console.WriteLine(node.ValueStr);

                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }
            }
        }
        #endregion

        // Breadth First Search
        public void BFS()
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                Console.WriteLine(node.ValueInt);
                Console.WriteLine(node.ValueStr);

                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }
            }
        }

        // Depth First Search
        public void DFS()
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (Root != null)
            {
                stack.Push(Root);
            }

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                Console.WriteLine(node.ValueInt);
                Console.WriteLine(node.ValueStr);

                if (node.LeftChild != null)
                {
                    stack.Push(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    stack.Push(node.RightChild);
                }
            }
        }
    }
}
