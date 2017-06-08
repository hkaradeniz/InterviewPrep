using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class MyTree
    {
        /* Create BST
          MyTree mt = new MyTree();
            mt.Add(400);
            mt.Add(200);
            mt.Add(100);
            mt.Add(120);
            mt.Add(160);
            mt.Add(220);
            mt.Add(300);
            mt.Add(500);
            mt.Add(450);
         */

        public TreeNode Root;
        int numberOfVisitedNodes = 0;
        int maxLevel = -1;
        int maxLevelResult = -1;

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

        /*  k-th largest element of the BST
         *  
         * http://blog.gainlo.co/index.php/2016/06/03/second-largest-element-of-a-binary-search-tree/
           * You don’t need to store all the visited elements into an array and find the k-th element. Instead, use a global variable i to record the index of visited elements. Inside the traversal function, every time when you visit an element, just increment i by one and when i == k, output the current element.
           * Be careful about cases where there are less than k elements in the BST.
           * You should handle empty tree as well.
           * Don’t forget to check if left and right are null when traversing the tree.
         */

        // Second Largest Element of a Binary Search Tree
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

        // Deepest Node In a Tree
        // Find the height of a tree. This can also be solved both recursively or non-recursively.
        // Find the longest path from the root to leaf in a tree.
        // Find the deepest left leaf of a tree.
        // http://blog.gainlo.co/index.php/2016/04/26/deepest-node-in-a-tree/

        public int FindDeepestNode()
        {
            maxLevel = -1;
            maxLevelResult = -1;

            DeepestNode(Root, 0);
            return maxLevelResult;
        }

        private void DeepestNode(TreeNode node, int currentLevel)
        {
            if (node != null)
            {
                DeepestNode(node.LeftChild, ++currentLevel);

                if (currentLevel > maxLevel)
                {
                    maxLevel = currentLevel;
                    maxLevelResult = node.ValueInt;
                }

                DeepestNode(node.RightChild, currentLevel);
            }
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
